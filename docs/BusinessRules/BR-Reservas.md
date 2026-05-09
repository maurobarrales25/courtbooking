# Reglas de Negocio — Módulo de Reservas

**Proyecto:** CanchasYa!
**Módulo:** Reservas
**Versión:** 1.0
**Estado:** Borrador

---

## Índice

1. [Validaciones de tiempo](#1-validaciones-de-tiempo)
2. [Slots y disponibilidad](#2-slots-y-disponibilidad)
3. [Multitenancy — aislamiento por complejo](#3-multitenancy--aislamiento-por-complejo)
4. [Estados de la reserva](#4-estados-de-la-reserva)
5. [Políticas de cancelación](#5-políticas-de-cancelación)
6. [Integridad y trazabilidad](#6-integridad-y-trazabilidad)

---

## 1. Validaciones de tiempo

### BR-01 — Anticipación máxima
Un usuario no podrá realizar una reserva con más de **30 días** de anticipación respecto a la fecha de inicio.

> **Justificación:** Evita el bloqueo especulativo de canchas que perjudica la disponibilidad para otros usuarios.
>
> **Criterio de verificación:** El sistema rechaza toda solicitud cuya fecha de inicio supere `hoy + 30 días`.

---

### BR-02 — Duración mínima
Toda reserva deberá tener una duración mínima de **1 hora** (60 minutos).

> **Justificación:** El modelo de negocio de los complejos opera por horas; fracciones menores no son rentables ni operativamente viables.
>
> **Criterio de verificación:** El sistema rechaza reservas cuya duración sea menor a 60 minutos.

---

### BR-03 — Incrementos de duración
La duración de una reserva deberá expresarse en **múltiplos de 1 hora** (1 h, 2 h, 3 h, 4 h). No se permiten fracciones intermedias (ej. 1 h 30 min).

> **Justificación:** Los complejos gestionan la disponibilidad por slots horarios completos.
>
> **Criterio de verificación:** El sistema rechaza duraciones que no sean múltiplos exactos de 60 minutos.

---

### BR-04 — Integridad temporal
La fecha y hora de finalización de una reserva deberá ser estrictamente posterior a su fecha y hora de inicio.

> **Criterio de verificación:** `horaFin > horaInicio` es validado antes de persistir cualquier reserva.

---

## 2. Slots y disponibilidad

### BR-05 — Ausencia de superposición
Una cancha no podrá tener dos reservas en estado **Confirmada** o **Pendiente** que compartan algún intervalo de tiempo.

> **Criterio de verificación:** Antes de confirmar una reserva, el sistema verifica que no exista otra reserva activa para la misma cancha cuyo intervalo `[horaInicio, horaFin)` se solape con la nueva.

---

### BR-06 — Slots habilitados por el complejo
Las reservas solo podrán realizarse dentro de los **horarios de operación** configurados por el complejo propietario de la cancha. No se permiten reservas fuera de ese rango horario.

> **Criterio de verificación:** El sistema rechaza solicitudes cuyo intervalo no esté completamente contenido en el horario de operación del día correspondiente.

---

### BR-07 — Bloqueo temporal durante pago
Cuando un usuario inicie el proceso de pago de una reserva, el slot seleccionado deberá quedar **bloqueado** durante **10 minutos** para otros usuarios.

> **Justificación:** Evita que dos usuarios intenten pagar simultáneamente el mismo slot.
>
> **Criterio de verificación:** Durante esos 10 minutos, el slot aparece como no disponible para nuevas reservas.

---

### BR-08 — Expiración de reserva pendiente
Si el pago no se confirma dentro del período de bloqueo (10 minutos), la reserva pasará automáticamente al estado **Expirada** y el slot volverá a estar disponible.

> **Criterio de verificación:** Un proceso programado evalúa reservas en estado Pendiente cada minuto y expira las que superaron el tiempo límite.

---

### BR-09 — Límite de reservas activas por usuario
Un usuario no podrá tener más de **5 reservas activas** simultáneamente (estados Pendiente o Confirmada).

> **Justificación:** Previene el acaparamiento de slots por parte de un único usuario.
>
> **Criterio de verificación:** El sistema rechaza nuevas reservas si el usuario ya posee 5 reservas en estado Pendiente o Confirmada.

---

## 3. Multitenancy — aislamiento por complejo

### BR-10 — Aislamiento de datos por complejo
Cada complejo deportivo opera como un **tenant independiente**. Un complejo no podrá acceder, visualizar ni modificar las reservas, canchas ni usuarios de otro complejo.

> **Justificación:** Garantía de privacidad y confidencialidad comercial entre competidores que comparten la plataforma.
>
> **Criterio de verificación:** Todas las consultas de reservas filtran obligatoriamente por `club_id`. No existe ningún endpoint que devuelva reservas de múltiples tenants en una sola respuesta sin autorización explícita de superadmin.

---

### BR-11 — Scope del administrador de complejo
Un usuario con rol **Administrador de Complejo** únicamente podrá gestionar (crear, modificar, cancelar, consultar) reservas que pertenezcan a **las canchas de su propio complejo**.

> **Criterio de verificación:** Toda operación administrativa valida que `cancha.club_id == usuario.club_id`. Un intento de operar sobre una cancha de otro complejo devuelve error 403.

---

### BR-12 — Identificador de tenant en toda reserva
Toda reserva deberá estar asociada al `club_id` del complejo al que pertenece la cancha reservada. Este campo no puede ser nulo ni modificado una vez asignado.

> **Criterio de verificación:** El `club_id` se asigna en el momento de creación de la reserva a partir de la cancha seleccionada y no puede actualizarse posteriormente.

---

### BR-13 — Configuración independiente por complejo
Cada complejo podrá configurar de forma independiente sus propios **horarios de operación**, **precios** y **políticas de cancelación**, sin afectar la configuración de otros complejos.

> **Criterio de verificación:** Los parámetros de configuración de cancelación y horarios se almacenan a nivel de tenant y no son compartidos entre complejos.

---

## 4. Estados de la reserva

### BR-14 — Estados válidos
Toda reserva deberá encontrarse en exactamente uno de los siguientes estados en todo momento:

| Estado | Descripción |
|---|---|
| **Pendiente** | Reserva creada; pago en proceso o pendiente de confirmación manual. |
| **Confirmada** | Pago aprobado (o confirmación manual del complejo). El slot está asignado. |
| **Cancelada** | Reserva anulada por el usuario o por el complejo dentro del plazo permitido. |
| **Expirada** | El pago no se completó en el tiempo límite. El slot queda libre automáticamente. |
| **Finalizada** | El horario de la reserva ya ocurrió y la reserva fue completada. |
| **No-show** | El usuario no se presentó a la cancha. Transición desde Confirmada. |

> **Criterio de verificación:** El sistema rechaza cualquier intento de asignar un estado que no figure en esta lista.

---

### BR-15 — Transiciones de estado permitidas

Solo las siguientes transiciones son válidas:

```
Pendiente   ──pago aprobado──────────→  Confirmada
Pendiente   ──tiempo expirado────────→  Expirada
Pendiente   ──cancelación usuario────→  Cancelada
Confirmada  ──cancelación (en plazo)─→  Cancelada
Confirmada  ──cancelación complejo───→  Cancelada
Confirmada  ──hora fin superada──────→  Finalizada
Confirmada  ──no se presentó──────────→  No-show
```

Toda transición fuera de este diagrama es inválida y debe ser rechazada por el sistema.

> **Criterio de verificación:** El módulo de estados valida la transición antes de persistirla. Se registra la transición en el log de auditoría con actor, estado anterior y estado nuevo.

---

### BR-16 — Inmutabilidad de reservas terminales
Una reserva en estado **Cancelada**, **Expirada**, **Finalizada** o **No-show** no podrá ser modificada ni reactivada.

> **Criterio de verificación:** El sistema rechaza cualquier operación de modificación sobre reservas en estado terminal.

---

### BR-17 — Asociación obligatoria a cancha y usuario
Toda reserva deberá estar asociada obligatoriamente a:
- Una **cancha** existente y activa en el sistema.
- Un **usuario registrado** en el sistema.

Ambas asociaciones son no nulas y no pueden modificarse una vez creada la reserva.

> **Criterio de verificación:** El sistema rechaza la creación de reservas con `cancha_id` o `usuario_id` nulos o inexistentes.

---

## 5. Políticas de cancelación

### BR-18 — Cancelación libre (más de 24 horas)
Si el usuario cancela con **más de 24 horas** de anticipación al inicio de la reserva, no se aplica ninguna penalización. El reembolso, si aplica, es del **100 %**.

> **Criterio de verificación:** `horaInicio - ahora > 24 horas` → cancelación sin cargo.

---

### BR-19 — Cancelación por el complejo
Cuando el complejo cancela una reserva **Confirmada** (por mantenimiento, clima u otras causas operativas), el usuario recibirá un **reembolso del 100 %**, independientemente del tiempo restante.

> **Justificación:** El negocio se reserva el derecho de interrumpir un compromiso de servicio por motivos operativos, logísticos o decisiones administrativas internas. 
> El usuario no es responsable de la cancelación; el incumplimiento es del proveedor del servicio.
>
> **Criterio de verificación:** Cancelaciones iniciadas por rol Administrador de Complejo sobre reservas Confirmadas generan reembolso total.

---

### BR-20 — No-show sin reembolso
Una reserva marcada como **No-show** (usuario no se presentó) no genera reembolso bajo ninguna circunstancia.

> **Criterio de verificación:** La transición `Confirmada → No-show` no dispara ningún proceso de reembolso.

---

### BR-21 — Ventana mínima de cancelación por usuario
Un usuario solo podrá cancelar una reserva si esta se encuentra en estado **Pendiente** o **Confirmada** y el inicio de la reserva aún no ha ocurrido.

> **Criterio de verificación:** El sistema rechaza solicitudes de cancelación sobre reservas cuya `horaInicio` ya pasó o que están en estado terminal.
>
> **Restricción:** El umbral de cancelación libre nunca podrá ser inferior a **1 hora**. La cancelación por parte del complejo siempre genera reembolso del 100 %.

---

### BR-22 — Política de cancelación configurable por complejo
Los umbrales de las políticas de cancelación (horas para cancelación libre, horas para penalización parcial, porcentajes) podrán ser configurados por cada complejo dentro de los rangos mínimos establecidos por la plataforma.

> **Justificación:** Cada complejo tiene su propio modelo de negocio; la plataforma actúa como facilitador, no como regulador.
>
> **Restricción:** El umbral de cancelación libre nunca podrá ser inferior a **1 hora**. La cancelación por parte del complejo siempre genera reembolso del 100 %.

---

---

### BR-23 — Reembolso manual
El Administrador del Complejo posee la facultad de ejecutar reembolsos manuales (totales o parciales) sobre cualquier reserva, ignorando las restricciones temporales de las políticas automáticas.

> **Justificación:** Permite gestionar contingencias climáticas, fallos técnicos en el complejo o cortesía comercial, manteniendo la autonomía operativa de cada tenant.
>
> **Restricción:** Toda cancelación iniciada por el complejo sobre una reserva confirmada dispara obligatoriamente un reembolso del 100%.
> 
> **Criterio de verificación:** El endpoint de reembolso manual valida que el ejecutor tenga rol AdminComplejo y pertenezca al mismo tenantId. Cada reembolso manual debe generar un evento de auditoría específico vinculado al usuarioId del administrador que lo autorizó.
---

## 6. Integridad y trazabilidad

### BR-24 — Registro de auditoría
El sistema deberá registrar toda creación, modificación de estado y cancelación de reservas, indicando: usuario responsable de la acción, marca de tiempo (UTC), estado anterior y estado nuevo.

> **Criterio de verificación:** El log de auditoría es inmutable; no existen endpoints para eliminar entradas de auditoría.

---

### BR-25 — Validación de pago previo a confirmación
En complejos con **pago en línea habilitado**, una reserva no podrá transicionar de Pendiente a Confirmada hasta que el proveedor de pago (Mercado Pago) notifique la aprobación de la transacción.

> **Criterio de verificación:** La transición `Pendiente → Confirmada` solo se ejecuta al recibir el webhook de pago aprobado de Mercado Pago.

---

## Resumen de reglas por área

| ID | Área | Título | Prioridad |
|---|---|---|---|
| BR-01 | Tiempo | Anticipación máxima (30 días) | Must have |
| BR-02 | Tiempo | Duración mínima (1 h) | Must have |
| BR-03 | Tiempo | Incrementos de duración (múltiplos de 1 h) | Should have |
| BR-04 | Tiempo | Integridad temporal | Must have |
| BR-05 | Slots | Ausencia de superposición | Must have |
| BR-06 | Slots | Slots habilitados por el complejo | Must have |
| BR-07 | Slots | Bloqueo temporal durante pago (10 min) | Must have |
| BR-08 | Slots | Expiración de reserva pendiente | Must have |
| BR-09 | Slots | Límite de reservas activas por usuario (5) | Should have |
| BR-10 | Multitenancy | Aislamiento de datos por complejo | Must have |
| BR-11 | Multitenancy | Scope del administrador de complejo | Must have |
| BR-12 | Multitenancy | Tenant ID en toda reserva | Must have |
| BR-13 | Multitenancy | Configuración independiente por complejo | Should have |
| BR-14 | Estados | Estados válidos (6 estados) | Must have |
| BR-15 | Estados | Transiciones permitidas | Must have |
| BR-16 | Estados | Inmutabilidad de estados terminales | Must have |
| BR-17 | Estados | Asociación obligatoria cancha-usuario | Must have |
| BR-18 | Cancelación | Cancelación libre > 24 h | Must have |
| BR-19 | Cancelación | Cancelación por el complejo (100 % reembolso) | Must have |
| BR-20 | Cancelación | No-show sin reembolso | Must have |
| BR-21 | Cancelación | Ventana mínima de cancelación | Must have |
| BR-22 | Cancelación | Política configurable por complejo | Should have |
| BR-23 | Cancelación | Reembolso Manual | Should have |
| BR-24 | Trazabilidad | Registro de auditoría | Must have |
| BR-25 | Trazabilidad | Validación de pago previo a confirmación | Must have |

---

