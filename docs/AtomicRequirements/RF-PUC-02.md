# Requisitos Atómicos — PUC-02: Cancelar una reserva por el jugador

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-08
**PUC origen:** PUC-02 — Cancelar una reserva por el jugador
**BUC origen:** BUC-02

---

## Índice

| ID | Descripción breve | Tipo | Prioridad |
|---|---|---|---|
| RF-13 | Calcular tiempo restante y determinar política de cancelación | Funcional | Must have |
| RF-14 | Aplicar devolución del 100% si cancelación > 24 horas | Funcional | Must have |
| RF-15 | Aplicar devolución del 50% si cancelación entre 2 y 24 horas | Funcional | Must have |
| RF-16 | No aplicar devolución si cancelación < 2 horas | Funcional | Must have |
| RF-17 | Registrar cancelación y cambiar estado a Cancelada | Funcional | Must have |
| RF-18 | Liberar turno de reserva cancelada | Funcional | Must have |
| RF-19 | Instruir devolución al intermediario de cobro | Funcional | Must have |
| RF-20 | Cancelar sin devolución si la reserva no fue pagada | Funcional | Must have |
| RF-21 | Rechazar cancelación de reserva en estado terminal | Funcional | Must have |
| RF-22 | Rechazar cancelación de reserva con turno ya iniciado | Funcional | Must have |
| RF-23 | Marcar devolución como pendiente si el intermediario no está disponible | Funcional | Must have |

---

## RF-13 — Calcular tiempo restante y determinar política de cancelación

| Campo | Valor |
|---|---|
| **# Requisito** | RF-13 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-02 (paso 2) |
| **Descripción** | El sistema deberá calcular el tiempo restante entre el momento de la solicitud de cancelación y el inicio del turno, y determinar la política de cancelación aplicable según los umbrales configurados por el complejo. |
| **Justificación** | El cálculo del tiempo restante es la base para determinar si corresponde devolución total, parcial o ninguna (BR-21, BR-22, BR-23). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Dada una reserva con inicio en `T`, la política determinada es: "libre" si `T - ahora > 24 h`; "parcial" si `2 h ≤ T - ahora ≤ 24 h`; "sin devolución" si `T - ahora < 2 h`. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-17 |
| **Conflictos** | — |
| **Material de soporte** | BR-21, BR-22, BR-23, BR-27, PUC-02 paso 2 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-14 — Aplicar devolución del 100% si cancelación con más de 24 horas

| Campo | Valor |
|---|---|
| **# Requisito** | RF-14 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-02 (paso 3, paso 6) |
| **Descripción** | El sistema deberá calcular el monto de devolución como el 100% del pago realizado cuando la cancelación se efectúe con más de 24 horas de anticipación al inicio del turno. |
| **Justificación** | Cancelaciones con suficiente anticipación no perjudican al complejo; el jugador merece reembolso completo (BR-21). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Una cancelación con `horaInicio - ahora > 24 h` produce una instrucción de devolución igual al 100% del monto pagado. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-13, RF-19 |
| **Conflictos** | RF-15, RF-16 |
| **Material de soporte** | BR-21, PUC-02 paso 2 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-15 — Aplicar devolución del 50% si cancelación entre 2 y 24 horas

| Campo | Valor |
|---|---|
| **# Requisito** | RF-15 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-02 (paso 3, paso 6) |
| **Descripción** | El sistema deberá calcular el monto de devolución como el 50% del pago realizado cuando la cancelación se efectúe entre 2 y 24 horas de anticipación al inicio del turno. |
| **Justificación** | Penalización parcial como compensación al complejo por el riesgo de no poder reasignar el turno (BR-22). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Una cancelación con `2 h ≤ horaInicio - ahora ≤ 24 h` produce una instrucción de devolución igual al 50% del monto pagado. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-13, RF-19 |
| **Conflictos** | RF-14, RF-16 |
| **Material de soporte** | BR-22, PUC-02 paso 2 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-16 — No aplicar devolución si cancelación con menos de 2 horas

| Campo | Valor |
|---|---|
| **# Requisito** | RF-16 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-02 (paso 3) |
| **Descripción** | El sistema deberá calcular el monto de devolución como cero cuando la cancelación se efectúe con menos de 2 horas de anticipación al inicio del turno. |
| **Justificación** | A tan poco tiempo del inicio, el complejo no puede reasignar el turno; la retención es justa (BR-23). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Una cancelación con `horaInicio - ahora < 2 h` produce una instrucción de devolución de $0. El monto pagado es retenido por el complejo. |
| **Satisfacción del interesado** | 3 |
| **Insatisfacción del interesado** | 3 |
| **Prioridad** | Must have |
| **Dependencias** | RF-13 |
| **Conflictos** | RF-14, RF-15 |
| **Material de soporte** | BR-23, PUC-02 paso 2 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-17 — Registrar cancelación y cambiar estado a Cancelada

| Campo | Valor |
|---|---|
| **# Requisito** | RF-17 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-02 (paso 5) |
| **Descripción** | El sistema deberá cambiar el estado de la reserva a Cancelada y registrar el evento de cancelación, incluyendo actor, marca de tiempo y motivo, cuando el jugador confirme la cancelación. |
| **Justificación** | El cambio de estado es la acción central de este caso de uso; sin él la reserva seguiría activa y el turno bloqueado (BR-17, BR-18). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras la cancelación, la reserva tiene estado "Cancelada" y el log de auditoría contiene un registro con el actor, la marca de tiempo y el estado anterior "Pendiente" o "Confirmada". |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-21, RF-22 |
| **Conflictos** | — |
| **Material de soporte** | BR-17, BR-18, PUC-02 paso 5 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-18 — Liberar turno de reserva cancelada

| Campo | Valor |
|---|---|
| **# Requisito** | RF-18 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-02 (paso 5) |
| **Descripción** | El sistema deberá hacer disponible para nuevas reservas el turno de una reserva que haya sido cancelada. |
| **Justificación** | La cancelación sin liberación del turno resultaría en disponibilidad incorrectamente bloqueada para otros jugadores. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Inmediatamente después de cancelar una reserva, el turno correspondiente aparece como disponible al consultar la disponibilidad de la cancha (RF-01). |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-17 |
| **Conflictos** | — |
| **Material de soporte** | PUC-02 paso 5 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-19 — Instruir devolución al intermediario de cobro

| Campo | Valor |
|---|---|
| **# Requisito** | RF-19 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-02 (paso 6) |
| **Descripción** | El sistema deberá enviar al intermediario de cobro la instrucción de devolución con el monto calculado según la política aplicable, una vez registrada la cancelación. |
| **Justificación** | La devolución económica al jugador es una consecuencia directa de la cancelación; el producto coordina pero no ejecuta la transacción financiera. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al cancelar una reserva pagada con devolución parcial o total, el intermediario de cobro recibe una instrucción de devolución con el monto correcto. No se envía instrucción de devolución cuando el monto es cero (RF-16). |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-13, RF-14, RF-15, RF-17 |
| **Conflictos** | — |
| **Material de soporte** | BR-21, BR-22, PUC-02 paso 6 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-20 — Cancelar sin devolución si la reserva no fue pagada

| Campo | Valor |
|---|---|
| **# Requisito** | RF-20 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-02 (A1.1) |
| **Descripción** | El sistema deberá cancelar una reserva en estado Pendiente sin generar ninguna instrucción de devolución al intermediario de cobro, liberando el turno directamente. |
| **Justificación** | Si no hubo pago, no existe monto a devolver; la cancelación es solo administrativa. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al cancelar una reserva en estado Pendiente (sin pago), el estado pasa a Cancelada y el turno queda libre sin que se genere ninguna instrucción de devolución. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-17, RF-18 |
| **Conflictos** | — |
| **Material de soporte** | PUC-02 A1.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-21 — Rechazar cancelación de reserva en estado terminal

| Campo | Valor |
|---|---|
| **# Requisito** | RF-21 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-02 (E1.1) |
| **Descripción** | El sistema deberá rechazar toda solicitud de cancelación sobre una reserva en estado Cancelada, Expirada, Finalizada o No-show, informando al jugador el motivo. |
| **Justificación** | Los estados terminales son inmutables; permitir cancelar una reserva ya cancelada o finalizada generaría inconsistencia (BR-19). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un intento de cancelar una reserva en estado Cancelada, Expirada, Finalizada o No-show es rechazado con el mensaje "La reserva no puede cancelarse en su estado actual". |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | BR-19, PUC-02 E1.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-22 — Rechazar cancelación con turno ya iniciado

| Campo | Valor |
|---|---|
| **# Requisito** | RF-22 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-02 (E1.2) |
| **Descripción** | El sistema deberá rechazar toda solicitud de cancelación de un jugador sobre una reserva cuyo turno ya haya comenzado. |
| **Justificación** | Una vez iniciado el turno no es posible cancelarlo; el servicio ya está siendo prestado (BR-26). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un intento de cancelar una reserva con `horaInicio ≤ ahora` es rechazado con el mensaje "El plazo de cancelación expiró". |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | BR-26, PUC-02 E1.2 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-23 — Marcar devolución como pendiente si el intermediario no está disponible

| Campo | Valor |
|---|---|
| **# Requisito** | RF-23 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-02 (E6.1) |
| **Descripción** | El sistema deberá registrar la cancelación y marcar la devolución como pendiente de resolución cuando el intermediario de cobro no pueda procesar la devolución en el momento de la solicitud. |
| **Justificación** | La cancelación debe quedar registrada aun cuando el intermediario falle, para no obligar al jugador a reintentar la cancelación. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Cuando el intermediario de cobro no responde o devuelve error, la reserva pasa a estado Cancelada y existe un registro de devolución pendiente asociado a esa reserva. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-17, RF-19 |
| **Conflictos** | — |
| **Material de soporte** | PUC-02 E6.1 |
| **Historial** | 2026-05-08 — Creado |
