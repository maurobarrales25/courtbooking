# Casos de Uso de Negocio — CanchasYa!


**Proyecto:** CanchasYa!
**Versión:** 2.0
**Estado:** Borrador
**Metodología:** Robertson & Robertson — *Mastering the Requirements Process*, 3ra ed.


> Un Caso de Uso de Negocio (BUC) describe cómo el trabajo responde a un evento que ocurre en el entorno adyacente (fuera de los límites del negocio), procesando datos de entrada y produciendo una salida de valor
> El sujeto implícito de todos los pasos es **el trabajo**.
> Los BUCs describen procesos de negocio, no soluciones técnicas.


---


## Índice


| ID | Nombre |
|---|---|
| [BUC-01](#buc-01--reservar-una-cancha) | Reservar una cancha |
| [BUC-02](#buc-02--cancelar-una-reserva-por-el-jugador) | Cancelar una reserva por el cliente|
| [BUC-03](#buc-03--cancelar-una-reserva-por-el-complejo) | El complejo decide cancelar una reserva |
| [BUC-04](#buc-04--pagar-una-reserva) | Pagar una reserva |


---


## BUC-01 — Reservar una cancha


| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | Reservar una cancha |
| **Disparador** | Un cliente quiere reservar en un complejo una cancha para jugar en una fecha y horario determinados. Datos que ingresan: cliente, complejo, cancha, fecha, turno y duración deseada. |
| **Precondiciones** | El complejo está abierto y tiene canchas disponibles para reservar. El cliente no superó el límite de reservas activas (BR-12). |
| **Interesados** | Cliente. Dueño del complejo.|
| **Actores** | Cliente. Dueño del complejo |


**Pasos del caso normal:**


1. El cliente quiere reservar en un complejo una cancha con fecha, turno y duración determinada.
2. El dueño del complejo verifica que el turno esté libre.
3. Acuerda con el cliente el medio y el monto del pago.
4. Confirma y notifica la reserva a nombre del cliente.
5. Registra la reserva en la agenda del complejo.


**Alternativas:**


- **A2.1** — El cliente no encuentra disponibilidad en el complejo elegido: informa la no disponibilidad y le ofrece otro horario/cancha.


**Excepciones:**


- **E1.1** — El complejo no atiende.
- **E2.1** — El Titular no encuentra disponibilidad en el complejo elegido: se le informa la no disponibilidad y se va.


| **Resultado** | La reserva queda confirmada a nombre del cliente. El turno queda asignado y el complejo lo registra en su agenda. |
|---|---|


---


## BUC-02 — Un cliente quiere cancelar una reserva


| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | Un cliente quiere cancelar una reserva |
| **Disparador** | Un cliente quiere cancelar una reserva que ya hizo. Datos que ingresan: cliente, reserva a cancelar. |
| **Precondiciones** | El cliente tiene una reserva activa (sin pagar o confirmada). El turno de la reserva todavía no comenzó. |
| **Interesados** | Cliente . Dueño del complejo. |
| **Actores** | Cliente. Dueño del complejo.|


**Pasos del caso normal:**


1. Recibe la solicitud de cancelación del cliente sobre una reserva activa.
2. Cancela la reserva y libera el turno para nuevas reservas.
3. Aplica la política de cancelación del complejo según el tiempo restante
4. Notifica al cliente la cancelación y el detalle de la devolución.


**Alternativas:**


- **A3.1** — Según las políticas del complejo se le otorga un reembolso
- **A4.1** — Si corresponde según política de cancelación.


**Excepciones:**


- **E1.1** — La reserva está en un estado final (ya cancelada, vencida o finalizada) (BR-19): rechaza la solicitud e informa al cliente.
- **E1.2** — El turno ya comenzó (BR-26): rechaza la cancelación e informa al cliente.


| **Resultado** | La reserva queda cancelada, el turno vuelve a estar disponible y el jugador recibe la devolución que le corresponde según la política del complejo. |
|---|---|


---


## BUC-03 — El complejo decide cancelar una reserva


| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | El complejo decide cancelar una reserva|
| **Disparador** | El complejo necesita cancelar una reserva confirmada por razones propias (mantenimiento, clima, fuerza mayor). Datos que ingresan: administrador, reserva a cancelar, motivo. |
| **Precondiciones** | Hay una reserva que está confirmada. |
| **Interesados** | Dueño del complejo. Cliente. |
| **Actores** | Dueño del complejo. Cliente. |


**Pasos del caso normal:**


1. Cancela la reserva y libera el turno.
2. Lo anota en la agenda. 
3. Notifica al cliente la cancelación y el motivo.


**Alternativas:**


- **A3.1** — Según las políticas del complejo se le otorga un reembolso


**Excepciones:**


| **Resultado** | La reserva queda cancelada, el turno queda libre y el jugador recibe la notificación. |
|---|---|


---


## BUC-04 — Pagar una reserva


| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | Pagar una reserva |
| **Disparador** | Un cliente con una reserva pendiente de pago necesita abonarla. Datos que ingresan: cliente, reserva, medio de pago elegido. |
| **Precondiciones** | El cliente tiene una reserva pendiente de pago a su nombre. |
| **Interesados** | Cliente. Dueño del complejo.|
| **Actores** | Cliente. Dueño del complejo. |


**Pasos del caso normal:**


1. Recibe la solicitud de pago del cliente con el medio de cobro elegido.
2. El dueño del complejo informa al cliente el monto.
3. Recibe el pago.
4. El dueño del complejo registra el pago.


**Alternativas:**


- **A3.1** — El medio de pago rechaza el pago: informa al cliente el motivo y le permite intentar con otro medio de pago.




**Excepciones:**


- **E3.1** — El medio de pago rechaza el pago y no se tiene otra forma de pago.


| **Resultado** | El pago queda registrado. |
|---|---|


---

## BUC-05 — Consultar agenda de reservas


| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | Consultar agenda de reservas |
| **Disparador** | Un cliente  necesita consultar la disponibilidad de canchas y horarios. Datos que ingresan: fecha, cancha y rango horario deseado. |
| **Precondiciones** | El complejo posee canchas. |
| **Interesados** | Cliente. Dueño del complejo. |
| **Actores** | Cliente. Dueño del complejo. |


**Pasos del caso normal:**


1. El cliente solicita consultar la disponibilidad de canchas para cierta fecha.
2. El dueño del complejo se fija en la agenda las canchas disponibles para la fecha dada. 
3. El dueño del complejo le comunica la disponibilidad de canchas para la fecha dada.


**Alternativas:**


- **A2.1** — Agenda física
- **A2.2** — Computadora

**Excepciones:**

- **E1.1** — El complejo no opera en la fecha solicitada (BR-06)

| **Resultado** | El cliente obtiene la disponibilidad actualizada de las canchas y horarios del complejo. |
|---|---|


---

## BUC-06 — Reprogramar reserva


| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | Reprogramar reserva |
| **Disparador** | Un cliente necesita modificar la fecha u horario de una reserva existente. Datos que ingresan: reserva, nueva fecha y nuevo horario solicitado. |
| **Precondiciones** | Existe una reserva registrada y vigente a nombre del cliente. |
| **Interesados** | Cliente. Dueño del complejo. |
| **Actores** | Cliente. Dueño del complejo. |


**Pasos del caso normal:**


1. Recibe la solicitud de reprogramación de la reserva.
2. Verifica los datos de la reserva existente.
3. Consulta la disponibilidad para la nueva fecha y horario solicitados.
4. Confirma la disponibilidad del nuevo horario.
5. Actualiza la reserva con la nueva fecha y horario.
6. Notifica la reprogramación de la reserva a las partes involucradas.


**Alternativas:**


- **A3.1** — El cliente solicita otra cancha: consulta la disponibilidad de la cancha alternativa.
- **A4.1** — El nuevo horario solicitado no se encuentra disponible: informa las opciones de horarios disponibles.


**Excepciones:**


- **E2.1** — La reserva no existe o no corresponde al cliente: informa que la reprogramación no puede realizarse.
- **E3.1** — No existen horarios disponibles para la fecha solicitada: informa la imposibilidad de reprogramar la reserva.
- **E5.1** — La reserva ya se encuentra vencida o cancelada: informa que no puede modificarse.


| **Resultado** | La reserva queda actualizada con la nueva fecha y horario acordados. |
|---|---|


---




## Trazabilidad hacia reglas de negocio


| Regla | BUC | Dónde aplica |
|---|---|---|
| BR-01 Anticipación máxima (30 días) | BUC-01 | E3.1 |
| BR-02 Duración mínima (1 h) | BUC-01 | E3.1 |
| BR-05 Ausencia de superposición | BUC-01 | E4.1 |
| BR-06 Slots habilitados por el complejo | BUC-05 | E1.1 |
| BR-14 Estados válidos (6 estados)| BUC-02 | E1.1, BUC-03 E1.2, BUC-07 E1.3 |
| BR-21/22/23 Políticas de cancelación | BUC-02 | Paso 3 |
| BR-24 Cancelación por complejo = devolución completa | BUC-03 | Paso 3 |


---

TODO: 

- Reprogramar reserva
