# Requisitos Atómicos — PUC-01: Reservar una cancha

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-08
**PUC origen:** PUC-01 — Reservar una cancha
**BUC origen:** BUC-01

---

## Índice

| ID | Descripción breve | Tipo | Prioridad |
|---|---|---|---|
| RF-01 | Consultar turnos disponibles de una cancha | Funcional | Must have |
| RF-02 | Validar anticipación mínima (1 hora) | Funcional | Must have |
| RF-03 | Validar anticipación máxima (30 días) | Funcional | Must have |
| RF-04 | Validar duración mínima (1 hora) | Funcional | Must have |
| RF-05 | Validar duración máxima (4 horas) | Funcional | Must have |
| RF-06 | Validar duración en múltiplos de 1 hora | Funcional | Should have |
| RF-07 | Bloquear turno temporalmente al iniciar reserva | Funcional | Must have |
| RF-08 | Validar límite de reservas activas por jugador | Funcional | Should have |
| RF-09 | Confirmar reserva al completarse el pago o al aceptarse sin pago | Funcional | Must have |
| RF-10 | Confirmar reserva sin pago para complejos sin cobro anticipado | Funcional | Must have |
| RF-11 | Notificar al jugador y al complejo la confirmación de reserva | Funcional | Must have |
| RF-12 | Expirar reserva temporal si el tiempo límite vence sin pago | Funcional | Must have |

---

## RF-01 — Consultar turnos disponibles de una cancha

| Campo | Valor |
|---|---|
| **# Requisito** | RF-01 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-01 (paso 2) |
| **Descripción** | El sistema deberá mostrar los turnos disponibles de una cancha para una fecha determinada, considerando únicamente los horarios de operación habilitados por el complejo (BR-08) y excluyendo los turnos ya reservados o bloqueados. |
| **Justificación** | El jugador necesita conocer la disponibilidad real antes de seleccionar un turno; sin esta consulta no es posible iniciar el proceso de reserva. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Dado un complejo con horario de operación configurado y al menos un turno ocupado, el resultado de la consulta excluye los turnos ocupados y los que queden fuera del horario habilitado. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-35 (el complejo debe estar registrado con horarios configurados) |
| **Conflictos** | — |
| **Material de soporte** | BR-08, PUC-01 paso 2 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-02 — Validar anticipación mínima

| Campo | Valor |
|---|---|
| **# Requisito** | RF-02 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-01 (paso 4, E4.1) |
| **Descripción** | El sistema deberá rechazar una solicitud de reserva cuyo turno de inicio sea inferior a 60 minutos desde el momento de la solicitud. |
| **Justificación** | Permite al complejo gestionar operativamente la preparación de la cancha (BR-01). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Una solicitud con `horaInicio < ahora + 60 min` es rechazada con el motivo "anticipación insuficiente". Una solicitud con `horaInicio ≥ ahora + 60 min` no es rechazada por este criterio. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | BR-01, PUC-01 E4.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-03 — Validar anticipación máxima

| Campo | Valor |
|---|---|
| **# Requisito** | RF-03 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-01 (paso 4, E4.1) |
| **Descripción** | El sistema deberá rechazar una solicitud de reserva cuya fecha de inicio supere 30 días naturales desde la fecha actual. |
| **Justificación** | Evita el bloqueo especulativo de turnos que perjudica la disponibilidad para otros jugadores (BR-02). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Una solicitud con `fechaInicio > hoy + 30 días` es rechazada con el motivo "anticipación excesiva". Una solicitud con `fechaInicio ≤ hoy + 30 días` no es rechazada por este criterio. |
| **Satisfacción del interesado** | 3 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | BR-02, PUC-01 E4.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-04 — Validar duración mínima

| Campo | Valor |
|---|---|
| **# Requisito** | RF-04 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-01 (paso 4, E4.1) |
| **Descripción** | El sistema deberá rechazar una solicitud de reserva cuya duración sea inferior a 60 minutos. |
| **Justificación** | El modelo de negocio de los complejos opera por horas; fracciones menores no son rentables ni viables (BR-03). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Una solicitud con duración < 60 minutos es rechazada. Una solicitud con duración = 60 minutos no es rechazada por este criterio. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | BR-03, PUC-01 E4.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-05 — Validar duración máxima

| Campo | Valor |
|---|---|
| **# Requisito** | RF-05 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-01 (paso 4, E4.1) |
| **Descripción** | El sistema deberá rechazar una solicitud de reserva cuya duración supere 240 minutos. |
| **Justificación** | Garantiza la rotación de canchas y evita acaparamientos (BR-04). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Una solicitud con duración > 240 minutos es rechazada. Una solicitud con duración = 240 minutos no es rechazada por este criterio. |
| **Satisfacción del interesado** | 3 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | BR-04, PUC-01 E4.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-06 — Validar duración en múltiplos de 1 hora

| Campo | Valor |
|---|---|
| **# Requisito** | RF-06 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-01 (paso 4) |
| **Descripción** | El sistema deberá rechazar una solicitud de reserva cuya duración no sea un múltiplo exacto de 60 minutos. |
| **Justificación** | Los complejos gestionan disponibilidad por slots horarios completos; fracciones rompen la lógica de ocupación (BR-05). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Una solicitud con duración = 90 minutos es rechazada. Una solicitud con duración = 120 minutos no es rechazada por este criterio. |
| **Satisfacción del interesado** | 3 |
| **Insatisfacción del interesado** | 3 |
| **Prioridad** | Should have |
| **Dependencias** | RF-04, RF-05 |
| **Conflictos** | — |
| **Material de soporte** | BR-05, PUC-01 paso 3 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-07 — Bloquear turno temporalmente al iniciar reserva

| Campo | Valor |
|---|---|
| **# Requisito** | RF-07 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-01 (paso 5) |
| **Descripción** | El sistema deberá bloquear el turno seleccionado durante 10 minutos a nombre del jugador que inició el proceso de reserva, impidiendo que otro jugador reserve ese mismo turno durante ese período. |
| **Justificación** | Evita que dos jugadores paguen simultáneamente el mismo turno (BR-09). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Inmediatamente después de iniciar la reserva, el turno no aparece disponible para otros jugadores. Transcurridos 10 minutos sin confirmación de pago, el turno vuelve a aparecer disponible. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-01 |
| **Conflictos** | — |
| **Material de soporte** | BR-09, PUC-01 paso 5 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-08 — Validar límite de reservas activas por jugador

| Campo | Valor |
|---|---|
| **# Requisito** | RF-08 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-01 (paso 4, E4.3) |
| **Descripción** | El sistema deberá rechazar una nueva solicitud de reserva cuando el jugador ya tenga 5 reservas en estado Pendiente o Confirmada. |
| **Justificación** | Previene el acaparamiento de turnos por parte de un único jugador (BR-12). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un jugador con 5 reservas activas recibe rechazo al intentar crear una sexta. Un jugador con 4 reservas activas puede crear una más sin ser rechazado por este criterio. |
| **Satisfacción del interesado** | 3 |
| **Insatisfacción del interesado** | 3 |
| **Prioridad** | Should have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | BR-12, PUC-01 E4.3 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-09 — Confirmar reserva al completarse el pago

| Campo | Valor |
|---|---|
| **# Requisito** | RF-09 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-01 (paso 8), PUC-06 (paso 6) |
| **Descripción** | El sistema deberá cambiar el estado de la reserva de Pendiente a Confirmada al recibir la confirmación de pago exitoso del intermediario de cobro. |
| **Justificación** | La reserva solo queda asegurada para el jugador cuando el pago ha sido procesado (BR-18, BR-31). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al recibir confirmación de pago, el estado de la reserva es "Confirmada". El turno no puede ser tomado por otro jugador después de esta transición. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-07, RF-43 |
| **Conflictos** | — |
| **Material de soporte** | BR-18, BR-31, PUC-01 paso 8, PUC-06 paso 6 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-10 — Confirmar reserva sin pago

| Campo | Valor |
|---|---|
| **# Requisito** | RF-10 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-01 (A7.1) |
| **Descripción** | El sistema deberá confirmar directamente una reserva, sin pasar por el flujo de pago, cuando el complejo no tenga habilitado el cobro por adelantado. |
| **Justificación** | Algunos complejos cobran en persona al momento del turno; el producto debe soportar este modelo de negocio. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | En un complejo sin cobro anticipado habilitado, la reserva pasa a estado Confirmada sin que se haya procesado ningún pago. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-35 |
| **Conflictos** | — |
| **Material de soporte** | PUC-01 A7.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-11 — Notificar confirmación de reserva

| Campo | Valor |
|---|---|
| **# Requisito** | RF-11 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-01 (paso 9) |
| **Descripción** | El sistema deberá enviar una notificación al jugador y al complejo cuando una reserva quede confirmada, indicando los datos del turno (cancha, fecha, horario, duración). |
| **Justificación** | Ambas partes necesitan confirmación explícita para planificar la asistencia y la agenda del complejo. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al confirmar una reserva, el jugador recibe una notificación con los datos del turno y el complejo recibe la misma información. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-09, RF-10 |
| **Conflictos** | — |
| **Material de soporte** | PUC-01 paso 9 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-12 — Expirar reserva temporal sin pago

| Campo | Valor |
|---|---|
| **# Requisito** | RF-12 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-01 (E7.1), PUC-06 (E3.1) |
| **Descripción** | El sistema deberá cambiar el estado de una reserva Pendiente a Expirada y liberar el turno cuando transcurran 10 minutos sin que el pago haya sido completado. |
| **Justificación** | Sin expiración automática, un turno bloqueado no liberado bloquea indefinidamente la disponibilidad (BR-10). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Una reserva en estado Pendiente cuyo tiempo de bloqueo de 10 minutos ha transcurrido pasa a estado Expirada y el turno aparece disponible para nuevas reservas. La evaluación ocurre al menos cada minuto (BR-10). |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-07 |
| **Conflictos** | — |
| **Material de soporte** | BR-09, BR-10, PUC-01 E7.1 |
| **Historial** | 2026-05-08 — Creado |
