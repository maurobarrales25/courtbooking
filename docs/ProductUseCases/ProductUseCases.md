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
| [PUC-02](#puc-02--cancelar-una-reserva-por-el-usuario) | Cancelar una reserva por el usuario | BUC-02 |
| [PUC-03](#puc-03--cancelar-una-reserva-por-el-complejo) | Cancelar una reserva por el complejo | BUC-03 |
| [PUC-04](#puc-04--registrar-un-usuario) | Registrar un usuario | BUC-04 |
| [PUC-05](#puc-05--incorporar-un-complejo-al-servicio) | Incorporar un complejo al servicio | BUC-05 |
| [PUC-06](#puc-06--pagar-una-reserva) | Pagar una reserva | BUC-06 |
| [PUC-07](#puc-07--registrar-la-inasistencia-de-un-usuario) | Registrar la inasistencia de un usuario | BUC-07 |


---


## PUC-01 — Reservar una cancha


**BUC origen:** BUC-01 — Reservar una cancha


> **Decisión de automatización:** El producto automatiza la consulta de disponibilidad, la reserva temporal del turno, la coordinación del pago y la confirmación de la reserva. La presencia física del usuario en la cancha queda fuera del alcance del producto.


| Campo | Descripción |
|---|---|
| **Nombre** | Reservar una cancha |
| **Disparador** | El usuario inicia una solicitud de reserva. Datos que ingresan: identificación del usuario, complejo elegido, cancha, fecha, turno y duración deseada. |
| **Precondiciones** | El usuario tiene una sesión activa. El complejo tiene al menos una cancha habilitada con disponibilidad. El usuario no alcanzó el límite de reservas activas (BR-09). |
| **Interesados** | Usuario Admin/Dueño del complejo. |
| **Actores** | Usuario Intermediario de cobro. |


**Pasos del caso normal:**


1. Se muestran los turnos disponibles para la cancha y fecha elegidas del complejo.
2. El usuario elige el turno y la duración.
3. Recibe la solicitud del usuario con el complejo, cancha, fecha, turno y duración elegidos.
4. Verifica que el turno esté libre y que cumpla las condiciones de anticipación y duración del complejo (BR-01, BR-02, BR-03, BR-04).
5. Reserva el turno temporalmente a nombre del usuario e inicia el tiempo límite de reserva (BR-07).
6. Presenta al usuario el resumen: cancha, fecha, turno, duración y monto a pagar.
7. El usuario confirma la reserva (BR-05, BR-17, BR-12).
8. Notifica al usuario y al complejo la confirmación de la reserva.


**Alternativas:**


- **A7.1** — El complejo tiene habilitado el pago en línea. El usuario realiza el pago en línea (PUC 6).
- **A7.2** — El complejo tiene habilitado el pago en efectivo. Se confirma la reserva (PUC 6).


**Excepciones:**


- **E4.1** — El turno no cumple las condiciones de anticipación o duración o horario operativo: informa el motivo al usuario y le permite elegir otro turno (BR-01, BR-06).
- **E4.3** — El usuario alcanzó el límite de reservas activas (BR-09): informa al usuario y no continúa el proceso.
- **E7.1** — El tiempo de reserva temporal vence antes de completarse el pago (BR-07): libera el turno, informa al usuario y cancela el proceso.


| **Resultado** | El turno queda reservado y confirmado a nombre del usuario. El complejo recibe la notificación del nuevo turno en su agenda. |
|---|---|


---


## PUC-02 — Usuario cancela una reserva


**BUC origen:** BUC-02 — Cancelar una reserva por el cliente


> **Decisión de automatización:** El producto automatiza el cálculo del tiempo restante, la aplicación de la política de cancelación y la instrucción de devolución al intermediario de cobro. La devolución del dinero la ejecuta el intermediario de cobro fuera del producto.


| Campo | Descripción |
|---|---|
| **Nombre** | Usuario cancela una reserva |
| **Disparador** | El usuario solicita la cancelación de una reserva activa. Datos que ingresan: identificación del usuario, identificación de la reserva a cancelar. |
| **Precondiciones** | El usuario tiene una sesión activa. La reserva es del usuario. La reserva está en estado activo (pendiente o confirmada). El turno aún no comenzó. |
| **Interesados** | Usuario. Dueño del complejo. |
| **Actores** | Usuario. |


**Pasos del caso normal:**


1. El usuario selecciona la reserva a cancelar desde su historial de reservas activas.
2. Calcula el tiempo restante hasta el inicio del turno y determina la política de cancelación aplicable (BR-18, BR-22).
3. Informa al usuario la política vigente y el caso siguiente.
4. El usuario confirma la cancelación.
5. Registra la cancelación y libera el turno para nuevas reservas.
6. Instruye al intermediario de cobro para procesar la devolución del monto correspondiente.
7. Notifica al usuario la cancelación y el detalle de la devolución gestionada.


**Alternativas:**


- **A4.1** — El usuario decide no confirmar la cancelación: no realiza ningún cambio y regresa al historial de reservas.
- **A3.1** — Según las políticas del complejo se le otorga un reembolso.


**Excepciones:**


- **E1.1** — La reserva está en un estado final (BR-14): informa al usuario que la reserva no puede cancelarse.
- **E1.2** — El turno ya comenzó (BR-21): informa al usuario que el plazo de cancelación expiró.
- **E6.1** — El intermediario de cobro no puede procesar la devolución en ese momento: registra la cancelación y marca la devolución como pendiente de resolución.


| **Resultado** | La reserva queda cancelada, el turno vuelve a estar disponible y el usuario recibe (o tiene pendiente) la devolución según la política del complejo. |
|---|---|


---


## PUC-03 — Administrador de Complejo cancela una reserva


**BUC origen:** BUC-03 — Administrador de complejo cancela una reserva


> **Decisión de automatización:** El producto automatiza el registro de la cancelación, la liberación del turno y la instrucción de devolución completa. La verificación de la causa operativa y la devolución del dinero las ejecuta el intermediario de cobro fuera del producto.


| Campo | Descripción |
|---|---|
| **Nombre** | Administrador de complejo cancela una reserva|
| **Disparador** | El administrador del complejo solicita la cancelación de una reserva confirmada por causas operativas. Datos que ingresan: identificación del administrador, reserva a cancelar, motivo. |
| **Precondiciones** | El administrador tiene una sesión activa con permisos de gestión sobre el complejo. La reserva pertenece a ese complejo y está confirmada. |
| **Interesados** | Dueño del complejo. Usuario. |
| **Actores** | Administrador del complejo. Intermediario de cobro. |


**Pasos del caso normal:**


1. El administrador selecciona una reserva confirmada de la agenda de su complejo e indica el motivo de la cancelación.
2. Registra la cancelación y libera el turno en la agenda del complejo (BR-19).
3. Instruye al intermediario de cobro para procesar la devolución completa del pago al usuario.
4. Notifica al usuario la cancelación, el motivo y la devolución gestionada.


**Alternativas:**


- **A1.1** — La reserva no fue pagada: cancela sin devolución económica y libera el turno directamente.
- **A3.1** — Según las políticas del complejo se le otorga un reembolso.


**Excepciones:**


- **E1.1** — El administrador intenta cancelar una reserva de otro complejo: rechaza la acción e informa al administrador (BR-11).
- **E1.2** — La reserva está en un estado final (BR-14): rechaza la acción e informa al administrador.
- **E3.1** — El intermediario de cobro no puede procesar la devolución en ese momento: registra la cancelación y marca la devolución como pendiente.


| **Resultado** | La reserva queda cancelada, el turno queda libre en la agenda del complejo y el usuario recibe la devolución completa del pago. |
|---|---|


---


## PUC-04 — Registrar un usuario


**BUC origen:** BUC-04 — Registrar un usuario


> **Decisión de automatización:** El producto automatiza la totalidad del proceso de registro. No hay pasos manuales fuera del producto en este caso de uso.


| Campo | Descripción |
|---|---|
| **Nombre** | Registrar un usuario |
| **Disparador** | Una persona solicita registrarse como usuario en el producto. Datos que ingresan: nombre y datos de contacto del solicitante. |
| **Precondiciones** | La persona no tiene cuenta activa en el producto. |
| **Interesados** | Usuario potencial. Dueños de complejos. |
| **Actores** | Usuario potencial. Proveedor de identidad externo (opcional). |


**Pasos del caso normal:**


1. La persona ingresa sus datos de registro.
2. Verifica que no exista ya una cuenta con esos datos.
3. Registra al usuario con perfil activo.
4. Notifica al usuario la confirmación del registro.


**Alternativas:**


- **A1.1** — El solicitante se identifica a través de un proveedor de identidad externo: obtiene los datos de identificación de ese proveedor y continúa desde el paso 2.


**Excepciones:**


- **E1.1** — Los datos son incompletos o inválidos: señala los campos a corregir antes de continuar.
- **E2.1** — Ya existe una cuenta con esos datos: informa al solicitante que ya tiene una cuenta registrada y no crea una nueva.


| **Resultado** | El solicitante queda registrado como usuario activo y puede hacer reservas en los complejos disponibles. |
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
| **Interesados** | Dueño del complejo. Usuario. Dueño del producto.|
| **Actores** | Dueño del complejo. |


**Pasos del caso normal:**


1. El dueño del producto ingresa los datos del complejo y del administrador principal.
2. Verifica que el complejo no esté ya incorporado.
3. Crea el espacio de gestión del complejo, aislado de los demás complejos del servicio (BR-10).
4. Crea la cuenta del administrador principal con permisos exclusivos sobre ese complejo.
5. El dueño registra las canchas del complejo con sus características (BR-13.
6. El dueño configura los horarios de operación y los precios por turno de cada cancha.
7. El dueño define la política de cancelación del complejo, dentro de los límites del servicio (BR-22).
8. Activa el complejo y hace visible su oferta de canchas a los usuarios.


**Alternativas:**


- **A7.1** — El dueño vincula las credenciales del complejo con el intermediario de cobro para procesar pagos en las reservas.


**Excepciones:**


- **E1.1** — Los datos son incompletos o inválidos: señala los campos a corregir antes de continuar.
- **E2.1** — El complejo ya está incorporado: informa al solicitante e interrumpe el proceso.


| **Resultado** | El complejo queda activo como operador independiente. Sus canchas son visibles para los usuarios y el administrador puede gestionar su agenda de forma autónoma. |
|---|---|


---


## PUC-06 — Pagar una reserva


**BUC origen:** BUC-06 — Pagar una reserva


> **Decisión de automatización:** El producto automatiza la presentación del resumen de pago, la coordinación con el intermediario de cobro y la confirmación de la reserva. La transacción financiera la ejecuta el intermediario de cobro como sistema externo.


| Campo | Descripción |
|---|---|
| **Nombre** | Pagar una reserva |
| **Disparador** | El usuario necesita abonar una reserva temporal para que quede confirmada. Datos que ingresan: identificación del usuario, identificación de la reserva temporal, medio de pago elegido. |
| **Precondiciones** | Existe una reserva temporal activa a nombre del usuario. La reserva es del usuario. El tiempo de reserva temporal no venció. El complejo tiene habilitado el cobro por adelantado. |
| **Interesados** | Usuario. Dueño del complejo. |
| **Actores** | Usuario. Intermediario de cobro. |


**Pasos del caso normal:**


1. El sistema presenta al usuario el resumen de la reserva temporal y el monto a pagar.
2. El usuario elige el medio de pago entre las opciones disponibles.
3. Transmite los datos del pago al intermediario de cobro.
4. El intermediario de cobro procesa el pago y comunica el resultado al producto.
5. Recibe la confirmación del pago exitoso.
6. Confirma la reserva.
7. Notifica al usuario y al complejo la confirmación del pago y de la reserva.


**Alternativas:**




**Excepciones:**


- **E3.1** — El tiempo de reserva temporal vence antes de completarse el pago (BR-08): cancela la operación, libera el turno e informa al usuario.
- **E4.1** — El intermediario rechaza el pago: informa al usuario el motivo y le permite intentar otro medio de pago mientras la reserva temporal esté vigente.
- **E4.2** — El intermediario reporta un error técnico: informa al usuario y mantiene la reserva temporal activa hasta el vencimiento.


| **Resultado** | El pago queda registrado y la reserva queda confirmada a nombre del usuario. |
|---|---|


---


## PUC-07 — Registrar la inasistencia de un usuario


**BUC origen:** BUC-07 — Registrar la inasistencia de un usuario


> **Decisión de automatización:** El producto automatiza el registro de la inasistencia y la actualización del historial del usuario. La verificación física de que el usuario no se presentó la realiza el administrador fuera del producto.


| Campo | Descripción |
|---|---|
| **Nombre** | Registrar la inasistencia de un usuario |
| **Disparador** | El administrador del complejo indica que el usuario no se presentó al turno. Datos que ingresan: identificación del administrador, identificación del usuario, identificación de la reserva correspondiente. |
| **Precondiciones** | El administrador tiene una sesión activa con permisos sobre el complejo. La reserva pertenece a ese complejo, estaba confirmada por el usuario y su turno ya inició o terminó. |
| **Interesados** | Dueño del complejo. Usuario. |
| **Actores** | Administrador del complejo. |


**Pasos del caso normal:**


1. El administrador accede a la agenda de turnos del día y selecciona la reserva sin presentación.
2. El administrador confirma el registro de inasistencia para ese turno.
3. Actualiza el estado de la reserva a inasistencia y retiene el pago a favor del complejo (BR-20).
4. Registra la inasistencia en el historial del usuario.


**Alternativas:**


**Excepciones:**


- **E2.1** — El administrador intenta registrar la inasistencia en una reserva de otro complejo: rechaza la acción e informa al administrador (BR-11).
- **E2.2** — El turno todavía no comenzó: rechaza la acción; el usuario aún puede presentarse.
- **E2.3** — La reserva ya está en un estado final (BR-14): rechaza la acción.
- **E2.4** — El administrador intenta registrar la inasistencia en una reserva que el jugador no hizo.


| **Resultado** | La inasistencia queda registrada, el complejo conserva el pago y el historial del usuario queda actualizado. |
|---|---|


---
### Correspondencia BUC → PUC


| BUC | PUC derivado | Pasos del BUC no automatizados por el producto |
|---|---|---|
| BUC-01 Reservar una cancha | PUC-01 | Presencia física del usuario en la cancha |
| BUC-02 Cancelar reserva (usuario) | PUC-02 | Usuario cancela una reserva |
| BUC-03 El complejo decide cancelar una reserva | PUC-03 | Administrador de Complejo cancela una reserva |
| BUC-04 Registrar un usuario | PUC-04 | — (proceso totalmente automatizado) |
| BUC-04 Pagar una reserva | PUC-06 | Pagar una reserva (intermediario de cobro) |


### Cobertura de reglas de negocio


| Regla | PUC que la aplica |
|---|---|
| BR-01 Anticipación máx | PUC-01 (paso 4) |
| BR-02 Duración mín/máx | PUC-01 (paso 4) |
| BR-03 Incrementos de duración| PUC-01 (paso 4) |
| BR-04 Integridad temporal | PUC-01 (paso 4) |
| BR-05 Ausencia de superposición | PUC-01 (paso 7) |
| BR-06 Slots habilitados por el complejo | PUC-01 (E4.1) |
| BR-07 Bloqueo temporal durante pago | PUC-01 (paso 5), PUC-01 (E7.1) |
| BR-08 Expiración de reserva pendiente | PUC-06 (E3.1) |
| BR-09 Límite de reservas activas | PUC-01 (E4.3) |
| BR-10 Aislamiento de datos por complejo | PUC-05 (paso 3) |
| BR-11 Scope del administrador del complejo | PUC-03 (E1.1), PUC-07 (E2.1) |
| BR-12 Identificador de tenant en toda reserva | PUC-01 (paso 7) |
| BR-13 Configuración independiente por complejo | PUC-05 (paso 5) |
| BR-14 Estados válidos |PUC-02 (E1.1), PUC-03 (E1.2), PUC-07 (E2.3) |
| BR-17 Asociación obligatorio a cancha y y usuario | PUC-01 (paso 7) |
| BR-18 Cancelación libre | PUC-02 (paso 2) |
| BR-19 Cancelación por complejo | PUC-03 (paso 2) |
| BR-20 No show sin reembolso | PUC-07 (paso 3) |
| BR-21 Ventana mínima de cancelación | PUC-02 (E1.2) |
| BR-22 Política de cancelación | PUC-02 (paso 2), PUC-05 (paso 7) |


---
