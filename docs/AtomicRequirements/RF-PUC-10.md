# Requisitos Atómicos — PUC-10: Administrar horarios de operación

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-09
**PUC origen:** PUC-10 — Administrar horarios de operación
**BUC origen:** —

---

## Índice

| ID | Descripción breve | Tipo | Prioridad |
|---|---|---|---|
| RF-64 | Configurar días y franjas horarias operativas de una cancha | Funcional | Must have |
| RF-65 | Actualizar disponibilidad futura de turnos al modificar horarios | Funcional | Must have |
| RF-66 | Rechazar horarios superpuestos o con rangos inválidos | Funcional | Must have |
| RF-67 | Rechazar modificación de horario que afecta reservas confirmadas | Funcional | Must have |

---

## RF-64 — Configurar días y franjas horarias operativas de una cancha

| Campo | Valor |
|---|---|
| **# Requisito** | RF-64 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-10 (pasos 2–5) |
| **Descripción** | El sistema deberá permitir al administrador definir los días de la semana habilitados y las franjas horarias de operación para cada cancha de su complejo, registrando la configuración de forma independiente para cada complejo. |
| **Justificación** | Sin horarios configurados, la cancha no puede generar turnos disponibles para reservas; los horarios son la base de toda la oferta del complejo (BR-06, BR-13). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras configurar los horarios, las franjas habilitadas aparecen como disponibles en la vista de disponibilidad (RF-52). Las franjas fuera del horario configurado no son ofrecidas a los usuarios. La configuración de un complejo no afecta la de otro (BR-13). |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-58, RF-35 |
| **Conflictos** | — |
| **Material de soporte** | BR-06, BR-13, PUC-10 pasos 2–5, US-20 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-65 — Actualizar disponibilidad futura de turnos al modificar horarios

| Campo | Valor |
|---|---|
| **# Requisito** | RF-65 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-10 (paso 6) |
| **Descripción** | El sistema deberá recalcular y actualizar la disponibilidad futura de turnos de la cancha inmediatamente después de confirmar una modificación en sus horarios de operación, de modo que los nuevos horarios sean los únicos visibles para nuevas reservas. |
| **Justificación** | Una modificación de horarios que no se refleja de inmediato en la disponibilidad permitiría que los usuarios reserven en franjas ya no operativas, generando conflictos con el complejo. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Inmediatamente después de guardar la modificación de horario, la vista de disponibilidad (RF-52) refleja solo las franjas incluidas en el nuevo horario. Las franjas eliminadas ya no aparecen disponibles. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-64, RF-52 |
| **Conflictos** | — |
| **Material de soporte** | PUC-10 paso 6, US-20 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-66 — Rechazar horarios superpuestos o con rangos inválidos

| Campo | Valor |
|---|---|
| **# Requisito** | RF-66 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-10 (E3.1) |
| **Descripción** | El sistema deberá rechazar una configuración de horarios cuando las franjas ingresadas se superpongan entre sí o cuando los valores de hora de inicio y fin sean inválidos (hora de fin no posterior a hora de inicio, valores fuera del rango 00:00–23:59), informando al administrador el conflicto específico. |
| **Justificación** | Franjas superpuestas o con rangos inválidos generarían slots inconsistentes, haciendo imposible determinar correctamente la disponibilidad de la cancha. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un intento de guardar dos franjas que se superponen es rechazado con el mensaje "Los horarios se superponen". Un intento con hora de fin anterior a hora de inicio es rechazado. Una configuración sin superposiciones y con rangos válidos no es rechazada por este criterio. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-64 |
| **Conflictos** | — |
| **Material de soporte** | PUC-10 E3.1, US-20 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-67 — Rechazar modificación de horario que afecta reservas confirmadas

| Campo | Valor |
|---|---|
| **# Requisito** | RF-67 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-10 (E3.2) |
| **Descripción** | El sistema deberá rechazar una modificación de horarios de operación cuando existan reservas en estado Confirmada cuyo turno quede fuera del nuevo horario propuesto, informando al administrador qué reservas están afectadas y no aplicando el cambio. |
| **Justificación** | Aplicar una reducción de horario que invalide turnos ya confirmados incumpliría compromisos con los usuarios; el administrador debe resolver las reservas afectadas antes de modificar el horario. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Si el nuevo horario excluye una franja con al menos una reserva Confirmada futura, el sistema rechaza la modificación y lista las reservas afectadas. Solo cuando no existan reservas incompatibles el sistema aplica el cambio. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-64, RF-65 |
| **Conflictos** | — |
| **Material de soporte** | PUC-10 E3.2, US-20 |
| **Historial** | 2026-05-09 — Creado |
