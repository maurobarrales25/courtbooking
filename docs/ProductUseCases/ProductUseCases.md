# Casos de Uso de Producto — CanchasYa!

**Proyecto:** CanchasYa!
**Versión:** 2.0
**Estado:** Borrador
**Metodología:** Robertson & Robertson — *Mastering the Requirements Process*, 3ra ed.

> Un Caso de Uso de Producto (PUC) describe la porción del BUC que el **producto** automatiza.
> El sujeto implícito de los pasos es **el producto**.
> Los actores son entidades externas al límite del producto.

---

## Índice

| ID | Nombre | BUC origen |
|---|---|---|
| [PUC-01](#puc-01--reservar-una-cancha) | Reservar una cancha | BUC-01 |
| [PUC-02](#puc-02--cancelar-una-reserva-por-el-jugador) | Cancelar una reserva por el jugador | BUC-02 |
| [PUC-03](#puc-03--cancelar-una-reserva-por-el-complejo) | Cancelar una reserva por el complejo | BUC-03 |
| [PUC-04](#puc-04--registrar-un-jugador) | Registrar un jugador | BUC-04 |
| [PUC-05](#puc-05--incorporar-un-complejo-al-servicio) | Incorporar un complejo al servicio | BUC-05 |
| [PUC-06](#puc-06--pagar-una-reserva) | Pagar una reserva | BUC-06 |
| [PUC-07](#puc-07--registrar-la-inasistencia-de-un-jugador) | Registrar la inasistencia de un jugador | BUC-07 |

---

## PUC-01 — Reservar una cancha

**BUC origen:** BUC-01 — Reservar una cancha

> **Decisión de automatización:** El producto automatiza la consulta de disponibilidad, la reserva temporal del turno, la coordinación del pago y la confirmación de la reserva. La presencia física del jugador en la cancha queda fuera del alcance del producto.

| Campo | Descripción |
|---|---|
| **Nombre** | Reservar una cancha |
| **Disparador** | El jugador inicia una solicitud de reserva. Datos que ingresan: identificación del jugador, complejo elegido, cancha, fecha, turno y duración deseada. |
| **Precondiciones** | El jugador tiene una sesión activa. El complejo tiene al menos una cancha habilitada con disponibilidad. El jugador no alcanzó el límite de reservas activas (BR-12). |
| **Interesados** | Jugador (asegurar el turno en la cancha elegida). Dueño del complejo (registrar el turno y cobrar). |
| **Actores** | Jugador. Intermediario de cobro. |

**Pasos del caso normal:**

1. Recibe la solicitud del jugador con el complejo, cancha, fecha, turno y duración elegidos.
2. Muestra los turnos disponibles para la cancha y fecha elegidas.
3. El jugador elige el turno y la duración.
4. Verifica que el turno esté libre y que cumpla las condiciones de anticipación y duración del complejo (BR-01, BR-02, BR-03, BR-04).
5. Reserva el turno temporalmente a nombre del jugador e inicia el tiempo límite de reserva (BR-09).
6. Presenta al jugador el resumen: cancha, fecha, turno, duración y monto a pagar.
7. El jugador autoriza el pago (ver PUC-06).
8. Confirma la reserva a nombre del jugador.
9. Notifica al jugador y al complejo la confirmación de la reserva.

**Alternativas:**

- **A1.1** — El jugador cambia de complejo: retoma desde el paso 1 con el nuevo complejo elegido.
- **A7.1** — El complejo no cobra por adelantado: confirma la reserva directamente sin pasar por el pago. Pasa al paso 8.

**Excepciones:**

- **E4.1** — El turno no cumple las condiciones de anticipación o duración: informa el motivo al jugador y le permite elegir otro turno (retoma paso 2).
- **E4.2** — Otro jugador tomó el mismo turno en el intervalo: informa la no disponibilidad y muestra los turnos libres actualizados (retoma paso 2).
- **E4.3** — El jugador alcanzó el límite de reservas activas (BR-12): informa al jugador y no continúa el proceso.
- **E7.1** — El tiempo de reserva temporal vence antes de completarse el pago (BR-10): libera el turno, informa al jugador y cancela el proceso.

| **Resultado** | El turno queda reservado y confirmado a nombre del jugador. El complejo recibe la notificación del nuevo turno en su agenda. |
|---|---|

---

## PUC-02 — Cancelar una reserva por el jugador

**BUC origen:** BUC-02 — Cancelar una reserva por el jugador

> **Decisión de automatización:** El producto automatiza el cálculo del tiempo restante, la aplicación de la política de cancelación y la instrucción de devolución al intermediario de cobro. La devolución del dinero la ejecuta el intermediario de cobro fuera del producto.

| Campo | Descripción |
|---|---|
| **Nombre** | Cancelar una reserva por el jugador |
| **Disparador** | El jugador solicita la cancelación de una reserva activa. Datos que ingresan: identificación del jugador, identificación de la reserva a cancelar. |
| **Precondiciones** | El jugador tiene una sesión activa. La reserva está en estado activo (temporal o confirmada). El turno aún no comenzó. |
| **Interesados** | Jugador (recuperar el pago según la política aplicable). Dueño del complejo (recuperar la disponibilidad del turno). |
| **Actores** | Jugador. Intermediario de cobro. |

**Pasos del caso normal:**

1. El jugador selecciona la reserva a cancelar desde su historial de reservas activas.
2. Calcula el tiempo restante hasta el inicio del turno y determina la política de cancelación aplicable (BR-21, BR-22, BR-23).
3. Informa al jugador la política vigente y el monto que recibirá como devolución.
4. El jugador confirma la cancelación.
5. Registra la cancelación y libera el turno para nuevas reservas.
6. Instruye al intermediario de cobro para procesar la devolución del monto correspondiente.
7. Notifica al jugador la cancelación y el detalle de la devolución gestionada.

**Alternativas:**

- **A4.1** — El jugador decide no confirmar la cancelación: no realiza ningún cambio y regresa al historial de reservas.
- **A1.1** — La reserva no fue pagada: cancela sin devolución económica y libera el turno. Pasa al paso 5.

**Excepciones:**

- **E1.1** — La reserva está en un estado final (BR-19): informa al jugador que la reserva no puede cancelarse.
- **E1.2** — El turno ya comenzó (BR-26): informa al jugador que el plazo de cancelación expiró.
- **E6.1** — El intermediario de cobro no puede procesar la devolución en ese momento: registra la cancelación y marca la devolución como pendiente de resolución.

| **Resultado** | La reserva queda cancelada, el turno vuelve a estar disponible y el jugador recibe (o tiene pendiente) la devolución según la política del complejo. |
|---|---|

---

## PUC-03 — Cancelar una reserva por el complejo

**BUC origen:** BUC-03 — Cancelar una reserva por el complejo

> **Decisión de automatización:** El producto automatiza el registro de la cancelación, la liberación del turno y la instrucción de devolución completa. La verificación de la causa operativa y la devolución del dinero las ejecuta el intermediario de cobro fuera del producto.

| Campo | Descripción |
|---|---|
| **Nombre** | Cancelar una reserva por el complejo |
| **Disparador** | El administrador del complejo solicita la cancelación de una reserva confirmada por causas operativas. Datos que ingresan: identificación del administrador, reserva a cancelar, motivo. |
| **Precondiciones** | El administrador tiene una sesión activa con permisos de gestión sobre el complejo. La reserva pertenece a ese complejo y está confirmada. |
| **Interesados** | Dueño del complejo (recuperar el turno para uso operativo). Jugador (recibir la devolución completa del pago). |
| **Actores** | Administrador del complejo. Intermediario de cobro. |

**Pasos del caso normal:**

1. El administrador selecciona una reserva confirmada de la agenda de su complejo e indica el motivo de la cancelación.
2. Registra la cancelación y libera el turno en la agenda del complejo.
3. Instruye al intermediario de cobro para procesar la devolución completa del pago al jugador (BR-24).
4. Notifica al jugador la cancelación, el motivo y la devolución gestionada.

**Alternativas:**

- **A1.1** — La reserva no fue pagada: cancela sin devolución económica y libera el turno directamente. Pasa al paso 2.

**Excepciones:**

- **E1.1** — El administrador intenta cancelar una reserva de otro complejo: rechaza la acción e informa al administrador (BR-14).
- **E1.2** — La reserva está en un estado final (BR-19): rechaza la acción e informa al administrador.
- **E3.1** — El intermediario de cobro no puede procesar la devolución en ese momento: registra la cancelación y marca la devolución como pendiente.

| **Resultado** | La reserva queda cancelada, el turno queda libre en la agenda del complejo y el jugador recibe la devolución completa del pago. |
|---|---|

---

## PUC-04 — Registrar un jugador

**BUC origen:** BUC-04 — Registrar un jugador

> **Decisión de automatización:** El producto automatiza la totalidad del proceso de registro. No hay pasos manuales fuera del producto en este caso de uso.

| Campo | Descripción |
|---|---|
| **Nombre** | Registrar un jugador |
| **Disparador** | Una persona solicita registrarse como jugador en el producto. Datos que ingresan: nombre y datos de contacto del solicitante. |
| **Precondiciones** | El solicitante no tiene cuenta activa en el producto. |
| **Interesados** | Jugador potencial (acceder a la oferta de canchas disponibles). Dueños de complejos (contar con jugadores identificados para gestionar reservas). |
| **Actores** | Solicitante. Proveedor de identidad externo (opcional). |

**Pasos del caso normal:**

1. El solicitante ingresa sus datos de registro.
2. Verifica que no exista ya una cuenta con esos datos.
3. Registra al jugador con perfil activo.
4. Notifica al solicitante la confirmación del registro.

**Alternativas:**

- **A1.1** — El solicitante se identifica a través de un proveedor de identidad externo: obtiene los datos de identificación de ese proveedor y continúa desde el paso 2.

**Excepciones:**

- **E2.1** — Ya existe una cuenta con esos datos: informa al solicitante que ya tiene una cuenta registrada y no crea una nueva.
- **E1.1** — Los datos son incompletos o inválidos: señala los campos a corregir antes de continuar.

| **Resultado** | El solicitante queda registrado como jugador activo y puede hacer reservas en los complejos disponibles. |
|---|---|

---

## PUC-05 — Incorporar un complejo al servicio

**BUC origen:** BUC-05 — Incorporar un complejo al servicio

> **Decisión de automatización:** El producto automatiza el alta del complejo como espacio de gestión aislado, la creación del administrador principal, el registro de canchas y la configuración de políticas. La negociación comercial entre el complejo y CanchasYa! ocurre fuera del producto.

| Campo | Descripción |
|---|---|
| **Nombre** | Incorporar un complejo al servicio |
| **Disparador** | El dueño de un complejo inicia el proceso de alta en el producto. Datos que ingresan: nombre del complejo, dirección, datos de contacto, datos del administrador principal, descripción de canchas. |
| **Precondiciones** | El complejo no está dado de alta en el producto. El solicitante tiene autoridad para representar al complejo. |
| **Interesados** | Dueño del complejo (digitalizar su gestión de reservas). Jugadores (acceder a la oferta del nuevo complejo). |
| **Actores** | Dueño del complejo. |

**Pasos del caso normal:**

1. El dueño ingresa los datos del complejo y del administrador principal.
2. Verifica que el complejo no esté ya incorporado.
3. Crea el espacio de gestión del complejo, aislado de los demás complejos del servicio (BR-13).
4. Crea la cuenta del administrador principal con permisos exclusivos sobre ese complejo (BR-14).
5. El dueño registra las canchas del complejo con sus características.
6. El dueño configura los horarios de operación y los precios por turno de cada cancha.
7. El dueño define la política de cancelación del complejo, dentro de los límites del servicio (BR-27).
8. Activa el complejo y hace visible su oferta de canchas a los jugadores.

**Alternativas:**

- **A7.1** — El dueño habilita el cobro por adelantado: vincula las credenciales del complejo con el intermediario de cobro para procesar pagos en las reservas.

**Excepciones:**

- **E2.1** — El complejo ya está incorporado: informa al solicitante e interrumpe el proceso.
- **E1.1** — Los datos son incompletos o inválidos: señala los campos a corregir antes de continuar.
- **E7.1** — La política de cancelación no cumple los límites mínimos del servicio (BR-27): informa los valores admisibles y solicita corrección.

| **Resultado** | El complejo queda activo como operador independiente. Sus canchas son visibles para los jugadores y el administrador puede gestionar su agenda de forma autónoma. |
|---|---|

---

## PUC-06 — Pagar una reserva

**BUC origen:** BUC-06 — Pagar una reserva

> **Decisión de automatización:** El producto automatiza la presentación del resumen de pago, la coordinación con el intermediario de cobro y la confirmación de la reserva. La transacción financiera la ejecuta el intermediario de cobro como sistema externo.

| Campo | Descripción |
|---|---|
| **Nombre** | Pagar una reserva |
| **Disparador** | El jugador necesita abonar una reserva temporal para que quede confirmada. Datos que ingresan: identificación del jugador, identificación de la reserva temporal, medio de pago elegido. |
| **Precondiciones** | Existe una reserva temporal activa a nombre del jugador. El tiempo de reserva temporal no venció. El complejo tiene habilitado el cobro por adelantado. |
| **Interesados** | Jugador (pagar el turno para asegurarlo). Dueño del complejo (cobrar el turno por adelantado). |
| **Actores** | Jugador. Intermediario de cobro. |

**Pasos del caso normal:**

1. Presenta al jugador el resumen de la reserva temporal y el monto a pagar.
2. El jugador elige el medio de pago entre las opciones disponibles.
3. Transmite los datos del pago al intermediario de cobro.
4. El intermediario de cobro procesa el pago y comunica el resultado al producto.
5. Recibe la confirmación del pago exitoso.
6. Confirma la reserva.
7. Notifica al jugador y al complejo la confirmación del pago y de la reserva.

**Alternativas:**

*(No aplica: el disparador ya está acotado a reservas temporales en complejos con cobro por adelantado habilitado.)*

**Excepciones:**

- **E4.1** — El intermediario rechaza el pago: informa al jugador el motivo y le permite intentar con otro medio de pago mientras la reserva temporal esté vigente.
- **E4.2** — El intermediario reporta un error técnico: informa al jugador y mantiene la reserva temporal activa hasta el vencimiento.
- **E3.1** — El tiempo de reserva temporal vence antes de completarse el pago (BR-10): cancela la operación, libera el turno e informa al jugador.

| **Resultado** | El pago queda registrado y la reserva queda confirmada a nombre del jugador. |
|---|---|

---

## PUC-07 — Registrar la inasistencia de un jugador

**BUC origen:** BUC-07 — Registrar la inasistencia de un jugador

> **Decisión de automatización:** El producto automatiza el registro de la inasistencia y la actualización del historial del jugador. La verificación física de que el jugador no se presentó la realiza el administrador fuera del producto.

| Campo | Descripción |
|---|---|
| **Nombre** | Registrar la inasistencia de un jugador |
| **Disparador** | El administrador del complejo indica que el jugador no se presentó al turno. Datos que ingresan: identificación del administrador, identificación de la reserva correspondiente. |
| **Precondiciones** | El administrador tiene una sesión activa con permisos sobre el complejo. La reserva pertenece a ese complejo, estaba confirmada y su turno ya inició o terminó. |
| **Interesados** | Dueño del complejo (conservar el pago y registrar el incumplimiento). Jugador (queda constancia de la inasistencia en su historial). |
| **Actores** | Administrador del complejo. |

**Pasos del caso normal:**

1. El administrador accede a la agenda de turnos del día y selecciona la reserva sin presentación.
2. El administrador confirma el registro de inasistencia para ese turno.
3. Actualiza el estado de la reserva a inasistencia y retiene el pago a favor del complejo (BR-25).
4. Registra la inasistencia en el historial del jugador.

**Alternativas:**

*(No aplica; la inasistencia es un hecho binario: el jugador se presentó o no.)*

**Excepciones:**

- **E2.1** — El administrador intenta registrar la inasistencia en una reserva de otro complejo: rechaza la acción e informa al administrador (BR-14).
- **E2.2** — El turno todavía no comenzó: rechaza la acción; el jugador aún puede presentarse.
- **E2.3** — La reserva ya está en un estado final (BR-19): rechaza la acción.

| **Resultado** | La inasistencia queda registrada, el complejo conserva el pago y el historial del jugador queda actualizado. |
|---|---|

---

## Trazabilidad

```
vision.md
    └── docs/BusinessRules/BR-Reservas.md
            └── docs/BusinessUseCases/BusinessUseCases.md
                    └── docs/ProductUseCases/ProductUseCases.md  ← este documento
                            └── RF-XX / RNF-XX (requisitos atómicos)  [pendiente]
                                    └── US-XX (historias de usuario)  [pendiente]
```

### Correspondencia BUC → PUC

| BUC | PUC derivado | Pasos del BUC no automatizados por el producto |
|---|---|---|
| BUC-01 Reservar una cancha | PUC-01 | Presencia física del jugador en la cancha |
| BUC-02 Cancelar reserva (jugador) | PUC-02 | Devolución del dinero (intermediario de cobro) |
| BUC-03 Cancelar reserva (complejo) | PUC-03 | Verificación de la causa operativa; devolución del dinero (intermediario) |
| BUC-04 Registrar un jugador | PUC-04 | — (proceso totalmente automatizado) |
| BUC-05 Incorporar un complejo | PUC-05 | Negociación comercial previa entre el complejo y CanchasYa! |
| BUC-06 Pagar una reserva | PUC-06 | Transacción financiera (intermediario de cobro) |
| BUC-07 Registrar la inasistencia | PUC-07 | Verificación física de la no presencia (administrador) |

### Cobertura de reglas de negocio

| Regla | PUC que la aplica |
|---|---|
| BR-01 / BR-02 Anticipación mín/máx | PUC-01 (E4.1) |
| BR-03 / BR-04 Duración mín/máx | PUC-01 (E4.1) |
| BR-09 Reserva temporal del turno | PUC-01 (paso 5) |
| BR-10 Vencimiento de reserva temporal | PUC-01 (E7.1), PUC-06 (E3.1) |
| BR-12 Límite de reservas activas | PUC-01 (E4.3) |
| BR-13 Aislamiento por complejo | PUC-05 (paso 3) |
| BR-14 Permisos del administrador | PUC-03 (E1.1), PUC-07 (E2.1) |
| BR-19 Estados finales | PUC-02 (E1.1), PUC-03 (E1.2), PUC-07 (E2.3) |
| BR-21 / BR-22 / BR-23 Política de cancelación | PUC-02 (paso 2) |
| BR-24 Cancelación por complejo = devolución completa | PUC-03 (paso 3) |
| BR-25 Inasistencia sin devolución | PUC-07 (paso 3) |
| BR-26 Solo se cancela si el turno no comenzó | PUC-02 (E1.2) |
| BR-27 Política configurable por complejo | PUC-05 (paso 7) |

---
