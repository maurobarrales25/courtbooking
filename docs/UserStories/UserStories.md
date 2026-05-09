# Historias de Usuario — CanchasYa!

**Proyecto:** CanchasYa!
**Versión:** 2.0
**Fecha:** 2026-05-09
**Estado:** Borrador
**Metodología:** Cohn (2004) — *User Stories Applied*; Robertson & Robertson (2012)

> Granularidad: entre un PUC y un requisito atómico.
> Estimación en semanas ideales de desarrollo (1 = simple, 2 = media, 3 = compleja).
> Todas las historias son verificables mediante sus criterios de aceptación.

---

## Índice de Épicas

| Épica | Nombre | PUC(s) origen |
|---|---|---|
| [É-01](#épica-1--acceso-al-servicio) | Acceso al servicio | PUC-04 |
| [É-02](#épica-2--exploración-y-disponibilidad) | Exploración y disponibilidad | PUC-08 |
| [É-03](#épica-3--reserva-de-turno) | Reserva de turno | PUC-01, PUC-06 |
| [É-04](#épica-4--cancelación-por-el-usuario) | Cancelación por el usuario | PUC-02 |
| [É-05](#épica-5--notificaciones-al-usuario) | Notificaciones al usuario | PUC-01, PUC-02, PUC-03 |
| [É-06](#épica-6--incorporación-del-complejo) | Incorporación del complejo | PUC-05 |
| [É-07](#épica-7--gestión-de-canchas-y-horarios) | Gestión de canchas y horarios | PUC-09, PUC-10 |
| [É-08](#épica-8--gestión-de-agenda-del-complejo) | Gestión de agenda del complejo | PUC-03, PUC-07 |
| [É-09](#épica-9--historial-de-reservas) | Historial de reservas | PUC-11 |

---

## Épica 1 — Acceso al servicio

**PUC origen:** PUC-04 — Registrar un usuario
**Descripción:** El usuario puede registrarse, autenticarse y gestionar su cuenta en el producto.

---

### US-01 — Registro con proveedor de identidad externo

Como persona interesada,
quiero registrarme usando mi cuenta de un proveedor de identidad externo,
para que pueda acceder al servicio sin crear una contraseña adicional.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-04 (A1.1) |
| **BUC origen** | PUC-04  |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El producto ofrece al menos una opción de proveedor externo en el formulario de registro.
- Si el correo del proveedor no está registrado, el sistema crea la cuenta y confirma el registro.
- Si el correo ya está registrado, el sistema asocia la sesión a la cuenta existente sin crear duplicados (PUC-04 E2.1).

---

### US-02 — Inicio y cierre de sesión

Como usuario registrado,
quiero iniciar y cerrar sesión en el producto,
para que pueda acceder a mis reservas y proteger mi cuenta cuando termino.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-04 |
| **BUC origen** | PUC-04  |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El usuario puede iniciar sesión con sus credenciales válidas.
- Si las credenciales son incorrectas, el sistema muestra un error y no concede acceso.
- El usuario puede cerrar sesión desde cualquier pantalla; tras hacerlo no puede acceder a sus datos sin volver a autenticarse.

---

### US-03 — Edición de perfil

Como usuario activo quiero consultar y actualizar mis datos de contacto,
para que mi información esté siempre vigente en el sistema.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-04 |
| **BUC origen** | PUC-04  |
| **Prioridad** | Should have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El usuario puede ver su nombre, correo y teléfono desde su perfil.
- El usuario puede editar nombre y teléfono; el correo requiere verificación previa si se cambia.
- Los cambios se guardan y se reflejan de inmediato en el perfil.

---

## Épica 2 — Exploración y disponibilidad

**PUC origen:** PUC-08 — Ver disponibilidad de canchas
**Descripción:** El usuario puede explorar complejos y consultar la disponibilidad de canchas antes de reservar.

---

### US-04 — Consulta de complejos disponibles

Como usuario, quiero ver los complejos deportivos activos con sus canchas y características,
para que pueda elegir dónde quiero jugar.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (paso 1), PUC-05 (paso 8) |
| **BUC origen** | BUC-01 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El listado muestra únicamente complejos activos con al menos una cancha habilitada.
- Cada complejo muestra nombre, ubicación y cantidad de canchas disponibles.
- Las canchas deshabilitadas no aparecen en la oferta visible al usuario (PUC-09 A1.1).
- El listado no expone datos de otros tenants (BR-10).

---

### US-05 — Ver disponibilidad de canchas por fecha

Como usuario, quiero consultar los turnos disponibles de las canchas de un complejo para una fecha determinada,
para que pueda elegir el horario que más me convenga antes de reservar.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-08 |
| **BUC origen** | BUC-05 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El usuario selecciona complejo y fecha; el sistema muestra turnos disponibles y ocupados (PUC-08 pasos 2–5).
- Solo se muestran franjas dentro del horario de operación configurado por el complejo (BR-06).
- Los turnos con reservas en estado Pendiente o Confirmada no aparecen como disponibles (BR-05).
- Si la fecha ingresada es inválida, el sistema informa y solicita una fecha válida (PUC-08 E2.1).
- Si el complejo no tiene canchas habilitadas para esa fecha, el sistema informa que no existe disponibilidad (PUC-08 E3.1, BR-06).
- Si no existe ninguna reserva registrada para la fecha consultada, todos los turnos del horario operativo se muestran disponibles (PUC-08 A5.1).
- El usuario puede filtrar por tipo de cancha (PUC-08 A1.1).
- El usuario puede seleccionar un turno disponible para iniciar una reserva (PUC-08 paso 6).

---

## Épica 3 — Reserva de turno

**PUC origen:** PUC-01, PUC-06
**Descripción:** El usuario puede seleccionar, reservar y pagar un turno.

---

### US-06 — Reserva provisional de turno

Como usuario,
quiero seleccionar una cancha, fecha, franja horaria y duración para que el turno quede reservado provisionalmente a mi nombre para que pueda completar el pago sin que otro usuario tome el mismo horario.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (pasos 3–5) |
| **BUC origen** | BUC-01 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El usuario puede seleccionar franja y duración en múltiplos de 1 hora (BR-03).
- El sistema rechaza reservas con más de 30 días de anticipación (BR-01).
- El sistema rechaza duraciones menores a 1 hora (BR-02).
- El sistema rechaza duraciones que no sean múltiplos exactos de 60 minutos (BR-03).
- El sistema rechaza solicitudes cuya hora de fin no sea estrictamente posterior a la de inicio (BR-04).
- El sistema rechaza franjas fuera del horario operativo del complejo (BR-06).
- Si el usuario ya tiene 5 reservas activas (Pendiente o Confirmada), el sistema rechaza la solicitud (BR-09).
- Si la franja está libre, el sistema la bloquea provisionalmente durante 10 minutos e inicia el tiempo límite de pago (BR-07).
- Si otro usuario tomó la franja en el intervalo, el sistema informa la no disponibilidad y muestra las franjas libres actualizadas (BR-05).

---

### US-07 — Visualización del resumen de reserva

Como usuario quiero ver un resumen con los datos de mi turno y el monto a pagar antes de confirmar,
para que pueda verificar que la información es correcta antes de abonar.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (paso 6) |
| **BUC origen** | BUC-01 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El resumen muestra: complejo, cancha, fecha, franja horaria, duración y monto a pagar.
- El resumen incluye el tiempo restante para completar el pago antes de que la reserva provisional expire (BR-07).
- El usuario puede volver atrás y elegir otra franja sin perder el proceso.

---

### US-08 — Pago de turno con medio de cobro en línea

Como usuario, quiero pagar mi reserva provisional usando un medio de cobro en línea disponible, para que el turno quede confirmado a mi nombre sin necesidad de presentarme al complejo.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-06 |
| **BUC origen** | BUC-04 |
| **Prioridad** | Should have |
| **Estimación** | 3 semanas |

**Criterios de aceptación:**
- El producto presenta las opciones de cobro habilitadas por el complejo (PUC-06 paso 2).
- El usuario puede completar el pago mientras la reserva provisional esté vigente.
- La reserva no pasa a Confirmada hasta que el intermediario de cobro notifique la aprobación (BR-25).
- Si el pago es aprobado, la reserva pasa a Confirmada y el usuario recibe confirmación (BR-14).
- Si el medio de cobro es rechazado, el sistema informa el motivo y permite intentar con otro mientras la reserva provisional esté vigente (PUC-06 E4.1).
- Si el intermediario reporta error técnico, el sistema mantiene la reserva provisional activa hasta el vencimiento (PUC-06 E4.2).
- Si los 10 minutos expiran antes de completar el pago, la reserva pasa a Expirada y el turno queda libre (BR-08, PUC-06 E3.1).

---

### US-09 — Confirmación sin cobro anticipado

Como usuario en un complejo que no requiere cobro anticipado, quiero que mi reserva quede confirmada directamente al seleccionar el turno, para que pueda asegurar el uso de la cancha y pagar al presentarme al complejo.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (A7.2) |
| **BUC origen** | BUC-01 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- Si el complejo no tiene cobro anticipado habilitado, la reserva pasa directamente a Confirmada tras la selección del turno.
- El usuario recibe confirmación de la reserva sin pasar por el flujo de pago en línea.
- El turno queda asignado y el complejo recibe la notificación de la nueva reserva (PUC-01 paso 8).

---

## Épica 4 — Cancelación por el usuario

**PUC origen:** PUC-02 — Usuario cancela una reserva
**Descripción:** El usuario puede cancelar sus reservas activas y conocer el monto de devolución antes de confirmar.

---

### US-10 — Consulta de política de cancelación antes de cancelar

Como usuario que desea cancelar una reserva,
quiero ver la política de cancelación aplicable y el monto que recibiré de devolución antes de confirmar,
para que pueda tomar la decisión con información completa.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-02 (pasos 2–3) |
| **BUC origen** | BUC-02 |
| **Prioridad** | Nice to have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El sistema muestra: tiempo restante hasta el inicio del turno, política de cancelación aplicable y monto a devolver.
- La política se calcula según las reglas configuradas por el complejo (BR-22).
- Si la anticipación es mayor a 24 horas, el sistema indica devolución del 100 % (BR-18).
- La pantalla permite confirmar la cancelación o volver atrás sin realizar cambios (PUC-02 A4.1).

---

### US-11 — Cancelación de reserva por el usuario

Como usuario, quiero cancelar una reserva activa y recibir la devolución correspondiente según la política del complejo,
para que pueda recuperar el valor abonado cuando no pueda asistir.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-02 (pasos 4–7) |
| **BUC origen** | BUC-02 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El usuario puede cancelar reservas en estado Pendiente o Confirmada cuyo inicio aún no haya ocurrido (BR-21).
- Tras confirmar, el turno se libera y la reserva pasa a Cancelada.
- La devolución se gestiona automáticamente según la política del complejo (BR-22).
- Si la reserva estaba en estado Pendiente sin pago registrado, se cancela sin cargo.
- El sistema rechaza la cancelación si la reserva está en estado terminal (PUC-02 E1.1, BR-16).
- El sistema rechaza la cancelación si el turno ya comenzó (PUC-02 E1.2, BR-21).
- El usuario recibe notificación con el detalle de la cancelación y la devolución gestionada (PUC-02 paso 7).

---

## Épica 5 — Notificaciones al usuario

**PUC origen:** PUC-01, PUC-02, PUC-03
**Descripción:** El usuario recibe notificaciones sobre los eventos relevantes de sus reservas.

---

### US-12 — Notificación de reserva confirmada

Como usuario quiero recibir una notificación cuando mi reserva queda confirmada,
para que pueda tener constancia del turno asegurado sin necesidad de consultar el historial.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (paso 8), PUC-06 (paso 7) |
| **BUC origen** | BUC-01 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- La notificación se envía inmediatamente tras la confirmación de la reserva.
- Incluye: complejo, cancha, fecha, franja horaria y monto abonado (si aplica).

---

### US-13 — Notificación de cancelación por el complejo

Como usuario, quiero ser notificado cuando el complejo cancela una de mis reservas confirmadas, con el motivo y el detalle de la devolución íntegra,
para que pueda planificar alternativas sin tener que consultar el producto activamente.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-03 (paso 4) |
| **BUC origen** | BUC-03 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- La notificación se envía inmediatamente tras la cancelación por el complejo.
- Incluye el motivo de cancelación y confirma que se gestiona la devolución íntegra del valor abonado (BR-19).

---

### US-14 — Recordatorio de turno próximo

Como usuario, quiero recibir un recordatorio antes de mi turno,
para que no se me olvide presentarme a la cancha.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 |
| **BUC origen** | BUC-01 |
| **Prioridad** | Nice to have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El recordatorio se envía con al menos 2 horas de anticipación al inicio del turno.
- Incluye complejo, cancha, fecha y franja horaria.
- No se envía si la reserva fue cancelada o expiró antes del momento de envío.

---

## Épica 6 — Incorporación del complejo

**PUC origen:** PUC-05 — Incorporar un complejo al servicio
**Descripción:** El propietario registra su complejo como operador independiente y configura la oferta inicial.

---

### US-15 — Alta del complejo y del administrador principal

Como propietario de un complejo deportivo,
quiero registrar mi complejo en CanchasYa! y crear la cuenta del administrador principal,
para que pueda comenzar a gestionar mis reservas de forma digital.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-05 (pasos 1–4) |
| **BUC origen** | PUC-05  |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El formulario requiere: nombre del complejo, dirección, datos de contacto y datos del administrador principal.
- Si los datos son incompletos o inválidos, el sistema señala los campos a corregir (PUC-05 E1.1).
- Si el complejo ya está incorporado, el sistema rechaza el alta duplicada (PUC-05 E2.1).
- Al completar el alta, el administrador puede iniciar sesión y gestionar exclusivamente su complejo (BR-11).
- El complejo queda en un espacio de gestión aislado de los demás tenants del servicio (BR-10).

---

### US-16 — Configuración de la política de cancelación del complejo

Como administrador,
quiero definir los umbrales de cancelación libre y penalización de mi complejo dentro de los límites del servicio,
para que las devoluciones reflejen mis condiciones comerciales.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-05 (paso 7) |
| **BUC origen** | PUC-05  |
| **Prioridad** | Nice to have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El administrador puede configurar los umbrales de cancelación libre y los porcentajes de devolución aplicables (BR-22).
- El sistema rechaza configuraciones con umbral de cancelación libre inferior a 1 hora (BR-22).
- La cancelación iniciada por el complejo siempre genera devolución íntegra, independientemente de la política configurada (BR-19).
- La configuración es independiente por complejo; no afecta a otros tenants (BR-13).

---

### US-17 — Habilitación del cobro anticipado en línea

Como administrador,
quiero habilitar el cobro anticipado en línea en mi complejo,
para que los usuarios paguen el turno al momento de reservar sin necesidad de presentarse al complejo.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-05 (A7.1) |
| **BUC origen** | PUC-05  |
| **Prioridad** | Should have |
| **Estimación** | 3 semanas |

**Criterios de aceptación:**
- El administrador puede vincular las credenciales del complejo con el intermediario de cobro (PUC-05 A7.1).
- El administrador puede activar o desactivar el cobro anticipado desde la configuración del complejo.
- Con cobro anticipado habilitado, una reserva no puede pasar a Confirmada hasta que el intermediario notifique el pago aprobado (BR-25).
- Con cobro anticipado deshabilitado, las reservas se confirman directamente sin pago previo.

---

## Épica 7 — Gestión de canchas y horarios

**PUC origen:** PUC-09, PUC-10
**Descripción:** El administrador gestiona las canchas del complejo y sus horarios de operación de forma continua.

---

### US-18 — Crear y editar canchas del complejo

Como administrador,
quiero registrar nuevas canchas o modificar la información de las existentes,
para que la oferta del complejo esté siempre actualizada y reflejada correctamente en el sistema.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-09 (pasos 1–7) |
| **BUC origen** | PUC-09  |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El administrador puede crear una cancha indicando nombre, tipo y características (PUC-09 paso 1).
- El administrador puede modificar los datos de una cancha existente (PUC-09 paso 3).
- Si los datos son inválidos o incompletos, el sistema informa el error y solicita corrección (PUC-09 E3.1).
- El administrador solo puede operar sobre canchas de su propio complejo (BR-11).
- La cancha creada o modificada queda visible con los nuevos datos en el sistema tras la confirmación (PUC-09 paso 8).

---

### US-19 — Deshabilitar y reactivar canchas

Como administrador,
quiero deshabilitar una cancha temporalmente y volver a habilitarla cuando esté disponible,
para que los usuarioes no puedan reservar canchas fuera de servicio.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-09 (A1.1, A2.1) |
| **BUC origen** | PUC-09  |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El administrador puede deshabilitar una cancha habilitada; deja de mostrar disponibilidad para nuevas reservas (PUC-09 A1.1).
- El administrador puede reactivar una cancha previamente deshabilitada; vuelve a aparecer en la disponibilidad (PUC-09 A2.1).
- Si existen reservas futuras confirmadas incompatibles con la deshabilitación, el sistema informa al administrador y no aplica el cambio automáticamente (PUC-09 E4.1).
- El administrador solo puede operar sobre canchas de su propio complejo (BR-11).

---

### US-20 — Configurar horarios de operación del complejo

Como administrador,
quiero definir los días de la semana y las franjas horarias habilitadas de cada cancha,
para que los usuarioes solo puedan reservar dentro de los horarios que yo establezco.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-10 (pasos 1–8) |
| **BUC origen** | PUC-10  |
| **Prioridad** | Nice to have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El administrador puede habilitar días de la semana y franjas horarias por cancha (BR-06).
- Los cambios en horarios se reflejan en la disponibilidad futura de turnos tras la confirmación (PUC-10 paso 6).
- Si los horarios ingresados se superponen o son inválidos, el sistema informa el conflicto y solicita corrección (PUC-10 E3.1).
- Si existen reservas confirmadas incompatibles con la modificación, el sistema rechaza la actualización e informa al administrador (PUC-10 E3.2).
- Los horarios de operación son independientes por complejo y no afectan a otros tenants (BR-13).

---

### US-21 — Configurar precios por franja de cancha

Como administrador,
quiero establecer el valor de la contraprestación por franja horaria de cada cancha,
para que el precio se aplique automáticamente en todas las nuevas reservas sin intervención manual.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-05 (paso 6), PUC-10 |
| **BUC origen** | PUC-05  |
| **Prioridad** | Should have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El administrador puede definir el valor por franja horaria para cada cancha.
- El valor es un campo obligatorio; no se acepta valor cero ni negativo.
- Los cambios de precio aplican solo a nuevas reservas; no afectan reservas ya confirmadas.
- La configuración de precios es independiente por complejo; no afecta a otros tenants (BR-13).

---

## Épica 8 — Gestión de agenda del complejo

**PUC origen:** PUC-03, PUC-07
**Descripción:** El administrador gestiona las reservas activas, cancela turnos por causas operativas, ejecuta reembolsos y registra inasistencias.

---

### US-22 — Consulta de agenda del complejo

Como administrador,
quiero ver la agenda de reservas de mi complejo por día y por cancha,
para que pueda planificar la operación diaria y semanal del complejo.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-03, PUC-07 |
| **BUC origen** | BUC-03 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El administrador puede ver las reservas Confirmadas y Pendientes de cada cancha por fecha.
- La vista puede filtrarse por cancha o por día.
- Solo se muestran reservas del complejo del administrador; no puede ver datos de otros tenants (BR-10, BR-11).

---

### US-23 — Cancelación de reserva confirmada por el complejo

Como administrador,
quiero cancelar una reserva confirmada indicando el motivo y que el sistema gestione la devolución íntegra al usuario,
para que pueda resolver imprevistos operativos sin gestionar el reintegro de forma manual.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-03 (pasos 1–4) |
| **BUC origen** | BUC-03 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El administrador puede cancelar reservas en estado Confirmada de su complejo.
- El motivo de cancelación es obligatorio (PUC-03 paso 1).
- Tras la cancelación, el turno queda libre y la devolución íntegra se gestiona automáticamente (BR-19).
- Si la reserva no tenía pago registrado, se cancela sin devolución económica y el turno se libera directamente (PUC-03 A1.1).
- El usuario recibe notificación de la cancelación con el motivo (PUC-03 paso 4).
- El administrador no puede cancelar reservas de otros complejos (BR-11, PUC-03 E1.1).
- El sistema rechaza cancelar reservas en estado terminal (BR-16, PUC-03 E1.2).

---

### US-24 — Reembolso manual por el administrador

Como administrador,
quiero ejecutar un reembolso total o parcial sobre cualquier reserva sin respetar los umbrales automáticos de la política de cancelación,
para que pueda gestionar contingencias operativas, fallos técnicos o cortesía comercial según mi criterio.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-03 (BR-23) |
| **BUC origen** | BUC-03 |
| **Prioridad** | Should have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El administrador puede ejecutar un reembolso manual total o parcial sobre reservas de su complejo (BR-23).
- El sistema no aplica restricciones de tiempo ni de porcentaje a los reembolsos manuales (BR-23).
- Cada reembolso manual genera un evento de auditoría que registra el identificador del administrador que lo autorizó, la marca de tiempo y el monto (BR-23, BR-24).
- El administrador no puede ejecutar reembolsos sobre reservas de otros complejos (BR-11).

---

### US-25 — Registro de inasistencia de usuario

Como administrador,
quiero registrar la inasistencia de un usuario cuyo turno ya transcurrió sin que se presentara,
para que el estado del turno quede actualizado y el complejo conserve el valor abonado.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-07 (pasos 1–4) |
| **BUC origen** | PUC-07  |
| **Prioridad** | Should have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El administrador puede registrar inasistencia solo en reservas Confirmadas cuya franja ya inició o concluyó (PUC-07 E2.2).
- El sistema rechaza el registro si la franja aún no comenzó.
- El sistema rechaza el registro si la reserva ya está en estado terminal (PUC-07 E2.3, BR-16).
- No se procesa ninguna devolución al registrar una inasistencia (BR-20).
- La inasistencia queda registrada en el historial del usuario (PUC-07 paso 4).
- El administrador no puede registrar inasistencias en reservas de otros complejos (BR-11, PUC-07 E2.1).

---

### US-26 — Notificación al administrador de nueva reserva

Como administrador,
quiero recibir una notificación cuando un usuario confirma una reserva en mi complejo,
para que pueda mantener actualizada mi agenda sin tener que consultar el producto manualmente.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (paso 8) |
| **BUC origen** | BUC-01 |
| **Prioridad** | Should have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- La notificación se envía al administrador inmediatamente tras la confirmación de una reserva en su complejo.
- Incluye: nombre del usuario, cancha, fecha y franja horaria del turno reservado.

---

## Épica 9 — Historial de reservas

**PUC origen:** PUC-11 — Consultar historial de reservas
**Descripción:** usuarioes y administradores pueden consultar el historial de reservas con filtros por estado, fecha y cancha.

---

### US-27 — Historial de reservas del usuario

Como usuario,
quiero ver mis reservas activas y mi historial de reservas pasadas con sus estados,
para que pueda consultar el estado de mis turnos en cualquier momento.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-11 (actor: Usuario) |
| **BUC origen** | BUC-01, BUC-02 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El usuario ve sus reservas activas (Pendiente, Confirmada) y las pasadas (Cancelada, Expirada, Finalizada, No-show) (BR-14).
- Cada entrada muestra: complejo, cancha, fecha, franja, estado y monto.
- El usuario puede filtrar por estado o por rango de fechas (PUC-11 A2.1, A2.2).
- El usuario puede consultar el detalle de una reserva específica (PUC-11 paso 6).
- El usuario solo ve sus propias reservas; no puede acceder a reservas de otros usuarioes (BR-10).
- Si no hay reservas para los criterios ingresados, el sistema informa que no hay resultados (PUC-11 E3.1).

---

### US-28 — Historial de reservas del complejo

Como administrador,
quiero ver el historial de reservas de mi complejo con filtros por fecha, cancha y estado,
para que pueda analizar la ocupación y gestionar la operación con información actualizada.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-11 (actor: Administrador del complejo) |
| **BUC origen** | BUC-03, BUC-05 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El administrador puede consultar el historial de reservas de su complejo.
- Puede filtrar por estado, rango de fechas y cancha (PUC-11 A2.1, A2.2, A2.3).
- Solo se muestran reservas del complejo del administrador; no puede acceder a datos de otros tenants (BR-10, BR-11, PUC-11 E4.1).
- Si no hay reservas para los criterios ingresados, el sistema informa que no hay resultados (PUC-11 E3.1).

---

## Resumen

| ID | Historia | Épica | PUC | BUC | Prioridad | Estimación |
|---|---|---|---|---|---|---|
| US-01 | Registro con proveedor externo | É-01 | PUC-04 | — | Should have | 2 sem |
| US-02 | Inicio y cierre de sesión | É-01 | PUC-04 | — | Must have | 1 sem |
| US-03 | Edición de perfil | É-01 | PUC-04 | — | Should have | 1 sem |
| US-04 | Consulta de complejos disponibles | É-02 | PUC-01, PUC-05 | BUC-01 | Must have | 1 sem |
| US-05 | Ver disponibilidad de canchas por fecha | É-02 | PUC-08 | BUC-05 | Must have | 2 sem |
| US-06 | Reserva provisional de turno | É-03 | PUC-01 | BUC-01 | Must have | 2 sem |
| US-07 | Visualización del resumen de reserva | É-03 | PUC-01 | BUC-01 | Must have | 1 sem |
| US-08 | Pago con medio de cobro en línea | É-03 | PUC-06 | BUC-04 | Should have | 3 sem |
| US-09 | Confirmación sin cobro anticipado | É-03 | PUC-01 | BUC-01 | Must have | 1 sem |
| US-10 | Consulta de política de cancelación | É-04 | PUC-02 | BUC-02 | Must have | 1 sem |
| US-11 | Cancelación de reserva por el usuario | É-04 | PUC-02 | BUC-02 | Must have | 2 sem |
| US-12 | Notificación de reserva confirmada | É-05 | PUC-01, PUC-06 | BUC-01 | Must have | 1 sem |
| US-13 | Notificación de cancelación por el complejo | É-05 | PUC-03 | BUC-03 | Must have | 1 sem |
| US-14 | Recordatorio de turno próximo | É-05 | PUC-01 | BUC-01 | Should have | 1 sem |
| US-15 | Alta del complejo y del administrador | É-06 | PUC-05 | — | Must have | 2 sem |
| US-16 | Configuración de política de cancelación | É-06 | PUC-05 | — | Should have | 1 sem |
| US-17 | Habilitación del cobro anticipado | É-06 | PUC-05 | — | Should have | 3 sem |
| US-18 | Crear y editar canchas | É-07 | PUC-09 | — | Must have | 2 sem |
| US-19 | Deshabilitar y reactivar canchas | É-07 | PUC-09 | — | Must have | 1 sem |
| US-20 | Configurar horarios de operación | É-07 | PUC-10 | — | Must have | 2 sem |
| US-21 | Configurar precios por franja | É-07 | PUC-05, PUC-10 | — | Must have | 1 sem |
| US-21 | Consulta de agenda del complejo | É-08 | PUC-03, PUC-07 | BUC-03 | Must have | 1 sem |
| US-22 | Cancelación de reserva por el complejo | É-08 | PUC-03 | BUC-03 | Must have | 2 sem |
| US-23 | Reembolso manual por el administrador | É-08 | PUC-03 | BUC-03 | Should have | 1 sem |
| US-24 | Registro de inasistencia | É-08 | PUC-07 | — | Must have | 1 sem |
| US-25 | Notificación al administrador de nueva reserva | É-08 | PUC-01 | BUC-01 | Should have | 1 sem |
| US-26 | Historial de reservas del usuario | É-09 | PUC-11 | BUC-01, BUC-02 | Must have | 1 sem |
| US-27 | Historial de reservas del complejo | É-09 | PUC-11 | BUC-03, BUC-05 | Must have | 2 sem |



