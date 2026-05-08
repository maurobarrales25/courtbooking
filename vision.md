# Acta de Constitución del Proyecto: CanchasYa!

## 1. Información General
| Campo | Detalle |
| :--- | :--- |
| **Nombre del Proyecto** | CanchasYa! |
| **Patrocinador** | Cátedra de Gestión de Proyectos - UCU (Pablo Rivas) |
| **Fecha** | 27/03/2026 |
| **Director del Proyecto** |   |

---

## 2. Propósito y Justificación
El departamento de Maldonado cuenta con una población mayor a 200.000 personas, en constante crecimiento. En la zona de ciudad de Maldonado - Punta del Este, hay más de 15 complejos de fútbol de 5, la mayoría de estas gestionan sus reservas de forma analógica. Este proyecto brinda una solución tecnológica que optimiza la gestión de agendas, reduce el margen de error por sobre reserva y ofrece una ventaja competitiva a los clubes que adopten la digitalización.

---

## 3. Objetivos SMART
Desarrollar una plataforma web para la reserva de canchas de fútbol que permita a los usuarios registrarse, consultar disponibilidad y realizar reservas, en un plazo de 12 semanas.

* **Específico:** Desarrollar una plataforma web para la reserva de canchas de fútbol.
* **Medible:** Implementar registro, consulta de disponibilidad y realización de reservas.
* **Alcanzable:** Uso de tecnologías conocidas.
* **Relevante:** Automatización de la gestión de reservas.
* **Temporal:** Plazo de 12 semanas.
* **Criterio de Éxito:** El proyecto se considerará exitoso si al implementar la solución, logra adherir 5 complejos deportivos, y las reservas realizadas a través de la aplicación alcanzan un 30% los primeros 2 meses. 

---

## 4. Requisitos de Alto Nivel
### Del Producto
* **Must Have:** Disponibilidad en tiempo real, reserva de turnos, panel de control para dueños, Identificación/Autenticación (IAA) y persistencia robusta.
* **Should Have:** Integración de pagos y mapa de Maldonado.
* **Nice to Have:** Matchmaking para jugadores solitarios e historial de estadísticas. Historial de estadísticas. 
 Sistema de Reputación para jugadores (por cancelaciones). 

### Del Proyecto (Restricciones)
* **Alcance:** Implementación de plataforma SaaS multitenant para complejos de Maldonado y Punta del Este
.
* **Cronograma:** Entrega funcional en la semana 12.
* **Calidad:** Los datos de usuarios y reservas deben mantenerse tras reiniciar la aplicación.

---

## 5. Alcance y Entregables
### Descripción
Implementación de una plataforma **SaaS multitenant** donde los complejos gestionan turnos y clientes de forma independiente
.

### Entregables Clave
* **Producto:** Aplicación Web (MVP), Panel de administración y DB en tiempo real
.
* **Gestión:** Registro de interesados, enunciado de alcance, EDT, cronograma, presupuesto y registro de riesgos[: 17].

### Exclusiones (Fuera de Alcance)
* Soporte técnico presencial o mantenimiento de redes/internet en los clubes
.
* Provisión de hardware o gestión de cobranza física en el local
.

---

## 6. Riesgos Generales
* **Resistencia al cambio:** Dueños de cancha o jugadores prefieren el método tradicional
.
* **Inasistencias:** Jugadores que reservan y no se presentan (afectando rentabilidad)
.
* **Competencia:** Entrada de Apps internacionales con mayor presupuesto
.
* **Cronograma:** Retrasos por curva de aprendizaje tecnológica o integración de pagos
.

---

## 7. Recursos Financieros (Presupuesto)
| Rubro | Estimación |
| :--- | :--- |
| **Desarrollo y Diseño Web** | USD 1.500 – 2.000  |
| **Hosting y Servidores** | USD 20 – 50 mensuales  |
| **Dominio y SSL** | USD 10 – 50 anuales  |
| **Marketing inicial** | USD 200 – 500  |

---

## 8. Cronograma de Hitos
| Hito | Descripción | Semana |
| :--- | :--- | :--- |
| **Análisis y Setup** | Requisitos, diseño e infraestructura base | 2  |
| **Autenticación** | Registro e inicio de sesión funcional | 3  |
| **Panel de Control** | CRUD de canchas y disponibilidad | 5 :  |
| **Reservas** | Sistema de reservas completo (Must Have) | 6 - 7  |
| **Extras** | Integración de pagos (Should Have) | 7 - 9  |
| **Testing** | Pruebas generales y ajustes | 10  |
| **Despliegue** | MVP en producción | 12  |

---

## 9. Interesados Clave
* **Usuarios Finales:** Jugadores aficionados en Maldonado (residentes/turistas).
* **Clientes B2B:** Dueños y administradores de complejos deportivos.
* **Operadores de Pago:** Mercado Pago y redes de cobranza.
* **Equipo:** Desarrolladores y diseñadores.

---

## 10. Autoridad del Director del Proyecto
El Director del Proyecto tiene autoridad para:
* Seleccionar tecnologías, frameworks y arquitectura.
* Asignar fondos a recursos humanos, marketing y servidores.
* Validar funcionalmente el sistema y aprobar el despliegue final.