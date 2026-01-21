# 📋 ÍNDICE - ESPECIFICACIÓN TÉCNICA IMPLEMENTABLE
## MFSScalpIndicator v3.0 - NinjaTrader 8

**Fecha:** 18 de Enero, 2026  
**Analista:** Arquitecto de Indicadores NT8  
**Estándar:** Cero Ambigüedad  
**Estado:** ✅ COMPLETO - Listo para Implementación

---

## 📚 ARCHIVOS GENERADOS

Esta especificación está dividida en **3 documentos técnicos** para facilitar navegación:

### 1. ESPEC_TECNICA_PARTE1_CONCEPTOS_Y_ESTADOS.md (~30 páginas)
**Contenido:**
- **[A] Mapa de Conceptos FPLEME → Variables NT8**
  - 33 conceptos mapeados con tipos, rangos y fuentes
  - 4 INCERTIDUMBRES identificadas con preguntas cerradas
- **[B] Máquina de Estados Completa**
  - 5 state machines: CycleState, EtapaState, ScenarioType, WallState, SignalQuality
  - 30+ transiciones con triggers, guards, side effects exactos

**Usar para:** Entender arquitectura base y estados del sistema

---

### 2. ESPEC_TECNICA_PARTE2_REGLAS_Y_FILTROS.md (~35 páginas)
**Contenido:**
- **[C] Reglas de Señal ETAPA 1 (Prioridad #1)**
  - Especificación completa LONG y SHORT (9 subsecciones cada una)
  - Pseudocódigo de 10 pasos validados
  - Dependencias críticas
- **[D] The_Wall - Filtro Inviolable (Prioridad #2)**
  - Reglas por color (verde, rosa/magenta, amarillo)
  - 3 opciones de acceso (MAPS_M7, VX_M7, proxy)
  - Pseudocódigo con fallback
- **[E] PAT (Perfect Alignment Trigger)**
  - 4 capas de validación
  - Sistema de scoring 0-4
  - Tabla de decisiones con 16 casos
- **[F] Escenarios PPM/MM**
  - Detección de convergencia/divergencia
  - 4 casos de ejemplo
  - Fallback si MAP no disponible

**Usar para:** Implementar lógica de detección de señales

---

### 3. ESPEC_TECNICA_PARTE3_INTEGRACION_Y_TESTS.md (~30 páginas)
**Contenido:**
- **[G] Integración con Indicador Actual**
  - 7 componentes que SE MANTIENEN
  - 5 componentes que SE REEMPLAZAN
  - 15 métodos NUEVOS a agregar
  - 17 variables nuevas
  - Diffs detallados por función
- **[H] Bloqueadores + Preguntas Cerradas**
  - 5 bloqueadores identificados (3 críticos, 2 menores)
  - **10 preguntas cerradas específicas** para resolver incertidumbres
  - Plan B técnico para cada bloqueador
- **[I] Casos de Prueba**
  - **12 casos Given/When/Then**
  - Cobertura completa: ETAPA 1, The_Wall, PAT, escenarios, invalidación
  - Comparación vs lógica actual (señales tardías)

**Usar para:** Plan de implementación y testing

---

## 🎯 ENTREGABLES COMPLETADOS

| ID | Entregable | Estado | Ubicación | Páginas |
|----|------------|--------|-----------|---------|
| A | Mapa Conceptos → Variables | ✅ | Parte 1 | 8 |
| B | Máquina de Estados | ✅ | Parte 1 | 12 |
| C | Reglas ETAPA 1 | ✅ | Parte 2 | 15 |
| D | The_Wall Filter | ✅ | Parte 2 | 7 |
| E | PAT Scoring | ✅ | Parte 2 | 8 |
| F | Escenarios PPM/MM | ✅ | Parte 2 | 5 |
| G | Integración Indicador | ✅ | Parte 3 | 10 |
| H | Bloqueadores | ✅ | Parte 3 | 8 |
| I | Casos de Prueba | ✅ | Parte 3 | 12 |

**Total:** ~95 páginas de especificación técnica detallada

---

## 📊 MÉTRICAS DEL ANÁLISIS

### Cobertura de Conceptos
- ✅ 33 conceptos FPLEME mapeados a variables NT8
- ✅ 5 máquinas de estados con 30+ transiciones
- ✅ 4 INCERTIDUMBRES identificadas con preguntas cerradas
- ✅ 15 métodos nuevos especificados
- ✅ 17 variables nuevas definidas
- ✅ 12 casos de prueba completos

### Citas y Fuentes
- ✅ 150+ referencias a fuentes originales
- ✅ Formato: [FUENTE: JSON → sección] o [FUENTE: RESUMEN_EJECUTIVO → línea X]
- ✅ Cada afirmación importante tiene fuente citada

### Estándar "Cero Ambigüedad"
- ✅ TODO lo ambiguo marcado como ⚠️ INCERTO
- ✅ 10 preguntas CERRADAS (Sí/No/Opción A/B/C)
- ✅ Plan B técnico para cada incertidumbre
- ✅ NO hay suposiciones sin documentar

---

## 🔑 INFORMACIÓN CRÍTICA

### Bloqueadores que DEBEN Resolverse (Orden de Prioridad)

#### 1. BLOQUEADOR #1: Acceso a FPLEME_M7_II ⚠️ CRÍTICO
**Preguntas Cerradas:**
- P#1: ¿FPLEME_M7_II expone `double FplemeValue`? **(Sí/No/Nombre exacto)**
- P#2: ¿Expone `FplemeState CurrentState`? **(Sí/No/Nombre exacto)**
- P#3: ¿Expone `bool IsEtapa1Long/Short`? **(Sí/No)**

**Plan B:** Usar SHARK calculado internamente como proxy (ya implementado en v2.0)

**Ubicación Detallada:** Parte 3 → H.1 Bloqueador #1

---

#### 2. BLOQUEADOR #2: Acceso a The_Wall ⚠️ CRÍTICO
**Preguntas Cerradas:**
- P#4: ¿MAPS_M7 expone `WallColor TheWallColor`? **(Sí/No/Nombre exacto)**
- P#5: ¿VX_M7 expone `WallColor VXWallColor`? **(Sí/No/Nombre exacto)**
- P#6: ¿MAPS_M7 expone `double MAP0`? **(Sí/No/Nombre exacto)**

**Plan B:** Proxy basado en análisis precio vs SMA(20) (implementado en Parte 2 → D.3.3)

**Ubicación Detallada:** Parte 3 → H.1 Bloqueador #2

---

#### 3. BLOQUEADOR #3: Cálculo MAP Exacto ⚠️ MEDIO
**Preguntas Cerradas:**
- P#7: ¿MAP en MAPS_M7 es `(Close - SMA(20)) / ATR(14)`? **(Sí/No/Fórmula alternativa)**
- P#8: ¿Usa `midPrice` o `Close`? **(midPrice/Close/Otro)**

**Plan B:** Validar con backtest comparativo

**Ubicación Detallada:** Parte 3 → H.1 Bloqueador #3

---

### Filosofía FPLEME - Reglas Fundamentales

**Flow → Cycle → Context → Signal**

1. **NUNCA contra The_Wall** (regla inviolable)
2. **ETAPA 1 al INICIO del ciclo** (2º o 3er box, NO tarde)
3. **PAT para calidad** (4 capas → HIGH, 3 → MEDIUM, <=2 → LOW)
4. **Context > Signal** (PPM/MM determina calidad)
5. **NO desde extremos** (+-8, +-12 invalidan ETAPA 1)

---

## 📖 CÓMO USAR ESTA ESPECIFICACIÓN

### Para Desarrolladores

**Paso 1: Lectura Rápida (1-2 horas)**
1. Leer este ÍNDICE completo
2. Revisar PARTE1 → Sección A (Mapa de Conceptos) - entender variables
3. Revisar PARTE3 → Sección G (Integración) - entender qué cambiar

**Paso 2: Resolver Incertidumbres (1 semana)**
1. Responder **10 preguntas cerradas** de PARTE3 → Sección H
2. Validar acceso a APIs de FPLEME_M7_II y MAPS_M7
3. Si no hay acceso, confirmar uso de Plans B

**Paso 3: Implementación (2-3 semanas)**
1. Agregar 17 variables nuevas (PARTE3 → G.5)
2. Implementar 15 métodos nuevos (PARTE3 → G.3)
3. Reescribir UpdateCycles y DetectSignals (PARTE3 → G.4)
4. Seguir pseudocódigo de PARTE2 → C.1.9 (ETAPA 1 LONG)
5. Implementar filtro The_Wall (PARTE2 → D.4)
6. Implementar PAT scoring (PARTE2 → E.3)

**Paso 4: Testing (1 semana)**
1. Ejecutar 12 casos de prueba (PARTE3 → Sección I)
2. Backtest mínimo 6 meses
3. Validar: WR >58%, trades/día 2-4, PF >1.5

---

### Para Planificación de Proyecto

**Fase 1: Investigación (Semana 1)**
- Resolver bloqueadores #1, #2, #3
- Responder 10 preguntas cerradas
- Documentar APIs disponibles

**Fase 2: Implementación Core (Semana 2-3)**
- Implementar ETAPA 1 LONG/SHORT
- Implementar filtro The_Wall
- Implementar PAT scoring

**Fase 3: Integración y Testing (Semana 4)**
- Integrar con indicador v2.0
- Ejecutar casos de prueba
- Backtest comparativo

**Fase 4: Optimización (Semana 5-6)**
- Ajustar R:R (Mejora #4)
- Implementar ETAPA 2 (opcional)
- Validación walk-forward

---

## 🎯 CRITERIOS DE ÉXITO

### Mínimo Aceptable (Para Aprobar v3.0)
- ✅ Winrate: **>58%** (vs 54.9% actual)
- ✅ Trades/día: **2-4** (vs 5.7 actual)
- ✅ Profit Factor: **>1.5** (vs 1.23 actual)
- ✅ Expectancy: **>5 ticks/trade** (vs 3.92 actual)
- ✅ Z-Score: **>2.0** (vs 1.86 actual)

### Validaciones Cualitativas
- ✅ CASO #12 pasa: NO señales tardías (vs v2.0)
- ✅ CASO #3 pasa: The_Wall respetado (0% bloqueados post-ejecución)
- ✅ CASO #4 pasa: NO entradas desde extremos
- ✅ CASO #5 pasa: Timing estricto 2º/3er box

### Objetivo Ideal (Para Considerar Producción)
- 🎯 Winrate: **>62%**
- 🎯 Trades/día: **2-3**
- 🎯 Profit Factor: **>2.0**
- 🎯 Paper trading: **2 semanas consecutivas positivas**

---

## ⚠️ ADVERTENCIAS IMPORTANTES

### 1. NO Implementar Sin Resolver Bloqueadores
- BLOQUEADOR #1 y #2 son **CRÍTICOS**
- Sin acceso a FPLEME real o The_Wall → usar Plans B
- Validar Plans B con backtest antes de continuar

### 2. NO Modificar Lo Que Funciona
- Mantener 7 componentes listados en PARTE3 → G.1
- Especialmente: DetectRenkoSwings, UpdateShark, Bug Fix TP/SL

### 3. NO Optimizar Prematuramente
- Implementar ETAPA 1 primero, validar
- ETAPA 2 es OPCIONAL (NO prioritario)
- R:R ajustar DESPUÉS de validar detección de señales

### 4. NO Inventar Sin Documentar
- Si algo no está en especificación → marcar como ⚠️ NUEVO
- Documentar decisiones de diseño
- Actualizar casos de prueba

---

## 📚 ARCHIVOS RELACIONADOS

### En Knowledge Base
- `MFS_KNOWLEDGE_BASE.json` - Fuente principal de datos
- `RESUMEN_EJECUTIVO.md` - Estado actual y mejoras prioritarias
- `README.md` - Contexto del proyecto

### En Proyecto Principal
- `MFSScalpIndicator.cs` - Indicador actual v2.0
- `docs/DOCUMENTACION_FPLEME.md` - Conceptos FPLEME
- `docs/DOCUMENTACION_FPLEME_V2.md` - Especificación técnica FPLEME
- `docs/MAPA_DEL_INDICADOR.md` - Guía rápida

---

## 📞 SOPORTE Y REFERENCIAS

### Para Dudas Técnicas
1. **Conceptos FPLEME:** Revisar Parte 1 → Sección A (Tabla de 33 conceptos)
2. **Lógica de Estados:** Revisar Parte 1 → Sección B (Máquinas de estados)
3. **Implementación ETAPA 1:** Revisar Parte 2 → Sección C (Pseudocódigo completo)
4. **Filtros y PAT:** Revisar Parte 2 → Secciones D y E
5. **Integración:** Revisar Parte 3 → Sección G (Diffs detallados)

### Para Resolver Incertidumbres
- **10 Preguntas Cerradas:** Parte 3 → Sección H.1
- **Plans B Técnicos:** Parte 3 → H.1 (para cada bloqueador)

### Para Validación
- **12 Casos de Prueba:** Parte 3 → Sección I
- **Criterios de Éxito:** Este índice → Sección "Criterios de Éxito"

---

## ✅ CHECKLIST DE IMPLEMENTACIÓN

### Fase Preparación
- [ ] Leer 3 archivos de especificación completos
- [ ] Responder 10 preguntas cerradas (Parte 3 → H)
- [ ] Validar acceso a APIs FPLEME_M7_II y MAPS_M7
- [ ] Confirmar Plans B si no hay acceso

### Fase Desarrollo
- [ ] Agregar 17 variables nuevas (Parte 3 → G.5)
- [ ] Implementar CountConsecutivePositiveBoxes()
- [ ] Implementar CountConsecutiveNegativeBoxes()
- [ ] Implementar GetWallColor() con fallback
- [ ] Implementar 4 métodos Layer1-4 (PAT)
- [ ] Implementar EvaluateSignalQuality()
- [ ] Implementar DetectEtapa1Long() completo
- [ ] Implementar DetectEtapa1Short() completo
- [ ] Implementar ApplyTheWallFilter()
- [ ] Implementar DetectScenario() (PPM/MM)
- [ ] Reescribir UpdateCycles() simplificado
- [ ] Eliminar DetectSignals() y reemplazar llamadas
- [ ] Actualizar OnBarUpdate() con nuevo flujo
- [ ] Actualizar DrawPanel() para mostrar PAT score

### Fase Testing
- [ ] Caso #1: ETAPA 1 LONG válido en 2º box
- [ ] Caso #2: ETAPA 1 SHORT válido en 3er box
- [ ] Caso #3: ETAPA 1 bloqueado por The_Wall
- [ ] Caso #4: ETAPA 1 inválido desde extremo
- [ ] Caso #5: ETAPA 1 timing incorrecto (1er box)
- [ ] Caso #6: ETAPA 1 SHARK desalineado
- [ ] Caso #7: PAT MEDIUM (3/4)
- [ ] Caso #8: PAT LOW (2/4)
- [ ] Caso #9: PPM Buy detectado
- [ ] Caso #10: MM con SHARK confirma
- [ ] Caso #11: Invalidación ETAPA 1
- [ ] Caso #12: Comparación vs v2.0 (NO tardío)

### Fase Validación
- [ ] Backtest 6+ meses de datos
- [ ] WR >= 58%
- [ ] Trades/día 2-4
- [ ] Profit Factor >= 1.5
- [ ] Walk-forward analysis
- [ ] Paper trading 2 semanas

---

## 📈 PROYECCIÓN DE RESULTADOS

**Basado en implementación de Mejoras #1, #2, #3 (ETAPA 1 + The_Wall + PAT):**

### Escenario Conservador
- Winrate: 58-60% (+5% vs actual)
- Trades/día: 3-4 (-40% vs actual)
- Profit Factor: ~1.6 (+30% vs actual)
- **Estado:** Sistema RENTABLE

### Escenario Optimista
- Winrate: 62-65% (+10% vs actual)
- Trades/día: 2-3 (-60% vs actual)
- Profit Factor: ~2.0 (+63% vs actual)
- **Estado:** Sistema SÓLIDO y RENTABLE

---

## 🎓 LECCIONES CLAVE PARA IMPLEMENTADORES

1. **Flow → Cycle → Context → Signal** es la filosofía base
2. **ETAPA 1 al INICIO del ciclo** soluciona señales tardías
3. **The_Wall es inviolable** - nunca skipear este filtro
4. **PAT determina calidad** - no todas las señales son iguales
5. **Context > Signal** - PPM/MM más importante que patrón local
6. **Timing es crítico** - 2º/3er box, NO antes ni después
7. **NO desde extremos** - validar siempre fplemePrevValue
8. **SHARK alinea** - confirma ciclo real vs lateral

---

**FIN DEL ÍNDICE**

*Especificación Técnica Completa Lista Para Implementación*

**Documentos Técnicos:**
1. ✅ ESPEC_TECNICA_PARTE1_CONCEPTOS_Y_ESTADOS.md
2. ✅ ESPEC_TECNICA_PARTE2_REGLAS_Y_FILTROS.md
3. ✅ ESPEC_TECNICA_PARTE3_INTEGRACION_Y_TESTS.md
4. ✅ INDICE_ESPECIFICACION_TECNICA.md (este archivo)

**Total: ~100 páginas de especificación técnica con "cero ambigüedad"**

*Generado: 2026-01-18 por Arquitecto de Indicadores NT8*
