# Requisitos Atómicos — PUC-09: Administrar canchas del complejo

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-09
**PUC origen:** PUC-09 — Administrar canchas del complejo
**BUC origen:** —

---

## Índice

| ID | Descripción breve | Tipo | Prioridad |
|---|---|---|---|
| RF-58 | Crear una cancha en el complejo con nombre, tipo y características | Funcional | Must have |
| RF-59 | Modificar datos de una cancha existente del complejo | Funcional | Must have |
| RF-60 | Validar datos de cancha al crear o modificar | Funcional | Must have |
| RF-61 | Deshabilitar una cancha habilitada del complejo | Funcional | Must have |
| RF-62 | Reactivar una cancha previamente deshabilitada | Funcional | Must have |
| RF-63 | Rechazar deshabilitación de cancha con reservas futuras confirmadas | Funcional | Must have |

---

## RF-58 — Crear una cancha en el complejo

| Campo | Valor |
|---|---|
| **# Requisito** | RF-58 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-09 (pasos 1–5) |
| **Descripción** | El sistema deberá permitir al administrador registrar una nueva cancha en su complejo, asociándola exclusivamente al espacio de gestión del complejo al que pertenece el administrador. |
| **Justificación** | Sin el alta de canchas, el complejo no puede ofrecer turnos ni recibir reservas; es el punto de entrada para toda la oferta del complejo. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras crear la cancha, esta aparece en el listado de canchas del complejo del administrador. No es visible desde el espacio de gestión de otro complejo (BR-11). La cancha no aparece en la oferta pública hasta que tenga horarios configurados. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-35, RF-36 |
| **Conflictos** | — |
| **Material de soporte** | BR-11, PUC-09 pasos 1–5, US-18 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-59 — Modificar datos de una cancha existente del complejo

| Campo | Valor |
|---|---|
| **# Requisito** | RF-59 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-09 (paso 3, pasos 5–8) |
| **Descripción** | El sistema deberá permitir al administrador modificar el nombre, tipo y características de una cancha existente de su complejo, reflejando los cambios de inmediato en el sistema. |
| **Justificación** | La información de las canchas puede cambiar a lo largo del tiempo (reformas, cambios de superficie, etc.); el administrador debe poder mantenerla actualizada. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras guardar la modificación, la cancha muestra los nuevos datos en el listado del complejo. Un administrador de otro complejo no puede modificar esta cancha (BR-11). |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-58, RF-36 |
| **Conflictos** | — |
| **Material de soporte** | BR-11, PUC-09 paso 3, US-18 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-60 — Validar datos de cancha al crear o modificar

| Campo | Valor |
|---|---|
| **# Requisito** | RF-60 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-09 (paso 4, E3.1) |
| **Descripción** | El sistema deberá rechazar la creación o modificación de una cancha cuando los datos ingresados sean inválidos o incompletos, informando al administrador el campo específico que requiere corrección. |
| **Justificación** | Datos incompletos o inválidos en una cancha generarían inconsistencias en la consulta de disponibilidad y en el proceso de reserva. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un intento de crear una cancha sin nombre es rechazado con el mensaje correspondiente. Un intento con todos los campos requeridos completos y válidos no es rechazado por este criterio. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-58, RF-59 |
| **Conflictos** | — |
| **Material de soporte** | PUC-09 E3.1, US-18 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-61 — Deshabilitar una cancha habilitada del complejo

| Campo | Valor |
|---|---|
| **# Requisito** | RF-61 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-09 (A1.1) |
| **Descripción** | El sistema deberá permitir al administrador deshabilitar una cancha activa de su complejo, impidiendo que aparezca disponible para nuevas reservas a partir de ese momento. |
| **Justificación** | Las canchas pueden quedar fuera de servicio por mantenimiento o remodelación; deshabilitar evita que los usuarios reserven turnos inviables operativamente. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras deshabilitar una cancha, esta no aparece en la vista de disponibilidad para nuevas reservas (RF-52). Las reservas ya confirmadas sobre esa cancha no se cancelan automáticamente. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-58, RF-63 |
| **Conflictos** | RF-62 |
| **Material de soporte** | PUC-09 A1.1, US-19 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-62 — Reactivar una cancha previamente deshabilitada

| Campo | Valor |
|---|---|
| **# Requisito** | RF-62 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-09 (A2.1) |
| **Descripción** | El sistema deberá permitir al administrador reactivar una cancha que se encuentra deshabilitada, volviendo a incluirla en la vista de disponibilidad para nuevas reservas. |
| **Justificación** | La deshabilitación es un estado temporal; una vez completado el mantenimiento el administrador debe poder restablecer la oferta de esa cancha sin necesidad de recrearla. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras reactivar la cancha, esta vuelve a aparecer en la vista de disponibilidad con sus horarios y precios configurados previamente. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-61 |
| **Conflictos** | RF-61 |
| **Material de soporte** | PUC-09 A2.1, US-19 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-63 — Rechazar deshabilitación de cancha con reservas futuras confirmadas

| Campo | Valor |
|---|---|
| **# Requisito** | RF-63 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-09 (E4.1) |
| **Descripción** | El sistema deberá informar al administrador y no aplicar la deshabilitación automáticamente cuando existan reservas futuras en estado Confirmada asociadas a la cancha que se intenta deshabilitar. |
| **Justificación** | Deshabilitar una cancha con reservas confirmadas sin gestionar esas reservas primero dejaría a los usuarios sin su turno y al complejo con una obligación incumplida. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al intentar deshabilitar una cancha con al menos una reserva Confirmada futura, el sistema muestra un aviso al administrador indicando el conflicto y no aplica la deshabilitación hasta que el administrador resuelva manualmente las reservas afectadas. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-61 |
| **Conflictos** | — |
| **Material de soporte** | PUC-09 E4.1, US-19 |
| **Historial** | 2026-05-09 — Creado |
