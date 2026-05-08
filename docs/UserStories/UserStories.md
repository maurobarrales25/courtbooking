# Historias de Usuario — CanchasYa!

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-08
**Estado:** Borrador
**Fuentes:** `docs/ProductUseCases/ProductUseCases.md`, `docs/BusinessUseCases/BusinessUseCases.md`, `docs/BusinessRules/BR-Reservas.md`
**Metodología:** Cohn (2004) — *User Stories Applied*; Robertson & Robertson (2012)

> Granularidad: entre un PUC y un requisito atómico.
> Estimación en semanas ideales de desarrollo (1 = simple, 2 = media, 3 = compleja).
> Más de 3 semanas indica que la historia debe dividirse.
> Todas las historias son verificables mediante sus criterios de aceptación.

---

## Índice de Épicas

| Épica | Nombre | PUC(s) origen |
|---|---|---|
| [É-01](#épica-1--acceso-al-servicio) | Acceso al servicio | PUC-04 |
| [É-02](#épica-2--exploración-de-la-oferta) | Exploración de la oferta | PUC-01 |
| [É-03](#épica-3--reserva-de-turno) | Reserva de turno | PUC-01, PUC-06 |
| [É-04](#épica-4--cancelación-por-el-jugador) | Cancelación por el jugador | PUC-02 |
| [É-05](#épica-5--notificaciones-al-jugador) | Notificaciones al jugador | PUC-01, PUC-02, PUC-03 |
| [É-06](#épica-6--incorporación-del-complejo) | Incorporación del complejo | PUC-05 |
| [É-07](#épica-7--gestión-de-oferta-de-canchas) | Gestión de oferta de canchas | PUC-05 |
| [É-08](#épica-8--gestión-de-agenda-del-complejo) | Gestión de agenda del complejo | PUC-03, PUC-07 |

---

## Épica 1 — Acceso al servicio

**PUC origen:** PUC-04 — Adhesión de un jugador
**Descripción:** El jugador puede registrarse, autenticarse y gestionar su perfil en el producto.

---

### US-01 — Registro de jugador

Como persona interesada en reservar canchas,
quiero registrarme en CanchasYa! ingresando mi nombre, correo electrónico y contraseña,
para que pueda acceder a la oferta de complejos y realizar reservas.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-04 |
| **BUC origen** | BUC-05 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El formulario requiere nombre, correo electrónico válido y contraseña (mínimo 8 caracteres).
- Si el correo ya está registrado, el sistema muestra un mensaje de error y no crea una cuenta duplicada.
- Si los datos son válidos, el sistema crea la cuenta y notifica al jugador la confirmación de su adhesión.
- El jugador queda con sesión activa tras el registro exitoso.

---

### US-02 — Registro con proveedor de identidad externo

Como persona interesada,
quiero registrarme usando una cuenta de un proveedor de identidad externo,
para que pueda acceder sin crear una contraseña adicional.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-04 (A1.1) |
| **BUC origen** | BUC-05 (A1.1) |
| **Prioridad** | Should have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El producto ofrece al menos una opción de proveedor de identidad externo en el formulario de adhesión.
- Si los datos del proveedor son válidos y el correo no está registrado, el sistema crea la cuenta y confirma la adhesión.
- Si el correo del proveedor ya está registrado, el sistema asocia la sesión a la cuenta existente.

---

### US-03 — Inicio y cierre de sesión

Como jugador registrado,
quiero iniciar y cerrar sesión en el producto,
para que pueda acceder a mis reservas y proteger mi cuenta cuando termino.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-04 |
| **BUC origen** | BUC-05 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El jugador puede iniciar sesión con correo y contraseña válidos.
- Si las credenciales son incorrectas, el sistema muestra error y no concede acceso.
- El jugador puede cerrar sesión desde cualquier pantalla; tras hacerlo no puede acceder a sus datos sin volver a autenticarse.

---

### US-04 — Recuperación de contraseña

Como jugador que olvidó su contraseña,
quiero recuperar el acceso a mi cuenta mediante mi correo electrónico,
para que pueda seguir usando el servicio sin perder mi historial.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-04 |
| **BUC origen** | BUC-05 |
| **Prioridad** | Should have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El producto ofrece la opción de recuperación desde la pantalla de inicio de sesión.
- Si el correo está registrado, se envía un enlace de restablecimiento con expiración de 30 minutos.
- Si el correo no está registrado, el sistema no revela información sobre su existencia.
- El jugador puede establecer una nueva contraseña usando el enlace antes de su vencimiento.

---

### US-05 — Consulta y edición de perfil

Como jugador activo,
quiero consultar y actualizar mis datos de contacto,
para que mis datos personales estén siempre vigentes.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-04 |
| **BUC origen** | BUC-05 |
| **Prioridad** | Should have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El jugador puede ver su nombre, correo y teléfono desde su perfil.
- El jugador puede editar nombre y teléfono; el correo requiere verificación previa si se cambia.
- Los cambios se guardan y se reflejan de inmediato en el perfil.

---

## Épica 2 — Exploración de la oferta

**PUC origen:** PUC-01 — Reservar una cancha (pasos 1–2)
**Descripción:** El jugador puede explorar complejos y canchas disponibles antes de reservar.

---

### US-06 — Consulta de complejos disponibles

Como jugador,
quiero ver los complejos deportivos activos en Maldonado / Punta del Este con sus canchas y características,
para que pueda elegir dónde quiero jugar.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (pasos 1–2) |
| **BUC origen** | BUC-01 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El listado muestra únicamente complejos activos con al menos una cancha habilitada.
- Cada complejo muestra nombre, ubicación y cantidad de canchas disponibles.
- Las canchas en mantenimiento no aparecen en la oferta visible al jugador (BR-11).
- El listado solo incluye complejos del propio tenant; no expone datos de otros tenants (BR-13).

---

### US-07 — Consulta de disponibilidad de turnos

Como jugador,
quiero ver los turnos disponibles de una cancha para una fecha determinada,
para que pueda elegir el horario que más me convenga antes de reservar.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (paso 2) |
| **BUC origen** | BUC-01 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- Solo se muestran franjas habilitadas por el complejo para el día consultado (BR-08).
- Solo se muestran franjas con anticipación mínima de 1 hora desde el momento de consulta (BR-01).
- No se muestran fechas posteriores a 30 días desde el día actual (BR-02).
- Los turnos ya reservados (Pendiente o Confirmado) no aparecen como disponibles (BR-07).

---

## Épica 3 — Reserva de turno

**PUC origen:** PUC-01, PUC-06
**Descripción:** El jugador puede seleccionar, reservar y pagar un turno.

---

### US-08 — Selección y reserva provisional de turno

Como jugador,
quiero seleccionar una cancha, fecha, franja horaria y duración, y que el turno quede reservado provisionalmente a mi nombre,
para que pueda completar el pago sin que otro jugador lo tome.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (pasos 3–5) |
| **BUC origen** | BUC-01 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El jugador puede seleccionar la franja y la duración (múltiplos de 1 hora, entre 1 y 4 horas) (BR-03, BR-04, BR-05).
- Si la franja no cumple condiciones de anticipación o duración, el sistema informa el motivo y no avanza (BR-01, BR-02, BR-03, BR-04).
- Si el jugador ya tiene 5 reservas activas, el sistema rechaza la solicitud (BR-12).
- Si la franja está libre, el sistema la reserva provisionalmente durante 10 minutos (BR-09).
- Si otro jugador tomó la franja en el intervalo, el sistema informa la no disponibilidad y ofrece las franjas libres actualizadas (BR-07).

---

### US-09 — Visualización del resumen de reserva

Como jugador,
quiero ver un resumen con los datos de mi turno y el monto a pagar antes de confirmar el pago,
para que pueda verificar que la información es correcta antes de abonar.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (paso 6) |
| **BUC origen** | BUC-01 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El resumen muestra: complejo, cancha, fecha, franja horaria, duración y monto de la contraprestación.
- El resumen incluye el tiempo restante para completar el pago antes de que la reserva provisional expire.
- El jugador puede volver atrás y elegir otra franja sin perder el proceso.

---

### US-10 — Pago de turno con medio de cobro en línea

Como jugador,
quiero pagar mi reserva provisional usando un medio de cobro en línea disponible,
para que el turno quede confirmado a mi nombre sin necesidad de ir al complejo.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-06 (pasos 1–6) |
| **BUC origen** | BUC-07 |
| **Prioridad** | Should have |
| **Estimación** | 3 semanas |

**Criterios de aceptación:**
- El producto presenta las opciones de cobro habilitadas por el complejo.
- El jugador puede completar el pago mientras la reserva provisional esté vigente.
- Si el pago es aprobado, la reserva pasa a Confirmada y el jugador recibe confirmación (BR-30).
- Si el instrumento de cobro es rechazado, el sistema informa el motivo y el jugador puede intentar con otro medio.
- Si los 10 minutos expiran antes de completar el pago, la reserva se extingue y el turno queda libre (BR-10).

---

### US-11 — Confirmación automática sin cobro anticipado

Como jugador en un complejo sin cobro anticipado,
quiero que mi reserva quede confirmada directamente al seleccionar el turno,
para que pueda asegurar el uso de la cancha y pagar en el momento de presentarme.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (A7.1) |
| **BUC origen** | BUC-01 (A5.1) |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- Si el complejo no tiene cobro anticipado habilitado, la reserva pasa directamente a Confirmada tras seleccionar el turno.
- El jugador recibe confirmación de la reserva sin pasar por el flujo de pago en línea.

---

### US-12 — Historial de reservas del jugador

Como jugador,
quiero ver mis reservas activas y mi historial de reservas pasadas,
para que pueda consultar el estado de mis turnos en cualquier momento.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01, PUC-02 |
| **BUC origen** | BUC-01, BUC-02 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El jugador ve sus reservas activas (Pendiente, Confirmada) y las pasadas (Cancelada, Expirada, Finalizada, No-show) (BR-17).
- Cada reserva muestra: complejo, cancha, fecha, franja, estado y monto.
- El jugador solo ve sus propias reservas; no puede acceder a reservas de otros jugadores.

---

## Épica 4 — Cancelación por el jugador

**PUC origen:** PUC-02 — Cancelar una reserva por el jugador
**Descripción:** El jugador puede cancelar sus reservas activas con la política de devolución correspondiente.

---

### US-13 — Consulta de política de cancelación antes de cancelar

Como jugador que desea cancelar una reserva,
quiero ver la política de cancelación aplicable y el monto que recibiré de devolución antes de confirmar la cancelación,
para que pueda decidir con información completa.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-02 (pasos 2–3) |
| **BUC origen** | BUC-02 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- Antes de confirmar, el sistema muestra: tiempo restante hasta el inicio, política aplicable y monto a devolver.
- La política se calcula según las reglas del complejo (BR-21, BR-22, BR-23).
- Si quedan menos de 2 horas, el sistema informa explícitamente que no habrá devolución.

---

### US-14 — Cancelación de reserva por el jugador

Como jugador,
quiero cancelar una reserva activa y recibir la devolución que me corresponde según la política del complejo,
para que pueda recuperar el valor abonado cuando no puedo asistir.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-02 (pasos 4–7) |
| **BUC origen** | BUC-02 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El jugador puede cancelar reservas en estado Pendiente o Confirmada cuyo inicio no haya ocurrido (BR-26).
- Tras confirmar, el turno se libera y la reserva pasa a Cancelada.
- La devolución se gestiona automáticamente: 100 % si >24 h, 50 % si entre 2-24 h, 0 % si <2 h (BR-21, BR-22, BR-23).
- Si la reserva era provisional (sin pago), se cancela sin cargo.
- El jugador recibe notificación con el detalle de la cancelación y la devolución gestionada.
- No es posible cancelar reservas en estado terminal (BR-19).

---

## Épica 5 — Notificaciones al jugador

**PUC origen:** PUC-01, PUC-02, PUC-03
**Descripción:** El jugador recibe notificaciones relevantes sobre el ciclo de vida de sus reservas.

---

### US-15 — Notificación de reserva confirmada

Como jugador,
quiero recibir una notificación cuando mi reserva queda confirmada,
para que pueda tener constancia del turno asegurado sin necesidad de consultar el historial.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (paso 9), PUC-06 (paso 7) |
| **BUC origen** | BUC-01, BUC-07 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- La notificación se envía inmediatamente tras la confirmación de la reserva.
- Incluye: complejo, cancha, fecha, franja horaria y monto abonado.

---

### US-16 — Notificación de cancelación por el complejo

Como jugador,
quiero ser notificado cuando el complejo cancela una de mis reservas confirmadas, con el motivo y el detalle de la devolución íntegra,
para que pueda planificar alternativas sin tener que consultar el producto activamente.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-03 (paso 5) |
| **BUC origen** | BUC-03 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- La notificación se envía inmediatamente tras la cancelación por el complejo.
- Incluye el motivo de cancelación y confirma la devolución íntegra del valor abonado (BR-24).

---

### US-17 — Recordatorio de turno próximo

Como jugador,
quiero recibir un recordatorio antes de mi turno,
para que no se me olvide presentarme a la cancha.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 |
| **BUC origen** | BUC-01 |
| **Prioridad** | Should have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El recordatorio se envía con al menos 2 horas de anticipación al inicio del turno.
- Incluye complejo, cancha, fecha y franja horaria.
- No se envía si la reserva fue cancelada o expiró antes del envío.

---

## Épica 6 — Incorporación del complejo

**PUC origen:** PUC-05 — Incorporación de un complejo
**Descripción:** El propietario puede registrar su complejo y configurar su oferta inicial.

---

### US-18 — Alta del complejo y del administrador principal

Como propietario de un complejo deportivo,
quiero registrar mi complejo en CanchasYa! y crear la cuenta del administrador principal,
para que pueda comenzar a gestionar mis reservas de forma digital.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-05 (pasos 1–4) |
| **BUC origen** | BUC-06 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El formulario de incorporación requiere: nombre del complejo, dirección, teléfono de contacto, y datos del administrador principal.
- Si el complejo ya existe, el sistema rechaza el alta duplicada.
- Al completar el alta, el administrador puede iniciar sesión con su cuenta y gestionar exclusivamente su complejo (BR-13, BR-14).

---

### US-19 — Registro de canchas del complejo

Como administrador de un complejo,
quiero registrar las canchas de mi complejo con su descripción y características,
para que los jugadores puedan verlas en la oferta disponible.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-05 (paso 5) |
| **BUC origen** | BUC-06 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El administrador puede registrar una o más canchas con nombre y descripción.
- Las canchas recién registradas no aparecen en la oferta pública hasta que tengan horarios configurados.
- El administrador solo puede registrar canchas en su propio complejo (BR-14).

---

### US-20 — Configuración de horarios y precios de una cancha

Como administrador,
quiero configurar los días y franjas horarias habilitadas y el valor de la contraprestación por franja de cada cancha,
para que los jugadores solo puedan reservar dentro de los horarios que yo establezco.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-05 (paso 6) |
| **BUC origen** | BUC-06 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El administrador puede habilitar días de la semana y franjas horarias específicas por cancha.
- El valor por franja es un campo obligatorio; no se acepta valor cero.
- Los cambios se reflejan de inmediato en la disponibilidad visible a los jugadores (BR-08).
- Si la modificación afecta franjas con reservas ya confirmadas, el sistema advierte al administrador antes de aplicar el cambio.

---

### US-21 — Configuración de la política de cancelación del complejo

Como administrador,
quiero definir la política de cancelación de mi complejo dentro de los límites del servicio,
para que las devoluciones reflejen mis condiciones comerciales.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-05 (paso 7) |
| **BUC origen** | BUC-06 |
| **Prioridad** | Should have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El administrador puede configurar los umbrales de cancelación libre y penalización parcial.
- El sistema rechaza configuraciones con umbral de cancelación libre inferior a 1 hora (BR-27).
- La cancelación por parte del complejo siempre genera devolución íntegra, independientemente de la política configurada (BR-24).

---

### US-22 — Habilitación del cobro anticipado en línea

Como administrador,
quiero habilitar el cobro anticipado en línea en mi complejo,
para que los jugadores paguen el turno al momento de reservar sin necesidad de ir al complejo.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-05 (A7.1) |
| **BUC origen** | BUC-06 (A6.1) |
| **Prioridad** | Should have |
| **Estimación** | 3 semanas |

**Criterios de aceptación:**
- El administrador puede activar o desactivar el cobro anticipado desde la configuración del complejo.
- Con cobro anticipado habilitado, las reservas requieren pago para confirmarse (BR-30).
- Con cobro anticipado deshabilitado, las reservas se confirman directamente.

---

## Épica 7 — Gestión de oferta de canchas

**PUC origen:** PUC-05 — Incorporación de un complejo (configuración continua)
**Descripción:** El administrador gestiona el estado y disponibilidad de sus canchas de forma continua.

---

### US-23 — Marcado de cancha en mantenimiento

Como administrador,
quiero marcar una cancha como fuera de servicio por mantenimiento,
para que no aparezca disponible para reservas mientras dure el trabajo.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-05 |
| **BUC origen** | BUC-06 |
| **Regla** | BR-11 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El administrador puede activar y desactivar el estado de mantenimiento de cada cancha.
- Mientras está en mantenimiento, la cancha no aparece en la oferta de turnos disponibles para los jugadores (BR-11).
- Las reservas ya confirmadas en esa cancha no se cancelan automáticamente; el administrador debe gestionarlas manualmente.

---

### US-24 — Bloqueo de franja para uso privado

Como administrador,
quiero bloquear franjas específicas de una cancha para uso propio o eventos privados,
para que esos horarios no aparezcan disponibles para reservas públicas.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-05 |
| **BUC origen** | BUC-06 |
| **Prioridad** | Should have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El administrador puede seleccionar una o más franjas de una cancha y bloquearlas para una fecha específica.
- Las franjas bloqueadas no aparecen disponibles para nuevas reservas.
- Las reservas ya confirmadas en esas franjas no se cancelan; el sistema advierte al administrador de los conflictos.

---

### US-25 — Edición de datos y configuración del complejo

Como administrador,
quiero poder editar los datos del complejo y la configuración de sus canchas después del alta inicial,
para que la información siempre refleje la realidad operativa.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-05 |
| **BUC origen** | BUC-06 |
| **Prioridad** | Should have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El administrador puede editar: nombre, dirección y teléfono del complejo; nombre y descripción de cada cancha; horarios, precios y política de cancelación.
- Los cambios en horarios y precios se aplican solo a nuevas reservas; no afectan reservas ya confirmadas.
- El administrador no puede acceder a los datos de otros complejos (BR-14).

---

## Épica 8 — Gestión de agenda del complejo

**PUC origen:** PUC-03, PUC-07
**Descripción:** El administrador gestiona las reservas del día, cancela turnos por causas operativas y registra inasistencias.

---

### US-26 — Consulta de agenda del complejo

Como administrador,
quiero ver la agenda de reservas de mi complejo por día y por cancha,
para que pueda planificar la operación diaria y semanal.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-03, PUC-07 |
| **BUC origen** | BUC-03, BUC-08 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El administrador puede ver las reservas confirmadas y pendientes de cada cancha por fecha.
- La vista puede filtrarse por cancha o por día.
- Solo se muestran reservas del complejo del administrador (BR-14).

---

### US-27 — Cancelación de reserva confirmada por el complejo

Como administrador,
quiero cancelar una reserva confirmada indicando el motivo, y que el sistema gestione la devolución íntegra al jugador,
para que pueda resolver imprevistos operativos sin tener que gestionar el reintegro manualmente.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-03 (pasos 1–5) |
| **BUC origen** | BUC-03 |
| **Regla** | BR-24 |
| **Prioridad** | Must have |
| **Estimación** | 2 semanas |

**Criterios de aceptación:**
- El administrador puede cancelar reservas en estado Confirmada de su complejo.
- El motivo de cancelación es obligatorio.
- Tras la cancelación, la devolución íntegra del valor abonado se gestiona automáticamente (BR-24), sin importar el tiempo restante.
- El jugador recibe notificación de la cancelación con el motivo.
- El administrador no puede cancelar reservas de otros complejos (BR-14).
- No es posible cancelar reservas en estado terminal (BR-19).

---

### US-28 — Registro de inasistencia de jugador

Como administrador,
quiero registrar la inasistencia de un jugador cuyo turno ya transcurrió sin que se presentara,
para que el estado del turno quede actualizado y el complejo conserve el valor abonado.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-07 (pasos 1–4) |
| **BUC origen** | BUC-08 |
| **Regla** | BR-25 |
| **Prioridad** | Must have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- El administrador puede registrar inasistencia solo sobre reservas Confirmadas cuya franja ya inició o concluyó.
- No se puede registrar inasistencia si la franja aún no comenzó.
- No se procesa devolución alguna al registrar una inasistencia (BR-25).
- El evento queda en el historial del jugador.
- El administrador no puede registrar inasistencias en reservas de otros complejos (BR-14).

---

### US-29 — Notificación al administrador de nueva reserva

Como administrador,
quiero recibir una notificación cuando un jugador confirma una reserva en mi complejo,
para que pueda mantener actualizada mi agenda sin tener que consultar el producto manualmente.

| Campo | Detalle |
|---|---|
| **PUC origen** | PUC-01 (paso 9) |
| **BUC origen** | BUC-01 |
| **Prioridad** | Should have |
| **Estimación** | 1 semana |

**Criterios de aceptación:**
- La notificación se envía al administrador inmediatamente tras la confirmación de una reserva en su complejo.
- Incluye: nombre del jugador, cancha, fecha y franja horaria del turno reservado.

---

## Resumen

| ID | Historia | Épica | PUC | Prioridad | Estimación |
|---|---|---|---|---|---|
| US-01 | Registro de jugador | É-01 | PUC-04 | Must have | 2 sem |
| US-02 | Registro con proveedor externo | É-01 | PUC-04 | Should have | 2 sem |
| US-03 | Inicio y cierre de sesión | É-01 | PUC-04 | Must have | 1 sem |
| US-04 | Recuperación de contraseña | É-01 | PUC-04 | Should have | 1 sem |
| US-05 | Consulta y edición de perfil | É-01 | PUC-04 | Should have | 1 sem |
| US-06 | Consulta de complejos disponibles | É-02 | PUC-01 | Must have | 2 sem |
| US-07 | Consulta de disponibilidad de turnos | É-02 | PUC-01 | Must have | 2 sem |
| US-08 | Selección y reserva provisional | É-03 | PUC-01 | Must have | 2 sem |
| US-09 | Visualización del resumen de reserva | É-03 | PUC-01 | Must have | 1 sem |
| US-10 | Pago con medio de cobro en línea | É-03 | PUC-06 | Should have | 3 sem |
| US-11 | Confirmación sin cobro anticipado | É-03 | PUC-01 | Must have | 1 sem |
| US-12 | Historial de reservas del jugador | É-03 | PUC-01 | Must have | 1 sem |
| US-13 | Consulta de política antes de cancelar | É-04 | PUC-02 | Must have | 1 sem |
| US-14 | Cancelación de reserva por el jugador | É-04 | PUC-02 | Must have | 2 sem |
| US-15 | Notificación de reserva confirmada | É-05 | PUC-01 | Must have | 1 sem |
| US-16 | Notificación de cancelación por el complejo | É-05 | PUC-03 | Must have | 1 sem |
| US-17 | Recordatorio de turno próximo | É-05 | PUC-01 | Should have | 1 sem |
| US-18 | Alta del complejo y administrador | É-06 | PUC-05 | Must have | 2 sem |
| US-19 | Registro de canchas | É-06 | PUC-05 | Must have | 1 sem |
| US-20 | Configuración de horarios y precios | É-06 | PUC-05 | Must have | 2 sem |
| US-21 | Configuración de política de cancelación | É-06 | PUC-05 | Should have | 1 sem |
| US-22 | Habilitación de cobro anticipado en línea | É-06 | PUC-05 | Should have | 3 sem |
| US-23 | Marcado de cancha en mantenimiento | É-07 | PUC-05 | Must have | 1 sem |
| US-24 | Bloqueo de franja para uso privado | É-07 | PUC-05 | Should have | 1 sem |
| US-25 | Edición de datos del complejo | É-07 | PUC-05 | Should have | 1 sem |
| US-26 | Consulta de agenda del complejo | É-08 | PUC-03 | Must have | 2 sem |
| US-27 | Cancelación de reserva por el complejo | É-08 | PUC-03 | Must have | 2 sem |
| US-28 | Registro de inasistencia | É-08 | PUC-07 | Must have | 1 sem |
| US-29 | Notificación al administrador de nueva reserva | É-08 | PUC-01 | Should have | 1 sem |

**Total: 29 historias**
**Estimación total Must have:** ~26 semanas ideales
**Estimación total Should have:** ~13 semanas ideales

---

## Trazabilidad

```
vision.md
    └── docs/BusinessRules/BR-Reservas.md
            └── docs/BusinessUseCases/BusinessUseCases.md
                    └── docs/ProductUseCases/ProductUseCases.md
                            └── docs/UserStories/UserStories.md  ← este documento
                                    └── RF-XX / RNF-XX (requisitos atómicos)  [pendiente]
```

---

*Las historias deben ser revisadas con el equipo de desarrollo para ajustar estimaciones antes del release planning. Las historias Must have constituyen el alcance del MVP de 12 semanas.*
