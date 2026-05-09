# Requisitos Atómicos — PUC-11: Consultar historial de reservas

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-09
**PUC origen:** PUC-11 — Consultar historial de reservas
**BUC origen:** BUC-01, BUC-02, BUC-03, BUC-05

---

## Índice

| ID | Descripción breve | Tipo | Prioridad |
|---|---|---|---|
| RF-68 | Mostrar historial de reservas del usuario autenticado con sus estados | Funcional | Must have |
| RF-69 | Mostrar historial de reservas del complejo al administrador | Funcional | Must have |
| RF-70 | Filtrar historial por estado de reserva | Funcional | Must have |
| RF-71 | Filtrar historial por rango de fechas | Funcional | Must have |
| RF-72 | Filtrar historial del complejo por cancha | Funcional | Must have |
| RF-73 | Rechazar consulta de historial sin permisos suficientes | Funcional | Must have |
| RF-74 | Mostrar detalle de una reserva individual desde el historial | Funcional | Must have |

---

## RF-68 — Mostrar historial de reservas del usuario autenticado

| Campo | Valor |
|---|---|
| **# Requisito** | RF-68 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-11 (pasos 3–5, actor: Usuario) |
| **Descripción** | El sistema deberá mostrar al usuario autenticado el listado de todas sus reservas en cualquier estado (Pendiente, Confirmada, Cancelada, Expirada, Finalizada, No-show), incluyendo para cada una: complejo, cancha, fecha, franja horaria, estado y monto. |
| **Justificación** | El usuario necesita consultar el estado de sus turnos en cualquier momento para planificar su asistencia y gestionar cancelaciones; sin este historial la experiencia es opaca. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | El historial del usuario muestra únicamente reservas asociadas a su cuenta. Las reservas de otros usuarios no aparecen, aun si se manipulan los identificadores de la solicitud (BR-10). Los seis estados válidos están representados correctamente (BR-14). |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | BR-10, BR-14, PUC-11 pasos 3–5, US-27 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-69 — Mostrar historial de reservas del complejo al administrador

| Campo | Valor |
|---|---|
| **# Requisito** | RF-69 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-11 (pasos 3–5, actor: Administrador del complejo) |
| **Descripción** | El sistema deberá mostrar al administrador autenticado el historial de reservas de las canchas de su complejo, incluyendo para cada reserva: usuario asociado, cancha, fecha, franja horaria, estado y monto. |
| **Justificación** | El administrador necesita consultar el historial de reservas de su complejo para analizar la ocupación, gestionar disputas y planificar la operación. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | El historial del administrador incluye únicamente reservas asociadas a canchas de su propio complejo. Reservas de otros complejos no aparecen, aun si se manipulan los identificadores (BR-10, BR-11). |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-36 |
| **Conflictos** | — |
| **Material de soporte** | BR-10, BR-11, PUC-11 pasos 3–5, US-28 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-70 — Filtrar historial por estado de reserva

| Campo | Valor |
|---|---|
| **# Requisito** | RF-70 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-11 (A2.1) |
| **Descripción** | El sistema deberá permitir al actor filtrar el historial de reservas por uno o más estados (Pendiente, Confirmada, Cancelada, Expirada, Finalizada, No-show), mostrando únicamente las reservas que coincidan con el estado seleccionado. |
| **Justificación** | Un usuario o administrador que solo desea ver sus reservas activas o sus reservas canceladas no debería tener que recorrer el historial completo; el filtro reduce el esfuerzo cognitivo. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al aplicar el filtro "Confirmada", el resultado incluye únicamente reservas en ese estado. Al aplicar múltiples estados, el resultado incluye las reservas que coincidan con alguno de ellos. Sin filtro, se muestran todos los estados. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 3 |
| **Prioridad** | Must have |
| **Dependencias** | RF-68, RF-69 |
| **Conflictos** | — |
| **Material de soporte** | BR-14, PUC-11 A2.1, US-27, US-28 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-71 — Filtrar historial por rango de fechas

| Campo | Valor |
|---|---|
| **# Requisito** | RF-71 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-11 (A2.2) |
| **Descripción** | El sistema deberá permitir al actor filtrar el historial de reservas estableciendo una fecha de inicio y una fecha de fin, mostrando únicamente las reservas cuya fecha de turno esté comprendida dentro del rango indicado. |
| **Justificación** | Consultar reservas de un período específico es la necesidad más común tanto para el usuario (ver turnos del mes) como para el administrador (analizar ocupación semanal). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al filtrar por el rango 2026-06-01 a 2026-06-30, el resultado incluye únicamente reservas con fecha de turno dentro de ese rango. Reservas fuera del rango no aparecen en el resultado. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-68, RF-69 |
| **Conflictos** | — |
| **Material de soporte** | PUC-11 A2.2, US-27, US-28 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-72 — Filtrar historial del complejo por cancha

| Campo | Valor |
|---|---|
| **# Requisito** | RF-72 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-11 (A2.3, actor: Administrador del complejo) |
| **Descripción** | El sistema deberá permitir al administrador filtrar el historial de reservas de su complejo por cancha específica, mostrando únicamente las reservas asociadas a esa cancha. |
| **Justificación** | El administrador necesita analizar el rendimiento individual de cada cancha (ocupación, inasistencias, cancelaciones) para tomar decisiones operativas informadas. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al filtrar por una cancha específica, el resultado incluye únicamente reservas de esa cancha dentro del complejo del administrador. Canchas de otros complejos no son seleccionables (BR-11). |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 3 |
| **Prioridad** | Must have |
| **Dependencias** | RF-69 |
| **Conflictos** | — |
| **Material de soporte** | BR-11, PUC-11 A2.3, US-28 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-73 — Rechazar consulta de historial sin permisos suficientes

| Campo | Valor |
|---|---|
| **# Requisito** | RF-73 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-11 (E4.1) |
| **Descripción** | El sistema deberá rechazar toda solicitud de consulta del historial de reservas cuando el actor autenticado no tenga permisos sobre la información solicitada, informando el motivo del rechazo sin revelar datos de otros usuarios o complejos. |
| **Justificación** | El acceso al historial de reservas contiene datos personales y comerciales sensibles; un acceso no autorizado violaría el aislamiento de datos del modelo multitenant (BR-10, BR-11). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un usuario que intente consultar el historial de otro usuario recibe rechazo con error de permisos y no obtiene ningún dato. Un administrador que intente consultar el historial de otro complejo recibe rechazo y no obtiene ningún dato (BR-10, BR-11). |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-68, RF-69 |
| **Conflictos** | — |
| **Material de soporte** | BR-10, BR-11, BR-12, BR-17, PUC-11 E4.1, US-27, US-28 |
| **Historial** | 2026-05-09 — Creado |

---

## RF-74 — Mostrar detalle de una reserva individual desde el historial

| Campo | Valor |
|---|---|
| **# Requisito** | RF-74 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-11 (paso 6) |
| **Descripción** | El sistema deberá mostrar al actor el detalle completo de una reserva seleccionada desde el historial, incluyendo: identificador de reserva, complejo, cancha, fecha, franja horaria, duración, estado actual, historial de estados y monto. |
| **Justificación** | El listado del historial muestra datos resumidos; el detalle permite al usuario verificar información específica de una reserva y al administrador resolver consultas o disputas con documentación completa. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al seleccionar una reserva del historial, el sistema muestra todos los campos indicados en la descripción. El actor solo puede consultar el detalle de reservas a las que tiene acceso (RF-73). |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-68, RF-69, RF-73 |
| **Conflictos** | — |
| **Material de soporte** | PUC-11 paso 6, US-27, US-28 |
| **Historial** | 2026-05-09 — Creado |
