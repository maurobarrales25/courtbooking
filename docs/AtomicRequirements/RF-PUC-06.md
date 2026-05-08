# Requisitos Atómicos — PUC-06: Pagar una reserva

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-08
**PUC origen:** PUC-06 — Pagar una reserva
**BUC origen:** BUC-06

---

## Índice

| ID | Descripción breve | Tipo | Prioridad |
|---|---|---|---|
| RF-43 | Presentar resumen de reserva temporal con monto a pagar | Funcional | Must have |
| RF-44 | Transmitir datos del pago al intermediario de cobro | Funcional | Must have |
| RF-45 | Confirmar reserva al recibir confirmación de pago exitoso | Funcional | Must have |
| RF-46 | Informar rechazo de pago y permitir reintento | Funcional | Must have |
| RF-47 | Notificar confirmación de pago y reserva a jugador y complejo | Funcional | Must have |

---

## RF-43 — Presentar resumen de reserva temporal con monto a pagar

| Campo | Valor |
|---|---|
| **# Requisito** | RF-43 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-06 (paso 1) |
| **Descripción** | El sistema deberá mostrar al jugador el resumen de su reserva temporal (cancha, fecha, turno, duración) junto con el monto total a pagar antes de iniciar el proceso de cobro. |
| **Justificación** | El jugador debe conocer y confirmar los detalles y el monto exacto antes de autorizar el pago para evitar cargos no esperados. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | El resumen presentado al jugador antes del pago muestra los mismos datos de turno que los registrados en la reserva temporal, incluyendo el monto calculado según el precio configurado por el complejo. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-07 |
| **Conflictos** | — |
| **Material de soporte** | PUC-06 paso 1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-44 — Transmitir datos del pago al intermediario de cobro

| Campo | Valor |
|---|---|
| **# Requisito** | RF-44 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-06 (paso 3) |
| **Descripción** | El sistema deberá transmitir al intermediario de cobro los datos de la operación (monto, identificación de la reserva, medio de pago elegido por el jugador) para que el intermediario procese el cobro. |
| **Justificación** | El producto coordina el pago pero no ejecuta la transacción financiera; la transmisión es el mecanismo de delegación al intermediario. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | El intermediario de cobro recibe una solicitud de cobro con el monto correcto correspondiente a la reserva, la referencia de la operación y el medio de pago seleccionado. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-43, RF-42 |
| **Conflictos** | — |
| **Material de soporte** | PUC-06 paso 3, (Should have — Mercado Pago) |
| **Historial** | 2026-05-08 — Creado |

---

## RF-45 — Confirmar reserva al recibir confirmación de pago exitoso

| Campo | Valor |
|---|---|
| **# Requisito** | RF-45 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-06 (paso 5, paso 6) |
| **Descripción** | El sistema deberá cambiar el estado de la reserva de Pendiente a Confirmada al recibir la confirmación de pago exitoso del intermediario de cobro. |
| **Justificación** | La transición al estado Confirmada solo es válida cuando existe confirmación de pago; confirmar sin dicha confirmación violaría la integridad financiera (BR-18, BR-31). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al recibir confirmación de pago exitoso del intermediario, la reserva pasa al estado "Confirmada". Sin esta confirmación, la reserva permanece en estado Pendiente hasta que venza el tiempo límite (RF-12). |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-44, RF-09 |
| **Conflictos** | — |
| **Material de soporte** | BR-18, BR-31, PUC-06 paso 5, paso 6 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-46 — Informar rechazo de pago y permitir reintento

| Campo | Valor |
|---|---|
| **# Requisito** | RF-46 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-06 (E4.1, E4.2) |
| **Descripción** | El sistema deberá informar al jugador el motivo del rechazo o error reportado por el intermediario de cobro y permitirle intentar el pago con un medio diferente mientras la reserva temporal siga vigente. |
| **Justificación** | Un rechazo puntual no debe forzar al jugador a reiniciar todo el proceso de reserva; la reserva temporal todavía protege el turno durante el tiempo límite (BR-09). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Cuando el intermediario rechaza el pago, el jugador recibe el motivo del rechazo y puede seleccionar otro medio de pago sin que la reserva temporal sea cancelada. La reserva temporal sigue vigente hasta el vencimiento de los 10 minutos. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-07, RF-44 |
| **Conflictos** | — |
| **Material de soporte** | PUC-06 E4.1, E4.2 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-47 — Notificar confirmación de pago y reserva

| Campo | Valor |
|---|---|
| **# Requisito** | RF-47 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-06 (paso 7) |
| **Descripción** | El sistema deberá enviar una notificación al jugador y al complejo cuando el pago haya sido confirmado y la reserva haya pasado a estado Confirmada, indicando los datos del turno y el monto cobrado. |
| **Justificación** | La confirmación del pago cierra el ciclo de la reserva; ambas partes necesitan la notificación para planificar. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras la confirmación del pago, el jugador recibe una notificación con los datos del turno y el monto cobrado. El complejo recibe notificación del nuevo turno confirmado en su agenda. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-45 |
| **Conflictos** | — |
| **Material de soporte** | PUC-06 paso 7 |
| **Historial** | 2026-05-08 — Creado |
