# Requisitos Atómicos — PUC-08: Ver disponibilidad de canchas

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-09
**PUC origen:** PUC-08 — Ver disponibilidad de canchas
**BUC origen:** BUC-05 — Consultar agenda de reservas

---

## Índice

| ID | Descripción breve | Tipo | Prioridad |
|---|---|---|---|
| RF-52 | Mostrar turnos disponibles y ocupados de un complejo por fecha | Funcional | Must have |
| RF-53 | Excluir de la vista turnos fuera del horario operativo | Funcional | Must have |
| RF-54 | Mostrar todos los turnos operativos como disponibles si no hay reservas | Funcional | Must have |
| RF-55 | Permitir filtrar disponibilidad por tipo de cancha | Funcional | Should have |
| RF-56 | Rechazar consulta de disponibilidad con fecha inválida | Funcional | Must have |
| RF-57 | Informar ausencia de canchas habilitadas para la fecha consultada | Funcional | Must have |

---

## RF-52 — Mostrar turnos disponibles y ocupados de un complejo por fecha

| Campo | Valor |
|---|---|
| **# Requisito** | RF-52 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-08 (pasos 3–5) |
| **Descripción** | El sistema deberá consultar y mostrar el estado de disponibilidad de cada franja horaria de las canchas habilitadas de un complejo para la fecha indicada, distinguiendo las franjas disponibles de las ocupadas. |
| **Justificación** | El usuario necesita conocer la disponibilidad real antes de seleccionar un turno; sin esta vista no puede iniciar el proceso de reserva de manera informada. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Dado un complejo con canchas configuradas y reservas activas, la vista muestra correctamente las franjas libres y las ocupadas para la fecha consultada. Las franjas con reservas en estado Pendiente o Confirmada aparecen como ocupadas (BR-05). |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-63 (horarios de operación configurados), RF-35 (complejo registrado) |
| **Conflictos** | — |
| **Material de soporte** | BR-05, BR-06, PUC-08 pasos 3–5, US-05 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-53 — Excluir de la vista turnos fuera del horario operativo

| Campo | Valor |
|---|---|
| **# Requisito** | RF-53 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-08 (paso 4) |
| **Descripción** | El sistema deberá excluir de la vista de disponibilidad toda franja horaria que no esté comprendida dentro del horario de operación configurado por el complejo para el día consultado. |
| **Justificación** | Solo los turnos dentro del horario operativo habilitado por el complejo son válidos para reservar; mostrar franjas fuera de ese rango induciría al usuario a error (BR-06). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Dada una cancha con horario operativo de 8:00 a 22:00, ninguna franja anterior a las 8:00 ni posterior a las 22:00 aparece en la vista de disponibilidad. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-63 |
| **Conflictos** | — |
| **Material de soporte** | BR-06, PUC-08 paso 4, US-05 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-54 — Mostrar todos los turnos operativos como disponibles si no hay reservas

| Campo | Valor |
|---|---|
| **# Requisito** | RF-54 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-08 (A5.1) |
| **Descripción** | El sistema deberá mostrar todas las franjas dentro del horario operativo como disponibles cuando no exista ninguna reserva registrada para la cancha y fecha consultadas. |
| **Justificación** | La ausencia de reservas indica disponibilidad total; el sistema no debe inferir ninguna restricción adicional donde no hay datos de ocupación. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Para una cancha sin reservas en la fecha consultada, todas las franjas del horario operativo aparecen con estado disponible. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-52, RF-53 |
| **Conflictos** | — |
| **Material de soporte** | PUC-08 A5.1, US-05 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-55 — Permitir filtrar disponibilidad por tipo de cancha

| Campo | Valor |
|---|---|
| **# Requisito** | RF-55 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-08 (A1.1) |
| **Descripción** | El sistema deberá permitir al usuario aplicar un filtro por tipo de cancha al consultar la disponibilidad, mostrando únicamente las canchas que coincidan con el tipo seleccionado. |
| **Justificación** | Un usuario que busca un tipo específico de superficie o formato de juego necesita filtrar la oferta para evitar resultados irrelevantes. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al aplicar el filtro por tipo de cancha, el resultado incluye únicamente canchas del tipo seleccionado y excluye el resto. Sin filtro, se muestran todas las canchas habilitadas. |
| **Satisfacción del interesado** | 3 |
| **Insatisfacción del interesado** | 2 |
| **Prioridad** | Should have |
| **Dependencias** | RF-52 |
| **Conflictos** | — |
| **Material de soporte** | PUC-08 A1.1, US-05 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-56 — Rechazar consulta de disponibilidad con fecha inválida

| Campo | Valor |
|---|---|
| **# Requisito** | RF-56 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-08 (E2.1) |
| **Descripción** | El sistema deberá rechazar una solicitud de consulta de disponibilidad cuando la fecha ingresada sea inválida (fecha pasada, formato incorrecto o fuera del rango permitido), informando al usuario y solicitando una fecha válida. |
| **Justificación** | Una fecha inválida haría que la consulta devuelva resultados incorrectos o genere un error en el sistema; la validación debe ocurrir antes de cualquier consulta. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Una solicitud con fecha en formato incorrecto o anterior a la fecha actual es rechazada con un mensaje que indica el motivo. Una solicitud con fecha futura válida no es rechazada por este criterio. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | PUC-08 E2.1, US-05 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-57 — Informar ausencia de canchas habilitadas para la fecha consultada

| Campo | Valor |
|---|---|
| **# Requisito** | RF-57 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-08 (E3.1, E3.2) |
| **Descripción** | El sistema deberá informar al usuario que no existe disponibilidad cuando el complejo no tenga canchas habilitadas o no tenga turnos libres para los criterios consultados, permitiendo que el usuario realice una nueva consulta. |
| **Justificación** | Sin esta información explícita, el usuario podría interpretar incorrectamente una lista vacía como un error del sistema en lugar de ausencia real de disponibilidad. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Cuando un complejo no tiene canchas habilitadas para la fecha consultada, el sistema muestra un mensaje de "sin disponibilidad" en lugar de una lista vacía sin contexto. El usuario puede iniciar una nueva consulta sin necesidad de recargar la vista. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 3 |
| **Prioridad** | Must have |
| **Dependencias** | RF-52 |
| **Conflictos** | — |
| **Material de soporte** | BR-06, PUC-08 E3.1, E3.2, US-05 |
| **Historial** | 2026-05-09 — Creado |
