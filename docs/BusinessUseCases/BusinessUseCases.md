# Casos de Uso de Negocio — CanchasYa!

**Proyecto:** CanchasYa!
**Versión:** 1.0
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
| [BUC-02](#buc-02--cancelar-una-reserva-por-el-jugador) | Cancelar una reserva por el jugador |
| [BUC-03](#buc-03--cancelar-una-reserva-por-el-complejo) | Cancelar una reserva por el complejo |
| [BUC-04](#buc-04--registrar-un-jugador) | Registrar un jugador |
| [BUC-05](#buc-05--incorporar-un-complejo-al-servicio) | Incorporar un complejo al servicio |
| [BUC-06](#buc-06--pagar-una-reserva) | Pagar una reserva |
| [BUC-07](#buc-07--registrar-la-inasistencia-de-un-jugador) | Registrar la inasistencia de un jugador |

---

## BUC-01 — Reservar una cancha

| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | Reservar una cancha |
| **Disparador** | Un jugador quiere reservar una cancha para jugar en una fecha y horario determinados. Datos que ingresan: jugador, complejo, cancha, fecha, turno y duración deseada. |
| **Precondiciones** | El jugador está registrado en el servicio. El complejo tiene canchas disponibles para reservar. El jugador no superó el límite de reservas activas (BR-12). |
| **Interesados** | Jugador (asegurar el turno en la cancha que eligió). Dueño del complejo (tener el turno ocupado y cobrar). Intermediario de cobro (procesar el pago entre jugador y complejo). |
| **Actores** | Jugador. Intermediario de cobro. |

**Pasos del caso normal:**

1. Recibe la solicitud del jugador con el complejo, cancha, fecha, turno y duración elegidos.
2. Informa al jugador los turnos disponibles en esa cancha para la fecha pedida.
3. Verifica que el turno esté libre y que cumpla las condiciones de anticipación y duración del complejo.
4. Reserva el turno temporalmente a nombre del jugador.
5. Acuerda con el jugador el medio y el monto del pago.
6. Recibe el pago del jugador a través del intermediario de cobro.
7. Confirma la reserva a nombre del jugador.
8. Notifica al jugador y al complejo la confirmación de la reserva.

**Alternativas:**

- **A2.1** — El jugador no encuentra disponibilidad en el complejo elegido: informa la no disponibilidad y el jugador elige otro complejo. Retoma desde el paso 1.
- **A5.1** — El complejo no cobra por adelantado: confirma la reserva directamente sin pasar por el pago. Pasa al paso 7.

**Excepciones:**

- **E3.1** — El turno no cumple las condiciones de anticipación o duración (BR-01, BR-02, BR-03, BR-04): rechaza la solicitud e informa el motivo al jugador.
- **E4.1** — Otro jugador tomó el mismo turno antes de completarse la reserva temporal: informa la falta de disponibilidad y ofrece los turnos libres actualizados. Retoma desde el paso 2.
- **E4.2** — El jugador ya tiene el máximo de reservas activas permitidas (BR-12): rechaza la solicitud e informa al jugador.
- **E6.1** — El pago no se completa dentro del tiempo reservado (BR-09, BR-10): la reserva temporal se cancela y el turno vuelve a estar disponible para otros jugadores.

| **Resultado** | La reserva queda confirmada a nombre del jugador. El turno queda asignado y el complejo lo registra en su agenda. |
|---|---|

---

## BUC-02 — Cancelar una reserva por el jugador

| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | Cancelar una reserva por el jugador |
| **Disparador** | Un jugador quiere cancelar una reserva que ya hizo. Datos que ingresan: jugador, reserva a cancelar. |
| **Precondiciones** | El jugador tiene una reserva activa (sin pagar o confirmada). El turno de la reserva todavía no comenzó. |
| **Interesados** | Jugador (recuperar todo o parte del dinero pagado). Dueño del complejo (recuperar el turno para ofrecerlo a otro jugador). |
| **Actores** | Jugador. Intermediario de cobro. |

**Pasos del caso normal:**

1. Recibe la solicitud de cancelación del jugador sobre una reserva activa.
2. Determina cuánto tiempo falta para el inicio del turno.
3. Aplica la política de cancelación del complejo según el tiempo restante:
   - Más de 24 horas antes: devolución completa del pago.
   - Entre 2 y 24 horas antes: devolución del 50 % del pago.
   - Menos de 2 horas antes: sin devolución.
4. Cancela la reserva y libera el turno para nuevas reservas.
5. Si corresponde devolución, gestiona el reembolso al jugador a través del intermediario de cobro.
6. Notifica al jugador la cancelación y el detalle de la devolución.

**Alternativas:**

- **A1.1** — La reserva todavía no fue pagada: cancela sin aplicar política de devolución y libera el turno de inmediato. Pasa al paso 4.

**Excepciones:**

- **E1.1** — La reserva está en un estado final (ya cancelada, vencida o finalizada) (BR-19): rechaza la solicitud e informa al jugador.
- **E1.2** — El turno ya comenzó (BR-26): rechaza la cancelación e informa al jugador.
- **E5.1** — No es posible procesar la devolución en ese momento: registra la cancelación y deja la devolución pendiente de resolución.

| **Resultado** | La reserva queda cancelada, el turno vuelve a estar disponible y el jugador recibe la devolución que le corresponde según la política del complejo. |
|---|---|

---

## BUC-03 — Cancelar una reserva por el complejo

| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | Cancelar una reserva por el complejo |
| **Disparador** | El complejo necesita cancelar una reserva confirmada por razones propias (mantenimiento, clima, fuerza mayor). Datos que ingresan: administrador, reserva a cancelar, motivo. |
| **Precondiciones** | El administrador tiene permiso para gestionar el complejo al que pertenece la reserva. La reserva está confirmada. |
| **Interesados** | Dueño del complejo (resolver el problema operativo y recuperar el turno). Jugador (recibir la devolución completa del pago, ya que el incumplimiento es del complejo). |
| **Actores** | Administrador del complejo. Intermediario de cobro. |

**Pasos del caso normal:**

1. Recibe la solicitud de cancelación del administrador con el motivo indicado.
2. Cancela la reserva y libera el turno.
3. Gestiona la devolución completa del pago al jugador, sin importar cuánto tiempo falta para el turno (BR-24).
4. Notifica al jugador la cancelación, el motivo y la devolución completa.

**Alternativas:**

- **A1.1** — La reserva no fue pagada: cancela sin devolución económica y libera el turno.

**Excepciones:**

- **E1.1** — El administrador intenta cancelar una reserva de otro complejo (BR-14): rechaza la acción e informa al administrador.
- **E1.2** — La reserva está en un estado final (BR-19): rechaza la acción.
- **E3.1** — No es posible procesar la devolución en ese momento: registra la cancelación y deja la devolución pendiente de resolución.

| **Resultado** | La reserva queda cancelada, el turno queda libre y el jugador recibe la devolución completa del pago. |
|---|---|

---

## BUC-04 — Registrar un jugador

| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | Registrar un jugador |
| **Disparador** | Una persona quiere usar el servicio para reservar canchas en Maldonado / Punta del Este. Datos que ingresan: nombre, datos de contacto del solicitante. |
| **Precondiciones** | El solicitante no tiene cuenta en el servicio. |
| **Interesados** | Jugador (acceder a la oferta de canchas disponibles). Dueños de complejos (tener jugadores registrados que puedan hacer reservas). |
| **Actores** | Solicitante. |

**Pasos del caso normal:**

1. Recibe los datos de registro del solicitante.
2. Verifica que no exista ya una cuenta con esos datos.
3. Registra al jugador en el servicio.
4. Confirma el registro al jugador.

**Alternativas:**

- **A1.1** — El solicitante se identifica a través de un proveedor de identidad externo: obtiene los datos de identificación de ese proveedor y continúa desde el paso 2.

**Excepciones:**

- **E2.1** — Ya existe una cuenta con esos datos: rechaza el registro duplicado e informa al solicitante.
- **E1.1** — Los datos son incompletos o inválidos: pide la corrección antes de continuar.

| **Resultado** | El solicitante queda registrado como jugador activo y puede hacer reservas en los complejos disponibles. |
|---|---|

---

## BUC-05 — Incorporar un complejo al servicio

| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | Incorporar un complejo al servicio |
| **Disparador** | El dueño de un complejo deportivo quiere ofrecer sus canchas a través del servicio. Datos que ingresan: datos del complejo, datos del administrador principal, descripción de las canchas. |
| **Precondiciones** | El complejo no está registrado en el servicio. El solicitante tiene autoridad para representar al complejo. |
| **Interesados** | Dueño del complejo (digitalizar su agenda, llegar a más jugadores y reducir errores de gestión). Jugadores (tener más canchas disponibles para reservar). |
| **Actores** | Dueño del complejo. |

**Pasos del caso normal:**

1. Recibe los datos del complejo y del administrador principal.
2. Verifica que el complejo no esté ya incorporado.
3. Habilita al complejo como operador independiente, separado de los demás complejos del servicio (BR-13).
4. Crea la cuenta del administrador principal con permisos exclusivos sobre ese complejo (BR-14).
5. Recibe el registro de las canchas del complejo con sus características.
6. Registra la política de cancelación del complejo, verificando que cumpla los mínimos del servicio (BR-27).
7. Pone disponible la oferta del complejo para que los jugadores puedan reservar.

**Alternativas:**

- **A6.1** — El dueño quiere cobrar las reservas por adelantado: vincula al complejo con un intermediario de cobro para procesar los pagos.

**Excepciones:**

- **E2.1** — El complejo ya está incorporado: rechaza el alta duplicada e informa al solicitante.
- **E1.1** — Los datos son incompletos o inválidos: pide la corrección antes de continuar.
- **E6.1** — La política de cancelación no cumple los mínimos del servicio (BR-27): rechaza la configuración e informa los valores permitidos.

| **Resultado** | El complejo queda activo. Sus canchas son visibles para los jugadores y el administrador puede gestionar su agenda de forma independiente. |
|---|---|

---

## BUC-06 — Pagar una reserva

| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | Pagar una reserva |
| **Disparador** | Un jugador con una reserva pendiente de pago necesita abonarla para que quede confirmada. Datos que ingresan: jugador, reserva, medio de pago elegido. |
| **Precondiciones** | El jugador tiene una reserva pendiente de pago a su nombre. El turno sigue reservado temporalmente para ese jugador. El tiempo de reserva temporal no venció. El complejo tiene habilitado el cobro por adelantado. |
| **Interesados** | Jugador (pagar el turno antes de que se libere). Dueño del complejo (cobrar el turno por adelantado). Intermediario de cobro (procesar el pago). |
| **Actores** | Jugador. Intermediario de cobro. |

**Pasos del caso normal:**

1. Recibe la solicitud de pago del jugador con el medio de cobro elegido.
2. Informa al intermediario de cobro el monto y los datos de la operación.
3. El intermediario de cobro procesa el pago.
4. Recibe la confirmación del pago del intermediario.
5. Confirma la reserva.
6. Notifica al jugador y al complejo la confirmación del pago y de la reserva.

**Alternativas:**

*(No aplica: el disparador ya está acotado a reservas pendientes de pago en complejos con cobro por adelantado habilitado.)*

**Excepciones:**

- **E3.1** — El intermediario rechaza el pago: informa al jugador el motivo y le permite intentar con otro medio de pago mientras la reserva temporal siga vigente.
- **E3.2** — El tiempo de reserva temporal vence antes de completarse el pago (BR-10): la reserva temporal se cancela y el turno queda disponible para otros jugadores.

| **Resultado** | El pago queda registrado y la reserva queda confirmada a nombre del jugador. |
|---|---|

---

## BUC-07 — Registrar la inasistencia de un jugador

| Campo | Descripción |
|---|---|
| **Nombre del caso de uso de negocio** | Registrar la inasistencia de un jugador |
| **Disparador** | El turno de una reserva confirmada termina sin que el jugador se haya presentado. Datos que ingresan: administrador, reserva correspondiente. |
| **Precondiciones** | La reserva estaba confirmada. El turno ya comenzó o terminó. El jugador no se presentó. |
| **Interesados** | Dueño del complejo (registrar el incumplimiento y quedarse con el pago). Jugador (queda constancia de que no se presentó). |
| **Actores** | Administrador del complejo. |

**Pasos del caso normal:**

1. Recibe la confirmación del administrador de que el jugador no se presentó al turno.
2. Registra la inasistencia en la reserva correspondiente.
3. Retiene el pago a favor del complejo, sin devolver nada al jugador (BR-25).
4. Deja constancia de la inasistencia en el historial del jugador.

**Alternativas:**

*(No aplica; la inasistencia es un hecho binario: el jugador se presentó o no.)*

**Excepciones:**

- **E1.1** — El administrador intenta registrar la inasistencia en una reserva de otro complejo (BR-14): rechaza la acción.
- **E1.2** — El turno todavía no comenzó: rechaza la acción; el jugador todavía puede presentarse.
- **E1.3** — La reserva está en un estado final (BR-19): rechaza la acción.

| **Resultado** | La inasistencia queda registrada, el complejo conserva el pago y el historial del jugador queda actualizado. |
|---|---|

---

## Trazabilidad hacia reglas de negocio

| Regla | BUC | Dónde aplica |
|---|---|---|
| BR-01 Anticipación mínima (1 h) | BUC-01 | E3.1 |
| BR-02 Anticipación máxima (30 días) | BUC-01 | E3.1 |
| BR-03 Duración mínima (1 h) | BUC-01 | E3.1 |
| BR-04 Duración máxima (4 h) | BUC-01 | E3.1 |
| BR-07 Sin superposición de turnos | BUC-01 | E4.1 |
| BR-09 Reserva temporal del turno | BUC-01 | Paso 4 |
| BR-10 Vencimiento de reserva temporal | BUC-01 | E6.1, BUC-06 E3.2 |
| BR-12 Límite de reservas activas | BUC-01 | E4.2 |
| BR-13 Separación de datos por complejo | BUC-05 | Paso 3 |
| BR-14 Permisos del administrador | BUC-03 | E1.1, BUC-07 E1.1 |
| BR-19 Estados finales | BUC-02 | E1.1, BUC-03 E1.2, BUC-07 E1.3 |
| BR-21/22/23 Política de cancelación | BUC-02 | Paso 3 |
| BR-24 Cancelación por complejo = devolución completa | BUC-03 | Paso 3 |
| BR-25 Inasistencia sin devolución | BUC-07 | Paso 3 |
| BR-26 Solo se cancela si el turno no comenzó | BUC-02 | E1.2 |
| BR-27 Política de cancelación configurable | BUC-05 | Paso 6 |

---
