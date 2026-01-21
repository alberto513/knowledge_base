# 📚 DOCUMENTACIÓN FPLEME V2 - ESPECIFICACIÓN TÉCNICA Y PROGRAMÁTICA

> **Propósito:** Este documento sirve como especificación técnica completa y objetivo para la implementación de cualquier código C# relacionado con FPLEME, ETAPA 1, ETAPA 2, y sistemas de trading derivados.

> **📄 Documentos de Referencia:** Existen documentos PDF de referencia disponibles que complementan esta documentación:
> - **ETAPA 1.pdf** y **ETAPA 2.pdf**: Documentación detallada de las etapas de trading
> - **MM.pdf**, **MM - PDF.pdf**: Información sobre MM (MAP com MAP) - Divergencia
> - **PDF PPM.pdf**, **PDF PPM (1).pdf**, **Check PPM.pdf**: Información sobre PPM (Progressão de Preço em MAP) - Convergencia
> - **PDF FPLEME (1).pdf**, **PDF FPLEME (3).pdf**: Documentación adicional de FPLEME
> - **PDF Maps.pdf**: Documentación detallada de MAPS
> - **PDF VX (2).pdf**, **PDF VX (3).pdf**, **VX M14 (1).pdf**: Documentación de VX M2
> 
> Estos documentos deben ser consultados para obtener información visual, ejemplos gráficos y detalles adicionales que complementan esta especificación técnica programática.

---

## 🎯 ÍNDICE

1. [Arquitectura General](#1-arquitectura-general)
2. [FPLEME: Definición Técnica](#2-fpleme-definición-técnica)
   - 2.1 Definición Conceptual e Importancia
   - 2.2 Propiedades Técnicas (Niveles, Estados)
   - 2.3 Lógica de Cambio de Color (Ciclo)
   - 2.4 Reglas de Usabilidad: Cuándo NO Operar
3. [ETAPA 1: Lógica Completa](#3-etapa-1-lógica-completa)
   - 3.1 Definición Conceptual y Mejor Momento para Trade
   - 3.2 ETAPA 1 Compradora
   - 3.3 ETAPA 1 Vendedora
   - 3.4 Filtro de Boxes Válidos
3B. [ETAPA 2: Lógica Completa](#3b-etapa-2-lógica-completa)
   - 3B.10 Filtro de Escenario para ETAPA 2
     - 3B.10.1 Integración con Escenarios PPM y MM
     - 3B.10.2 ETAPA 2 en Contexto MM: Reglas de Confirmación con SHARK
4. [SHARK: Sistema de Confirmación](#4-shark-sistema-de-confirmación)
   - 4.1 Definición Conceptual
   - 4.2 Estados de SHARK
   - 4.3 Post-its Amarillos en la Línea SHARK
   - 4.4 Colores en Plataforma NinjaTrader
   - 4.5 Movimientos Lateralizados
5. [Timing de Entrada](#5-timing-de-entrada)
6. [Gestión de Stop Loss](#6-gestión-de-stop-loss)
7. [Filtros de Calidad y Escenarios](#7-filtros-de-calidad-y-escenarios)
   - 7.1 Comparativo de Ciclos de Fuerza
   - 7.2 Escenarios PPM (Convergencia) y MM (Divergencia)
     - 7.2.1 PPM (Progressão de Preço em MAP) - Convergencia
       - 7.2.1.1 PPM COMPRA - Checklist (6 Reglas)
       - 7.2.1.2 PPM VENDA - Checklist (6 Reglas)
       - 7.2.1.3 Relación de PPM con Fases del Mercado
         - 7.2.1.3.1 Acumulação (Acumulación)
         - 7.2.1.3.2 Início de Alta (Inicio de Alta)
         - 7.2.1.3.3 Alta Forte (Alta Fuerte)
         - 7.2.1.3.4 Distribuição (Distribución)
         - 7.2.1.3.5 Início de Baixa (Inicio de Baja)
         - 7.2.1.3.6 Baixa Forte (Baja Fuerte)
         - 7.2.1.3.7 Reacumulação y Redistribuição
     - 7.2.1 PPM (Progressão de Preço em MAP) - Convergencia
     - 7.2.2 MM (MAP com MAP) - Divergencia
       - 7.2.2.1 Reglas para Ciclos Compradores en MM
       - 7.2.2.2 Reglas para Ciclos Vendedores en MM
       - 7.2.2.3 Recomendaciones para MM
       - 7.2.2.4 Advertencias para MM
   - 7.3 MAPS: Sistema de Mapeo Inteligente
     - 7.3.1 Definición Conceptual
     - 7.3.2 Nomenclatura de MAPS
     - 7.3.3 Regla de Volatilidad para Líneas Extendidas
     - 7.3.4 Consideraciones sobre MAPS
   - 7.4 The_Wall como Filtro de Seguridad
     - 7.4.1 Definición Conceptual
     - 7.4.2 Estados y Colores de The_Wall
     - 7.4.3 Reglas de The_Wall por Color
     - 7.4.4 Advertencia sobre Extremos
   - 7.5 VX M2: CORES, NOMENCLATURA E USABILIDADE
     - 7.5.0 Definición y Utilidad de VX M2
     - 7.5.1 Nomenclatura de VX M2
     - 7.5.2 Colores de VX M2
     - 7.5.3 Usabilidad de VX M2
       - 7.5.3.1 Rompimiento de Líneas Horizontales (MAPs)
       - 7.5.3.2 Saldo Necesario para Rompimiento
       - 7.5.3.3 Identificación de The_Wall cruzando MAP
       - 7.5.3.4 Post-its Amarillos en The_Wall del VX
       - 7.5.3.5 Ejemplos de No Rompimiento
   - 7.6 Funciones Inteligentes de MAPS
     - 7.6.1 Range (Rango)
     - 7.6.2 Problines (Líneas Probabilísticas)
     - 7.6.3 Pullback_lines (Líneas de Compradores y Vendedores)
     - 7.6.4 Coloração (Colores de MAPS)
8. [Post-its y Señales Visuales](#8-post-its-y-señales-visuales)
   - 8.1 Niveles Destacados (Etiquetas)
   - 8.2 Tipos de Post-it (FPLEME y SHARK)
     - 8.2.3 Post-its Amarillos en The_Wall del VX
   - 8.3 Lógica de Visualización
9. [APIs y Contratos de Código](#9-apis-y-contratos-de-código)
   - 9.1 Interfaz Principal de FPLEME
   - 9.2 Interfaz de ETAPA 1 Detector
   - 9.2B Interfaz de ETAPA 2 Detector
   - 9.3 Interfaz de Timing de Entrada
   - 9.4 Interfaz de Gestión de Riesgo
   - 9.5 Interfaz de MAPS Engine
   - 9.6.1 Interfaz de The_Wall del VX
   - 9.6.2 Interfaz de VX M2 Engine
   - 9.6.3 Interfaz de VX Breakout Detector
   - 9.6 Interfaz de The_Wall Filter
   - 9.7 Interfaz de Probline Detector
   - 9.8 Interfaz de Pullback Lines
10. [Pseudocódigo y Algoritmos](#10-pseudocódigo-y-algoritmos)
11. [Casos de Prueba y Validaciones](#11-casos-de-prueba-y-validaciones)
12. [Estructuras de Datos Completas](#12-estructuras-de-datos-completas)
13. [Parámetros de Configuración](#13-parámetros-de-configuración)
   - 13.1 FPLEME_M7_II - Parámetros de Configuración
   - 13.2 VX_M7 - Parámetros de Configuración
   - 13.3 MAPS_M7 - Parámetros de Configuración
   - 13.4 STOP_ABS_DEFAULT - Parámetros de Configuración
   - 13.5 HERTZ_N_DEFAULT - Configuración
   - 13.6 RENKOBRZ - Configuración
   - 13.7 Valores por Defecto Recomendados
14. [Conclusión y Próximos Pasos](#14-conclusión-y-próximos-pasos)

---

## 1. ARQUITECTURA GENERAL

### 1.1 Componentes Principales

```
FPLEME System
├── FPLEME Engine (Cálculo de valores y niveles)
├── SHARK Engine (Confirmación de ciclos)
├── ETAPA 1 Detector (Detección de oportunidades de inicio de ciclo)
├── ETAPA 2 Detector (Detección de oportunidades post-inicio)
├── Order Placement Logic (Posicionamiento de órdenes)
├── Risk Management (Stop Loss, Take Profit)
├── Quality Filters (PPM, MM, The_Wall)
└── Visual Signals (Post-its, marcadores)
```

### 1.2 Flujo de Datos

```
Price Data (Renko Bars)
    ↓
FPLEME Calculation
    ↓
SHARK Calculation
    ↓
ETAPA 1 Detection OR ETAPA 2 Detection
    ↓
Quality Filters (PPM/MM/The_Wall)
    ↓
Order Placement Decision
    ↓
Risk Management Application
```

---

## 2. FPLEME: DEFINICIÓN TÉCNICA

### 2.1 Definición Conceptual

**FPLEME** es un indicador que oscila entre niveles -12.00 y +12.00, representando la fuerza direccional del mercado.

### 2.1.1 Importancia de FPLEME frente al Ciclo de Precio

**El FPLEME es esencial** porque observar solo si el box del Renko es positivo o negativo **NO es suficiente** para determinar la dirección del mercado.

**Funcionalidades clave:**
- Ayuda a identificar el **inicio de grandes movimientos**.
- Hace el uso más **eficaz** al proporcionar contexto más allá del simple color del box.
- Transforma el flujo de mercado en **ciclos** identificables.

**Regla fundamental:** El FPLEME lee el flujo de mercado y lo transforma en ciclos. Esta funcionalidad permite identificar el inicio y el fin de cada movimiento, proporcionando un mejor gerenciamiento de riesgo y mayor seguridad en la elección de trades.

### 2.1.2 Las Dos Líneas Principales

La herramienta FPLEME posee **dos líneas principales**:

1. **Línea del FPLEME (línea más fina):**
   - Cuanto más alta, mayor la fuerza de compra.
   - Cuanto más baja, mayor la fuerza de venta.
   - Es la línea primaria del indicador.

2. **Línea del SHARK (línea más gruesa):**
   - Funciona de la misma forma: cuanto más alta, mayor la fuerza de compra; cuanto más baja, mayor la fuerza de venta.
   - Estas dos líneas eran herramientas separadas en el pasado, pero actualmente son complementarias y aparecen juntas en el gráfico.
   - Ver sección 4 para más detalles sobre SHARK.

```csharp
public class FplemeLineProperties
{
    public double Thickness { get; set; } = 1.0;  // Línea más fina
    public FplemeLineColor Color { get; set; }
    public double CurrentValue { get; set; }
}

public class SharkLineProperties
{
    public double Thickness { get; set; } = 2.0;  // Línea más gruesa
    public SharkState State { get; set; }
    public double CurrentValue { get; set; }
}
```

### 2.2 Propiedades Técnicas

#### 2.2.1 Niveles Críticos (Constantes)

```csharp
public class FplemeConstants
{
    public const double LEVEL_EXTREME_HIGH = 12.00;
    public const double LEVEL_HIGH = 8.00;
    public const double LEVEL_MEDIUM_HIGH = 6.00;
    public const double LEVEL_CONFIRMATION_LONG = 4.00;  // Confirmación ciclo comprador
    public const double LEVEL_SUPPORT = 3.00;
    public const double LEVEL_EQUILIBRIUM = 0.00;        // Línea de cambio
    public const double LEVEL_SUPPORT_NEG = -3.00;
    public const double LEVEL_CONFIRMATION_SHORT = -4.00; // Confirmación ciclo vendedor
    public const double LEVEL_MEDIUM_LOW = -6.00;
    public const double LEVEL_LOW = -8.00;
    public const double LEVEL_EXTREME_LOW = -12.00;
}
```

#### 2.2.2 Estado de FPLEME

```csharp
public enum FplemeState
{
    Unknown = 0,
    ExtremeHigh = 1,        // >= +12.00
    High = 2,               // >= +8.00 && < +12.00
    MediumHigh = 3,         // >= +6.00 && < +8.00
    ConfirmationLong = 4,   // >= +4.00 && < +6.00
    Support = 5,            // >= +3.00 && < +4.00
    Equilibrium = 6,        // > -3.00 && < +3.00
    SupportNeg = 7,         // > -4.00 && <= -3.00
    ConfirmationShort = 8,  // > -6.00 && <= -4.00
    MediumLow = 9,          // > -8.00 && <= -6.00
    Low = 10,               // > -12.00 && <= -8.00
    ExtremeLow = 11         // <= -12.00
}
```

### 2.3 Lógica de Cambio de Color (Ciclo)

#### 2.3.1 Reglas de Cambio de Color de la Línea FPLEME

**Regla fundamental:** Los niveles +4.00 y -4.00 son los puntos exactos donde la línea del FPLEME cambia de color.

**Cambio de Verde a Rojo:**
- Ocurre cuando la línea cruza el nivel +4.00 y llega al 0.00.
- Programáticamente: `PreviousValue >= +4.00` y `CurrentValue <= 0.00`.

**Cambio de Rojo a Verde:**
- Ocurre cuando la línea cruza el nivel -4.00 y llega al 0.00.
- Programáticamente: `PreviousValue <= -4.00` y `CurrentValue >= 0.00`.

```csharp
public enum FplemeLineColor
{
    Unknown = 0,
    Green = 1,      // Ciclo comprador (fuerza de compra)
    Red = 2         // Ciclo vendedor (fuerza de venta)
}

public FplemeLineColor DetermineLineColor(double currentValue, double previousValue)
{
    // Cambio de verde a rojo: cruza +4.00 hacia 0.00
    if (previousValue >= FplemeConstants.LEVEL_CONFIRMATION_LONG && 
        currentValue <= FplemeConstants.LEVEL_EQUILIBRIUM)
    {
        return FplemeLineColor.Red;
    }
    
    // Cambio de rojo a verde: cruza -4.00 hacia 0.00
    if (previousValue <= FplemeConstants.LEVEL_CONFIRMATION_SHORT && 
        currentValue >= FplemeConstants.LEVEL_EQUILIBRIUM)
    {
        return FplemeLineColor.Green;
    }
    
    // Mantener color actual basado en posición
    if (currentValue >= FplemeConstants.LEVEL_CONFIRMATION_LONG)
    {
        return FplemeLineColor.Green;
    }
    else if (currentValue <= FplemeConstants.LEVEL_CONFIRMATION_SHORT)
    {
        return FplemeLineColor.Red;
    }
    
    // Entre -4.00 y +4.00: mantener color anterior o determinar por contexto
    return FplemeLineColor.Unknown;
}
```

#### 2.3.2 Colores en Plataforma NinjaTrader

**IMPORTANTE:** En la plataforma NinjaTrader, los colores de visualización son diferentes a los colores conceptuales:

```csharp
public class NinjaTraderColorMapping
{
    // Ciclo comprador: representado por AZUL (no verde)
    public static Color BuyerCycleColor = Colors.Blue;
    
    // Ciclo vendedor: representado por ROSA/MAGENTA (no rojo)
    public static Color SellerCycleColor = Colors.Magenta; // o Colors.Pink
}
```

**Regla de implementación:**
- Internamente, el sistema puede usar `Green/Red` para lógica.
- Visualmente en NinjaTrader, debe renderizarse como `Blue/Magenta`.
- Esta diferencia es solo visual, no afecta la lógica programática.

#### 2.3.3 Grosor de Línea como Indicador de Fuerza

**Regla:** Cuando hay mucha fuerza direccional, la línea del FPLEME se vuelve más gruesa, reforzando la intensidad de la fuerza.

```csharp
public class FplemeLineThickness
{
    public double CalculateLineThickness(double currentValue, double velocity, double trendStrength)
    {
        // Grosor base
        double baseThickness = 1.0;
        
        // Calcular fuerza direccional
        double directionalForce = Math.Abs(currentValue) + (velocity * 0.5) + (trendStrength * 0.3);
        
        // Grosor aumenta con fuerza direccional
        if (directionalForce > 8.0)
        {
            return baseThickness * 3.0; // Muy gruesa (fuerza extrema)
        }
        else if (directionalForce > 6.0)
        {
            return baseThickness * 2.5; // Gruesa (fuerza alta)
        }
        else if (directionalForce > 4.0)
        {
            return baseThickness * 2.0; // Media-gruesa (fuerza media)
        }
        
        return baseThickness; // Normal
    }
}
```

#### 2.3.4 Ciclo Comprador (Verde/Azul)

**Condiciones para activar ciclo comprador:**

```csharp
public bool IsBuyerCycle()
{
    // Condición 1: FPLEME debe estar en +4.00 o superior
    bool condition1 = (CurrentValue >= FplemeConstants.LEVEL_CONFIRMATION_LONG);
    
    // Condición 2: FPLEME cruzó desde -4.00 hacia 0.00
    bool condition2 = (PreviousValue < FplemeConstants.LEVEL_CONFIRMATION_SHORT) &&
                      (CurrentValue >= FplemeConstants.LEVEL_EQUILIBRIUM);
    
    // Restricción: NO puede iniciar desde niveles extremos
    bool notFromExtreme = (PreviousValue > FplemeConstants.LEVEL_LOW) &&
                          (PreviousValue < FplemeConstants.LEVEL_HIGH);
    
    return (condition1 || condition2) && notFromExtreme;
}
```

#### 2.3.5 Ciclo Vendedor (Rojo/Rosa)

**Condiciones para activar ciclo vendedor:**

```csharp
public bool IsSellerCycle()
{
    // Condición 1: FPLEME debe estar en -4.00 o inferior
    bool condition1 = (CurrentValue <= FplemeConstants.LEVEL_CONFIRMATION_SHORT);
    
    // Condición 2: FPLEME cruzó desde +4.00 hacia 0.00
    bool condition2 = (PreviousValue > FplemeConstants.LEVEL_CONFIRMATION_LONG) &&
                      (CurrentValue <= FplemeConstants.LEVEL_EQUILIBRIUM);
    
    // Restricción: NO puede iniciar desde niveles extremos
    bool notFromExtreme = (PreviousValue > FplemeConstants.LEVEL_LOW) &&
                          (PreviousValue < FplemeConstants.LEVEL_HIGH);
    
    return (condition1 || condition2) && notFromExtreme;
}
```

### 2.4 Reglas de Usabilidad: Cuándo NO Operar

#### 2.4.1 Regla: NO Adelantarse al Ciclo

**Concepto fundamental:** Observar solo si el box del Renko es positivo o negativo NO es suficiente para determinar la dirección del mercado. FPLEME ayuda a identificar el inicio de grandes movimientos.

**Regla para LONG (Compra):**
- **NO comprar** cuando FPLEME está en configuración de fuerza vendedora (rojo/rosa).
- **NO comprar** cuando FPLEME está descendiendo desde niveles altos hacia 0.00.
- **Esperar** a que FPLEME confirme cambio de color (de rojo a verde) y toque 0.00.

```csharp
public bool CanConsiderLongEntry(FplemeData fpleme)
{
    // NO comprar si FPLEME está en zona vendedora fuerte
    if (fpleme.CurrentValue <= FplemeConstants.LEVEL_CONFIRMATION_SHORT)
    {
        return false; // FPLEME en zona vendedora
    }
    
    // NO comprar si FPLEME está descendiendo desde +4.00 hacia 0.00
    if (fpleme.PreviousValue >= FplemeConstants.LEVEL_CONFIRMATION_LONG &&
        fpleme.CurrentValue < fpleme.PreviousValue &&
        fpleme.CurrentValue > FplemeConstants.LEVEL_EQUILIBRIUM)
    {
        return false; // FPLEME descendiendo, no adelantarse
    }
    
    return true; // Condiciones básicas cumplidas
}
```

**Regla para SHORT (Venta):**
- **NO vender** cuando FPLEME está en configuración de fuerza compradora (verde/azul).
- **NO vender** cuando FPLEME está ascendiendo desde niveles bajos hacia 0.00.
- **Esperar** a que FPLEME confirme cambio de color (de verde a rojo) y toque 0.00.

```csharp
public bool CanConsiderShortEntry(FplemeData fpleme)
{
    // NO vender si FPLEME está en zona compradora fuerte
    if (fpleme.CurrentValue >= FplemeConstants.LEVEL_CONFIRMATION_LONG)
    {
        return false; // FPLEME en zona compradora
    }
    
    // NO vender si FPLEME está ascendiendo desde -4.00 hacia 0.00
    if (fpleme.PreviousValue <= FplemeConstants.LEVEL_CONFIRMATION_SHORT &&
        fpleme.CurrentValue > fpleme.PreviousValue &&
        fpleme.CurrentValue < FplemeConstants.LEVEL_EQUILIBRIUM)
    {
        return false; // FPLEME ascendiendo, no adelantarse
    }
    
    return true; // Condiciones básicas cumplidas
}
```

### 2.4 Configuración por Defecto de FPLEME

**IMPORTANTE:** Todas las condiciones y niveles documentados están basados en la configuración **"padrão de fábrica"** (default de fábrica) de FPLEME:

```csharp
public class FplemeDefaultConfig
{
    // Parámetros que deben estar en su valor por defecto
    public const bool XR_ENABLED = false;          // XR -> Não (desactivado)
    public const bool MODO_RAPIDO = false;         // Modo Rápido -> Não (desactivado)
    
    // Observación: Los puntos y condiciones presentados están basados en 
    // la lectura del FPLEME con parámetros originales, sin alteraciones.
    // Cualquier cambio en estos parámetros afectará los niveles y triggers.
}
```

### 2.5 Estructura de Datos

```csharp
public class FplemeData
{
    public double CurrentValue { get; set; }
    public double PreviousValue { get; set; }
    public FplemeState CurrentState { get; set; }
    public FplemeState PreviousState { get; set; }
    public bool IsBuyerCycle { get; set; }
    public bool IsSellerCycle { get; set; }
    public DateTime LastUpdate { get; set; }
    public int BarsSinceStateChange { get; set; }
}
```

---

## 3. ETAPA 1: LÓGICA COMPLETA

### 3.1 Definición Conceptual

**ETAPA 1** es el momento de inicio de un potencial ciclo comprador o vendedor, confirmado cuando FPLEME sale de niveles críticos (-4.00 o +4.00) y alcanza 0.00.

**Los Post-its en los niveles +4.00 y -4.00 son atajos visuales** que muestran que la herramienta cambió de color y tocó el nivel 0.00, representando lo que llamamos ETAPA 1.

**ETAPA 1 marca el inicio de un posible ciclo comprador o vendedor.**

**REGLA CRÍTICA:** El Post-it aislado NO es un set-up. Su interpretación debe ser hecha en conjunto con otros factores, explicados parcialmente en este módulo y detallados en los próximos.

### 3.1.1 El Mejor Momento para un Trade (ETAPA 1)

**El mejor momento para un trade** es el **inicio de ciclo en ETAPA 1**, que ocurre cuando:

#### Para LONG (Compra):
- **Niveles +4.00 confirmando el nivel 0.00.**
- FPLEME sale de -4.00 y alcanza 0.00.
- En esta condición, las líneas del FPLEME y del SHARK tendrán **coloraciones alineadas**, representando la fuerza del mercado.
- Este alineamiento aumenta las chances de movimientos fluidos.

#### Para SHORT (Venta):
- **Niveles -4.00 confirmando el nivel 0.00.**
- FPLEME sale de +4.00 y alcanza 0.00.
- En esta condición, las líneas del FPLEME y del SHARK tendrán **coloraciones alineadas**, representando la fuerza del mercado.
- Este alineamiento aumenta las chances de movimientos fluidos.

```csharp
public class BestMomentForTrade
{
    public bool IsBestMomentForLong(FplemeData fpleme, SharkData shark)
    {
        // Condición 1: Niveles +4.00 confirmando 0.00
        bool plus4ConfirmingZero = (fpleme.PreviousValue <= FplemeConstants.LEVEL_CONFIRMATION_SHORT) &&
                                   (fpleme.CurrentValue >= FplemeConstants.LEVEL_EQUILIBRIUM);
        
        // Condición 2: Colores alineados (FPLEME y SHARK en misma dirección)
        bool colorsAligned = AreColorsAlignedForLong(fpleme, shark);
        
        return plus4ConfirmingZero && colorsAligned;
    }
    
    public bool IsBestMomentForShort(FplemeData fpleme, SharkData shark)
    {
        // Condición 1: Niveles -4.00 confirmando 0.00
        bool minus4ConfirmingZero = (fpleme.PreviousValue >= FplemeConstants.LEVEL_CONFIRMATION_LONG) &&
                                    (fpleme.CurrentValue <= FplemeConstants.LEVEL_EQUILIBRIUM);
        
        // Condición 2: Colores alineados (FPLEME y SHARK en misma dirección)
        bool colorsAligned = AreColorsAlignedForShort(fpleme, shark);
        
        return minus4ConfirmingZero && colorsAligned;
    }
    
    private bool AreColorsAlignedForLong(FplemeData fpleme, SharkData shark)
    {
        // Para LONG: FPLEME debe estar en zona compradora Y SHARK debe estar azul
        bool fplemeBuyer = fpleme.IsBuyerCycle || 
                          (fpleme.CurrentValue >= FplemeConstants.LEVEL_CONFIRMATION_SHORT);
        bool sharkBuyer = shark.State == SharkState.Blue;
        
        return fplemeBuyer && sharkBuyer;
    }
    
    private bool AreColorsAlignedForShort(FplemeData fpleme, SharkData shark)
    {
        // Para SHORT: FPLEME debe estar en zona vendedora Y SHARK debe estar rosa/rojo
        bool fplemeSeller = fpleme.IsSellerCycle || 
                           (fpleme.CurrentValue <= FplemeConstants.LEVEL_CONFIRMATION_LONG);
        bool sharkSeller = shark.State == SharkState.Red;
        
        return fplemeSeller && sharkSeller;
    }
}
```

### 3.2 ETAPA 1 Compradora

**OBSERVACIÓN CRÍTICA (de PDFs):** Los puntos y consideraciones presentados están basados en la lectura del FPLEME con los parámetros originales, sin ninguna alteración — es decir, en el **"padrão de fábrica"** (configuración de fábrica). Esto significa que el **XR está desactivado** y el **Modo Rápido también está desligado** (XR -> Não y Modo Rápido -> Não).

**IMPORTANTE:** Si nunca alteraste estas configuraciones en tu FPLEME, puedes estar tranquilo, pues ya estará configurado exactamente como en las representaciones presentadas.

#### 3.2.1 Definición Programática

```csharp
public class Etapa1Buyer
{
    // Condición principal: FPLEME sale de -4.00 y alcanza 0.00
    public bool IsEtapa1Buyer(FplemeData fpleme, RenkoBar currentBar, RenkoBar[] recentBars)
    {
        // Validación 1: FPLEME debe haber salido de -4.00
        bool exitedMinus4 = (fpleme.PreviousValue <= FplemeConstants.LEVEL_CONFIRMATION_SHORT) &&
                            (fpleme.CurrentValue > FplemeConstants.LEVEL_CONFIRMATION_SHORT);
        
        // Validación 2: FPLEME debe alcanzar 0.00
        bool reachedZero = fpleme.CurrentValue >= FplemeConstants.LEVEL_EQUILIBRIUM;
        
        // Validación 3: Debe ocurrir en 2º o 3º box positivo
        int positiveBoxIndex = GetPositiveBoxIndex(recentBars);
        bool correctBoxCount = (positiveBoxIndex == 2) || (positiveBoxIndex == 3);
        
        // Validación 4: NO puede iniciar desde -12.00 o -8.00 en 1 solo box
        bool notFromExtreme = !CannotReachZeroInOneBox(fpleme.PreviousValue);
        
        return exitedMinus4 && reachedZero && correctBoxCount && notFromExtreme;
    }
    
    private bool CannotReachZeroInOneBox(double previousValue)
    {
        // Si está en -12.00 o -8.00, necesita más de 1 box para llegar a 0.00
        return (previousValue <= FplemeConstants.LEVEL_LOW) ||
               (previousValue <= FplemeConstants.LEVEL_EXTREME_LOW);
    }
    
    private int GetPositiveBoxIndex(RenkoBar[] bars)
    {
        int positiveCount = 0;
        for (int i = bars.Length - 1; i >= 0; i--)
        {
            if (bars[i].IsPositive)
            {
                positiveCount++;
            }
            else
            {
                break; // Se detiene al encontrar un box negativo
            }
        }
        return positiveCount;
    }
}
```

#### 3.2.2 Estructura de Datos

```csharp
public class Etapa1BuyerData
{
    public bool IsActive { get; set; }
    public bool IsConfirmed { get; set; }
    public int ConfirmationBoxIndex { get; set; } // 2 o 3
    public DateTime ActivationTime { get; set; }
    public double ActivationPrice { get; set; }
    public FplemeData FplemeAtActivation { get; set; }
    public PostItType PostItType { get; set; } // Destacado u opaco
}
```

### 3.3 ETAPA 1 Vendedora

#### 3.3.1 Definición Programática

```csharp
public class Etapa1Seller
{
    // Condición principal: FPLEME sale de +4.00 y alcanza 0.00
    public bool IsEtapa1Seller(FplemeData fpleme, RenkoBar currentBar, RenkoBar[] recentBars)
    {
        // Validación 1: FPLEME debe haber salido de +4.00
        bool exitedPlus4 = (fpleme.PreviousValue >= FplemeConstants.LEVEL_CONFIRMATION_LONG) &&
                           (fpleme.CurrentValue < FplemeConstants.LEVEL_CONFIRMATION_LONG);
        
        // Validación 2: FPLEME debe alcanzar 0.00
        bool reachedZero = fpleme.CurrentValue <= FplemeConstants.LEVEL_EQUILIBRIUM;
        
        // Validación 3: Debe ocurrir en 2º o 3º box negativo
        int negativeBoxIndex = GetNegativeBoxIndex(recentBars);
        bool correctBoxCount = (negativeBoxIndex == 2) || (negativeBoxIndex == 3);
        
        // Validación 4: NO puede iniciar desde +12.00 o +8.00 en 1 solo box
        bool notFromExtreme = !CannotReachZeroInOneBox(fpleme.PreviousValue);
        
        return exitedPlus4 && reachedZero && correctBoxCount && notFromExtreme;
    }
    
    private bool CannotReachZeroInOneBox(double previousValue)
    {
        // Si está en +12.00 o +8.00, necesita más de 1 box para llegar a 0.00
        return (previousValue >= FplemeConstants.LEVEL_HIGH) ||
               (previousValue >= FplemeConstants.LEVEL_EXTREME_HIGH);
    }
    
    private int GetNegativeBoxIndex(RenkoBar[] bars)
    {
        int negativeCount = 0;
        for (int i = bars.Length - 1; i >= 0; i--)
        {
            if (bars[i].IsNegative)
            {
                negativeCount++;
            }
            else
            {
                break; // Se detiene al encontrar un box positivo
            }
        }
        return negativeCount;
    }
}
```

#### 3.3.2 Estructura de Datos

```csharp
public class Etapa1SellerData
{
    public bool IsActive { get; set; }
    public bool IsConfirmed { get; set; }
    public int ConfirmationBoxIndex { get; set; } // 2 o 3
    public DateTime ActivationTime { get; set; }
    public double ActivationPrice { get; set; }
    public FplemeData FplemeAtActivation { get; set; }
    public PostItType PostItType { get; set; } // Destacado u opaco
}
```

### 3.4 Filtro de Boxes Válidos

#### 3.4.1 Boxes Positivos para LONG

```csharp
public bool IsValidPositiveBoxForLong(FplemeData fpleme, RenkoBar bar)
{
    // NO operar si FPLEME está en -12.00 o -8.00
    if (fpleme.CurrentValue <= FplemeConstants.LEVEL_LOW)
    {
        return false;
    }
    
    // NO operar si no hay chance de ETAPA 1
    // FPLEME debe estar en -4.00 o superior para tener chance
    if (fpleme.CurrentValue < FplemeConstants.LEVEL_CONFIRMATION_SHORT)
    {
        return false;
    }
    
    // El box debe ser positivo
    if (!bar.IsPositive)
    {
        return false;
    }
    
    return true;
}
```

#### 3.4.2 Boxes Negativos para SHORT

### 3.5 Importancia de ETAPA 1 dentro de Escenarios

**REGLA FUNDAMENTAL (de PDFs):** "Siempre una ETAPA 1 dentro de un escenario será más segura que una ETAPA 1 aislada."

**¿Qué significa esto?**

Prioriza realizar ETAPA 1 cuando estén dentro de escenarios de **PPM (Progressão de Preço em MAP)** o **MM (MAP com MAP)**.

**Ejemplo práctico:**
- **ETAPA 1 aislada:** Movimiento de alta sin contexto → menor probabilidad de éxito
- **ETAPA 1 dentro de PPM:** Entrada de ETAPA 1 dentro de un escenario de Progressão de Preço em MAP → mayor probabilidad de éxito

**Por qué es importante:**
Esta información es **extremadamente valiosa**, porque es lo que ayudará a identificar buenas entradas. **El secreto de un trade bien-sucedido está en el contexto del escenario.**

**Advertencia sobre contexto incorrecto:**
Si el escenario está dentro de un PPM na venda (venta), las entradas compradoras quedan fuera de contexto y resultan, frecuentemente, en movimientos cortos y de menor probabilidad de éxito.

**Ejemplo:**
- Si el último movimiento de compra tiene la The_Wall en color rosa (magenta/fúcsia), es más un indicador de seguridad mostrando que aún no hay posibilidad de compras seguras.
- En ese caso, sería mucho más inteligente y seguro realizar una ETAPA 1 na venda que intentar una ETAPA 1 na compra, porque el escenario es de Progresso de Preço em MAP na venda.

```csharp
public class Etapa1ScenarioFilter
{
    public SignalQuality EvaluateEtapa1WithScenario(
        Etapa1Data etapa1,
        PpmScenario ppm,
        bool isMm,
        WallMapsData wallMaps)
    {
        // ETAPA 1 dentro de escenario = más segura
        bool withinScenario = (ppm != PpmScenario.None) || isMm;
        
        if (!withinScenario)
        {
            return SignalQuality.Medium; // ETAPA 1 aislada (menos segura)
        }
        
        // Validar alineación con el escenario
        if (etapa1.IsBuyer)
        {
            // Para LONG: escenario debe ser PPM Buy o MM
            bool aligned = (ppm == PpmScenario.PpmBuy) || isMm;
            
            // The_Wall no debe estar en contra
            bool wallOk = (wallMaps.Color != WallMapsColor.Pink) && 
                         (wallMaps.Color != WallMapsColor.Magenta);
            
            if (aligned && wallOk)
            {
                return SignalQuality.High; // ETAPA 1 dentro de escenario favorable
            }
            else
            {
                return SignalQuality.Low; // ETAPA 1 fuera de contexto
            }
        }
        else if (etapa1.IsSeller)
        {
            // Para SHORT: escenario debe ser PPM Sell o MM
            bool aligned = (ppm == PpmScenario.PpmSell) || isMm;
            
            // The_Wall no debe estar en contra
            bool wallOk = (wallMaps.Color != WallMapsColor.Green);
            
            if (aligned && wallOk)
            {
                return SignalQuality.High; // ETAPA 1 dentro de escenario favorable
            }
            else
            {
                return SignalQuality.Low; // ETAPA 1 fuera de contexto
            }
        }
        
        return SignalQuality.Unknown;
    }
    
    public string GetRecommendation(Etapa1Data etapa1, PpmScenario ppm, WallMapsData wall)
    {
        if (etapa1.IsBuyer && ppm == PpmScenario.PpmSell)
        {
            return "⚠️ ADVERTENCIA: ETAPA 1 compradora en escenario PPM VENDA. " +
                   "Considerar ETAPA 1 vendedora en su lugar.";
        }
        
        if (etapa1.IsSeller && ppm == PpmScenario.PpmBuy)
        {
            return "⚠️ ADVERTENCIA: ETAPA 1 vendedora en escenario PPM COMPRA. " +
                   "Considerar ETAPA 1 compradora en su lugar.";
        }
        
        return "✅ ETAPA 1 alineada con el escenario.";
    }
}
```

```csharp
public bool IsValidNegativeBoxForShort(FplemeData fpleme, RenkoBar bar)
{
    // NO operar si FPLEME está en +12.00 o +8.00
    if (fpleme.CurrentValue >= FplemeConstants.LEVEL_HIGH)
    {
        return false;
    }
    
    // NO operar si no hay chance de ETAPA 1
    // FPLEME debe estar en +4.00 o inferior para tener chance
    if (fpleme.CurrentValue > FplemeConstants.LEVEL_CONFIRMATION_LONG)
    {
        return false;
    }
    
    // El box debe ser negativo
    if (!bar.IsNegative)
    {
        return false;
    }
    
    return true;
}
```

---

## 3B. ETAPA 2: LÓGICA COMPLETA

### 3B.1 Definición Conceptual

**ETAPA 2** es una estrategia de timing de mercado que permite una entrada **después** del inicio de un nuevo ciclo. Es una alternativa para traders que:
- No pudieron entrar en ETAPA 1
- Prefieren operar con más confirmaciones antes de tomar una decisión
- Buscan trades de tendencia con un perfil más conservador

**Diferencia clave con ETAPA 1:**
- **ETAPA 1:** Predictible (confirmación en 2º o 3º box)
- **ETAPA 2:** Reactiva (solo se identifica cuando ocurre)

### 3B.2 ETAPA 2 Compradora

#### 3B.2.1 Definición Programática

```csharp
public class Etapa2Buyer
{
    // Condición principal: FPLEME sale de +4.00 y alcanza +8.00
    public bool IsEtapa2Buyer(FplemeData fpleme, RenkoBar currentBar, RenkoBar[] recentBars)
    {
        // Validación 1: FPLEME debe haber salido de +4.00 (ya positivo)
        bool exitedPlus4 = (fpleme.PreviousValue >= FplemeConstants.LEVEL_CONFIRMATION_LONG) &&
                           (fpleme.PreviousValue < FplemeConstants.LEVEL_HIGH);
        
        // Validación 2: FPLEME debe alcanzar +8.00
        bool reachedPlus8 = fpleme.CurrentValue >= FplemeConstants.LEVEL_HIGH;
        
        // Validación 3: El movimiento debe ocurrir en un solo box
        // (diferencia con ETAPA 1: ETAPA 2 no requiere 2º o 3º box)
        
        // Validación 4: NO es ETAPA 2 si va de 0.00 a +4.00 (eso sería ETAPA 1)
        bool notFromZeroTo4 = !((fpleme.PreviousValue >= FplemeConstants.LEVEL_EQUILIBRIUM) &&
                                 (fpleme.PreviousValue < FplemeConstants.LEVEL_CONFIRMATION_LONG));
        
        // Validación 5: NO es ETAPA 2 si va de +8.00 a +12.00 (nivel extremo)
        bool notFrom8To12 = !((fpleme.PreviousValue >= FplemeConstants.LEVEL_HIGH) &&
                               (fpleme.PreviousValue < FplemeConstants.LEVEL_EXTREME_HIGH));
        
        return exitedPlus4 && reachedPlus8 && notFromZeroTo4 && notFrom8To12;
    }
    
    // Confirmación: ETAPA 2 solo se confirma cuando realmente ocurre (reactivo)
    public bool ConfirmEtapa2Buyer(FplemeData fpleme, RenkoBar confirmationBar)
    {
        // La confirmación ocurre en el mismo box donde FPLEME alcanza +8.00
        return IsEtapa2Buyer(fpleme, confirmationBar, null) && 
               (fpleme.CurrentValue >= FplemeConstants.LEVEL_HIGH);
    }
}
```

#### 3B.2.2 Estructura de Datos

```csharp
public class Etapa2BuyerData
{
    public bool IsActive { get; set; }
    public bool IsConfirmed { get; set; }
    public DateTime ActivationTime { get; set; }
    public double ActivationPrice { get; set; }
    public RenkoBar ConfirmationBar { get; set; }  // Box que confirmó ETAPA 2
    public FplemeData FplemeAtActivation { get; set; }
    public SharkState SharkAtActivation { get; set; }
    public EntryTimingMode TimingMode { get; set; } // Clásico o 2.2
}
```

### 3B.3 ETAPA 2 Vendedora

#### 3B.3.1 Definición Programática

```csharp
public class Etapa2Seller
{
    // Condición principal: FPLEME sale de -4.00 y alcanza -8.00
    public bool IsEtapa2Seller(FplemeData fpleme, RenkoBar currentBar, RenkoBar[] recentBars)
    {
        // Validación 1: FPLEME debe haber salido de -4.00 (ya negativo)
        bool exitedMinus4 = (fpleme.PreviousValue <= FplemeConstants.LEVEL_CONFIRMATION_SHORT) &&
                            (fpleme.PreviousValue > FplemeConstants.LEVEL_LOW);
        
        // Validación 2: FPLEME debe alcanzar -8.00
        bool reachedMinus8 = fpleme.CurrentValue <= FplemeConstants.LEVEL_LOW;
        
        // Validación 3: NO es ETAPA 2 si va de 0.00 a -4.00 (eso sería ETAPA 1)
        bool notFromZeroToMinus4 = !((fpleme.PreviousValue <= FplemeConstants.LEVEL_EQUILIBRIUM) &&
                                      (fpleme.PreviousValue > FplemeConstants.LEVEL_CONFIRMATION_SHORT));
        
        // Validación 4: NO es ETAPA 2 si va de -8.00 a -12.00 (nivel extremo)
        bool notFromMinus8ToMinus12 = !((fpleme.PreviousValue <= FplemeConstants.LEVEL_LOW) &&
                                         (fpleme.PreviousValue > FplemeConstants.LEVEL_EXTREME_LOW));
        
        return exitedMinus4 && reachedMinus8 && notFromZeroToMinus4 && notFromMinus8ToMinus12;
    }
    
    // Confirmación: ETAPA 2 solo se confirma cuando realmente ocurre (reactivo)
    public bool ConfirmEtapa2Seller(FplemeData fpleme, RenkoBar confirmationBar)
    {
        // La confirmación ocurre en el mismo box donde FPLEME alcanza -8.00
        return IsEtapa2Seller(fpleme, confirmationBar, null) && 
               (fpleme.CurrentValue <= FplemeConstants.LEVEL_LOW);
    }
}
```

#### 3B.3.2 Estructura de Datos

```csharp
public class Etapa2SellerData
{
    public bool IsActive { get; set; }
    public bool IsConfirmed { get; set; }
    public DateTime ActivationTime { get; set; }
    public double ActivationPrice { get; set; }
    public RenkoBar ConfirmationBar { get; set; }  // Box que confirmó ETAPA 2
    public FplemeData FplemeAtActivation { get; set; }
    public SharkState SharkAtActivation { get; set; }
    public EntryTimingMode TimingMode { get; set; } // Clásico o 2.2
}
```

### 3B.4 Confirmación con SHARK

**Regla fundamental:** Para ser considerada ETAPA 2 válida, el SHARK debe estar alineado con la dirección.

```csharp
public bool ValidateEtapa2WithShark(Etapa2Data etapa2, SharkData shark)
{
    if (etapa2.IsBuyer)
    {
        // ETAPA 2 Compradora: SHARK debe estar azul
        return shark.State == SharkState.Blue;
    }
    else if (etapa2.IsSeller)
    {
        // ETAPA 2 Vendedora: SHARK debe estar rojo
        return shark.State == SharkState.Red;
    }
    
    return false;
}

// Señal de salida: Si SHARK cambia de color después de entrar
public bool ShouldExitEtapa2Trade(TradePosition position, SharkData shark)
{
    if (position.Direction == TradeDirection.Long)
    {
        // Si SHARK se vuelve rojo, considerar salir
        return shark.State == SharkState.Red;
    }
    else if (position.Direction == TradeDirection.Short)
    {
        // Si SHARK se vuelve azul, considerar salir
        return shark.State == SharkState.Blue;
    }
    
    return false;
}
```

### 3B.5 Modos de Timing de Entrada para ETAPA 2

#### 3B.5.1 Timing Clásico (Más Conservador)

```csharp
public enum EntryTimingMode
{
    Classic = 0,     // Base del box anterior al que confirmó ETAPA 2
    Mode2_2 = 1      // Base del propio box que confirmó ETAPA 2
}

public class Etapa2ClassicTiming
{
    // LONG: Base del box positivo anterior al que confirmó ETAPA 2
    public double CalculateClassicLongEntry(
        RenkoBar confirmationBar, 
        RenkoBar[] bars, 
        int confirmationBarIndex)
    {
        // Buscar el box positivo anterior al que confirmó ETAPA 2
        RenkoBar previousPositiveBox = null;
        
        for (int i = confirmationBarIndex - 1; i >= 0; i--)
        {
            if (bars[i].IsPositive)
            {
                previousPositiveBox = bars[i];
                break;
            }
        }
        
        if (previousPositiveBox == null)
        {
            return double.NaN;
        }
        
        // La base del box positivo anterior es su Low
        return previousPositiveBox.Low;
    }
    
    // SHORT: Topo del box negativo anterior al que confirmó ETAPA 2
    public double CalculateClassicShortEntry(
        RenkoBar confirmationBar, 
        RenkoBar[] bars, 
        int confirmationBarIndex)
    {
        // Buscar el box negativo anterior al que confirmó ETAPA 2
        RenkoBar previousNegativeBox = null;
        
        for (int i = confirmationBarIndex - 1; i >= 0; i--)
        {
            if (bars[i].IsNegative)
            {
                previousNegativeBox = bars[i];
                break;
            }
        }
        
        if (previousNegativeBox == null)
        {
            return double.NaN;
        }
        
        // El topo del box negativo anterior es su High
        return previousNegativeBox.High;
    }
}
```

#### 3B.5.2 Timing 2.2 (Menos Conservador, Mayor Volatilidad)

```csharp
public class Etapa2Mode2_2Timing
{
    // LONG: Base del propio box positivo que confirmó ETAPA 2
    public double CalculateMode22LongEntry(RenkoBar confirmationBar)
    {
        if (!confirmationBar.IsPositive)
        {
            return double.NaN;
        }
        
        // La base del box que confirmó ETAPA 2 es su Low
        return confirmationBar.Low;
    }
    
    // SHORT: Topo del propio box negativo que confirmó ETAPA 2
    public double CalculateMode22ShortEntry(RenkoBar confirmationBar)
    {
        if (!confirmationBar.IsNegative)
        {
            return double.NaN;
        }
        
        // El topo del box que confirmó ETAPA 2 es su High
        return confirmationBar.High;
    }
    
    // Regla: Timing 2.2 es más apropiado para momentos de mayor volatilidad
    // (ej: activos como Nasdaq)
    public bool IsAppropriateForMode22(double currentVolatility, double averageVolatility)
    {
        // Si la volatilidad actual es 1.5x o mayor que la promedio, considerar 2.2
        double volatilityRatio = currentVolatility / averageVolatility;
        return volatilityRatio >= 1.5;
    }
}
```

### 3B.6 Reglas Fundamentales de Timing para ETAPA 2

#### 3B.6.1 NUNCA comprar en el topo del box positivo

```csharp
// Misma regla que ETAPA 1
public bool IsInvalidEtapa2LongEntry(RenkoBar bar, double entryPrice)
{
    double boxTop = bar.High;
    double tolerance = bar.Range * 0.1;
    bool isNearTop = Math.Abs(entryPrice - boxTop) <= tolerance;
    
    return isNearTop;
}
```

#### 3B.6.2 NUNCA vender en el fondo del box negativo

```csharp
// Misma regla que ETAPA 1
public bool IsInvalidEtapa2ShortEntry(RenkoBar bar, double entryPrice)
{
    double boxBottom = bar.Low;
    double tolerance = bar.Range * 0.1;
    bool isNearBottom = Math.Abs(entryPrice - boxBottom) <= tolerance;
    
    return isNearBottom;
}
```

#### 3B.6.3 NUNCA entrar en el cierre del box

```csharp
// Regla universal: No entrar en el cierre del box de confirmación
public bool CanEnterEtapa2Trade(RenkoBar confirmationBar)
{
    // La entrada debe planificarse para el siguiente box o intra-bar
    return !confirmationBar.IsClosed;
}
```

### 3B.7 Stop Loss para ETAPA 2

#### 3B.7.1 STOP para LONG (ETAPA 2 Compradora)

```csharp
public class Etapa2StopLossManager
{
    // STOP: Base de 2 boxes positivos anteriores, contando desde el mejor punto de entrada
    public double CalculateEtapa2LongStopLoss(
        RenkoBar[] bars,
        int entryBarIndex,
        EntryTimingMode timingMode)
    {
        // Contar desde el mejor punto de entrada (el bar de entrada)
        // Buscar 2 boxes positivos anteriores al entry
        int positiveBoxCount = 0;
        RenkoBar secondPositiveBox = null;
        
        for (int i = entryBarIndex - 1; i >= 0 && positiveBoxCount < 2; i--)
        {
            if (bars[i].IsPositive)
            {
                positiveBoxCount++;
                if (positiveBoxCount == 2)
                {
                    secondPositiveBox = bars[i];
                    break;
                }
            }
        }
        
        if (secondPositiveBox == null)
        {
            return double.NaN; // No hay suficientes boxes positivos
        }
        
        // STOP en la base (Low) del 2º box positivo anterior
        return secondPositiveBox.Low;
    }
    
    // Opción alternativa: 2 boxes + 1 tick
    public double CalculateEtapa2LongStopLossWithTick(
        RenkoBar[] bars,
        int entryBarIndex,
        double tickSize)
    {
        double baseStop = CalculateEtapa2LongStopLoss(bars, entryBarIndex, EntryTimingMode.Classic);
        
        if (double.IsNaN(baseStop))
        {
            return double.NaN;
        }
        
        // STOP = base de 2 boxes + 1 tick (para dar más espacio)
        return baseStop - tickSize;
    }
}
```

#### 3B.7.2 STOP para SHORT (ETAPA 2 Vendedora)

```csharp
public class Etapa2StopLossManager
{
    // STOP: Topo de 2 boxes negativos anteriores, contando desde el mejor punto de entrada
    public double CalculateEtapa2ShortStopLoss(
        RenkoBar[] bars,
        int entryBarIndex,
        EntryTimingMode timingMode)
    {
        // Contar desde el mejor punto de entrada (el bar de entrada)
        // Buscar 2 boxes negativos anteriores al entry
        int negativeBoxCount = 0;
        RenkoBar secondNegativeBox = null;
        
        for (int i = entryBarIndex - 1; i >= 0 && negativeBoxCount < 2; i--)
        {
            if (bars[i].IsNegative)
            {
                negativeBoxCount++;
                if (negativeBoxCount == 2)
                {
                    secondNegativeBox = bars[i];
                    break;
                }
            }
        }
        
        if (secondNegativeBox == null)
        {
            return double.NaN; // No hay suficientes boxes negativos
        }
        
        // STOP en el topo (High) del 2º box negativo anterior
        return secondNegativeBox.High;
    }
    
    // Opción alternativa: 2 boxes + 1 tick
    public double CalculateEtapa2ShortStopLossWithTick(
        RenkoBar[] bars,
        int entryBarIndex,
        double tickSize)
    {
        double baseStop = CalculateEtapa2ShortStopLoss(bars, entryBarIndex, EntryTimingMode.Classic);
        
        if (double.IsNaN(baseStop))
        {
            return double.NaN;
        }
        
        // STOP = topo de 2 boxes + 1 tick (para dar más espacio)
        return baseStop + tickSize;
    }
}
```

#### 3B.7.3 Consideraciones sobre Ticks

```csharp
public class TickConstants
{
    // Valores de tick por instrumento (ejemplo)
    public const double TICK_DOLLAR = 0.50;
    public const double TICK_NASDAQ = 0.25;
    public const double TICK_GOLD = 0.10;
    public const double TICK_INDEX = 5.00; // Para índices que mueven en incrementos de 5 puntos
    
    public static double GetTickSize(string instrument)
    {
        switch (instrument.ToUpper())
        {
            case "USD":
            case "DOLLAR":
                return TICK_DOLLAR;
            case "NQ":
            case "MNQ":
            case "NASADAQ":
                return TICK_NASDAQ;
            case "GC":
            case "GOLD":
                return TICK_GOLD;
            case "ES":
            case "YM":
            case "INDEX":
                return TICK_INDEX;
            default:
                return 0.01; // Default mínimo
        }
    }
}
```

### 3B.8 Regla: El segundo box contrario solo cierra negativo si supera mínimo + 1 tick

```csharp
public class Etapa2ExitCondition
{
    // Esta opción es usada por algunas personas
    // El segundo box contrario a la posición solo cierra negativo si supera 
    // el mínimo del segundo box positivo + 1 tick
    
    public bool ShouldExitOnSecondContraryBox(
        TradePosition position,
        RenkoBar[] bars,
        int currentBarIndex,
        double tickSize)
    {
        if (position.Direction == TradeDirection.Long)
        {
            // Para LONG: El segundo box negativo solo cierra si supera 
            // el mínimo del segundo box positivo + 1 tick
            
            int negativeBoxCount = 0;
            RenkoBar secondNegativeBox = null;
            
            for (int i = currentBarIndex; i >= 0 && negativeBoxCount < 2; i--)
            {
                if (bars[i].IsNegative)
                {
                    negativeBoxCount++;
                    if (negativeBoxCount == 2)
                    {
                        secondNegativeBox = bars[i];
                        break;
                    }
                }
            }
            
            if (secondNegativeBox == null)
            {
                return false;
            }
            
            // Buscar el segundo box positivo anterior
            int positiveBoxCount = 0;
            RenkoBar secondPositiveBox = null;
            
            for (int i = currentBarIndex - 1; i >= 0 && positiveBoxCount < 2; i--)
            {
                if (bars[i].IsPositive)
                {
                    positiveBoxCount++;
                    if (positiveBoxCount == 2)
                    {
                        secondPositiveBox = bars[i];
                        break;
                    }
                }
            }
            
            if (secondPositiveBox == null)
            {
                return false;
            }
            
            // El segundo box negativo cierra si su Low supera el Low del 
            // segundo box positivo + 1 tick
            double threshold = secondPositiveBox.Low - tickSize;
            return secondNegativeBox.Low < threshold;
        }
        else if (position.Direction == TradeDirection.Short)
        {
            // Lógica similar para SHORT (inversa)
            // ...
            return false; // Placeholder
        }
        
        return false;
    }
}
```

### 3B.9 Precauciones para ETAPA 2 en Regiones Sobrecompradas/Sobreventidas

```csharp
public class Etapa2Precautions
{
    // Consideración importante: En ETAPA 2 de compra en regiones sobrecompradas,
    // las tendencias pueden desacelerar o encontrar obstáculos que interrumpan el movimiento
    
    public bool IsInOverboughtRegion(FplemeData fpleme, RenkoBar[] bars, int currentBarIndex)
    {
        // FPLEME en niveles altos indica sobrecompra
        bool fplemeOverbought = fpleme.CurrentValue >= FplemeConstants.LEVEL_HIGH;
        
        // Precio en máximos recientes
        double recentHigh = GetRecentHigh(bars, currentBarIndex, 10);
        bool priceAtHighs = bars[currentBarIndex].High >= (recentHigh * 0.99); // 99% del máximo
        
        return fplemeOverbought || priceAtHighs;
    }
    
    public bool IsInOversoldRegion(FplemeData fpleme, RenkoBar[] bars, int currentBarIndex)
    {
        // FPLEME en niveles bajos indica sobreventa
        bool fplemeOversold = fpleme.CurrentValue <= FplemeConstants.LEVEL_LOW;
        
        // Precio en mínimos recientes
        double recentLow = GetRecentLow(bars, currentBarIndex, 10);
        bool priceAtLows = bars[currentBarIndex].Low <= (recentLow * 1.01); // 101% del mínimo
        
        return fplemeOversold || priceAtLows;
    }
    
    // Advertencia: En regiones extremas, reducir tamaño de posición o evitar trades
    public double AdjustPositionSizeForRegion(double baseSize, bool isOverbought, bool isOversold)
    {
        if (isOverbought || isOversold)
        {
            // Reducir tamaño a 50% en regiones extremas
            return baseSize * 0.5;
        }
        return baseSize;
    }
}
```

### 3B.10 Filtro de Escenario para ETAPA 2

**Regla fundamental:** "Una ETAPA 2 dentro de un escenario será siempre más segura que una ETAPA 2 aislada"

#### 3B.10.1 Integración con Escenarios PPM y MM

```csharp
public class Etapa2ScenarioFilter
{
    public SignalQuality EvaluateEtapa2WithScenario(
        Etapa2Data etapa2,
        PpmScenario ppm,
        bool isMm,
        WallMapsData wallMaps,
        double currentPrice)
    {
        // ETAPA 2 dentro de escenario PPM o MM = más segura
        bool withinScenario = (ppm != PpmScenario.None) || isMm;
        
        if (!withinScenario)
        {
            return SignalQuality.Low; // ETAPA 2 aislada
        }
        
        // Priorizar ETAPA 2 cuando:
        // 1. Está dentro de PPM o MM
        // 2. El precio ya rompió The_Wall dentro del escenario
        // 3. The_Wall está en el color de la tendencia deseada
        
        bool priceBrokeWall = false;
        bool wallColorMatches = false;
        
        if (etapa2.IsBuyer)
        {
            // Para LONG: precio debe estar arriba de The_Wall
            priceBrokeWall = currentPrice > wallMaps.WallPrice;
            // The_Wall debe ser verde (tendencia compradora)
            wallColorMatches = wallMaps.Color == WallMapsColor.Green;
            
            // Validar alineación con dirección del escenario
            bool alignedWithScenario = (ppm == PpmScenario.PpmBuy) || isMm;
            
            if (!alignedWithScenario)
            {
                return SignalQuality.VeryLow; // ETAPA 2 fuera de contexto
            }
        }
        else if (etapa2.IsSeller)
        {
            // Para SHORT: precio debe estar debajo de The_Wall
            priceBrokeWall = currentPrice < wallMaps.WallPrice;
            // The_Wall debe ser rosa/magenta/rojo (tendencia vendedora)
            wallColorMatches = (wallMaps.Color == WallMapsColor.Pink) ||
                              (wallMaps.Color == WallMapsColor.Magenta) ||
                              (wallMaps.Color == WallMapsColor.Red);
            
            // Validar alineación con dirección del escenario
            bool alignedWithScenario = (ppm == PpmScenario.PpmSell) || isMm;
            
            if (!alignedWithScenario)
            {
                return SignalQuality.VeryLow; // ETAPA 2 fuera de contexto
            }
        }
        
        // ETAPA 2 dentro de escenario, precio rompió The_Wall, 
        // y The_Wall está en color correcto = alta calidad
        if (priceBrokeWall && wallColorMatches)
        {
            return SignalQuality.High;
        }
        
        // ETAPA 2 dentro de escenario pero sin romper The_Wall o color incorrecto
        return SignalQuality.Medium;
    }
}
```

#### 3B.10.2 ETAPA 2 en Contexto MM: Reglas de Confirmación con SHARK

**Para operaciones LONG en MM (Segundo Ciclo Comprador):**

**1°: Punto Inicial**
- Elegir el lado que se desea analizar
- Ejemplo: Si el activo está en **MAP Central** y está **azul**, se quiere analizar la fuerza de compra

**2°: Esperar formación de fondo y confirmación SHARK**
- Siempre es necesario esperar la formación de al menos un **fondo**
- En ese fondo de referencia, el **SHARK necesita virar azul**, indicando el inicio del **primer ciclo comprador**
- Sin esta confirmación de SHARK, NO proceder

**3°: Prepararse para entrar en el segundo ciclo comprador**
- Prepararse para entrar en el **segundo ciclo comprador**
- Este es el punto de entrada principal (equivalente a ETAPA 2 en contexto MM)

**Para operaciones SHORT en MM (Segundo Ciclo Vendedor):**

**1°: Punto Inicial**
- Elegir el lado que se desea analizar
- Ejemplo: Si el activo está en **MAP Central** y está **naranja**, el foco será analizar la fuerza de venta

**2°: Esperar formación de topo y confirmación SHARK**
- Siempre es necesario esperar la formación de al menos un **topo**
- En ese topo de referencia, el **SHARK necesita virar rojo**, indicando el inicio del **primer ciclo vendedor**
- Sin esta confirmación de SHARK, NO proceder

**3°: Prepararse para entrar en el segundo ciclo vendedor**
- Prepararse para entrar en el **segundo ciclo vendedor**
- Este es el punto de entrada principal (equivalente a ETAPA 2 en contexto MM)

```csharp
public class Etapa2MmConfirmation
{
    public bool ValidateEtapa2BuyerWithMm(
        Etapa2Data etapa2,
        RenkoBar[] bars,
        int currentBarIndex,
        SharkData shark,
        SharkData[] sharkHistory,
        MapsLine[] mapsLines,
        int lookbackPeriod = 20)
    {
        // Regla 1: Verificar MAP Central y color (debe ser azul para compra)
        MapsLine map0 = mapsLines.FirstOrDefault(l => l.Name == MapsConstants.MAP_0);
        if (map0 == null || map0.Color != MapsLineColor.Blue) return false;
        
        // Regla 2: Buscar formación de fondo y confirmación SHARK azul
        bool foundBottom = false;
        bool sharkTurnedBlue = false;
        
        for (int i = currentBarIndex; i >= Math.Max(0, currentBarIndex - lookbackPeriod); i--)
        {
            // Detectar fondo (mínimo local)
            if (IsLocalMinimum(bars, i))
            {
                foundBottom = true;
                
                // Verificar que SHARK viró azul en o después de ese fondo
                int sharkIndex = Math.Min(i, sharkHistory.Length - 1);
                if (sharkIndex >= 0 && sharkHistory[sharkIndex].State == SharkState.Blue)
                {
                    sharkTurnedBlue = true;
                    break;
                }
            }
        }
        
        if (!foundBottom || !sharkTurnedBlue)
        {
            return false; // NO proceder sin fondo + SHARK azul
        }
        
        // Regla 3: Verificar que estamos en segundo ciclo comprador
        bool isSecondBuyerCycle = IsSecondBuyerCycle(bars, currentBarIndex, lookbackPeriod);
        if (!isSecondBuyerCycle)
        {
            return false;
        }
        
        // Regla 4: Segundo ciclo debe estar más alto
        bool secondCycleHigher = IsSecondCycleHigher(bars, currentBarIndex, lookbackPeriod);
        if (!secondCycleHigher)
        {
            return false;
        }
        
        // Regla 5: Segundo ciclo debe estar en misma MAP
        bool sameMapLevel = IsSecondCycleAtSameMapLevel(
            mapsLines, bars, currentBarIndex, lookbackPeriod);
        if (!sameMapLevel)
        {
            return false;
        }
        
        return true;
    }
    
    public bool ValidateEtapa2SellerWithMm(
        Etapa2Data etapa2,
        RenkoBar[] bars,
        int currentBarIndex,
        SharkData shark,
        SharkData[] sharkHistory,
        MapsLine[] mapsLines,
        int lookbackPeriod = 20)
    {
        // Regla 1: Verificar MAP Central y color (debe ser naranja para venta)
        MapsLine map0 = mapsLines.FirstOrDefault(l => l.Name == MapsConstants.MAP_0);
        if (map0 == null || map0.Color != MapsLineColor.Orange) return false;
        
        // Regla 2: Buscar formación de topo y confirmación SHARK rojo
        bool foundTop = false;
        bool sharkTurnedRed = false;
        
        for (int i = currentBarIndex; i >= Math.Max(0, currentBarIndex - lookbackPeriod); i--)
        {
            // Detectar topo (máximo local)
            if (IsLocalMaximum(bars, i))
            {
                foundTop = true;
                
                // Verificar que SHARK viró rojo en o después de ese topo
                int sharkIndex = Math.Min(i, sharkHistory.Length - 1);
                if (sharkIndex >= 0 && sharkHistory[sharkIndex].State == SharkState.Red)
                {
                    sharkTurnedRed = true;
                    break;
                }
            }
        }
        
        if (!foundTop || !sharkTurnedRed)
        {
            return false; // NO proceder sin topo + SHARK rojo
        }
        
        // Regla 3: Verificar que estamos en segundo ciclo vendedor
        bool isSecondSellerCycle = IsSecondSellerCycle(bars, currentBarIndex, lookbackPeriod);
        if (!isSecondSellerCycle)
        {
            return false;
        }
        
        // Regla 4: Segundo ciclo debe estar más bajo
        bool secondCycleLower = IsSecondCycleLower(bars, currentBarIndex, lookbackPeriod);
        if (!secondCycleLower)
        {
            return false;
        }
        
        // Regla 5: Segundo ciclo debe estar en misma MAP
        bool sameMapLevel = IsSecondCycleAtSameMapLevel(
            mapsLines, bars, currentBarIndex, lookbackPeriod);
        if (!sameMapLevel)
        {
            return false;
        }
        
        return true;
    }
    
    private bool IsLocalMinimum(RenkoBar[] bars, int index)
    {
        if (index <= 0 || index >= bars.Length - 1) return false;
        return bars[index].Low < bars[index - 1].Low && 
               bars[index].Low < bars[index + 1].Low;
    }
    
    private bool IsLocalMaximum(RenkoBar[] bars, int index)
    {
        if (index <= 0 || index >= bars.Length - 1) return false;
        return bars[index].High > bars[index - 1].High && 
               bars[index].High > bars[index + 1].High;
    }
    
    // Métodos auxiliares IsSecondBuyerCycle, IsSecondCycleHigher, etc. 
    // (similar a MmBuyerCycleRules)
}
```

### 3B.11 Estructura de Datos Completa para ETAPA 2

```csharp
public class Etapa2Data
{
    public bool IsBuyer { get; set; }
    public bool IsSeller { get; set; }
    public bool IsActive { get; set; }
    public bool IsConfirmed { get; set; }
    public DateTime ActivationTime { get; set; }
    public double ActivationPrice { get; set; }
    public RenkoBar ConfirmationBar { get; set; }
    public int ConfirmationBarIndex { get; set; }
    public FplemeData FplemeAtActivation { get; set; }
    public SharkState SharkAtActivation { get; set; }
    public EntryTimingMode TimingMode { get; set; }
    public SignalQuality Quality { get; set; }
    public bool IsWithinScenario { get; set; }
    public bool PriceBrokeWall { get; set; }
    public bool WallColorMatches { get; set; }
}
```

### 3B.12 Tipos de Datos Comunes

```csharp
// Enums utilizados en todo el sistema

public enum TradeDirection
{
    None = 0,
    Long = 1,
    Short = 2
}

public enum SignalQuality
{
    Unknown = 0,
    VeryLow = 1,
    Low = 2,
    Medium = 3,
    High = 4      // ~100% probabilidad de éxito
}

public enum EntryMode
{
    Market = 0,
    Limit = 1,
    Stop = 2,
    StopLimit = 3
}

public enum ExitReason
{
    None = 0,
    TakeProfit = 1,
    StopLoss = 2,
    Etapa1Invalidated = 3,
    Etapa2Invalidated = 4,
    SharkColorChanged = 5,
    MaxStopReached = 6,
    Manual = 7
}

public enum EntryTimingMode
{
    Classic = 0,     // Base/topo del box anterior
    Mode2_2 = 1      // Base/topo del propio box que confirmó
}
```

---

## 4. SHARK: SISTEMA DE CONFIRMACIÓN

### 4.1 Definición Conceptual

**SHARK** es un indicador complementario que confirma cambios de ciclo en el mercado. Lee los mismos datos que FPLEME pero indica el estado del ciclo de forma más estable.

**Características principales:**
- Funciona de la misma forma que FPLEME: cuanto más alta, mayor la fuerza de compra; cuanto más baja, mayor la fuerza de venta.
- Estas dos líneas (FPLEME y SHARK) eran herramientas separadas en el pasado, pero actualmente son complementarias y aparecen juntas en el gráfico.
- La línea del SHARK es más gruesa que la línea del FPLEME.

### 4.2 Estados de SHARK

```csharp
public enum SharkState
{
    Unknown = 0,
    Blue = 1,          // Ciclo comprador (fuerza de compra) - NinjaTrader: azul
    Red = 2,           // Ciclo vendedor (fuerza de venta) - NinjaTrader: rosa/magenta
    Yellow = 3,        // Equilibrio (puede anticipar cambio)
    Transition = 4     // Transición entre estados
}
```

### 4.3 Post-its Amarillos en la Línea SHARK

#### 4.3.1 Definición y Significado

**Post-its amarillos** son pequeños rectángulos que aparecen en la línea del SHARK, indicando:
- **Equilibrio** en el mercado
- **Anticipación** de una posible mudanza de ciclo

**REGLA CRÍTICA:** Un Post-it amarillo, por sí solo, NO es un set-up de entrada o salida. Su funcionalidad se explica parcialmente en este módulo y se profundiza en módulos siguientes.

**Confirmación requerida:**
- La mudanza de ciclo solo puede ser **confirmada por la coloración de la línea**.
- El Post-it es una señal **anticipatoria**, no una confirmación.

```csharp
public class SharkYellowPostIt
{
    public bool IsActive { get; set; }
    public DateTime DetectionTime { get; set; }
    public double SharkValueAtDetection { get; set; }
    public bool IsConfirmedByLineColor { get; set; }
    public SharkState ConfirmedState { get; set; }
    
    // Detectar Post-it amarillo (equilibrio)
    public bool DetectYellowPostIt(SharkData shark, SharkData previousShark)
    {
        // Post-it aparece cuando SHARK está en equilibrio o cambio de dirección
        bool isEquilibrium = Math.Abs(shark.CurrentValue) < 2.0; // Cerca de 0.00
        bool isDirectionChange = (shark.CurrentValue * previousShark.CurrentValue) < 0; // Cambio de signo
        
        return isEquilibrium || isDirectionChange;
    }
    
    // Confirmar Post-it con coloración de línea
    public bool ConfirmWithLineColor(SharkState currentState)
    {
        // La confirmación ocurre cuando la línea cambia de color
        if (currentState == SharkState.Blue || currentState == SharkState.Red)
        {
            IsConfirmedByLineColor = true;
            ConfirmedState = currentState;
            return true;
        }
        
        return false;
    }
}
```

#### 4.3.2 Regla para Activos Volátiles (Ej: Nasdaq)

**IMPORTANTE:** Para activos altamente volátiles (como Nasdaq), el color del ciclo del mercado puede cambiar **ANTES** de que aparezca un Post-it.

**Regla de prioridad:**
- En activos volátiles, el **color de la línea es el indicador definitivo**.
- El color de la línea determina si el ciclo es comprador o vendedor.
- El Post-it es secundario y puede aparecer después del cambio de color.

```csharp
public class VolatileAssetHandler
{
    public bool IsVolatileAsset(string instrument)
    {
        // Instrumentos conocidos por alta volatilidad
        string[] volatileInstruments = { "NQ", "MNQ", "NASADAQ", "ES", "YM" };
        return volatileInstruments.Contains(instrument.ToUpper());
    }
    
    public SharkState GetDefinitiveCycleState(
        SharkData shark, 
        SharkYellowPostIt postIt, 
        bool isVolatileAsset)
    {
        if (isVolatileAsset)
        {
            // En activos volátiles, el color de la línea es definitivo
            // NO esperar Post-it
            return shark.State;
        }
        else
        {
            // En activos menos volátiles, esperar confirmación de Post-it
            if (postIt != null && postIt.IsConfirmedByLineColor)
            {
                return postIt.ConfirmedState;
            }
            
            return SharkState.Unknown;
        }
    }
}
```

### 4.4 Colores en Plataforma NinjaTrader (SHARK)

**IMPORTANTE:** Los colores de visualización en NinjaTrader son específicos:

```csharp
public class SharkNinjaTraderColors
{
    // Ciclo comprador: AZUL (no verde)
    public static Color BuyerCycleColor = Colors.Blue;
    
    // Ciclo vendedor: ROSA/MAGENTA (no rojo)
    public static Color SellerCycleColor = Colors.Magenta; // o Colors.Pink
}
```

**Regla de implementación:**
- Internamente, el sistema puede usar `Green/Red` para lógica.
- Visualmente en NinjaTrader, SHARK debe renderizarse como `Blue/Magenta`.
- Esta diferencia es solo visual, no afecta la lógica programática.

### 4.3 Integración con ETAPA 1 y ETAPA 2

#### 4.3.1 Post-it Destacado vs Opaco (ETAPA 1)

**Lógica para determinar tipo de Post-it:**

```csharp
public PostItType DeterminePostItType(Etapa1Data etapa1, SharkData shark)
{
    // Post-it DESTACADO: SHARK alineado con ETAPA 1 (movimiento fluido)
    if (etapa1.IsBuyer && shark.State == SharkState.Blue)
    {
        return PostItType.HighlightedGreen; // Verde destacado
    }
    
    if (etapa1.IsSeller && shark.State == SharkState.Red)
    {
        return PostItType.HighlightedRed; // Rojo destacado
    }
    
    // Post-it OPACO: SHARK opuesto a ETAPA 1 (movimiento lateralizado)
    if (etapa1.IsBuyer && shark.State == SharkState.Red)
    {
        return PostItType.OpaqueGreen; // Verde opaco/acinzentado
    }
    
    if (etapa1.IsSeller && shark.State == SharkState.Blue)
    {
        return PostItType.OpaqueRed; // Rojo opaco/acinzentado
    }
    
    return PostItType.None;
}
```

#### 4.3.2 Impacto en Calidad de Señal

```csharp
public SignalQuality GetSignalQuality(Etapa1Data etapa1, SharkData shark)
{
    PostItType postIt = DeterminePostItType(etapa1, shark);
    
    // Post-it destacado = movimiento fluido = mayor probabilidad
    if (postIt == PostItType.HighlightedGreen || postIt == PostItType.HighlightedRed)
    {
        return SignalQuality.High; // ~100% probabilidad
    }
    
    // Post-it opaco = movimiento lateralizado = menor probabilidad
    if (postIt == PostItType.OpaqueGreen || postIt == PostItType.OpaqueRed)
    {
        return SignalQuality.Low; // Movimiento lateralizado
    }
    
    return SignalQuality.Unknown;
}
```

### 4.5 Movimientos Lateralizados

#### 4.5.1 Definición

**Movimientos lateralizados** ocurren cuando FPLEME y SHARK **NO poseen coloraciones alineadas**. Esto indica un desalineamiento de fuerzas en el mercado, resultando en movimientos laterales (sin dirección clara).

**REGLA CRÍTICA:** Este concepto NO es un set-up y NO debe ser usado de forma aislada. Debe ser combinado con la construcción de escenarios.

```csharp
public class LateralizedMovementDetector
{
    public bool IsLateralizedMovement(FplemeData fpleme, SharkData shark)
    {
        // Movimiento lateralizado: colores NO alineados
        bool colorsAligned = AreColorsAligned(fpleme, shark);
        
        return !colorsAligned;
    }
    
    private bool AreColorsAligned(FplemeData fpleme, SharkData shark)
    {
        // Colores alineados:
        // - FPLEME verde/azul Y SHARK azul = alineado (comprador)
        // - FPLEME rojo/rosa Y SHARK rosa/magenta = alineado (vendedor)
        
        bool fplemeIsBuyer = fpleme.IsBuyerCycle || 
                            (fpleme.CurrentValue >= FplemeConstants.LEVEL_CONFIRMATION_LONG);
        bool fplemeIsSeller = fpleme.IsSellerCycle || 
                             (fpleme.CurrentValue <= FplemeConstants.LEVEL_CONFIRMATION_SHORT);
        
        bool sharkIsBuyer = shark.State == SharkState.Blue;
        bool sharkIsSeller = shark.State == SharkState.Red;
        
        // Alineación: ambos en la misma dirección
        bool alignedBuyer = fplemeIsBuyer && sharkIsBuyer;
        bool alignedSeller = fplemeIsSeller && sharkIsSeller;
        
        return alignedBuyer || alignedSeller;
    }
    
    // Advertencia: NO usar como set-up aislado
    public string GetWarning()
    {
        return "▲ Atención: Este concepto no es un set-up y no debe ser usado de forma aislada. " +
               "Debe ser combinado con la construcción de escenarios.";
    }
}
```

---

## 5. TIMING DE ENTRADA

### 5.1 Reglas Fundamentales (Aplican a ETAPA 1 y ETAPA 2)

#### 5.1.1 NUNCA comprar en el topo del box positivo

```csharp
public bool IsInvalidLongEntry(RenkoBar bar, double entryPrice)
{
    // El topo del box positivo es su High
    double boxTop = bar.High;
    
    // NO comprar si el precio de entrada está en o cerca del topo
    double tolerance = bar.Range * 0.1; // 10% de tolerancia
    bool isNearTop = Math.Abs(entryPrice - boxTop) <= tolerance;
    
    return isNearTop;
}
```

#### 5.1.2 NUNCA vender en el fondo del box negativo

```csharp
public bool IsInvalidShortEntry(RenkoBar bar, double entryPrice)
{
    // El fondo del box negativo es su Low
    double boxBottom = bar.Low;
    
    // NO vender si el precio de entrada está en o cerca del fondo
    double tolerance = bar.Range * 0.1; // 10% de tolerancia
    bool isNearBottom = Math.Abs(entryPrice - boxBottom) <= tolerance;
    
    return isNearBottom;
}
```

### 5.2 Posicionamiento Correcto de Órdenes

**REGLA FUNDAMENTAL (de PDFs):** "NUNCA comprar en el topo del box positivo" y "NUNCA vender en el fondo del box negativo".

**Proceso paso a paso:**

#### ETAPA 1 Compradora - Ejemplo Práctico:

**1º - ETAPA 1 identificada:**
- Normalmente, el FPLEME alcanzará la línea 0.00 en el segundo o tercer box positivo a favor del movimiento
- En el ejemplo: ETAPA 1 confirmada en el 3º box positivo

**2º - NUNCA comprar en el topo del box:**
- Si estás pensando en comprar, NUNCA debes comprar en el topo del box positivo

**3º - Posicionarse en la base del box positivo anterior:**
- Posiciónate lo más cerca posible de la base del box positivo anterior
- Si ETAPA 1 se confirmó en el 3º box: posicionarse en la base del 2º box
- Si ETAPA 1 se confirmó en el 2º box: posicionarse en la base del 1º box

**Por qué es importante:**
- Esta estrategia planeada reduce el tamaño de tu STOP
- Comprar en el topo aumenta el tamaño del STOP innecesariamente
- Comprar en la base del box anterior mejora el Risk/Reward ratio

#### 5.2.1 LONG: Base del Box Positivo Anterior

```csharp
public double CalculateLongEntryPrice(RenkoBar[] bars, int currentBarIndex)
{
    // Identificar el box positivo anterior
    RenkoBar previousPositiveBox = null;
    
    for (int i = currentBarIndex - 1; i >= 0; i--)
    {
        if (bars[i].IsPositive)
        {
            previousPositiveBox = bars[i];
            break;
        }
    }
    
    if (previousPositiveBox == null)
    {
        return double.NaN; // No hay box positivo anterior
    }
    
    // La base del box positivo es su Low
    return previousPositiveBox.Low;
}
```

#### 5.2.2 SHORT: Topo del Box Negativo Anterior

```csharp
public double CalculateShortEntryPrice(RenkoBar[] bars, int currentBarIndex)
{
    // Identificar el box negativo anterior
    RenkoBar previousNegativeBox = null;
    
    for (int i = currentBarIndex - 1; i >= 0; i--)
    {
        if (bars[i].IsNegative)
        {
            previousNegativeBox = bars[i];
            break;
        }
    }
    
    if (previousNegativeBox == null)
    {
        return double.NaN; // No hay box negativo anterior
    }
    
    // El topo del box negativo es su High
    return previousNegativeBox.High;
}
```

### 5.3 Regla: NUNCA entrar en el cierre del box

```csharp
public bool CanEnterTrade(RenkoBar confirmationBar)
{
    // NO entrar si la señal se confirma en el cierre del box actual
    // La entrada debe planificarse para el siguiente box o intra-bar
    // Esta validación se hace en el simulador/estrategia principal
    
    // Esta función retorna true solo si NO estamos en el cierre del box de confirmación
    return !confirmationBar.IsClosed;
}
```

### 5.4 Flujo Completo de Timing de Entrada

```csharp
public class EntryTimingProcessor
{
    public EntrySignal ProcessEntryTiming(
        Etapa1Data etapa1,
        RenkoBar[] bars,
        int currentBarIndex,
        FplemeData fpleme,
        SharkData shark)
    {
        EntrySignal signal = new EntrySignal();
        
        // Paso 1: Identificar ETAPA 1
        if (!etapa1.IsActive || !etapa1.IsConfirmed)
        {
            return null; // No hay ETAPA 1 activa
        }
        
        // Paso 2: Validar calidad de señal (Post-it destacado preferido)
        SignalQuality quality = GetSignalQuality(etapa1, shark);
        if (quality == SignalQuality.Low)
        {
            // Opcional: Filtrar señales de baja calidad
            // signal.Warning = "Movimiento lateralizado detectado";
        }
        
        // Paso 3: Calcular precio de entrada
        if (etapa1.IsBuyer)
        {
            signal.EntryPrice = CalculateLongEntryPrice(bars, currentBarIndex);
            signal.Direction = TradeDirection.Long;
            
            // Validar que NO estemos en el topo del box
            RenkoBar currentBar = bars[currentBarIndex];
            if (IsInvalidLongEntry(currentBar, signal.EntryPrice))
            {
                return null; // Entrada inválida
            }
        }
        else if (etapa1.IsSeller)
        {
            signal.EntryPrice = CalculateShortEntryPrice(bars, currentBarIndex);
            signal.Direction = TradeDirection.Short;
            
            // Validar que NO estemos en el fondo del box
            RenkoBar currentBar = bars[currentBarIndex];
            if (IsInvalidShortEntry(currentBar, signal.EntryPrice))
            {
                return null; // Entrada inválida
            }
        }
        
        // Paso 4: Validar que NO entramos en el cierre del box de confirmación
        RenkoBar confirmationBar = bars[etapa1.ConfirmationBoxIndex];
        if (!CanEnterTrade(confirmationBar))
        {
            // Planificar entrada para siguiente bar o intra-bar
            signal.EntryMode = EntryMode.LimitOrder;
            signal.PlanForNextBar = true;
        }
        
        return signal;
    }
}
```

---

## 6. GESTIÓN DE STOP LOSS

### 6.1 STOP para LONG (Etapa 1 Compradora)

**NOTA:** Ver sección 3B.7 para Stop Loss específico de ETAPA 2.

---

#### 6.1.1 STOP Mínimo

```csharp
public double CalculateMinStopLossLong(RenkoBar[] bars, int currentBarIndex)
{
    // El STOP debe estar debajo del último fondo formado
    // desde el último ciclo comprador
    
    double lastBuyCycleLow = FindLastBuyCycleLow(bars, currentBarIndex);
    
    // STOP mínimo: justo debajo del último fondo
    return lastBuyCycleLow - TickSize;
}
```

#### 6.1.2 STOP Máximo

```csharp
public double CalculateMaxStopLossLong(RenkoBar[] bars, int currentBarIndex)
{
    // El STOP máximo es 1 box negativo debajo del último fondo
    double lastBuyCycleLow = FindLastBuyCycleLow(bars, currentBarIndex);
    
    // Encontrar el tamaño de un box negativo
    double negativeBoxSize = GetAverageNegativeBoxSize(bars, currentBarIndex);
    
    // STOP máximo: 1 box negativo debajo
    return lastBuyCycleLow - negativeBoxSize;
}
```

#### 6.1.3 Condición de Invalidación

```csharp
public bool IsEtapa1InvalidatedLong(FplemeData fpleme, double currentPrice, double entryPrice)
{
    // Si FPLEME rompe 0.00 hacia abajo y alcanza -4.00,
    // la operación se descaracteriza como ETAPA 1
    
    bool brokeZeroDown = (fpleme.PreviousValue >= FplemeConstants.LEVEL_EQUILIBRIUM) &&
                         (fpleme.CurrentValue < FplemeConstants.LEVEL_EQUILIBRIUM);
    
    bool reachedMinus4 = fpleme.CurrentValue <= FplemeConstants.LEVEL_CONFIRMATION_SHORT;
    
    return brokeZeroDown && reachedMinus4;
}
```

### 6.2 STOP para SHORT (Etapa 1 Vendedora)

#### 6.2.1 STOP Mínimo

```csharp
public double CalculateMinStopLossShort(RenkoBar[] bars, int currentBarIndex)
{
    // El STOP debe estar arriba del último tope formado
    // desde el último ciclo vendedor
    
    double lastSellCycleHigh = FindLastSellCycleHigh(bars, currentBarIndex);
    
    // STOP mínimo: justo arriba del último tope
    return lastSellCycleHigh + TickSize;
}
```

#### 6.2.2 STOP Máximo

```csharp
public double CalculateMaxStopLossShort(RenkoBar[] bars, int currentBarIndex)
{
    // El STOP máximo es 1 box positivo arriba del último tope
    double lastSellCycleHigh = FindLastSellCycleHigh(bars, currentBarIndex);
    
    // Encontrar el tamaño de un box positivo
    double positiveBoxSize = GetAveragePositiveBoxSize(bars, currentBarIndex);
    
    // STOP máximo: 1 box positivo arriba
    return lastSellCycleHigh + positiveBoxSize;
}
```

#### 6.2.3 Condición de Invalidación

```csharp
public bool IsEtapa1InvalidatedShort(FplemeData fpleme, double currentPrice, double entryPrice)
{
    // Si FPLEME rompe 0.00 hacia arriba y alcanza +4.00,
    // la operación se descaracteriza como ETAPA 1
    
    bool brokeZeroUp = (fpleme.PreviousValue <= FplemeConstants.LEVEL_EQUILIBRIUM) &&
                       (fpleme.CurrentValue > FplemeConstants.LEVEL_EQUILIBRIUM);
    
    bool reachedPlus4 = fpleme.CurrentValue >= FplemeConstants.LEVEL_CONFIRMATION_LONG;
    
    return brokeZeroUp && reachedPlus4;
}
```

### 6.3 Regla Fundamental: "El motivo que te hizo entrar debe ser el mismo motivo que te hace salir"

```csharp
public class StopLossManager
{
    public ExitReason CheckExitConditions(
        TradePosition position,
        FplemeData fpleme,
        Etapa1Data etapa1)
    {
        // Si la ETAPA 1 se invalidó, salir inmediatamente
        if (position.Direction == TradeDirection.Long)
        {
            if (IsEtapa1InvalidatedLong(fpleme, position.CurrentPrice, position.EntryPrice))
            {
                return ExitReason.Etapa1Invalidated;
            }
        }
        else if (position.Direction == TradeDirection.Short)
        {
            if (IsEtapa1InvalidatedShort(fpleme, position.CurrentPrice, position.EntryPrice))
            {
                return ExitReason.Etapa1Invalidated;
            }
        }
        
        // Si el precio rompió el STOP máximo, salir
        if (position.Direction == TradeDirection.Long)
        {
            double maxStop = CalculateMaxStopLossLong(position.Bars, position.BarIndex);
            if (position.CurrentPrice <= maxStop)
            {
                return ExitReason.MaxStopReached;
            }
        }
        else if (position.Direction == TradeDirection.Short)
        {
            double maxStop = CalculateMaxStopLossShort(position.Bars, position.BarIndex);
            if (position.CurrentPrice >= maxStop)
            {
                return ExitReason.MaxStopReached;
            }
        }
        
        return ExitReason.None;
    }
}
```

---

## 7. FILTROS DE CALIDAD Y ESCENARIOS

### 7.1 Comparativo de Ciclos de Fuerza

**El comparativo de ciclos de fuerza es esencial para la montaje de escenarios.**

El comparativo será esencial para la montaje de escenarios:
1. **Divergencia:** Analizada en el escenario de comparativo de MAP con MAP (MM).
2. **Convergencia:** Analizada en el escenario de progreso del precio en MAP (PPM).

### 7.2 Escenarios PPM y MM

#### 7.2.1 PPM (Progressão de Preço em MAP) - Convergencia

**Definición Conceptual:**

**PPM (Progressão de Preço em MAP)** es el escenario donde el precio **progresa** a través de las MAPS en una dirección clara. Este escenario es una de las maneras más eficaces de identificar la fuerza del mercado y determinar la dirección correcta a seguir.

**Utilidad:**
- El escenario de PPM consigue explicar **cualquier patrón gráfico existente**
- Puede anticipar patrones de reversión como: topo duplo, cuña, ombro-cabeça-ombro, figura diamante, fundo arredondado, entre otros
- **Por qué estos patrones pueden generar reversiones:** La reversión no está en el patrón en sí, sino en la **forma como el precio progresa en las MAPS**
- A diferencia de los patrones gráficos tradicionales que son subjetivos (varias posibilidades de formación), en PPM el movimiento es **fijo y predecible**, lo que trae mayor consistencia y permite un planeamiento más preciso para el futuro

**Características:**
- **Frecuencia:** Ocurre **muy frecuentemente** (más que MM)
- **Fuerza:** Los movimientos en PPM son **más expresivos** que en MM
- **Uso:** Es el escenario principal para identificar oportunidades de tendencia
- **Eficiencia:** Es más eficiente para movimientos a favor de la tendencia

**Definición de Convergencia:**
- La convergencia ocurre cuando el precio **progresa en la dirección del MAP**
- En el gráfico, se visualiza con flechas amarillas apuntando en la dirección de la progresión
- La convergencia indica **alineación entre precio e indicadores**, confirmando tendencia
- El precio avanza de una MAP a otra (ej: MAP 0 → S1 → S2 → S3, o MAP 0 → i1 → i2 → i3)
- Gradualmente, el precio comienza a formar **fondos más altos** en las MAPS (para compra) o **topos más bajos** en las MAPS (para venta)

**Comparación con MM:**
- **PPM:** Precio progresa a través de MAPS (convergencia)
- **MM:** Precio NO progresa y vuelve a la misma MAP (divergencia)
- **PPM es más fuerte:** El movimiento en PPM avanza significativamente más que en MM

**Direcciones de PPM:**
- **PPM na Compra (PpmBuy):** Progresión de precio en MAP comprando (de MAP 0 hacia arriba). Ejemplo: un fondo en i3 seguido por un nuevo fondo en i1.
- **PPM na Venda (PpmSell):** Progresión de precio en MAP vendendo (de MAP 0 hacia abajo). Ejemplo: un topo en s3 seguido por un nuevo topo en s1.

#### 7.2.1.1 PPM COMPRA - Checklist (6 Reglas)

**Secuencia de análisis:** Toda análise de Progressão de Preço em MAP sigue la secuencia del checklist. Para operaciones LONG en PPM:

**Regla 1°: Punto Inicial y Referencia**
- Escoger el lado que se desea analizar
- Si el activo está en **subprecio**, se debe analizar la **fuerza de compra**, ya que el objetivo es comprar
- **Esperar tener una referencia:** Al menos un **fondo**, con el **SHARK virando azul**, indicando el inicio de un **primer ciclo comprador**

**Regla 2°: Formación de Topo y Primer Ciclo Vendedor**
- **Esperar** la formación de al menos un **topo**, con el **SHARK virando rojo**, indicando el inicio de un **primer ciclo vendedor**
- Esta formación de topo es necesaria para identificar el ciclo de referencia

**Regla 3°: Prepararse para Segundo Ciclo Comprador**
- Prepararse para entrar en el **segundo ciclo comprador**
- Este es el punto de entrada principal para trades LONG en PPM

**Regla 4°: Segundo Ciclo Más Alto**
- El **segundo ciclo comprador** debe estar **más alto** que el ciclo anterior
- Esto confirma que hay progresión alcista en el contexto de PPM

**Regla 5°: Progresión en MAP más Alta**
- Para una compra, el **segundo ciclo comprador** debe ocurrir en **cualquier MAP más alta** que la **MAP del ciclo de referencia**
- **Forma fácil de identificar:** El VX debe estar **subiendo**
- Ejemplos válidos:
  - i2 con i1 (ciclo de referencia en i2, segundo ciclo en i1)
  - i1 con MAP 0
  - MAP 0 con S1
  - S1 con S2, etc.

**Regla 6°: Estado de The_Wall**
- En el momento de entrada en la operación, **The_Wall debe estar lateralizada o a favor del lado que deseas** (Amarilla o Verde)
- Para LONG: The_Wall debe estar **Amarilla (lateral)** o **Verde (a favor)**

```csharp
public class PpmBuyChecklist
{
    public bool ValidatePpmBuy(
        MapsLine[] mapsLines,
        RenkoBar[] bars,
        int currentBarIndex,
        SharkData shark,
        SharkData[] sharkHistory,
        WallMapsData wall,
        VxData vx,  // VX indicator data
        int lookbackPeriod = 20)
    {
        // Regla 1: Punto inicial - analizar fuerza de compra
        // Buscar formación de fondo y confirmación SHARK azul
        bool foundBottomWithSharkBlue = FindBottomAndSharkConfirmation(
            bars, currentBarIndex, shark, sharkHistory, SharkState.Blue, lookbackPeriod);
        if (!foundBottomWithSharkBlue) return false;
        
        // Regla 2: Formación de topo y SHARK rojo (primer ciclo vendedor)
        bool foundTopWithSharkRed = FindTopAndSharkConfirmation(
            bars, currentBarIndex, shark, sharkHistory, SharkState.Red, lookbackPeriod);
        if (!foundTopWithSharkRed) return false;
        
        // Regla 3: Identificar segundo ciclo comprador
        bool isSecondBuyerCycle = IsSecondBuyerCycle(bars, currentBarIndex, lookbackPeriod);
        if (!isSecondBuyerCycle) return false;
        
        // Regla 4: Segundo ciclo debe estar más alto que el anterior
        bool secondCycleHigher = IsSecondCycleHigher(bars, currentBarIndex, lookbackPeriod);
        if (!secondCycleHigher) return false;
        
        // Regla 5: Segundo ciclo debe estar en MAP más alta que el ciclo de referencia
        // Y VX debe estar subiendo
        bool higherMapLevel = IsSecondCycleAtHigherMap(
            mapsLines, bars, currentBarIndex, lookbackPeriod);
        if (!higherMapLevel) return false;
        
        bool vxRising = IsVxRising(vx);
        if (!vxRising) return false;
        
        // Regla 6: The_Wall debe estar lateral (amarillo) o a favor (verde)
        bool wallFavorable = (wall.Color == WallMapsColor.Yellow) || 
                            (wall.Color == WallMapsColor.Green);
        if (!wallFavorable) return false;
        
        return true; // Todas las reglas cumplidas
    }
    
    private bool FindBottomAndSharkConfirmation(
        RenkoBar[] bars, int currentIndex, SharkData shark, SharkData[] sharkHistory,
        SharkState requiredState, int lookback)
    {
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (IsLocalMinimum(bars, i))
            {
                int sharkIndex = Math.Min(i, sharkHistory.Length - 1);
                if (sharkIndex >= 0 && sharkHistory[sharkIndex].State == requiredState)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    private bool FindTopAndSharkConfirmation(
        RenkoBar[] bars, int currentIndex, SharkData shark, SharkData[] sharkHistory,
        SharkState requiredState, int lookback)
    {
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (IsLocalMaximum(bars, i))
            {
                int sharkIndex = Math.Min(i, sharkHistory.Length - 1);
                if (sharkIndex >= 0 && sharkHistory[sharkIndex].State == requiredState)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    private bool IsSecondBuyerCycle(RenkoBar[] bars, int currentIndex, int lookback)
    {
        int buyerCycleCount = 0;
        bool inBuyerCycle = false;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (bars[i].IsPositive)
            {
                if (!inBuyerCycle)
                {
                    inBuyerCycle = true;
                    buyerCycleCount++;
                }
            }
            else
            {
                inBuyerCycle = false;
            }
        }
        
        return buyerCycleCount >= 2;
    }
    
    private bool IsSecondCycleHigher(RenkoBar[] bars, int currentIndex, int lookback)
    {
        List<double> cycleHighs = new List<double>();
        bool inBuyerCycle = false;
        double currentCycleHigh = double.MinValue;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (bars[i].IsPositive)
            {
                if (!inBuyerCycle)
                {
                    inBuyerCycle = true;
                    currentCycleHigh = bars[i].High;
                }
                else
                {
                    currentCycleHigh = Math.Max(currentCycleHigh, bars[i].High);
                }
            }
            else
            {
                if (inBuyerCycle)
                {
                    cycleHighs.Add(currentCycleHigh);
                    inBuyerCycle = false;
                }
            }
        }
        
        if (cycleHighs.Count >= 2)
        {
            double secondCycle = cycleHighs[cycleHighs.Count - 1];
            double firstCycle = cycleHighs[cycleHighs.Count - 2];
            return secondCycle > firstCycle;
        }
        
        return false;
    }
    
    private bool IsSecondCycleAtHigherMap(
        MapsLine[] mapsLines, RenkoBar[] bars, int currentIndex, int lookback)
    {
        string referenceMap = GetReferenceCycleMap(mapsLines, bars, currentIndex, lookback);
        string secondCycleMap = GetSecondCycleMap(mapsLines, bars, currentIndex);
        
        if (string.IsNullOrEmpty(referenceMap) || string.IsNullOrEmpty(secondCycleMap))
            return false;
        
        // Verificar que segunda MAP es más alta que la de referencia
        return IsMapHigher(secondCycleMap, referenceMap);
    }
    
    private bool IsVxRising(VxData vx)
    {
        // VX debe estar subiendo para confirmar progresión en MAP
        return vx.IsRising; // Simplificado, implementar lógica de tendencia VX
    }
    
    private bool IsLocalMinimum(RenkoBar[] bars, int index)
    {
        if (index <= 0 || index >= bars.Length - 1) return false;
        return bars[index].Low < bars[index - 1].Low && 
               bars[index].Low < bars[index + 1].Low;
    }
    
    private bool IsLocalMaximum(RenkoBar[] bars, int index)
    {
        if (index <= 0 || index >= bars.Length - 1) return false;
        return bars[index].High > bars[index - 1].High && 
               bars[index].High > bars[index + 1].High;
    }
    
    // Métodos auxiliares para obtener MAP de ciclos y comparación
    private string GetReferenceCycleMap(MapsLine[] mapsLines, RenkoBar[] bars, int currentIndex, int lookback)
    {
        // Buscar el fondo del primer ciclo comprador (referencia)
        for (int i = currentIndex - 5; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (IsLocalMinimum(bars, i))
            {
                double price = bars[i].Low;
                return GetClosestMapName(price, mapsLines);
            }
        }
        return null;
    }
    
    private string GetSecondCycleMap(MapsLine[] mapsLines, RenkoBar[] bars, int currentIndex)
    {
        double currentPrice = bars[currentIndex].Close;
        return GetClosestMapName(currentPrice, mapsLines);
    }
    
    private string GetClosestMapName(double price, MapsLine[] mapsLines)
    {
        var activeLines = mapsLines.Where(l => l.IsActive).ToList();
        if (!activeLines.Any()) return null;
        
        var closest = activeLines.OrderBy(l => Math.Abs(l.Price - price)).First();
        return closest.Name;
    }
    
    private bool IsMapHigher(string map1, string map2)
    {
        // Jerarquía de MAPS (de inferior a superior)
        var mapHierarchy = new Dictionary<string, int>
        {
            { MapsConstants.I8, 0 }, { MapsConstants.I7, 1 }, { MapsConstants.I6, 2 },
            { MapsConstants.I5, 3 }, { MapsConstants.I4, 4 }, { MapsConstants.I3, 5 },
            { MapsConstants.I2, 6 }, { MapsConstants.I1, 7 },
            { MapsConstants.MAP_0, 8 },
            { MapsConstants.S1, 9 }, { MapsConstants.S2, 10 }, { MapsConstants.S3, 11 },
            { MapsConstants.S4, 12 }, { MapsConstants.S5, 13 }, { MapsConstants.S6, 14 },
            { MapsConstants.S7, 15 }, { MapsConstants.S8, 16 }
        };
        
        if (!mapHierarchy.ContainsKey(map1) || !mapHierarchy.ContainsKey(map2))
            return false;
        
        return mapHierarchy[map1] > mapHierarchy[map2];
    }
}
```

#### 7.2.1.2 PPM VENDA - Checklist (6 Reglas)

**Secuencia de análisis:** Para operaciones SHORT en PPM:

**Regla 1°: Punto Inicial y Referencia**
- Escoger el lado que se desea analizar
- Si el activo está en **sobreprecio**, se debe analizar la **fuerza de venta**, ya que el objetivo es vender
- **Esperar tener una referencia:** Al menos un **topo**, y verificar si el **SHARK viró rojo**, indicando el inicio de un **ciclo vendedor**

**Regla 2°: Formación de Fondo y Primer Ciclo Comprador**
- **Esperar** la formación de al menos un **fondo** y confirmar que el **SHARK viró azul**, señalando el inicio de un **ciclo comprador**
- Esta formación de fondo es necesaria para identificar el ciclo de referencia

**Regla 3°: Prepararse para Segundo Ciclo Vendedor**
- Prepararse para entrar en el **segundo ciclo vendedor**
- Este es el punto de entrada principal para trades SHORT en PPM

**Regla 4°: Segundo Ciclo Más Bajo**
- Verificar si el segundo ciclo vendedor está en **nivel más bajo** que el primer ciclo vendedor
- Esto confirma que hay progresión bajista en el contexto de PPM

**Regla 5°: Progresión en MAP más Baja**
- Confirmar que el segundo ciclo vendedor está en **una MAP más baja** que la **MAP del ciclo de referencia**
- **Dica:** El VX debe estar en **caída** (descendiendo)
- Ejemplos válidos:
  - S3 con S2 (ciclo de referencia en S3, segundo ciclo en S2)
  - S2 con S1
  - S1 con MAP 0
  - MAP 0 con i1, etc.

**Regla 6°: Estado de The_Wall**
- En el momento de entrada, asegurarse de que **The_Wall está lateralizada o a favor de la operación** (Amarilla o Rosa)
- Para SHORT: The_Wall debe estar **Amarilla (lateral)** o **Rosa/Magenta (a favor)**

```csharp
public class PpmSellChecklist
{
    public bool ValidatePpmSell(
        MapsLine[] mapsLines,
        RenkoBar[] bars,
        int currentBarIndex,
        SharkData shark,
        SharkData[] sharkHistory,
        WallMapsData wall,
        VxData vx,
        int lookbackPeriod = 20)
    {
        // Regla 1: Punto inicial - analizar fuerza de venta
        // Buscar formación de topo y confirmación SHARK rojo
        bool foundTopWithSharkRed = FindTopAndSharkConfirmation(
            bars, currentBarIndex, shark, sharkHistory, SharkState.Red, lookbackPeriod);
        if (!foundTopWithSharkRed) return false;
        
        // Regla 2: Formación de fondo y SHARK azul (primer ciclo comprador)
        bool foundBottomWithSharkBlue = FindBottomAndSharkConfirmation(
            bars, currentBarIndex, shark, sharkHistory, SharkState.Blue, lookbackPeriod);
        if (!foundBottomWithSharkBlue) return false;
        
        // Regla 3: Identificar segundo ciclo vendedor
        bool isSecondSellerCycle = IsSecondSellerCycle(bars, currentBarIndex, lookbackPeriod);
        if (!isSecondSellerCycle) return false;
        
        // Regla 4: Segundo ciclo debe estar en nivel más bajo que el primero
        bool secondCycleLower = IsSecondCycleLower(bars, currentBarIndex, lookbackPeriod);
        if (!secondCycleLower) return false;
        
        // Regla 5: Segundo ciclo debe estar en MAP más baja que el ciclo de referencia
        // Y VX debe estar en caída
        bool lowerMapLevel = IsSecondCycleAtLowerMap(
            mapsLines, bars, currentBarIndex, lookbackPeriod);
        if (!lowerMapLevel) return false;
        
        bool vxFalling = IsVxFalling(vx);
        if (!vxFalling) return false;
        
        // Regla 6: The_Wall debe estar lateral (amarillo) o a favor (rosa/magenta)
        bool wallFavorable = (wall.Color == WallMapsColor.Yellow) || 
                            (wall.Color == WallMapsColor.Pink) ||
                            (wall.Color == WallMapsColor.Magenta);
        if (!wallFavorable) return false;
        
        return true; // Todas las reglas cumplidas
    }
    
    // Métodos similares a PpmBuyChecklist pero para SHORT
    private bool FindTopAndSharkConfirmation(
        RenkoBar[] bars, int currentIndex, SharkData shark, SharkData[] sharkHistory,
        SharkState requiredState, int lookback)
    {
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (IsLocalMaximum(bars, i))
            {
                int sharkIndex = Math.Min(i, sharkHistory.Length - 1);
                if (sharkIndex >= 0 && sharkHistory[sharkIndex].State == requiredState)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    private bool FindBottomAndSharkConfirmation(
        RenkoBar[] bars, int currentIndex, SharkData shark, SharkData[] sharkHistory,
        SharkState requiredState, int lookback)
    {
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (IsLocalMinimum(bars, i))
            {
                int sharkIndex = Math.Min(i, sharkHistory.Length - 1);
                if (sharkIndex >= 0 && sharkHistory[sharkIndex].State == requiredState)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    private bool IsSecondSellerCycle(RenkoBar[] bars, int currentIndex, int lookback)
    {
        int sellerCycleCount = 0;
        bool inSellerCycle = false;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (bars[i].IsNegative)
            {
                if (!inSellerCycle)
                {
                    inSellerCycle = true;
                    sellerCycleCount++;
                }
            }
            else
            {
                inSellerCycle = false;
            }
        }
        
        return sellerCycleCount >= 2;
    }
    
    private bool IsSecondCycleLower(RenkoBar[] bars, int currentIndex, int lookback)
    {
        List<double> cycleLows = new List<double>();
        bool inSellerCycle = false;
        double currentCycleLow = double.MaxValue;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (bars[i].IsNegative)
            {
                if (!inSellerCycle)
                {
                    inSellerCycle = true;
                    currentCycleLow = bars[i].Low;
                }
                else
                {
                    currentCycleLow = Math.Min(currentCycleLow, bars[i].Low);
                }
            }
            else
            {
                if (inSellerCycle)
                {
                    cycleLows.Add(currentCycleLow);
                    inSellerCycle = false;
                }
            }
        }
        
        if (cycleLows.Count >= 2)
        {
            double secondCycle = cycleLows[cycleLows.Count - 1];
            double firstCycle = cycleLows[cycleLows.Count - 2];
            return secondCycle < firstCycle;
        }
        
        return false;
    }
    
    private bool IsSecondCycleAtLowerMap(
        MapsLine[] mapsLines, RenkoBar[] bars, int currentIndex, int lookback)
    {
        string referenceMap = GetReferenceCycleMap(mapsLines, bars, currentIndex, lookback);
        string secondCycleMap = GetSecondCycleMap(mapsLines, bars, currentIndex);
        
        if (string.IsNullOrEmpty(referenceMap) || string.IsNullOrEmpty(secondCycleMap))
            return false;
        
        // Verificar que segunda MAP es más baja que la de referencia
        return IsMapLower(secondCycleMap, referenceMap);
    }
    
    private bool IsVxFalling(VxData vx)
    {
        // VX debe estar en caída para confirmar progresión descendente en MAP
        return vx.IsFalling; // Simplificado, implementar lógica de tendencia VX
    }
    
    // Métodos auxiliares similares a PpmBuyChecklist
    private bool IsLocalMaximum(RenkoBar[] bars, int index)
    {
        if (index <= 0 || index >= bars.Length - 1) return false;
        return bars[index].High > bars[index - 1].High && 
               bars[index].High > bars[index + 1].High;
    }
    
    private bool IsLocalMinimum(RenkoBar[] bars, int index)
    {
        if (index <= 0 || index >= bars.Length - 1) return false;
        return bars[index].Low < bars[index - 1].Low && 
               bars[index].Low < bars[index + 1].Low;
    }
    
    private string GetReferenceCycleMap(MapsLine[] mapsLines, RenkoBar[] bars, int currentIndex, int lookback)
    {
        // Buscar el topo del primer ciclo vendedor (referencia)
        for (int i = currentIndex - 5; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (IsLocalMaximum(bars, i))
            {
                double price = bars[i].High;
                return GetClosestMapName(price, mapsLines);
            }
        }
        return null;
    }
    
    private string GetSecondCycleMap(MapsLine[] mapsLines, RenkoBar[] bars, int currentIndex)
    {
        double currentPrice = bars[currentIndex].Close;
        return GetClosestMapName(currentPrice, mapsLines);
    }
    
    private string GetClosestMapName(double price, MapsLine[] mapsLines)
    {
        var activeLines = mapsLines.Where(l => l.IsActive).ToList();
        if (!activeLines.Any()) return null;
        
        var closest = activeLines.OrderBy(l => Math.Abs(l.Price - price)).First();
        return closest.Name;
    }
    
    private bool IsMapLower(string map1, string map2)
    {
        var mapHierarchy = new Dictionary<string, int>
        {
            { MapsConstants.I8, 0 }, { MapsConstants.I7, 1 }, { MapsConstants.I6, 2 },
            { MapsConstants.I5, 3 }, { MapsConstants.I4, 4 }, { MapsConstants.I3, 5 },
            { MapsConstants.I2, 6 }, { MapsConstants.I1, 7 },
            { MapsConstants.MAP_0, 8 },
            { MapsConstants.S1, 9 }, { MapsConstants.S2, 10 }, { MapsConstants.S3, 11 },
            { MapsConstants.S4, 12 }, { MapsConstants.S5, 13 }, { MapsConstants.S6, 14 },
            { MapsConstants.S7, 15 }, { MapsConstants.S8, 16 }
        };
        
        if (!mapHierarchy.ContainsKey(map1) || !mapHierarchy.ContainsKey(map2))
            return false;
        
        return mapHierarchy[map1] < mapHierarchy[map2];
    }
}
```

#### 7.2.1.3 Relación de PPM con Fases del Mercado

**Fases Fundamentales del Mercado:**

El mercado pasa por diferentes fases, descritas en la literatura clásica. Antes de profundizar en los escenarios (PPM y MM), es importante entender que el mercado atraviesa diferentes fases.

**Para Ciclos Compradores:**
1. **Acumulação** (Acumulación)
2. **Início de Alta** (Inicio de Alta)
3. **Alta Forte** (Alta Fuerte)

**Para Ciclos Vendedores:**
1. **Distribuição** (Distribución)
2. **Início de Baixa** (Inicio de Baja)
3. **Baixa Forte** (Baja Fuerte)

**Fases Complementarias:**
- **Reacumulação** (Reacumulación): Ocurre cuando la acumulación no genera inicio de alta ni alta fuerte. La fuerza compradora aún predomina. Hay lateralización en medio del camino, pero después de esa lateralización, el movimiento vuelve a subir, retomando la tendencia de alta.
- **Redistribuição** (Redistribución): Ocurre cuando la distribución no genera inicio de baixa ni baixa forte. La fuerza vendedora aún predomina. Hay lateralización en medio del camino, pero después de ese período, el movimiento continúa en dirección a la baja.

#### 7.2.1.3.1 Acumulação (Acumulación)

**Definición:**

Una acumulación exitosa es el punto de partida para un movimiento de alta. Generalmente ocurre después de una caída fuerte del mercado (bear market), cuando los precios de los activos están bajos y se consideran "por debajo del valor justo de mercado". La acumulación solo se confirma si los movimientos posteriores indican el comienzo de un movimiento de alta, seguido por una alta fuerte.

Durante esta fase, inversores bien informados comienzan a adquirir activos, reconociendo que el mercado está infravalorado.

**Características:**

**MAPS:**
- Este movimiento generalmente ocurre en **i3, i4 o i5**, con el rango específico dependiendo de la volatilidad del activo
- Mayor volatilidad corresponde a un área de acumulación más baja

Ejemplos por activo:
- **Dólar:** Generalmente en **i2, i3 o i4**
- **Índice:** Debido a mayor volatilidad, normalmente en **i3, i4 o i5**
- **Nasdaq:** Con volatilidad aún mayor, generalmente en **i4, i5 o i6**

**The_Wall (del gráfico):**
- La acumulación ocurre contra un movimiento de tendencia bajista
- Esto significa que los síntomas de acumulación emergen mientras "The_Wall" todavía está **rosa (magenta/fucsia)**
- Si la acumulación es exitosa, The_Wall comenzará a lateralizarse hasta volverse **amarilla**
- El precio debe entonces permanecer **arriba de The_Wall** y **arriba de la MAP central**
- Si estas condiciones no se cumplen, significa que la acumulación fue fallida, llevando a una redistribución

#### 7.2.1.3.2 Início de Alta (Inicio de Alta)

**Definición:**

La mayoría de los inversores comienza a percibir la recuperación del mercado. Sin embargo, todavía no hay una confianza sólida por parte del público menos informado.

**Características:**

**MAPS:**
- El inicio de alta puede ocurrir en **cualquier área inferior del MAPA**, desde que el precio esté **arriba de i4**
- **i4 es el punto** en que un activo "normaliza" la caída
- **Abajo de i4**, el activo todavía está muy volátil, lo que torna arriesgado considerar un movimiento de alta
- Gradualmente, el precio comienza a formar **fondos más altos** en las MAPS, caracterizando el llamado **Progresso de Preço em MAPS (PPM)**
- Ejemplo: un fondo en i3, seguido por un nuevo fondo en i1

**The_Wall (del gráfico):**
- Normalmente, en un inicio de alta, el precio estará ligeramente **arriba o abajo** de la línea de The_Wall, intentando moverse hacia la parte positiva de las MAPS
- Durante este movimiento, The_Wall tiende a cambiar de color, pasando de **rosa (magenta/fucsia) para amarillo**

**Preços Progredindo em MAPS:**
- En los inicios de alta, es posible observar **solo escenarios de Progresso de Preço em MAP (PPM)**
- El escenario de MAP con MAP (MM) no es aplicable, porque si estuviera ocurriendo, todavía sería considerado una acumulación

#### 7.2.1.3.3 Alta Forte (Alta Fuerte)

**Definición:**

La alta fuerte es la última etapa de un movimiento de alta. Esta fase se caracteriza por un aumento significativo en los precios de los activos, muchas veces impulsado por la especulación y el optimismo exagerado. En ese momento, la entrada de inversores menos experimentados, influenciados por el entusiasmo de los medios y la euforia del mercado, acelera aún más el crecimiento de los precios.

**Características:**

**MAPS:**
- La alta fuerte puede ocurrir en **cualquier región superior del MAPA**, es decir, de la **MAP central para arriba**
- Gradualmente, el precio va formando **fondos más altos** en las MAPs
- Con frecuencia, **acelera al romper la S2**
- Este movimiento tiende a prolongarse hasta alcanzar la **región de sobreprecio**, momento en que la alta comienza a desacelerar

**The_Wall (del gráfico):**
- The_Wall **NO puede estar rosa (magenta/fucsia)**. Si está, no se puede considerar el movimiento como una alta fuerte
- Normalmente, en una alta fuerte, el precio estará **arriba de la línea de The_Wall**, intentando permanecer en la parte positiva de las MAPs
- Aunque no sea obligatorio, la coloración **verde de The_Wall** indica una fuerza aún mayor para el movimiento

**Preços Progredindo em MAPS:**
- En las altas fuertes, es posible observar escenarios de **Progresso de Preço em MAP (PPM)** y también de **MAP com MAP**, a partir de la **MAP central (M0)**

#### 7.2.1.3.4 Distribuição (Distribución)

**Definición:**

Una distribución exitosa puede ser el punto de partida para un movimiento de baja. Generalmente ocurre después de un período de fuerte rally del mercado (alta fuerte), cuando los precios de los activos están en niveles elevados y considerados por encima de su "valor justo de mercado". Solo se considera una distribución si, después de este movimiento, emergen movimientos de baja inicial y baja fuerte.

**Características:**

**MAPS:**
- Este movimiento normalmente está ubicado en **s3, s4 o s5**
- Esto puede variar según la volatilidad del activo; mayor volatilidad lleva a un área de distribución superior

Ejemplos por activo:
- **Dólar:** Distribución típicamente ocurre en **s2, s3, s4**
- **Índice:** Al ser más volátil, generalmente ocurre en **s3, s4, s5**
- **Nasdaq:** Con volatilidad aún mayor, distribución generalmente ocurre en **s4, s5, s6**

**The_Wall (del gráfico):**
- La distribución ocurre contra un movimiento de tendencia alcista
- Por lo tanto, las señales de distribución emergen mientras "The_Wall" todavía está **verde**
- Si la distribución es exitosa, The_Wall comenzará a lateralizarse hasta volverse **amarilla**
- En este escenario, el precio debe permanecer **abajo de The_Wall** y **abajo de la MAP central**
- De lo contrario, significa que la distribución no fue exitosa, siendo caracterizada como una reacumulación

**Preços Estáveis (Precios Estables):**
- Después de un período de ascenso acentuado, los precios de los activos tienden a estabilizarse, dejando el activo en consolidación
- Durante estas consolidaciones, es posible identificar escenarios de **MAP com MAP (MM)** y **Progresso de Preço em MAP (PPM)**

#### 7.2.1.3.5 Início de Baixa (Inicio de Baja)

**Definición:**

La mayoría de los inversores comienza a percibir que los precios pueden estar altos. Sin embargo, todavía no hay una confianza concreta por parte del público desinformado.

**Características:**

**MAPS:**
- Este movimiento puede ocurrir en **cualquier parte superior del MAPA**, desde que esté **abajo de s4**
- El nivel **s4 es el punto** en que un activo "normaliza" la alta; arriba de ese nivel, todavía no es recomendado pensar en caída, porque el activo permanece muy volátil
- A los pocos, el precio comienza a formar **topos más bajos** en las MAPS, caracterizando el llamado **Progresso de Preço em MAPS**
- Ejemplo: un topo en s3, seguido por un nuevo topo en s1

**The_Wall (del gráfico):**
- Normalmente, en un inicio de baja, el precio estará ligeramente **arriba o abajo** de la línea de The_Wall, intentando descender hacia la parte negativa de las MAPS
- Durante este movimiento, The_Wall tiende a cambiar de color, pasando de **verde para amarillo**

**Preços Progredindo em MAPS:**
- En los inicios de baja, es posible observar **solo escenarios de Progresso de Preço em MAP (PPM)**
- El escenario de MAP com MAP no es aplicable, porque si estuviera ocurriendo, todavía sería considerado una distribución

#### 7.2.1.3.6 Baixa Forte (Baja Fuerte)

**Definición:**

La fase de baja fuerte es la última etapa del movimiento de fuerza de baja. Se caracteriza por una caída excesiva en los precios de los activos, muchas veces impulsada por la especulación y el pesimismo exagerado. En este momento, la entrada de inversores menos experimentados, influenciados por el pesimismo de los medios y el pánico del mercado, acelera aún más la caída de los precios.

**Características:**

**MAPS:**
- Este movimiento puede ocurrir en **cualquier parte inferior del MAPA**, es decir, de la **MAP central para abajo**
- Gradualmente, el precio comienza a formar **topos más bajos** en las MAPS
- Normalmente, puede acelerar con el **rompimiento de la i2**
- Este movimiento tiende a extenderse hasta la **región de subprecio**
- Al alcanzar la región de subprecio, la baja comienza a desacelerar

**The_Wall (del gráfico):**
- The_Wall **NO puede estar verde**; si está, no se puede considerar una baja fuerte
- Generalmente, en una baja fuerte, el precio estará **abajo de la línea de The_Wall** e intentará permanecer en la parte negativa de las MAPS
- No es obligatorio, pero si The_Wall se vuelve **roja**, indica aún más fuerza en el movimiento

**Preços Progredindo em MAPS:**
- En las bajas fuertes, es posible observar escenarios de **Progresso de Preço em MAP (PPM)**, así como escenarios de **MAP com MAP** a partir de la **MAP central (M0)**

#### 7.2.1.3.7 Reacumulação y Redistribuição

**Reacumulação (Reacumulación):**

**Cuándo ocurre:**
- Cuando la acumulación **NO consigue generar** el inicio de alta ni la alta fuerte
- Esto ocurre porque la **fuerza de compra aún es predominante**

**Características:**
- La reacumulación ocurre cuando hay una **lateralización en medio del camino**, pero después de esa lateralización, el movimiento **vuelve a subir**, retomando la tendencia de alta
- En este caso, el precio NO permanece abajo de The_Wall y abajo de la MAP central, como sería esperado en una distribución exitosa

**Redistribuição (Redistribución):**

**Cuándo ocurre:**
- Cuando la distribución **NO consigue generar** el inicio de baja ni la baja fuerte
- Esto ocurre porque la **fuerza de venta aún es predominante**

**Características:**
- La redistribución ocurre cuando hay una **lateralización en medio del camino**, pero después de ese período, el movimiento **continúa en dirección a la baja**
- En este caso, el precio NO permanece arriba de The_Wall y arriba de la MAP central, como sería esperado en una acumulación exitosa

```csharp
public class ConvergenceDetector
{
    public bool DetectConvergence(
        RenkoBar[] priceBars,
        MapData[] maps,
        int currentBarIndex,
        int lookback = 5)
    {
        // Convergencia: precio progresa en dirección del MAP
        // Precio haciendo máximos/mínimos más altos/bajos
        // MAP también progresa en la misma dirección
        
        bool priceProgressingUp = IsPriceProgressingUp(priceBars, currentBarIndex, lookback);
        bool priceProgressingDown = IsPriceProgressingDown(priceBars, currentBarIndex, lookback);
        
        bool mapProgressingUp = IsMapProgressingUp(maps, currentBarIndex, lookback);
        bool mapProgressingDown = IsMapProgressingDown(maps, currentBarIndex, lookback);
        
        // Convergencia alcista: ambos progresando arriba
        bool bullishConvergence = priceProgressingUp && mapProgressingUp;
        
        // Convergencia bajista: ambos progresando abajo
        bool bearishConvergence = priceProgressingDown && mapProgressingDown;
        
        return bullishConvergence || bearishConvergence;
    }
    
    private bool IsPriceProgressingUp(RenkoBar[] bars, int currentIndex, int lookback)
    {
        if (currentIndex < lookback) return false;
        
        double recentHigh = bars[currentIndex].High;
        double previousHigh = bars[currentIndex - lookback].High;
        
        return recentHigh > previousHigh;
    }
    
    private bool IsPriceProgressingDown(RenkoBar[] bars, int currentIndex, int lookback)
    {
        if (currentIndex < lookback) return false;
        
        double recentLow = bars[currentIndex].Low;
        double previousLow = bars[currentIndex - lookback].Low;
        
        return recentLow < previousLow;
    }
    
    private bool IsMapProgressingUp(MapData[] maps, int currentIndex, int lookback)
    {
        if (currentIndex < lookback) return false;
        
        double recentValue = maps[currentIndex].Value;
        double previousValue = maps[currentIndex - lookback].Value;
        
        return recentValue > previousValue;
    }
    
    private bool IsMapProgressingDown(MapData[] maps, int currentIndex, int lookback)
    {
        if (currentIndex < lookback) return false;
        
        double recentValue = maps[currentIndex].Value;
        double previousValue = maps[currentIndex - lookback].Value;
        
        return recentValue < previousValue;
    }
}
```

#### 7.2.2 MM (MAP com MAP) - Divergencia

**MM** es el escenario donde se analiza la **divergencia** en el comparativo de MAP con MAP.

**Definición de Divergencia:**
- **Divergencia alcista (bearish):** Precio haciendo máximos más altos, pero indicador haciendo máximos más bajos.
- **Divergencia bajista (bullish):** Precio haciendo mínimos más bajos, pero indicador haciendo mínimos más altos.
- La divergencia indica debilidad en la tendencia actual y posible reversión.

```csharp
public enum DivergenceType
{
    None = 0,
    BearishDivergence = 1,  // Precio sube, indicador baja (señal de venta)
    BullishDivergence = 2   // Precio baja, indicador sube (señal de compra)
}

public class DivergenceDetector
{
    public DivergenceType DetectDivergence(
        RenkoBar[] priceBars,
        MapData[] maps,
        int currentBarIndex,
        int lookback = 5)
    {
        // Buscar dos máximos consecutivos en precio
        double priceHigh1 = FindRecentHigh(priceBars, currentBarIndex, lookback);
        double priceHigh2 = FindPreviousHigh(priceBars, currentBarIndex, lookback * 2);
        
        // Buscar dos máximos consecutivos en indicador MAP
        double mapHigh1 = FindRecentHigh(maps, currentBarIndex, lookback);
        double mapHigh2 = FindPreviousHigh(maps, currentBarIndex, lookback * 2);
        
        // Divergencia alcista (bearish): precio sube, indicador baja
        if (priceHigh1 > priceHigh2 && mapHigh1 < mapHigh2)
        {
            return DivergenceType.BearishDivergence;
        }
        
        // Buscar dos mínimos consecutivos en precio
        double priceLow1 = FindRecentLow(priceBars, currentBarIndex, lookback);
        double priceLow2 = FindPreviousLow(priceBars, currentBarIndex, lookback * 2);
        
        // Buscar dos mínimos consecutivos en indicador MAP
        double mapLow1 = FindRecentLow(maps, currentBarIndex, lookback);
        double mapLow2 = FindPreviousLow(maps, currentBarIndex, lookback * 2);
        
        // Divergencia bajista (bullish): precio baja, indicador sube
        if (priceLow1 < priceLow2 && mapLow1 > mapLow2)
        {
            return DivergenceType.BullishDivergence;
        }
        
        return DivergenceType.None;
    }
    
    private double FindRecentHigh(RenkoBar[] bars, int currentIndex, int lookback)
    {
        double maxHigh = double.MinValue;
        int startIndex = Math.Max(0, currentIndex - lookback);
        
        for (int i = startIndex; i <= currentIndex; i++)
        {
            if (bars[i].High > maxHigh)
            {
                maxHigh = bars[i].High;
            }
        }
        
        return maxHigh;
    }
    
    private double FindPreviousHigh(RenkoBar[] bars, int currentIndex, int lookback)
    {
        double maxHigh = double.MinValue;
        int startIndex = Math.Max(0, currentIndex - lookback * 2);
        int endIndex = Math.Max(0, currentIndex - lookback);
        
        for (int i = startIndex; i < endIndex; i++)
        {
            if (bars[i].High > maxHigh)
            {
                maxHigh = bars[i].High;
            }
        }
        
        return maxHigh;
    }
    
    // Métodos similares para FindRecentLow, FindPreviousLow, y para MapData
}
```

```csharp
public enum PpmScenario
{
    None = 0,
    PpmBuy = 1,      // PPM na Compra (progresión de precio en MAP comprando, de MAP 0 hacia arriba)
    PpmSell = 2      // PPM na Venda (progresión de precio en MAP vendendo, de MAP 0 hacia abajo)
}

public class PpmDetector
{
    public PpmScenario DetectPpmScenario(
        RenkoBar[] bars,
        MapsLine[] mapsLines,  // MAP lines (S1-S8, i1-i8, Map-0)
        int currentBarIndex,
        int lookbackPeriod = 20)
    {
        // PPM: El precio progresa a través de las MAPS
        MapsLine map0 = mapsLines.FirstOrDefault(l => l.Name == MapsConstants.MAP_0);
        if (map0 == null) return PpmScenario.None;
        
        // Analizar las últimas N barras para ver si el precio progresa a través de MAPS
        List<string> touchedMaps = new List<string>();
        
        for (int i = currentBarIndex; i >= Math.Max(0, currentBarIndex - lookbackPeriod); i--)
        {
            double price = bars[i].Close;
            string closestMap = GetClosestMapName(price, mapsLines);
            
            if (!string.IsNullOrEmpty(closestMap))
            {
                touchedMaps.Add(closestMap);
            }
        }
        
        // Verificar si hay progresión hacia arriba (PpmBuy)
        bool progressingUp = IsProgressingUpward(touchedMaps);
        if (progressingUp)
        {
            return PpmScenario.PpmBuy;
        }
        
        // Verificar si hay progresión hacia abajo (PpmSell)
        bool progressingDown = IsProgressingDownward(touchedMaps);
        if (progressingDown)
        {
            return PpmScenario.PpmSell;
        }
        
        return PpmScenario.None; // No hay progresión clara (podría ser MM)
    }
    
    private bool IsProgressingUpward(List<string> touchedMaps)
    {
        // Progresión hacia arriba: precio tocó MAPs en orden ascendente
        // Ejemplo: MAP 0 → S1 → S2 → S3
        var mapHierarchy = new Dictionary<string, int>
        {
            { MapsConstants.I8, 0 }, { MapsConstants.I7, 1 }, { MapsConstants.I6, 2 },
            { MapsConstants.I5, 3 }, { MapsConstants.I4, 4 }, { MapsConstants.I3, 5 },
            { MapsConstants.I2, 6 }, { MapsConstants.I1, 7 },
            { MapsConstants.MAP_0, 8 },
            { MapsConstants.S1, 9 }, { MapsConstants.S2, 10 }, { MapsConstants.S3, 11 },
            { MapsConstants.S4, 12 }, { MapsConstants.S5, 13 }, { MapsConstants.S6, 14 },
            { MapsConstants.S7, 15 }, { MapsConstants.S8, 16 }
        };
        
        // Verificar si la secuencia de MAPs tocadas muestra progresión ascendente
        int previousLevel = -1;
        int ascendingCount = 0;
        
        foreach (var map in touchedMaps)
        {
            if (mapHierarchy.ContainsKey(map))
            {
                int currentLevel = mapHierarchy[map];
                
                if (previousLevel >= 0 && currentLevel > previousLevel)
                {
                    ascendingCount++;
                }
                
                previousLevel = currentLevel;
            }
        }
        
        // Si hay al menos 2 progresiones ascendentes consecutivas, es PPM Buy
        return ascendingCount >= 2;
    }
    
    private bool IsProgressingDownward(List<string> touchedMaps)
    {
        // Similar a IsProgressingUpward pero para dirección descendente
        var mapHierarchy = new Dictionary<string, int>
        {
            { MapsConstants.I8, 0 }, { MapsConstants.I7, 1 }, { MapsConstants.I6, 2 },
            { MapsConstants.I5, 3 }, { MapsConstants.I4, 4 }, { MapsConstants.I3, 5 },
            { MapsConstants.I2, 6 }, { MapsConstants.I1, 7 },
            { MapsConstants.MAP_0, 8 },
            { MapsConstants.S1, 9 }, { MapsConstants.S2, 10 }, { MapsConstants.S3, 11 },
            { MapsConstants.S4, 12 }, { MapsConstants.S5, 13 }, { MapsConstants.S6, 14 },
            { MapsConstants.S7, 15 }, { MapsConstants.S8, 16 }
        };
        
        int previousLevel = -1;
        int descendingCount = 0;
        
        foreach (var map in touchedMaps)
        {
            if (mapHierarchy.ContainsKey(map))
            {
                int currentLevel = mapHierarchy[map];
                
                if (previousLevel >= 0 && currentLevel < previousLevel)
                {
                    descendingCount++;
                }
                
                previousLevel = currentLevel;
            }
        }
        
        return descendingCount >= 2;
    }
    
    private string GetClosestMapName(double price, MapsLine[] mapsLines)
    {
        var activeLines = mapsLines.Where(l => l.IsActive).ToList();
        if (!activeLines.Any()) return null;
        
        var closest = activeLines.OrderBy(l => Math.Abs(l.Price - price)).First();
        return closest.Name;
    }
}
```

#### 7.1.2 MM (MAP com MAP) - Divergencia

**Definición Conceptual:**

**MAP con MAP (MM)** es un escenario donde el precio **NO progresa** en las MAPS y **continúa retornando a la misma MAP**. Por este motivo, es llamado "MAP con MAP" (comparación de una MAP consigo misma).

**Diferencia clave con PPM:**
- **PPM (Convergencia):** El precio progresa a través de las MAPS en una dirección (ej: de MAP 0 a S1, luego a S2, etc.)
- **MM (Divergencia):** El precio NO progresa y continúa volviendo a la misma MAP (ej: MAP 0 → S1 → vuelve a MAP 0 → S1 → vuelve a MAP 0)

**Características:**
- Frecuencia: Ocurre con **menor frecuencia** que PPM
- Uso: Solo se usará cuando el escenario PPM **NO es aplicable**
- Movimientos: Los movimientos en MM normalmente **NO son tan expresivos** como en PPM
- Contexto: Tienden a ocurrir durante **momentos de lateralización del mercado**

**Comparación con PPM:**
- El escenario MAP con MAP es **más débil** que el escenario Progresso de Preço em MAP (PPM)
- Esto puede observarse fácilmente: el movimiento en PPM avanza significativamente más que los movimientos en MM

**Análisis requerido:**
En el escenario MM, la comparación se hace **entre una MAP y ella misma**, respetando la misma secuencia de ciclos.

**Ejemplo:** MAP Central (Map 0) con su propia MAP Central (Map 0), respetando la misma secuencia de ciclos.

```csharp
public class MmDetector
{
    public bool IsMmScenario(
        MapsLine[] mapsLines,
        RenkoBar[] bars,
        int currentBarIndex,
        int lookbackPeriod = 20)
    {
        // MM: El precio NO progresa y continúa volviendo a la misma MAP
        
        MapsLine map0 = mapsLines.FirstOrDefault(l => l.Name == MapsConstants.MAP_0);
        if (map0 == null) return false;
        
        // Analizar las últimas N barras para ver si el precio vuelve a la misma MAP
        List<string> touchedMaps = new List<string>();
        
        for (int i = currentBarIndex; i >= Math.Max(0, currentBarIndex - lookbackPeriod); i--)
        {
            double price = bars[i].Close;
            string closestMap = GetClosestMapName(price, mapsLines);
            
            if (!string.IsNullOrEmpty(closestMap) && !touchedMaps.Contains(closestMap))
            {
                touchedMaps.Add(closestMap);
            }
        }
        
        // Si el precio toca la misma MAP múltiples veces sin progresar, es MM
        // Ejemplo: MAP 0 → S1 → MAP 0 → S1 (no progresa a S2)
        bool priceReturnsToSameMap = HasPriceReturnedToSameMap(touchedMaps, map0.Name);
        
        return priceReturnsToSameMap;
    }
    
    private bool HasPriceReturnedToSameMap(List<string> touchedMaps, string referenceMap)
    {
        // Contar cuántas veces volvió a la misma MAP
        int returnCount = touchedMaps.Count(m => m == referenceMap);
        
        // Si vuelve 2 o más veces a la misma MAP, es MM
        return returnCount >= 2;
    }
    
    private string GetClosestMapName(double price, MapsLine[] mapsLines)
    {
        var activeLines = mapsLines.Where(l => l.IsActive).ToList();
        if (!activeLines.Any()) return null;
        
        var closest = activeLines.OrderBy(l => Math.Abs(l.Price - price)).First();
        return closest.Name;
    }
}
```

#### 7.1.2.1 Reglas para Ciclos Compradores en MM

**Condiciones para operaciones LONG en escenario MM:**

**1°: Punto Inicial (Initial Point):**
- Escoger el lado que se desea analizar
- Ejemplo: Si el activo está en **MAP Central** y está **azul**, se quiere analizar la fuerza de compra, ya que se está interesado en comprar

**2°: Esperar formación de fondo y confirmación SHARK:**
- Siempre es necesario esperar la formación de al menos un **fondo**
- En ese fondo de referencia, el **SHARK debe virar azul**, indicando el inicio del **primer ciclo comprador**

**3°: Prepararse para entrar en el segundo ciclo comprador:**
- Prepararse para entrar en el **segundo ciclo comprador**
- Este es el punto de entrada principal para trades LONG en MM

**4°: El segundo ciclo comprador debe estar más alto:**
- El segundo ciclo comprador debe estar **más alto** que el ciclo anterior
- Esto confirma que hay progresión a pesar de estar en MM

**5°: Alineación con MAP de referencia:**
- Para una compra, el segundo ciclo comprador debe estar en la **misma MAP** del ciclo de referencia
- Ejemplos:
  - MAP 0 con MAP 0
  - S1 con S1
  - S2 con S2
  - O incluso en las inferiores: i1 con i1, i2 con i2, etc.

**6°: Estado de The_Wall:**
- En el momento de entrada en la operación, **The_Wall debe estar lateral o a favor del lado que deseas operar**
- Para LONG: The_Wall debe estar **Amarilla (lateral)** o **Verde (a favor)**

```csharp
public class MmBuyerCycleRules
{
    public bool ValidateMmBuyerCycle(
        MapsLine[] mapsLines,
        RenkoBar[] bars,
        int currentBarIndex,
        SharkData shark,
        FplemeData fpleme,
        WallMapsData wall,
        int lookbackPeriod = 20)
    {
        // Regla 1: Identificar MAP Central y su color (debe ser azul para analizar fuerza de compra)
        MapsLine map0 = mapsLines.FirstOrDefault(l => l.Name == MapsConstants.MAP_0);
        if (map0 == null || map0.Color != MapsLineColor.Blue) return false;
        
        // Regla 2: Buscar formación de fondo y confirmación SHARK azul
        bool foundBottom = FindBottomAndSharkConfirmation(
            bars, currentBarIndex, shark, lookbackPeriod);
        if (!foundBottom) return false;
        
        // Regla 3: Identificar segundo ciclo comprador
        bool isSecondBuyerCycle = IsSecondBuyerCycle(bars, currentBarIndex, lookbackPeriod);
        if (!isSecondBuyerCycle) return false;
        
        // Regla 4: Segundo ciclo debe estar más alto que el anterior
        bool secondCycleHigher = IsSecondCycleHigher(bars, currentBarIndex, lookbackPeriod);
        if (!secondCycleHigher) return false;
        
        // Regla 5: Segundo ciclo debe estar en la misma MAP que el ciclo de referencia
        bool sameMapLevel = IsSecondCycleAtSameMapLevel(
            mapsLines, bars, currentBarIndex, lookbackPeriod);
        if (!sameMapLevel) return false;
        
        // Regla 6: The_Wall debe estar lateral (amarillo) o a favor (verde)
        bool wallFavorable = (wall.Color == WallMapsColor.Yellow) || 
                            (wall.Color == WallMapsColor.Green);
        if (!wallFavorable) return false;
        
        return true;
    }
    
    private bool FindBottomAndSharkConfirmation(
        RenkoBar[] bars, int currentIndex, SharkData shark, int lookback)
    {
        // Buscar al menos un fondo en las últimas N barras
        bool foundBottom = false;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            // Detectar fondo: mínimo local
            if (IsLocalMinimum(bars, i))
            {
                foundBottom = true;
                
                // Verificar que SHARK viró azul en o después de ese fondo
                // (lógica simplificada, en producción necesitarías datos históricos de SHARK)
                if (shark.State == SharkState.Blue)
                {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    private bool IsLocalMinimum(RenkoBar[] bars, int index)
    {
        if (index <= 0 || index >= bars.Length - 1) return false;
        
        return bars[index].Low < bars[index - 1].Low && 
               bars[index].Low < bars[index + 1].Low;
    }
    
    private bool IsSecondBuyerCycle(RenkoBar[] bars, int currentIndex, int lookback)
    {
        // Contar ciclos compradores (consecutivos de boxes positivos)
        int buyerCycleCount = 0;
        bool inBuyerCycle = false;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (bars[i].IsPositive)
            {
                if (!inBuyerCycle)
                {
                    inBuyerCycle = true;
                    buyerCycleCount++;
                }
            }
            else
            {
                inBuyerCycle = false;
            }
        }
        
        return buyerCycleCount >= 2;
    }
    
    private bool IsSecondCycleHigher(RenkoBar[] bars, int currentIndex, int lookback)
    {
        // Comparar máximos de ciclos compradores
        List<double> cycleHighs = new List<double>();
        bool inBuyerCycle = false;
        double currentCycleHigh = double.MinValue;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (bars[i].IsPositive)
            {
                if (!inBuyerCycle)
                {
                    inBuyerCycle = true;
                    currentCycleHigh = bars[i].High;
                }
                else
                {
                    currentCycleHigh = Math.Max(currentCycleHigh, bars[i].High);
                }
            }
            else
            {
                if (inBuyerCycle)
                {
                    cycleHighs.Add(currentCycleHigh);
                    inBuyerCycle = false;
                    currentCycleHigh = double.MinValue;
                }
            }
        }
        
        if (inBuyerCycle && currentCycleHigh > double.MinValue)
        {
            cycleHighs.Add(currentCycleHigh);
        }
        
        // El segundo ciclo (más reciente) debe ser más alto que el primero
        if (cycleHighs.Count >= 2)
        {
            double secondCycleHigh = cycleHighs[cycleHighs.Count - 1]; // Más reciente
            double firstCycleHigh = cycleHighs[cycleHighs.Count - 2];  // Anterior
            
            return secondCycleHigh > firstCycleHigh;
        }
        
        return false;
    }
    
    private bool IsSecondCycleAtSameMapLevel(
        MapsLine[] mapsLines, RenkoBar[] bars, int currentIndex, int lookback)
    {
        // Obtener MAP del ciclo de referencia (primer ciclo)
        string referenceMap = GetReferenceCycleMap(mapsLines, bars, currentIndex, lookback);
        if (string.IsNullOrEmpty(referenceMap)) return false;
        
        // Obtener MAP del segundo ciclo (ciclo actual)
        string secondCycleMap = GetSecondCycleMap(mapsLines, bars, currentIndex);
        if (string.IsNullOrEmpty(secondCycleMap)) return false;
        
        // Deben estar en la misma MAP
        return referenceMap == secondCycleMap;
    }
    
    private string GetReferenceCycleMap(MapsLine[] mapsLines, RenkoBar[] bars, int currentIndex, int lookback)
    {
        // Buscar el primer ciclo comprador (ciclo de referencia)
        // Simplificado: encontrar el fondo más antiguo y determinar su MAP
        for (int i = currentIndex - 5; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (IsLocalMinimum(bars, i))
            {
                double price = bars[i].Low;
                return GetClosestMapName(price, mapsLines);
            }
        }
        
        return null;
    }
    
    private string GetSecondCycleMap(MapsLine[] mapsLines, RenkoBar[] bars, int currentIndex)
    {
        // MAP del segundo ciclo (ciclo actual)
        double currentPrice = bars[currentIndex].Close;
        return GetClosestMapName(currentPrice, mapsLines);
    }
    
    private string GetClosestMapName(double price, MapsLine[] mapsLines)
    {
        var activeLines = mapsLines.Where(l => l.IsActive).ToList();
        if (!activeLines.Any()) return null;
        
        var closest = activeLines.OrderBy(l => Math.Abs(l.Price - price)).First();
        return closest.Name;
    }
}
```

#### 7.1.2.2 Reglas para Ciclos Vendedores en MM

**Condiciones para operaciones SHORT en escenario MM:**

**1°: Punto Inicial:**
- Escoger el lado que se desea analizar
- Ejemplo: Si el activo está en **MAP Central** y está **naranja**, el foco será analizar la fuerza de venta, ya que el objetivo es vender

**2°: Esperar formación de topo y confirmación SHARK:**
- Siempre es necesario esperar la formación de al menos un **topo**
- En ese topo de referencia, el **SHARK debe virar rojo**, indicando el inicio del **primer ciclo vendedor**

**3°: Prepararse para entrar en el segundo ciclo vendedor:**
- Prepararse para entrar en el **segundo ciclo vendedor**
- Este es el punto de entrada principal para trades SHORT en MM

**4°: El segundo ciclo vendedor debe estar más bajo:**
- El segundo ciclo vendedor debe estar **más bajo** que el ciclo anterior
- Esto confirma que hay progresión bajista a pesar de estar en MM

**5°: Alineación con MAP de referencia:**
- Para una venta, el segundo ciclo vendedor debe estar en la **misma MAP** del ciclo de referencia
- Ejemplos:
  - MAP 0 con MAP 0
  - i1 con i1
  - i2 con i2
  - O incluso en las superiores: S3 con S3, S2 con S2, etc.

**6°: Estado de The_Wall:**
- En el momento de entrada en la operación, **The_Wall debe estar lateral o a favor del lado que deseas operar**
- Para SHORT: The_Wall debe estar **Amarilla (lateral)** o **Rosa/Magenta (a favor)**

```csharp
public class MmSellerCycleRules
{
    public bool ValidateMmSellerCycle(
        MapsLine[] mapsLines,
        RenkoBar[] bars,
        int currentBarIndex,
        SharkData shark,
        FplemeData fpleme,
        WallMapsData wall,
        int lookbackPeriod = 20)
    {
        // Regla 1: Identificar MAP Central y su color (debe ser naranja para analizar fuerza de venta)
        MapsLine map0 = mapsLines.FirstOrDefault(l => l.Name == MapsConstants.MAP_0);
        if (map0 == null || map0.Color != MapsLineColor.Orange) return false;
        
        // Regla 2: Buscar formación de topo y confirmación SHARK rojo
        bool foundTop = FindTopAndSharkConfirmation(
            bars, currentBarIndex, shark, lookbackPeriod);
        if (!foundTop) return false;
        
        // Regla 3: Identificar segundo ciclo vendedor
        bool isSecondSellerCycle = IsSecondSellerCycle(bars, currentBarIndex, lookbackPeriod);
        if (!isSecondSellerCycle) return false;
        
        // Regla 4: Segundo ciclo debe estar más bajo que el anterior
        bool secondCycleLower = IsSecondCycleLower(bars, currentBarIndex, lookbackPeriod);
        if (!secondCycleLower) return false;
        
        // Regla 5: Segundo ciclo debe estar en la misma MAP que el ciclo de referencia
        bool sameMapLevel = IsSecondCycleAtSameMapLevel(
            mapsLines, bars, currentBarIndex, lookbackPeriod);
        if (!sameMapLevel) return false;
        
        // Regla 6: The_Wall debe estar lateral (amarillo) o a favor (rosa/magenta)
        bool wallFavorable = (wall.Color == WallMapsColor.Yellow) || 
                            (wall.Color == WallMapsColor.Pink) ||
                            (wall.Color == WallMapsColor.Magenta);
        if (!wallFavorable) return false;
        
        return true;
    }
    
    private bool FindTopAndSharkConfirmation(
        RenkoBar[] bars, int currentIndex, SharkData shark, int lookback)
    {
        // Buscar al menos un topo en las últimas N barras
        bool foundTop = false;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            // Detectar topo: máximo local
            if (IsLocalMaximum(bars, i))
            {
                foundTop = true;
                
                // Verificar que SHARK viró rojo en o después de ese topo
                if (shark.State == SharkState.Red)
                {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    private bool IsLocalMaximum(RenkoBar[] bars, int index)
    {
        if (index <= 0 || index >= bars.Length - 1) return false;
        
        return bars[index].High > bars[index - 1].High && 
               bars[index].High > bars[index + 1].High;
    }
    
    private bool IsSecondSellerCycle(RenkoBar[] bars, int currentIndex, int lookback)
    {
        // Contar ciclos vendedores (consecutivos de boxes negativos)
        int sellerCycleCount = 0;
        bool inSellerCycle = false;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (bars[i].IsNegative)
            {
                if (!inSellerCycle)
                {
                    inSellerCycle = true;
                    sellerCycleCount++;
                }
            }
            else
            {
                inSellerCycle = false;
            }
        }
        
        return sellerCycleCount >= 2;
    }
    
    private bool IsSecondCycleLower(RenkoBar[] bars, int currentIndex, int lookback)
    {
        // Comparar mínimos de ciclos vendedores
        List<double> cycleLows = new List<double>();
        bool inSellerCycle = false;
        double currentCycleLow = double.MaxValue;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (bars[i].IsNegative)
            {
                if (!inSellerCycle)
                {
                    inSellerCycle = true;
                    currentCycleLow = bars[i].Low;
                }
                else
                {
                    currentCycleLow = Math.Min(currentCycleLow, bars[i].Low);
                }
            }
            else
            {
                if (inSellerCycle)
                {
                    cycleLows.Add(currentCycleLow);
                    inSellerCycle = false;
                    currentCycleLow = double.MaxValue;
                }
            }
        }
        
        if (inSellerCycle && currentCycleLow < double.MaxValue)
        {
            cycleLows.Add(currentCycleLow);
        }
        
        // El segundo ciclo (más reciente) debe ser más bajo que el primero
        if (cycleLows.Count >= 2)
        {
            double secondCycleLow = cycleLows[cycleLows.Count - 1]; // Más reciente
            double firstCycleLow = cycleLows[cycleLows.Count - 2];  // Anterior
            
            return secondCycleLow < firstCycleLow;
        }
        
        return false;
    }
    
    // Similar a IsSecondCycleAtSameMapLevel de MmBuyerCycleRules pero para SHORT
    private bool IsSecondCycleAtSameMapLevel(
        MapsLine[] mapsLines, RenkoBar[] bars, int currentIndex, int lookback)
    {
        string referenceMap = GetReferenceCycleMap(mapsLines, bars, currentIndex, lookback);
        if (string.IsNullOrEmpty(referenceMap)) return false;
        
        string secondCycleMap = GetSecondCycleMap(mapsLines, bars, currentIndex);
        if (string.IsNullOrEmpty(secondCycleMap)) return false;
        
        return referenceMap == secondCycleMap;
    }
    
    private string GetReferenceCycleMap(MapsLine[] mapsLines, RenkoBar[] bars, int currentIndex, int lookback)
    {
        // Buscar el primer ciclo vendedor (ciclo de referencia)
        for (int i = currentIndex - 5; i >= Math.Max(0, currentIndex - lookback); i--)
        {
            if (IsLocalMaximum(bars, i))
            {
                double price = bars[i].High;
                return GetClosestMapName(price, mapsLines);
            }
        }
        
        return null;
    }
    
    private string GetSecondCycleMap(MapsLine[] mapsLines, RenkoBar[] bars, int currentIndex)
    {
        double currentPrice = bars[currentIndex].Close;
        return GetClosestMapName(currentPrice, mapsLines);
    }
    
    private string GetClosestMapName(double price, MapsLine[] mapsLines)
    {
        var activeLines = mapsLines.Where(l => l.IsActive).ToList();
        if (!activeLines.Any()) return null;
        
        var closest = activeLines.OrderBy(l => Math.Abs(l.Price - price)).First();
        return closest.Name;
    }
}
```

#### 7.1.2.3 Recomendaciones para MM

**Recomendación 1: Diferencia de inclinación entre ciclos**

El escenario MAP con MAP es **más seguro** cuando la **diferencia de inclinación entre los ciclos es más evidente**.

**Caso NO recomendado:**
- Cuando los niveles de los ciclos están **iguales**
- Cuando la diferencia de inclinación no es evidente
- Esto indica consolidación sin dirección clara

**Caso recomendado:**
- Cuando los niveles de los ciclos están **más altos** (para compra) o **más bajos** (para venta)
- Cuando hay una diferencia clara de inclinación entre ciclos
- Esto indica que hay progresión a pesar de estar en MM

```csharp
public class MmRecommendations
{
    public bool IsRecommendedScenario(
        MapsLine[] mapsLines,
        RenkoBar[] bars,
        int currentBarIndex,
        bool isBuyerCycle)
    {
        // Verificar diferencia de inclinación entre ciclos
        double inclinationDifference = CalculateInclinationDifference(
            bars, currentBarIndex, isBuyerCycle);
        
        // Si la diferencia es muy pequeña, no es recomendado
        double minInclinationDifference = 0.15; // 15% mínimo
        if (inclinationDifference < minInclinationDifference)
        {
            return false; // Caso NO recomendado
        }
        
        // Verificar que los niveles de ciclos están progresando
        if (isBuyerCycle)
        {
            // Para compra: ciclos más altos
            return AreCyclesGettingHigher(bars, currentBarIndex);
        }
        else
        {
            // Para venta: ciclos más bajos
            return AreCyclesGettingLower(bars, currentBarIndex);
        }
    }
    
    private double CalculateInclinationDifference(
        RenkoBar[] bars, int currentIndex, bool isBuyerCycle)
    {
        // Calcular pendiente/ángulo de los últimos 2 ciclos
        // Simplificado: comparar la pendiente de los últimos N boxes
        
        if (currentIndex < 10) return 0.0;
        
        List<double> cycleValues = new List<double>();
        bool inCycle = false;
        double cycleValue = 0.0;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - 20); i--)
        {
            double value = isBuyerCycle ? bars[i].High : bars[i].Low;
            bool matchesCycle = isBuyerCycle ? bars[i].IsPositive : bars[i].IsNegative;
            
            if (matchesCycle)
            {
                if (!inCycle)
                {
                    inCycle = true;
                    cycleValue = value;
                }
                else
                {
                    cycleValue = isBuyerCycle ? 
                        Math.Max(cycleValue, value) : 
                        Math.Min(cycleValue, value);
                }
            }
            else
            {
                if (inCycle)
                {
                    cycleValues.Add(cycleValue);
                    inCycle = false;
                }
            }
        }
        
        if (cycleValues.Count < 2) return 0.0;
        
        // Calcular diferencia de inclinación entre últimos 2 ciclos
        double cycle1Value = cycleValues[cycleValues.Count - 1];
        double cycle2Value = cycleValues[cycleValues.Count - 2];
        
        double difference = Math.Abs(cycle1Value - cycle2Value) / Math.Max(cycle1Value, cycle2Value);
        return difference;
    }
    
    private bool AreCyclesGettingHigher(RenkoBar[] bars, int currentIndex)
    {
        // Verificar que los máximos de ciclos están aumentando
        List<double> cycleHighs = new List<double>();
        bool inBuyerCycle = false;
        double currentCycleHigh = double.MinValue;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - 20); i--)
        {
            if (bars[i].IsPositive)
            {
                if (!inBuyerCycle)
                {
                    inBuyerCycle = true;
                    currentCycleHigh = bars[i].High;
                }
                else
                {
                    currentCycleHigh = Math.Max(currentCycleHigh, bars[i].High);
                }
            }
            else
            {
                if (inBuyerCycle)
                {
                    cycleHighs.Add(currentCycleHigh);
                    inBuyerCycle = false;
                }
            }
        }
        
        if (cycleHighs.Count < 2) return false;
        
        // Los últimos 2 ciclos deben estar progresando hacia arriba
        double lastCycle = cycleHighs[cycleHighs.Count - 1];
        double previousCycle = cycleHighs[cycleHighs.Count - 2];
        
        return lastCycle > previousCycle;
    }
    
    private bool AreCyclesGettingLower(RenkoBar[] bars, int currentIndex)
    {
        // Similar a AreCyclesGettingHigher pero para SHORT
        List<double> cycleLows = new List<double>();
        bool inSellerCycle = false;
        double currentCycleLow = double.MaxValue;
        
        for (int i = currentIndex; i >= Math.Max(0, currentIndex - 20); i--)
        {
            if (bars[i].IsNegative)
            {
                if (!inSellerCycle)
                {
                    inSellerCycle = true;
                    currentCycleLow = bars[i].Low;
                }
                else
                {
                    currentCycleLow = Math.Min(currentCycleLow, bars[i].Low);
                }
            }
            else
            {
                if (inSellerCycle)
                {
                    cycleLows.Add(currentCycleLow);
                    inSellerCycle = false;
                }
            }
        }
        
        if (cycleLows.Count < 2) return false;
        
        double lastCycle = cycleLows[cycleLows.Count - 1];
        double previousCycle = cycleLows[cycleLows.Count - 2];
        
        return lastCycle < previousCycle;
    }
}
```

#### 7.1.2.4 Advertencias para MM

**Advertencia sobre MAP compradora en región de subprecio:**
- El escenario MAP con MAP **compradora** es más eficiente para movimientos a favor de la tendencia, es decir, de **MAP 0 para arriba**
- Al intentar operar en la **región de subprecio**, el activo puede todavía estar en un área de acumulación, lo que puede generar cierta dificultad para que el movimiento consiga subir
- Para reversiones, es más seguro aguardar el **Progresso de Preço em MAP (PPM)**

**Advertencia sobre MAP vendedora en región de sobreprecio:**
- El escenario MAP con MAP **vendedora** es más eficaz para movimientos a favor de la tendencia, es decir, de **MAP 0 para abajo**
- Al intentar operar en la **región de sobreprecio**, existe la posibilidad de que el activo todavía esté en un área de distribución, lo que puede generar cierta dificultad para que el movimiento de caída ocurra
- Para reversiones, es más seguro aguardar el **Progresso de Preço em MAP (PPM)**

**Regla crítica: Evitar MAP con MAP en el extremo**

**NO operar cuando:**
- El precio está en el **extremo inferior** y The_Wall está **rosa** (para compra)
- El precio está en el **extremo superior** y The_Wall está **verde** (para venta)

**Ejemplo para compra (extremo inferior):**
- Si el precio va al extremo inferior y The_Wall todavía está rosa, NO debe realizarse el trade en compra
- Incluso si The_Wall intentó quedarse amarilla pero no se sostuvo, NO operar
- Esto ocurre porque, además de que las fuerzas no están favorables para la compra, The_Wall todavía está rosa

**Ejemplo para venta (extremo superior):**
- Si el precio va al extremo superior y The_Wall todavía está verde, NO debe realizarse el trade en venta
- Esto ocurre porque, además de que las fuerzas no están favorables para la venta, The_Wall todavía está verde

```csharp
public class MmWarnings
{
    public bool ShouldAvoidMmAtExtreme(
        double currentPrice,
        MapsLine[] mapsLines,
        WallMapsData wall,
        bool isBuyerScenario)
    {
        MapsLine map0 = mapsLines.FirstOrDefault(l => l.Name == MapsConstants.MAP_0);
        if (map0 == null) return false;
        
        // Determinar si estamos en extremo
        bool isAtLowerExtreme = IsPriceAtLowerExtreme(currentPrice, mapsLines);
        bool isAtUpperExtreme = IsPriceAtUpperExtreme(currentPrice, mapsLines);
        
        if (isBuyerScenario && isAtLowerExtreme)
        {
            // Extremo inferior para compra: The_Wall NO debe estar rosa
            if (wall.Color == WallMapsColor.Pink || wall.Color == WallMapsColor.Magenta)
            {
                return true; // EVITAR
            }
        }
        
        if (!isBuyerScenario && isAtUpperExtreme)
        {
            // Extremo superior para venta: The_Wall NO debe estar verde
            if (wall.Color == WallMapsColor.Green)
            {
                return true; // EVITAR
            }
        }
        
        return false;
    }
    
    private bool IsPriceAtLowerExtreme(double price, MapsLine[] mapsLines)
    {
        // Extremo inferior: precio cerca de i4, i5, i6, i7, i8
        var lowerExtremeMaps = new[] 
        { 
            MapsConstants.I4, MapsConstants.I5, MapsConstants.I6, 
            MapsConstants.I7, MapsConstants.I8 
        };
        
        foreach (var mapName in lowerExtremeMaps)
        {
            var map = mapsLines.FirstOrDefault(l => l.Name == mapName && l.IsActive);
            if (map != null)
            {
                double distance = Math.Abs(price - map.Price) / price;
                if (distance < 0.02) // Dentro del 2% de la línea
                {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    private bool IsPriceAtUpperExtreme(double price, MapsLine[] mapsLines)
    {
        // Extremo superior: precio cerca de S4, S5, S6, S7, S8
        var upperExtremeMaps = new[] 
        { 
            MapsConstants.S4, MapsConstants.S5, MapsConstants.S6, 
            MapsConstants.S7, MapsConstants.S8 
        };
        
        foreach (var mapName in upperExtremeMaps)
        {
            var map = mapsLines.FirstOrDefault(l => l.Name == mapName && l.IsActive);
            if (map != null)
            {
                double distance = Math.Abs(price - map.Price) / price;
                if (distance < 0.02) // Dentro del 2% de la línea
                {
                    return true;
                }
            }
        }
        
        return false;
    }
}
```

### 7.2 Filtro de Escenario para ETAPA 1

**Regla fundamental:** "Una ETAPA 1 dentro de un escenario será siempre más segura que una ETAPA 1 aislada"

**NOTA:** Ver sección 3B.10 para filtro de escenario específico de ETAPA 2.

```csharp
public class ScenarioFilter
{
    public SignalQuality EvaluateEtapa1WithScenario(
        Etapa1Data etapa1,
        PpmScenario ppm,
        bool isMm,
        SharkData shark)
    {
        // ETAPA 1 dentro de escenario PPM o MM = más segura
        bool withinScenario = (ppm != PpmScenario.None) || isMm;
        
        if (!withinScenario)
        {
            return SignalQuality.Low; // ETAPA 1 aislada
        }
        
        // Validar alineación con dirección del escenario
        bool alignedWithScenario = false;
        
        if (etapa1.IsBuyer)
        {
            // ETAPA 1 compradora debe estar en PPM na compra o MM
            alignedWithScenario = (ppm == PpmScenario.PpmBuy) || isMm;
        }
        else if (etapa1.IsSeller)
        {
            // ETAPA 1 vendedora debe estar en PPM na venda o MM
            alignedWithScenario = (ppm == PpmScenario.PpmSell) || isMm;
        }
        
        if (!alignedWithScenario)
        {
            return SignalQuality.VeryLow; // ETAPA 1 fuera de contexto
        }
        
        // ETAPA 1 dentro de escenario y alineada = alta calidad
        return SignalQuality.High;
    }
}
```

### 7.3 MAPS: Sistema de Mapeo Inteligente

#### 7.3.0 Funcionalidad Principal

**El mapeo tiene como principal función traer un planeamiento estratégico para el trade.**

**Bases de cualquier operación:**
- Continuidad del movimiento de tendencia
- Descontinuidad del movimiento de tendencia
- Consolidación (congestión o lateralización)

**Preguntas que MAPS responde:**
- ¿Cómo identificar dónde los movimientos pueden ocurrir?
- ¿Dónde las tendencias pueden comenzar o terminar?
- ¿Dónde hay posibilidades de consolidación?
- ¿Qué es considerado un precio justo para el mercado?
- ¿Cuánto es un precio caro? ¿Y cuánto es un precio barato?

**Solución:** Todas estas cuestiones pueden ser respondidas, anticipadas o, al menos, probabilizadas por medio del mapeo.

#### 7.3.2 Nomenclatura de MAPS

```csharp
public class MapsConstants
{
    // Línea central: Precio Justo (Fair Price)
    public const string MAP_0 = "Map 0";
    
    // Líneas superiores (arriba de Map 0)
    public const string S1 = "S1";
    public const string S2 = "S2";
    public const string S3 = "S3";
    public const string S4 = "S4";
    public const string S5 = "S5";  // Solo en alta volatilidad
    public const string S6 = "S6";  // Solo en alta volatilidad
    public const string S7 = "S7";  // Solo en alta volatilidad
    public const string S8 = "S8";  // Solo en alta volatilidad
    
    // Líneas inferiores (debajo de Map 0)
    public const string I1 = "i1";
    public const string I2 = "i2";
    public const string I3 = "i3";
    public const string I4 = "i4";
    public const string I5 = "i5";  // Solo en alta volatilidad
    public const string I6 = "i6";  // Solo en alta volatilidad
    public const string I7 = "i7";  // Solo en alta volatilidad
    public const string I8 = "i8";  // Solo en alta volatilidad
}

public class MapsLine
{
    public string Name { get; set; }  // S1-S8, i1-i8, Map-0
    public double Price { get; set; }
    public MapsLineType Type { get; set; }
    public bool IsActive { get; set; }  // Solo S5-S8 e i5-i8 activos en alta volatilidad
    public MapsLineColor Color { get; set; }
    public LineStyle Style { get; set; }  // Solid, Dashed, Dotted
}

public enum MapsLineType
{
    Map0 = 0,      // Precio Justo (central)
    Superior = 1,  // S1-S8
    Inferior = 2   // i1-i8
}

public enum MapsLineColor
{
    Unknown = 0,
    Blue = 1,       // Map-0 y algunas S/i
    Orange = 2,     // Map-0 alternado
    Yellow = 3,     // S1-S4, i1-i4 (consolidación)
    LightBlue = 4,  // S3-S4, i3-i4, S5-S6, i5-i6
    Green = 5,      // Compradores, i7-i8
    Red = 6,        // Vendedores, S7-S8
    Purple = 7      // Extremos
}

public enum LineStyle
{
    Solid = 0,
    Dashed = 1,
    Dotted = 2
}
```

#### 7.3.3 Regla de Volatilidad para Líneas S5-S8 e i5-i8

**Las líneas S5, S6, S7, S8 e i5, i6, i7, i8 solo aparecen cuando el mercado está muy volátil.**

```csharp
public class MapsVolatilityFilter
{
    public bool ShouldShowExtendedLines(double currentVolatility, double averageVolatility)
    {
        // Si la volatilidad actual es 2x o mayor que la promedio, mostrar líneas extendidas
        double volatilityRatio = currentVolatility / averageVolatility;
        return volatilityRatio >= 2.0;
    }
    
    public List<string> GetActiveLines(bool isHighVolatility)
    {
        List<string> activeLines = new List<string>
        {
            MapsConstants.MAP_0,
            MapsConstants.S1, MapsConstants.S2, MapsConstants.S3, MapsConstants.S4,
            MapsConstants.I1, MapsConstants.I2, MapsConstants.I3, MapsConstants.I4
        };
        
        if (isHighVolatility)
        {
            activeLines.AddRange(new[]
            {
                MapsConstants.S5, MapsConstants.S6, MapsConstants.S7, MapsConstants.S8,
                MapsConstants.I5, MapsConstants.I6, MapsConstants.I7, MapsConstants.I8
            });
        }
        
        return activeLines;
    }
}
```

#### 7.3.4 Consideraciones sobre MAPS

**Regla fundamental:** El MAP es el destino, es la ruta correcta, pero las herramientas cuantitativas (FPLEME y VX) son fundamentales para guiar este camino.

**Proporción de importancia:**
- El éxito en trading está 80% relacionado con el MAP
- Aún quedan 20% por aprender, y estos 20% también son extremadamente importantes

**Advertencia:** NO usar el MAP en aislamiento. Cuando el precio alcanza una región estratégica, la construcción de escenarios será indispensable para guiar las decisiones.

```csharp
public class MapsWarning
{
    public static string GetRecommendation()
    {
        return "▲ IMPORTANTE: NO usar el MAP en aislamiento. " +
               "Cuando el precio alcanza una región estratégica, " +
               "la construcción de escenarios será indispensable para guiar las decisiones.";
    }
    
    public static string GetSuccessFormula()
    {
        return "Éxito en trading: 80% MAP + 20% herramientas cuantitativas (FPLEME, VX).";
    }
}
```

### 7.4 The_Wall como Filtro de Seguridad

#### 7.4.1 Definición Conceptual

**The_Wall (O muro)** sirve para dividir el mercado: el precio está arriba o abajo de él. Esta división se vuelve más aparente cuando el mercado exhibe una tendencia direccional clara.

**Funcionalidades clave:**
- Divide el mercado en dos regiones (arriba/abajo)
- Si el precio está "cruzando" The_Wall, indica que el mercado carece de dirección definida (consolidación o fin de tendencia)
- Los colores de The_Wall también actúan como mecanismo de seguridad, ayudando a identificar la intensidad del mercado

#### 7.4.2 Estados y Colores de The_Wall

```csharp
public enum WallMapsColor
{
    Unknown = 0,
    Green = 1,      // Alta fuerza de compra
    Pink = 2,       // Alta fuerza de venta (Rosa/Magenta/Fúcsia)
    Magenta = 3,    // Alta fuerza de venta (variante)
    Red = 4,        // Alta fuerza de venta (variante)
    Yellow = 5      // Consolidación/Equilibrio
}

public enum WallMapsPosition
{
    Central = 0,    // Amarillo en la parte central del MAPA = movimiento lateralizado
    Extreme = 1     // Amarillo en los extremos del MAPA = posible oportunidad de reversión
}

public class WallMapsData
{
    public WallMapsColor Color { get; set; }
    public double WallPrice { get; set; }
    public WallMapsPosition YellowPosition { get; set; }
    public bool IsPriceAbove { get; set; }
    public bool IsPriceBelow { get; set; }
    public bool IsPriceCrossing { get; set; }  // Consolidación/fin de tendencia
}
```

#### 7.4.3 Reglas de The_Wall por Color

**VERDE: Alta fuerza de compra**
- **NUNCA considerar escenarios de venta** mientras The_Wall esté verde
- Esto significa ir contra la fuerza dominante del mercado
- Solo considerar operaciones LONG cuando The_Wall está verde

**ROSA/MAGENTA: Alta fuerza de venta**
- **NUNCA considerar escenarios de compra** mientras The_Wall esté rosa/magenta
- Esto significa ir contra la fuerza dominante del mercado
- Solo considerar operaciones SHORT cuando The_Wall está rosa/magenta

**AMARILLO: Consolidación/Equilibrio**
- **Amarillo en la parte central del MAPA:** Indica movimiento lateralizado y equilibrio de fuerzas
- Para determinar la dirección futura del mercado, se requiere la herramienta FPLEME para construir el escenario correcto
- **Amarillo en los extremos del MAPA:** Puede ser interpretado como una posible oportunidad de reversión del mercado

```csharp
public class WallMapsFilter
{
    public bool IsSafeToBuy(WallMapsColor wallColor, WallMapsPosition yellowPosition = WallMapsPosition.Central)
    {
        // NUNCA comprar si The_Wall está rosa/magenta/rojo
        if (wallColor == WallMapsColor.Pink ||
            wallColor == WallMapsColor.Magenta ||
            wallColor == WallMapsColor.Red)
        {
            return false;
        }
        
        // Amarillo en extremos = posible reversión (oportunidad)
        if (wallColor == WallMapsColor.Yellow && yellowPosition == WallMapsPosition.Extreme)
        {
            // Requiere confirmación con FPLEME para construir escenario
            return true; // Posible, pero requiere confirmación
        }
        
        // Amarillo central = lateralizado (no operar sin FPLEME)
        if (wallColor == WallMapsColor.Yellow && yellowPosition == WallMapsPosition.Central)
        {
            return false; // Requiere FPLEME para determinar dirección
        }
        
        // Comprar solo si The_Wall está verde
        return wallColor == WallMapsColor.Green;
    }
    
    public bool IsSafeToSell(WallMapsColor wallColor, WallMapsPosition yellowPosition = WallMapsPosition.Central)
    {
        // NUNCA vender si The_Wall está verde
        if (wallColor == WallMapsColor.Green)
        {
            return false; // NO hay posibilidades seguras de venta
        }
        
        // Amarillo en extremos = posible reversión (oportunidad)
        if (wallColor == WallMapsColor.Yellow && yellowPosition == WallMapsPosition.Extreme)
        {
            // Requiere confirmación con FPLEME para construir escenario
            return true; // Posible, pero requiere confirmación
        }
        
        // Amarillo central = lateralizado (no operar sin FPLEME)
        if (wallColor == WallMapsColor.Yellow && yellowPosition == WallMapsPosition.Central)
        {
            return false; // Requiere FPLEME para determinar dirección
        }
        
        // Vender solo si The_Wall está rosa/magenta/rojo
        return (wallColor == WallMapsColor.Pink ||
                wallColor == WallMapsColor.Magenta ||
                wallColor == WallMapsColor.Red);
    }
    
    public bool IsMarketConsolidating(WallMapsData wall)
    {
        // Si el precio está "cruzando" The_Wall, indica consolidación
        return wall.IsPriceCrossing;
    }
}
```

#### 7.4.4 Advertencia sobre Extremos

**IMPORTANTE:** No es porque el precio llegó al extremo y The_Wall quedó amarilla que debes entrar en operación inmediatamente.

**Regla:**
- Ese es solo el **inicio de un escenario de reversión** y una de las condiciones necesarias
- Como operar en escenarios específicos será abordado con más profundidad en los próximos módulos

```csharp
public class WallExtremeWarning
{
    public static string GetWarning()
    {
        return "▲ OBSERVACIÓN IMPORTANTE: " +
               "No es porque el precio llegó al extremo y The_Wall quedó amarilla " +
               "que debes entrar en operación inmediatamente. " +
               "Ese es solo el inicio de un escenario de reversión y una de las condiciones necesarias.";
    }
    
    public bool IsExtremeReversalSetup(WallMapsData wall, FplemeData fpleme)
    {
        // Extremo + The_Wall amarilla = inicio de escenario, NO señal inmediata
        bool isExtreme = wall.YellowPosition == WallMapsPosition.Extreme;
        bool isYellow = wall.Color == WallMapsColor.Yellow;
        
        // Requiere construcción de escenario completo con FPLEME
        return isExtreme && isYellow; // Solo inicio, no señal completa
    }
}
```

#### 7.4.5 The_Wall del VX

**Definición Conceptual:**

**The_Wall del gráfico** y **The_Wall del VX** son la **misma herramienta**, pero presentadas bajo **diferentes perspectivas** y con **coloraciones distintas**.

**Perspectivas diferentes:**
- **The_Wall del gráfico:** Visualizada directamente en el gráfico de precio, dividiendo el mercado arriba/abajo
- **The_Wall del VX:** Visualizada a través del indicador VX M2, utilizando las propias MAPS como referencia comparativa

**Relación funcional:**
- Es posible identificar cuando **The_Wall del gráfico está sobrepasando una MAP** por medio de **The_Wall del VX**
- The_Wall del VX utiliza las propias **MAPS como referencia comparativa** para determinar su inclinación y color

**Lógica de Coloración basada en inclinación:**

**Verde:**
- Cuando **The_Wall del VX está más inclinada hacia arriba** en relación a la MAP
- Indica fuerza de compra predominante

**Rosa/Magenta/Fúcsia:**
- Cuando **The_Wall del VX está más inclinada hacia abajo** en relación a la MAP
- Indica fuerza de venta predominante

**Amarillo (Post-its amarillos):**
- Los **Post-its amarillos** indican una **mudanza de color**, es decir, una mudanza en la dirección de The_Wall
- Estos post-its amarillos ayudan a:
  - Mantener la interpretación de un escenario ya establecido
  - Proporcionar una visión anticipada de lo que puede acontecer con The_Wall plotada en el gráfico
- Son fundamentales para mantener la lectura del escenario actual y anticipar posibles movimientos futuros de The_Wall exhibida en el gráfico

**Días de fuerte tendencia:**
- Días de fuerte tendencia, por increíble que parezca, son los días que más causan pérdidas para traders
- Esto ocurre cuando traders intentan operar **contra la tendencia** o intentan encontrar el **topo o fondo del día**
- **Regla:** No busques topos o fondos. Aprovecha la tendencia y opera a tu favor

```csharp
public class WallVxData
{
    public WallMapsColor Color { get; set; }
    public double WallPrice { get; set; }
    public double Inclination { get; set; }  // Inclinación relativa a MAP
    public MapsLine ReferenceMap { get; set; }  // MAP de referencia
    public bool HasYellowPostIt { get; set; }  // Post-it amarillo presente
    public DateTime YellowPostItTime { get; set; }
    public WallMapsColor PreviousColor { get; set; }  // Color anterior antes del cambio
}

public class WallVxDetector
{
    public WallVxData CalculateWallVx(
        MapsLine[] mapsLines,
        double currentPrice,
        double previousPrice,
        VxData vx)
    {
        WallVxData wallVx = new WallVxData();
        
        // Determinar MAP de referencia más cercana
        MapsLine referenceMap = GetClosestMap(mapsLines, currentPrice);
        wallVx.ReferenceMap = referenceMap;
        
        // Calcular inclinación de The_Wall del VX relativa a la MAP
        double wallInclination = CalculateWallInclination(vx, referenceMap);
        wallVx.Inclination = wallInclination;
        
        // Determinar color basado en inclinación
        if (wallInclination > 0.05) // Inclinada hacia arriba
        {
            wallVx.Color = WallMapsColor.Green;
        }
        else if (wallInclination < -0.05) // Inclinada hacia abajo
        {
            wallVx.Color = WallMapsColor.Pink; // o Magenta
        }
        else // Lateral/equilibrio
        {
            wallVx.Color = WallMapsColor.Yellow;
        }
        
        // Detectar Post-it amarillo (cambio de dirección)
        if (HasColorChanged(vx))
        {
            wallVx.HasYellowPostIt = true;
            wallVx.YellowPostItTime = DateTime.Now;
            wallVx.PreviousColor = GetPreviousWallColor(vx);
        }
        
        wallVx.WallPrice = CalculateWallPrice(vx, referenceMap);
        
        return wallVx;
    }
    
    private double CalculateWallInclination(VxData vx, MapsLine referenceMap)
    {
        // Calcular inclinación de The_Wall del VX relativa a la MAP
        // Si The_Wall está más alta que la MAP y subiendo → inclinación positiva
        // Si The_Wall está más baja que la MAP y bajando → inclinación negativa
        
        double wallValue = vx.WallValue;
        double mapValue = referenceMap.Price;
        
        // Diferencia porcentual
        double diffPercent = (wallValue - mapValue) / mapValue;
        
        // Considerar también la dirección del movimiento
        double velocity = vx.WallVelocity; // Velocidad de cambio de The_Wall
        
        // Inclinación = diferencia de posición + componente de velocidad
        return diffPercent + (velocity * 0.001);
    }
    
    private bool HasColorChanged(VxData vx)
    {
        // Detectar cambio de dirección de The_Wall
        // Post-it amarillo aparece cuando cambia la inclinación
        return vx.WallDirectionChanged; // Simplificado
    }
    
    private WallMapsColor GetPreviousWallColor(VxData vx)
    {
        return vx.PreviousWallColor;
    }
    
    private MapsLine GetClosestMap(MapsLine[] mapsLines, double price)
    {
        var activeLines = mapsLines.Where(l => l.IsActive).ToList();
        if (!activeLines.Any()) return null;
        
        return activeLines.OrderBy(l => Math.Abs(l.Price - price)).First();
    }
    
    private double CalculateWallPrice(VxData vx, MapsLine referenceMap)
    {
        // Calcular precio de The_Wall basado en VX y MAP de referencia
        return referenceMap.Price + (vx.WallValue * referenceMap.Price * 0.01);
    }
}

// Estructura de datos para VX
public class VxData
{
    public double WallValue { get; set; }
    public double WallVelocity { get; set; }
    public bool WallDirectionChanged { get; set; }
    public WallMapsColor PreviousWallColor { get; set; }
    public double CurrentVxBar { get; set; }  // Valor de la barra actual del VX
    public bool IsRising { get; set; }  // Para PPM Buy: VX subiendo
    public bool IsFalling { get; set; }  // Para PPM Sell: VX en caída
}
```

### 7.5 VX M2: CORES, NOMENCLATURA E USABILIDADE

#### 7.5.0 Definición y Utilidad de VX M2

**Definición Conceptual:**

**VX M2** es un sistema que ofrece una **nueva perspectiva sobre MAP**, permitiendo una lectura más clara y eficiente, especialmente en lo que se refiere a las **divergencias o convergencias de la MAP**.

**Utilidad principal:**
- Al observar el VX, estás viendo la **MAP desde un nuevo punto de vista**
- Esto permite una lectura más clara y eficiente
- Especialmente útil para identificar **divergencias o convergencias** de la MAP

**Señales de dirección:**
- Las **barras del VX creciendo o decreciendo** señalan la dirección del mercado (compra o venta)
- **Barras crecientes:** Señalizan dirección de compra
- **Barras decrecientes:** Señalizan dirección de venta

**Advertencia sobre tendencias fuertes:**
- Días de fuerte tendencia, por increíble que parezca, son los días que **más causan pérdidas** para traders
- Esto ocurre cuando traders intentan operar **contra la tendencia** o intentan encontrar el **topo o fondo del día**
- **REGLA CRÍTICA:** No busques topos o fondos. Aprovecha la tendencia y opera a tu favor

#### 7.5.1 Nomenclatura de VX M2

**Líneas superiores (arriba de Map 0):**
- **s1** | **s2** | **s3** | **s4** | **s5**

**Línea central:**
- **Map 0** (MAP Central / Precio Justo)

**Líneas inferiores (abajo de Map 0):**
- **i1** | **i2** | **i3** | **i4** | **i5**

**Nota:** La nomenclatura es similar a MAPS, pero VX M2 representa estas líneas desde una perspectiva diferente (a través del indicador VX).

```csharp
public class VxM2Constants
{
    // Línea central
    public const string MAP_0 = "Map 0";
    
    // Líneas superiores
    public const string S1 = "s1";
    public const string S2 = "s2";
    public const string S3 = "s3";
    public const string S4 = "s4";
    public const string S5 = "s5";
    
    // Líneas inferiores
    public const string I1 = "i1";
    public const string I2 = "i2";
    public const string I3 = "i3";
    public const string I4 = "i4";
    public const string I5 = "i5";
}
```

#### 7.5.2 Colores de VX M2

**Barras crecientes arriba de MAP 0 (MAP Central):**
- **Color:** Cyan/Azul claro
- **Significado:** **Agresión compradora predominante**
- **Interpretación:** Indica fuerza de compra predominante en el mercado

**Barras decrecientes abajo de MAP 0 (MAP Central):**
- **Color:** Rojo
- **Significado:** **Agresión vendedora predominante**
- **Interpretación:** Indica fuerza de venta predominante en el mercado

**Barras de movimiento contra-tendencia:**
- **Color:** Azul oscuro
- **Significado:** **Señalización de movimiento de contra tendencia**
- **Interpretación:** Indica un movimiento en dirección opuesta a la tendencia predominante

**Líneas límite:**

**Línea punteada roja:**
- **Nivel límite de compra** que el VX puede alcanzar
- Indica el máximo nivel de agresión compradora posible

**Línea punteada verde:**
- **Nivel límite de venta** que el VX puede alcanzar
- Indica el máximo nivel de agresión vendedora posible

#### 7.5.2.1 VX M14 - Coloração Avanzada

**VX M14** es una versión avanzada del VX que proporciona información adicional sobre la intensidad y velocidad de las barras del VX:

**Barras crecientes arriba de MAP 0 (MAP Central):**
- **Agresión regular de compra:** Representa la agresión regular de compra
- **Aumento significativo:** Sinaliza un aumento significativo en intensidad o velocidad en el saldo de agresión de compra

**Barras decrecientes abajo de MAP 0 (MAP Central):**
- **Agresión regular de venda:** Representa la agresión regular de venta
- **Aumento significativo:** Sinaliza un aumento significativo en intensidad o velocidad en el saldo de agresión de venta

**Indicadores de divergencia y posibles reversiones:**
- **Posible divergencia en sentido de compra:** Indicada por barras específicas
- **Posible divergencia en sentido de venta:** Indicada por barras específicas

**Indicadores de cambio de rango:**
- **Posible cambio en el rango dentro del área de sobreventa:** Representa un posible "fondo"
- **Posible cambio en el rango dentro del área de sobrecompra:** Representa un posible "topo"

```csharp
public enum VxM14BarType
{
    RegularBuyingAggression = 1,      // Agresión regular de compra
    IncreasedBuyingAggression = 2,    // Aumento significativo en agresión de compra
    RegularSellingAggression = 3,     // Agresión regular de venta
    IncreasedSellingAggression = 4,   // Aumento significativo en agresión de venta
    PossibleBuyDivergence = 5,        // Posible divergencia en sentido de compra
    PossibleSellDivergence = 6,       // Posible divergencia en sentido de venta
    PossibleBottomInOversold = 7,     // Posible fondo en sobreventa
    PossibleTopInOverbought = 8       // Posible topo en sobrecompra
}

public class VxM14Bar
{
    public double Value { get; set; }
    public VxM14BarType Type { get; set; }
    public double Intensity { get; set; }  // Intensidad del movimiento
    public double Velocity { get; set; }   // Velocidad del cambio
    public bool IsAboveMap0 { get; set; }
    public bool IsBelowMap0 { get; set; }
    public double Height { get; set; }
}

public class VxM14Coloration
{
    public VxM14BarType DetermineBarType(
        VxBar currentBar,
        VxBar previousBar,
        VxBar[] recentBars,
        double map0Price)
    {
        bool isGrowing = currentBar.Height > previousBar.Height;
        bool isDecreasing = currentBar.Height < previousBar.Height;
        bool isAboveMap0 = currentBar.Value > map0Price;
        bool isBelowMap0 = currentBar.Value < map0Price;
        
        // Calcular intensidad (cambio en altura vs promedio)
        double avgHeight = recentBars.Take(10).Average(b => b.Height);
        double intensityChange = Math.Abs(currentBar.Height - previousBar.Height) / Math.Max(avgHeight, 0.01);
        
        // Calcular velocidad (cambio de posición)
        double velocity = Math.Abs(currentBar.Value - previousBar.Value) / Math.Max(Math.Abs(previousBar.Value), 0.01);
        
        // Determinar tipo según posición y cambios
        if (isAboveMap0 && isGrowing)
        {
            if (intensityChange > 1.5 || velocity > 0.02)
            {
                return VxM14BarType.IncreasedBuyingAggression; // Aumento significativo
            }
            return VxM14BarType.RegularBuyingAggression; // Agresión regular
        }
        
        if (isBelowMap0 && isDecreasing)
        {
            if (intensityChange > 1.5 || velocity > 0.02)
            {
                return VxM14BarType.IncreasedSellingAggression; // Aumento significativo
            }
            return VxM14BarType.RegularSellingAggression; // Agresión regular
        }
        
        // Detectar posibles divergencias y cambios de rango
        // (lógica más compleja basada en patrones de barras)
        
        return VxM14BarType.RegularBuyingAggression; // Default
    }
}
```

```csharp
public enum VxBarColor
{
    Unknown = 0,
    Cyan = 1,           // Barras crecientes arriba MAP 0 - Agresión compradora predominante
    Red = 2,            // Barras decrecientes abajo MAP 0 - Agresión vendedora predominante
    DarkBlue = 3        // Movimiento contra-tendencia
}

public class VxBar
{
    public double Value { get; set; }
    public VxBarColor Color { get; set; }
    public bool IsAboveMap0 { get; set; }
    public bool IsBelowMap0 { get; set; }
    public bool IsCounterTrend { get; set; }
    public double Height { get; set; }  // Altura de la barra
}

public class VxM2Coloration
{
    public VxBarColor DetermineBarColor(
        VxBar bar,
        double map0Price,
        VxBar previousBar)
    {
        // Determinar si está arriba o abajo de MAP 0
        bool aboveMap0 = bar.Value > map0Price;
        bool belowMap0 = bar.Value < map0Price;
        
        // Determinar si es creciente o decreciente
        bool isGrowing = bar.Height > previousBar.Height;
        bool isDecreasing = bar.Height < previousBar.Height;
        
        // Determinar si es contra-tendencia
        bool counterTrend = IsCounterTrendMovement(bar, previousBar, map0Price);
        
        if (counterTrend)
        {
            return VxBarColor.DarkBlue;
        }
        
        if (aboveMap0 && isGrowing)
        {
            return VxBarColor.Cyan; // Agresión compradora
        }
        
        if (belowMap0 && isDecreasing)
        {
            return VxBarColor.Red; // Agresión vendedora
        }
        
        return VxBarColor.Unknown;
    }
    
    private bool IsCounterTrendMovement(VxBar bar, VxBar previousBar, double map0Price)
    {
        // Detectar movimiento contra-tendencia
        // Si estaba arriba y ahora está bajando, o viceversa
        bool wasAbove = previousBar.Value > map0Price;
        bool isAbove = bar.Value > map0Price;
        
        if (wasAbove && !isAbove && bar.Value < previousBar.Value)
        {
            return true; // Movimiento contra-tendencia bajista
        }
        
        if (!wasAbove && isAbove && bar.Value > previousBar.Value)
        {
            return true; // Movimiento contra-tendencia alcista
        }
        
        return false;
    }
}

public class VxLimitLevels
{
    public double BuyLimitLevel { get; set; }  // Nivel límite de compra (línea punteada roja)
    public double SellLimitLevel { get; set; }  // Nivel límite de venta (línea punteada verde)
    
    public bool IsAtBuyLimit(VxBar bar)
    {
        return bar.Value >= BuyLimitLevel;
    }
    
    public bool IsAtSellLimit(VxBar bar)
    {
        return bar.Value <= SellLimitLevel;
    }
}
```

#### 7.5.3 Usabilidad de VX M2

**7.5.3.1 Rompimiento de Líneas Horizontales (MAPs)**

**Concepto:**
- Las **líneas horizontales se engrosan** cuando las **líneas verticales las sobrepasan**
- Esta **espessura (engrosamiento) en las líneas horizontales** indica que el precio consiguió romper aquella determinada línea
- Si la línea horizontal es rota por las líneas verticales, ella quedará más espesa, indicando que el precio rompió la MAP correspondiente

**Identificación programática:**
- Cuando las barras verticales del VX sobrepasan una línea horizontal (MAP), esa línea debe aumentar su grosor visualmente
- Este engrosamiento es un indicador visual de que el rompimiento de la MAP fue exitoso

```csharp
public class VxMapBreakoutDetector
{
    public bool DetectMapBreakout(
        VxBar[] vxBars,
        MapsLine mapLine,
        int currentBarIndex)
    {
        // Verificar si las barras verticales del VX sobrepasaron la línea horizontal
        double mapPrice = mapLine.Price;
        
        for (int i = currentBarIndex; i >= Math.Max(0, currentBarIndex - 5); i--)
        {
            VxBar bar = vxBars[i];
            
            // Verificar si la barra sobrepasó la MAP
            if (bar.Value > mapPrice && bar.Height > mapPrice)
            {
                // La barra vertical sobrepasó la línea horizontal
                // Marcar la línea para engrosamiento visual
                mapLine.Thickness = MapsLineThickness.Thick; // Engrosada
                return true;
            }
            
            if (bar.Value < mapPrice && bar.Height < mapPrice)
            {
                // La barra vertical sobrepasó hacia abajo
                mapLine.Thickness = MapsLineThickness.Thick; // Engrosada
                return true;
            }
        }
        
        return false;
    }
}

public enum MapsLineThickness
{
    Normal = 1,
    Thick = 2  // Línea engrosada después de rompimiento
}
```

**7.5.3.2 Saldo Necesario para Rompimiento**

**Concepto:**
- Es posible visualizar el **saldo necesario para el rompimiento de The_Wall**
- Si el precio en el gráfico intenta romper una línea (por ejemplo, S3), pero las **barras verticales NO rompen la línea horizontal** y la **línea horizontal NO queda más espesa**, entonces **NO va a romper la MAP**

**Condiciones para rompimiento exitoso:**
1. El precio en el gráfico debe intentar romper la línea horizontal (MAP)
2. Las barras verticales del VX deben romper efectivamente la línea horizontal
3. La línea horizontal debe engrosarse (quedarse más espesa)

Si alguna de estas condiciones NO se cumple, el rompimiento NO será exitoso.

```csharp
public class VxBreakoutBalance
{
    public bool HasSufficientBalanceForBreakout(
        double chartPrice,
        VxBar[] vxBars,
        MapsLine mapLine,
        int currentBarIndex)
    {
        // Verificar si hay saldo suficiente para rompimiento
        
        // 1. El precio del gráfico intenta romper la línea
        bool priceAttemptingBreakout = IsPriceAttemptingBreakout(chartPrice, mapLine);
        if (!priceAttemptingBreakout) return false;
        
        // 2. Las barras verticales del VX deben romper la línea horizontal
        bool vxBarsBreakLine = DoVxBarsBreakLine(vxBars, mapLine, currentBarIndex);
        if (!vxBarsBreakLine) return false;
        
        // 3. La línea horizontal debe engrosarse (confirmación visual)
        // Esto se maneja en el detector de rompimiento
        
        return true; // Saldo suficiente para rompimiento
    }
    
    private bool IsPriceAttemptingBreakout(double price, MapsLine mapLine)
    {
        double distanceToMap = Math.Abs(price - mapLine.Price) / mapLine.Price;
        return distanceToMap < 0.02; // Dentro del 2% de la MAP
    }
    
    private bool DoVxBarsBreakLine(VxBar[] vxBars, MapsLine mapLine, int currentBarIndex)
    {
        double mapPrice = mapLine.Price;
        
        // Verificar si las barras del VX están cruzando efectivamente la línea
        for (int i = currentBarIndex; i >= Math.Max(0, currentBarIndex - 3); i--)
        {
            VxBar bar = vxBars[i];
            
            // Verificar si la barra cruza la línea horizontal
            bool crossesAbove = (bar.Value <= mapPrice && bar.Value + bar.Height > mapPrice);
            bool crossesBelow = (bar.Value >= mapPrice && bar.Value - bar.Height < mapPrice);
            
            if (crossesAbove || crossesBelow)
            {
                return true; // Las barras rompen la línea
            }
        }
        
        return false; // No hay suficiente fuerza para romper
    }
    
    public string GetBreakoutBalanceStatus(
        double chartPrice,
        VxBar[] vxBars,
        MapsLine mapLine,
        int currentBarIndex)
    {
        bool hasBalance = HasSufficientBalanceForBreakout(
            chartPrice, vxBars, mapLine, currentBarIndex);
        
        if (hasBalance)
        {
            return "✅ Saldo suficiente para rompimiento";
        }
        else
        {
            return "❌ Saldo insuficiente - Rompimiento NO exitoso";
        }
    }
}
```

**7.5.3.3 Identificación de The_Wall cruzando MAP**

**Utilidad:**
- Es posible identificar cuando **The_Wall del gráfico está sobrepasando una MAP** por medio de **The_Wall del VX**
- The_Wall del VX proporciona una perspectiva complementaria que facilita la detección de estos eventos

**Ejemplo de uso:**
- Si The_Wall del gráfico está cruzando S3, pero las barras verticales del VX no confirman este cruce, puede ser una señal de que el cruce no es válido
- Si tanto The_Wall del gráfico como The_Wall del VX confirman el cruce de la MAP, el rompimiento es más probable que sea exitoso

```csharp
public class WallMapCrossDetector
{
    public bool DetectWallCrossingMap(
        WallMapsData wallChart,  // The_Wall del gráfico
        WallVxData wallVx,       // The_Wall del VX
        MapsLine mapLine)
    {
        // Verificar si The_Wall del gráfico está sobrepasando la MAP
        bool chartWallCrossing = IsWallCrossingMap(wallChart, mapLine);
        
        // Verificar confirmación a través de The_Wall del VX
        bool vxWallConfirming = IsVxWallConfirmingCross(wallVx, mapLine);
        
        // Ambos deben confirmar para considerar el cruce válido
        return chartWallCrossing && vxWallConfirming;
    }
    
    private bool IsWallCrossingMap(WallMapsData wall, MapsLine map)
    {
        // Verificar si The_Wall está cruzando la MAP
        double distance = Math.Abs(wall.WallPrice - map.Price) / map.Price;
        return distance < 0.01 && wall.IsPriceCrossing; // Dentro del 1% y cruzando
    }
    
    private bool IsVxWallConfirmingCross(WallVxData wallVx, MapsLine map)
    {
        // The_Wall del VX debe estar en la misma dirección del cruce
        if (wallVx.Color == WallMapsColor.Green && wallVx.Inclination > 0)
        {
            // Cruce hacia arriba confirmado
            return true;
        }
        
        if ((wallVx.Color == WallMapsColor.Pink || wallVx.Color == WallMapsColor.Magenta) 
            && wallVx.Inclination < 0)
        {
            // Cruce hacia abajo confirmado
            return true;
        }
        
        return false;
    }
}
```

**7.5.3.4 Post-its Amarillos en The_Wall del VX**

**Definición:**
- Los **Post-its amarillos en The_Wall** indican **mudanzas en la dirección de la herramienta**
- Específicamente, indican una **mudanza de color** de The_Wall

**Utilidad:**
- Esta información es **fundamental** para:
  - Mantener la lectura del escenario actual
  - Antecipar posibles movimientos futuros de The_Wall exhibida en el gráfico
- Los post-its amarillos ayudan a:
  - Mantener la interpretación de un escenario ya establecido
  - Proporcionar una visión anticipada de lo que puede acontecer con The_Wall plotada en el gráfico

**Detección programática:**
- Un Post-it amarillo aparece cuando The_Wall del VX cambia de dirección (inclinación)
- El cambio de inclinación resulta en un cambio de color (verde ↔ rosa/magenta)
- Este cambio anticipa lo que puede ocurrir con The_Wall del gráfico

```csharp
public class WallYellowPostItDetector
{
    public bool DetectYellowPostIt(WallVxData currentWall, WallVxData previousWall)
    {
        // Post-it amarillo aparece cuando cambia la dirección de The_Wall
        
        // Verificar cambio de inclinación
        bool inclinationChanged = Math.Sign(currentWall.Inclination) != 
                                  Math.Sign(previousWall.Inclination);
        
        // Verificar cambio de color
        bool colorChanged = currentWall.Color != previousWall.Color;
        
        // Post-it amarillo = cambio de dirección (inclinación o color)
        return inclinationChanged || colorChanged;
    }
    
    public WallYellowPostItData CreateYellowPostIt(
        WallVxData wall,
        DateTime detectionTime)
    {
        return new WallYellowPostItData
        {
            IsActive = true,
            DetectionTime = detectionTime,
            WallPriceAtDetection = wall.WallPrice,
            PreviousColor = wall.PreviousColor,
            NewColor = wall.Color,
            InclinationAtDetection = wall.Inclination,
            Message = $"Mudanza de dirección: {wall.PreviousColor} → {wall.Color}"
        };
    }
}

public class WallYellowPostItData
{
    public bool IsActive { get; set; }
    public DateTime DetectionTime { get; set; }
    public double WallPriceAtDetection { get; set; }
    public WallMapsColor PreviousColor { get; set; }
    public WallMapsColor NewColor { get; set; }
    public double InclinationAtDetection { get; set; }
    public string Message { get; set; }
}
```

**7.5.3.5 Ejemplos de No Rompimiento**

**Caso 1: Precio no rompe línea horizontal**
- Si el precio en el gráfico intenta romper una línea (ej: S3), pero:
  - Las barras verticales NO rompen la línea horizontal
  - La línea horizontal NO queda más espesa
- **Resultado:** NO va a romper la MAP

**Caso 2: Falta de saldo**
- Si las barras del VX no muestran suficiente agresión (saldo) para romper la línea horizontal
- **Resultado:** El rompimiento fallará, incluso si el precio se acerca a la MAP

**Caso 3: Precio oscilando entre límites**
- Si el precio está oscilando entre S1 e I1 sin romper ninguna de las dos líneas
- Las barras verticales no muestran rompimiento claro de ninguna línea
- **Resultado:** Mercado lateralizado, sin rompimiento de MAP

```csharp
public class VxNoBreakoutDetector
{
    public bool IsNonBreakoutScenario(
        double chartPrice,
        VxBar[] vxBars,
        MapsLine upperMap,  // Ej: S1
        MapsLine lowerMap,  // Ej: I1
        int currentBarIndex)
    {
        // Verificar si el precio está oscilando entre límites sin romper
        
        // 1. Precio debe estar entre las dos MAPS
        bool priceBetweenMaps = chartPrice < upperMap.Price && chartPrice > lowerMap.Price;
        if (!priceBetweenMaps) return false;
        
        // 2. Las barras del VX no deben romper ninguna línea
        bool noBreakoutAbove = !DoVxBarsBreakLine(vxBars, upperMap, currentBarIndex);
        bool noBreakoutBelow = !DoVxBarsBreakLine(vxBars, lowerMap, currentBarIndex);
        
        // 3. Las líneas no deben estar engrosadas
        bool upperNotThick = upperMap.Thickness == MapsLineThickness.Normal;
        bool lowerNotThick = lowerMap.Thickness == MapsLineThickness.Normal;
        
        // Es un escenario de no-rompimiento si todo se cumple
        return priceBetweenMaps && 
               noBreakoutAbove && 
               noBreakoutBelow && 
               upperNotThick && 
               lowerNotThick;
    }
    
    private bool DoVxBarsBreakLine(VxBar[] vxBars, MapsLine mapLine, int currentBarIndex)
    {
        double mapPrice = mapLine.Price;
        
        for (int i = currentBarIndex; i >= Math.Max(0, currentBarIndex - 3); i--)
        {
            VxBar bar = vxBars[i];
            
            bool crossesAbove = (bar.Value <= mapPrice && bar.Value + bar.Height > mapPrice);
            bool crossesBelow = (bar.Value >= mapPrice && bar.Value - bar.Height < mapPrice);
            
            if (crossesAbove || crossesBelow)
            {
                return true;
            }
        }
        
        return false;
    }
}
```

### 7.6 Funciones Inteligentes de MAPS

#### 7.6.1 Range (Rango)

**Definición:** El Range está representado por líneas más gruesas que delimitan la distancia entre el movimiento mínimo y máximo de un activo. Esta amplitud se llama tradicionalmente "Range."

**Funcionalidad:**
- Define los límites de variación o amplitud del activo
- Funcionan como puntos de atención
- Se usan como referencias de soporte y resistencia

**Comportamiento observado:** Prácticamente cada vez que el precio alcanzó una línea de Range, se detuvo y revirtió su dirección.

**REGLA CRÍTICA:** Esta imagen es solo un ejemplo para facilitar la comprensión y **NO representa un Setup**. Aunque el Range es un punto de atención, **NO hay garantía** de que el precio siempre revertirá cuando lo toque.

**Dinámica subyacente:** El comportamiento del Range está directamente relacionado con la volatilidad del activo. Si hay un cambio abrupto en la volatilidad, el mercado requerirá que el Range se ajuste nuevamente.

```csharp
public class RangeLine
{
    public double UpperRange { get; set; }  // Límite superior
    public double LowerRange { get; set; }  // Límite inferior
    public double Amplitude { get { return UpperRange - LowerRange; } }
    public DateTime LastUpdate { get; set; }
    public double Volatility { get; set; }
    
    // Recalcular Range cuando hay cambio abrupto de volatilidad
    public void AdjustForVolatilityChange(double newVolatility, double priceHigh, double priceLow)
    {
        if (Math.Abs(newVolatility - Volatility) / Volatility > 0.5) // Cambio > 50%
        {
            UpperRange = priceHigh;
            LowerRange = priceLow;
            Volatility = newVolatility;
            LastUpdate = DateTime.Now;
        }
    }
    
    // Verificar si precio está en Range
    public bool IsPriceAtRange(double currentPrice, double tolerance = 0.01)
    {
        double distToUpper = Math.Abs(currentPrice - UpperRange) / Amplitude;
        double distToLower = Math.Abs(currentPrice - LowerRange) / Amplitude;
        
        return distToUpper < tolerance || distToLower < tolerance;
    }
}
```

#### 7.6.2 Problines (Líneas Probabilísticas)

**Definición:** Las Problines son funciones inteligentes que indican, basadas en probabilidad, cuáles serán las próximas líneas fuertes en el mapeo, incluso antes de que Hertz cambie su número.

**Regla fundamental:** Se espera que un activo no supere fácilmente S4, así como tampoco se espera que supere i4.

**Condición de activación:** Esto solo puede ocurrir cuando el activo sufre un cambio abrupto en la volatilidad.

**Apareamiento y progresión:**
- Las Problines siempre aparecen en pares
- Inicio: S4 y S5 (representadas con flechas amarillas)
- Si la volatilidad continúa aumentando:
  - Siguientes líneas: S5 y S6 (flechas verdes)
  - Luego: S6 y S7 (flechas blancas)
  - Potencialmente: S7 y S8
- Mismo patrón en región inferior: i4/i5 → i5/i6 → i6/i7 → i7/i8

**Interpretación:**
- Si las Problines están activas, hay probabilidad de que el precio alcance estas líneas (requiere cautela)
- NO anticipar venta en S4 o i4 porque el extremo está más lejos
- Si una Probline se activa pero el precio no la alcanza, NO significa que falló. Indica que el mercado no pudo alcanzar los niveles probabilísticos, señalando potencial pérdida de fuerza en esa dirección

```csharp
public enum ProblinePair
{
    None = 0,
    S4_S5 = 1,    // Amarillo
    S5_S6 = 2,    // Verde
    S6_S7 = 3,    // Blanco
    S7_S8 = 4,    // Extrema
    I4_I5 = 5,    // Amarillo
    I5_I6 = 6,    // Verde
    I6_I7 = 7,    // Blanco
    I7_I8 = 8     // Extrema
}

public class ProblineDetector
{
    public ProblinePair DetectActiveProbline(
        double currentVolatility,
        double averageVolatility,
        double price,
        MapsLine[] mapsLines)
    {
        double volatilityRatio = currentVolatility / averageVolatility;
        
        // Cambio abrupto de volatilidad (> 2x)
        if (volatilityRatio >= 2.0)
        {
            // Determinar región (superior o inferior)
            MapsLine map0 = mapsLines.FirstOrDefault(l => l.Name == MapsConstants.MAP_0);
            if (map0 == null) return ProblinePair.None;
            
            bool isAboveMap0 = price > map0.Price;
            
            if (isAboveMap0)
            {
                // Región superior: determinar par según volatilidad
                if (volatilityRatio >= 4.0) return ProblinePair.S7_S8;
                if (volatilityRatio >= 3.5) return ProblinePair.S6_S7;
                if (volatilityRatio >= 3.0) return ProblinePair.S5_S6;
                return ProblinePair.S4_S5;
            }
            else
            {
                // Región inferior: determinar par según volatilidad
                if (volatilityRatio >= 4.0) return ProblinePair.I7_I8;
                if (volatilityRatio >= 3.5) return ProblinePair.I6_I7;
                if (volatilityRatio >= 3.0) return ProblinePair.I5_I6;
                return ProblinePair.I4_I5;
            }
        }
        
        return ProblinePair.None;
    }
    
    public bool DidPriceReachProbline(ProblinePair probline, double price, MapsLine[] mapsLines)
    {
        string[] lineNames = GetLineNamesForProbline(probline);
        if (lineNames == null || lineNames.Length < 2) return false;
        
        MapsLine line1 = mapsLines.FirstOrDefault(l => l.Name == lineNames[0]);
        MapsLine line2 = mapsLines.FirstOrDefault(l => l.Name == lineNames[1]);
        
        if (line1 == null || line2 == null) return false;
        
        double upper = Math.Max(line1.Price, line2.Price);
        double lower = Math.Min(line1.Price, line2.Price);
        
        return price >= lower && price <= upper;
    }
    
    private string[] GetLineNamesForProbline(ProblinePair probline)
    {
        switch (probline)
        {
            case ProblinePair.S4_S5: return new[] { MapsConstants.S4, MapsConstants.S5 };
            case ProblinePair.S5_S6: return new[] { MapsConstants.S5, MapsConstants.S6 };
            case ProblinePair.S6_S7: return new[] { MapsConstants.S6, MapsConstants.S7 };
            case ProblinePair.S7_S8: return new[] { MapsConstants.S7, MapsConstants.S8 };
            case ProblinePair.I4_I5: return new[] { MapsConstants.I4, MapsConstants.I5 };
            case ProblinePair.I5_I6: return new[] { MapsConstants.I5, MapsConstants.I6 };
            case ProblinePair.I6_I7: return new[] { MapsConstants.I6, MapsConstants.I7 };
            case ProblinePair.I7_I8: return new[] { MapsConstants.I7, MapsConstants.I8 };
            default: return null;
        }
    }
}
```

#### 7.6.3 Pullback_lines (Líneas de Compradores y Vendedores)

**Definición:** Las líneas de compradores y vendedores funcionan como atalhos visuales para identificar puntos de atención en el gráfico.

**Colores:**
- **Líneas verdes:** Representan compradores
- **Líneas rojas:** Representan vendedores

**Funcionalidad:**
- Funcionan como atajo visual para identificar puntos de atención
- Indican dónde hay interés del mercado

**REGLA CRÍTICA:** Para que esta información sea utilizada de forma operacional, debe ser analizada dentro de una construcción de escenario, **NO de forma aislada**.

**Limitación:** Aunque sabemos que en estos niveles existen compradores y vendedores, **NO es posible determinar si ellos irán a actuar**. Esta confirmación solo puede ser hecha utilizando la herramienta FPLEME, que mide la actuación de esas fuerzas en el mercado.

**Recomendación:** Estas líneas NO deben ser usadas aisladamente. Además, para iniciantes, se recomienda ocultarlas inicialmente para evitar confusiones con los otros atalhos visuales.

```csharp
public class PullbackLines
{
    public List<PullbackLine> BuyerLines { get; set; }  // Verdes
    public List<PullbackLine> SellerLines { get; set; } // Rojas
    
    public bool IsPriceNearBuyerLine(double price, double tolerance = 0.01)
    {
        return BuyerLines.Any(line => Math.Abs(price - line.Price) / price < tolerance);
    }
    
    public bool IsPriceNearSellerLine(double price, double tolerance = 0.01)
    {
        return SellerLines.Any(line => Math.Abs(price - line.Price) / price < tolerance);
    }
    
    // Requiere confirmación con FPLEME
    public bool ConfirmBuyerAction(double price, FplemeData fpleme)
    {
        bool nearBuyerLine = IsPriceNearBuyerLine(price);
        bool fplemeConfirmsBuyer = fpleme.IsBuyerCycle || 
                                   fpleme.CurrentValue >= FplemeConstants.LEVEL_CONFIRMATION_SHORT;
        
        return nearBuyerLine && fplemeConfirmsBuyer;
    }
    
    public bool ConfirmSellerAction(double price, FplemeData fpleme)
    {
        bool nearSellerLine = IsPriceNearSellerLine(price);
        bool fplemeConfirmsSeller = fpleme.IsSellerCycle || 
                                    fpleme.CurrentValue <= FplemeConstants.LEVEL_CONFIRMATION_LONG;
        
        return nearSellerLine && fplemeConfirmsSeller;
    }
}

public class PullbackLine
{
    public double Price { get; set; }
    public PullbackLineType Type { get; set; }
    public DateTime DetectionTime { get; set; }
}

public enum PullbackLineType
{
    Buyer = 0,   // Verde
    Seller = 1   // Rojo
}
```

#### 7.6.4 Coloração (Colores de MAPS)

**Interpretación de colores:**

1. **Amarillo:** Región de consolidación
   - Indica área donde el movimiento puede ser menos direccional o range-bound

2. **Azul claro (MAP 0):** Precio de equilibrio - MAP 0
   - Representa el precio justo o fair value
   - Línea central de referencia

3. **Verde:** Indicativo de región de subprecio en días muy volátiles (cautela)
   - Región de underprice cuando hay alta volatilidad
   - Requiere precaución al operar

4. **Rojo oscuro:** Indicativo de región de sobreprecio en días muy volátiles (cautela)
   - Región de overprice cuando hay alta volatilidad
   - Requiere precaución al operar

5. **Gris oscuro:** Región intermedia del precio
   - Niveles entre consolidación y extremos
   - Zonas intermedias

6. **Púrpura:** Indicativo de región de subprecio debajo de MAPS y sobreprecio arriba de MAPS
   - Extremos del mapeo
   - Líneas más externas (S5-S8, i5-i8)

```csharp
public class MapsColoration
{
    public MapsColorZone DetermineColorZone(double price, MapsLine[] mapsLines, double volatility, double avgVolatility)
    {
        MapsLine map0 = mapsLines.FirstOrDefault(l => l.Name == MapsConstants.MAP_0);
        if (map0 == null) return MapsColorZone.Unknown;
        
        // Determinar región relativa a Map-0
        bool isAboveMap0 = price > map0.Price;
        
        // Encontrar líneas cercanas
        MapsLine closestLine = FindClosestLine(price, mapsLines);
        if (closestLine == null) return MapsColorZone.Unknown;
        
        // Evaluar según volatilidad y posición
        bool isHighVolatility = volatility / avgVolatility >= 2.0;
        
        if (isHighVolatility)
        {
            // Días muy volátiles
            if (isAboveMap0 && price >= GetLinePrice(mapsLines, MapsConstants.S7))
            {
                return MapsColorZone.OverpriceHighVolatility; // Rojo oscuro (cautela)
            }
            
            if (!isAboveMap0 && price <= GetLinePrice(mapsLines, MapsConstants.I7))
            {
                return MapsColorZone.UnderpriceHighVolatility; // Verde (cautela)
            }
        }
        
        // Regiones normales
        if (closestLine.Color == MapsLineColor.Yellow)
        {
            return MapsColorZone.Consolidation;
        }
        
        if (closestLine.Name.StartsWith("S") && int.Parse(closestLine.Name.Substring(1)) >= 5 ||
            closestLine.Name.StartsWith("i") && int.Parse(closestLine.Name.Substring(1)) >= 5)
        {
            return MapsColorZone.Extreme; // Púrpura
        }
        
        return MapsColorZone.Intermediate; // Gris oscuro
    }
    
    private MapsLine FindClosestLine(double price, MapsLine[] mapsLines)
    {
        return mapsLines
            .Where(l => l.IsActive)
            .OrderBy(l => Math.Abs(l.Price - price))
            .FirstOrDefault();
    }
    
    private double GetLinePrice(MapsLine[] mapsLines, string lineName)
    {
        var line = mapsLines.FirstOrDefault(l => l.Name == lineName);
        return line?.Price ?? double.NaN;
    }
}

public enum MapsColorZone
{
    Unknown = 0,
    Consolidation = 1,              // Amarillo
    Equilibrium = 2,                 // Azul claro (MAP 0)
    UnderpriceHighVolatility = 3,   // Verde (cautela)
    OverpriceHighVolatility = 4,    // Rojo oscuro (cautela)
    Intermediate = 5,                // Gris oscuro
    Extreme = 6                      // Púrpura
}
```

---

## 8. POST-ITS Y SEÑALES VISUALES

### 8.1 Niveles Destacados (Etiquetas)

En la herramienta FPLEME, existen algunos niveles destacados en el lado derecho, identificados por "etiquetas":

```csharp
public class FplemeHighlightedLevels
{
    // Niveles destacados con colores específicos
    public const double LEVEL_PLUS_4 = 4.00;   // Destacado en VERDE
    public const double LEVEL_MINUS_4 = -4.00;  // Destacado en ROJO
    public const double LEVEL_ZERO = 0.00;      // Destacado en BLANCO
    public const double LEVEL_PLUS_8 = 8.00;    // Destacado en GRIS
    public const double LEVEL_MINUS_8 = -8.00;   // Destacado en GRIS
}
```

**Colores de etiquetas:**
- **+4.00:** Destacado en **verde**
- **-4.00:** Destacado en **rojo**
- **0.00:** Destacado en **blanco**
- **+8.00 y -8.00:** Destacados en **gris**

### 8.2 Tipos de Post-it

#### 8.2.1 Post-its en la Línea FPLEME

Los Post-its son pequeños rectángulos que aparecen en los niveles **+4.00** y **-4.00** de la línea del FPLEME, siguiendo la trayectoria de la línea.

**Colores de Post-its:**
- **Verde claro (opaco)** y **Verde destacado**
- **Rojo claro (opaco)** y **Rojo destacado**

```csharp
public enum PostItType
{
    None = 0,
    HighlightedGreen = 1,    // Verde destacado (SHARK azul, movimiento fluido)
    OpaqueGreen = 2,         // Verde opaco/acinzentado (SHARK rojo, lateralizado)
    HighlightedRed = 3,      // Rojo destacado (SHARK rojo/rosa, movimiento fluido)
    OpaqueRed = 4            // Rojo opaco/acinzentado (SHARK azul, lateralizado)
}

public class PostItLocation
{
    public double Level { get; set; }  // +4.00 o -4.00
    public PostItType Type { get; set; }
    public DateTime DetectionTime { get; set; }
    public bool IsOnFplemeLine { get; set; } = true;  // Post-it en línea FPLEME
    public bool IsOnSharkLine { get; set; } = false; // Post-it en línea SHARK (amarillo)
}
```

#### 8.2.2 Post-its Amarillos en la Línea SHARK

Los **Post-its amarillos** aparecen en la línea del SHARK y tienen un significado diferente:

- Indican **equilibrio** en el mercado
- Posibilitan **anticipar** una posible mudanza de ciclo
- **IMPORTANTE:** La mudanza solo puede ser confirmada por la coloración de la línea

```csharp
public enum YellowPostItType
{
    None = 0,
    Equilibrium = 1,         // Equilibrio detectado
    AnticipatingChange = 2   // Anticipando mudanza de ciclo
}

public class YellowPostIt
{
    public YellowPostItType Type { get; set; }
    public DateTime DetectionTime { get; set; }
    public double SharkValueAtDetection { get; set; }
    public bool IsConfirmedByLineColor { get; set; }
    public SharkState ConfirmedState { get; set; }
}
```

#### 8.2.3 Post-its Amarillos en The_Wall del VX

Los **Post-its amarillos en The_Wall** indican **mudanzas en la dirección de la herramienta**. Específicamente, indican una **mudanza de color** de The_Wall.

**Funcionalidad:**
- Los Post-its amarillos aparecen cuando The_Wall del VX cambia de dirección (inclinación)
- El cambio de inclinación resulta en un cambio de color (verde ↔ rosa/magenta)
- Esta información es **fundamental** para:
  - Mantener la lectura del escenario actual
  - Anticipar posibles movimientos futuros de The_Wall exhibida en el gráfico

**Utilidad:**
- Ayudan a **mantener la interpretación** de un escenario ya establecido
- Proporcionan una **visión anticipada** de lo que puede acontecer con The_Wall plotada en el gráfico
- Permiten **anticipar** posibles movimientos futuros de The_Wall antes de que ocurran en el gráfico de precio

**Detección:**
- Post-it amarillo aparece cuando:
  - The_Wall del VX cambia de inclinación (de positiva a negativa o viceversa)
  - Esto resulta en un cambio de color (verde → rosa/magenta o viceversa)
  - El cambio anticipa lo que puede ocurrir con The_Wall del gráfico

```csharp
public enum WallYellowPostItType
{
    None = 0,
    DirectionChange = 1,        // Mudanza de dirección de The_Wall
    ColorChange = 2             // Mudanza de color (incluido en DirectionChange)
}

public class WallYellowPostIt
{
    public WallYellowPostItType Type { get; set; }
    public DateTime DetectionTime { get; set; }
    public double WallPriceAtDetection { get; set; }
    public WallMapsColor PreviousColor { get; set; }
    public WallMapsColor NewColor { get; set; }
    public double PreviousInclination { get; set; }
    public double NewInclination { get; set; }
    public MapsLine ReferenceMap { get; set; }
    public string Message { get; set; }  // Ej: "Mudanza de dirección: Verde → Rosa"
    
    public bool IsAnticipatingChartWall { get; set; }  // Anticipa movimiento en gráfico
}

public class WallYellowPostItDetector
{
    public WallYellowPostIt DetectWallYellowPostIt(
        WallVxData currentWall,
        WallVxData previousWall)
    {
        // Post-it amarillo aparece cuando cambia la dirección de The_Wall
        
        // Verificar cambio de inclinación
        bool inclinationChanged = Math.Sign(currentWall.Inclination) != 
                                  Math.Sign(previousWall.Inclination);
        
        // Verificar cambio de color
        bool colorChanged = currentWall.Color != previousWall.Color;
        
        if (!inclinationChanged && !colorChanged)
        {
            return null; // No hay Post-it
        }
        
        // Crear Post-it amarillo
        WallYellowPostIt postIt = new WallYellowPostIt
        {
            Type = WallYellowPostItType.DirectionChange,
            DetectionTime = DateTime.Now,
            WallPriceAtDetection = currentWall.WallPrice,
            PreviousColor = previousWall.Color,
            NewColor = currentWall.Color,
            PreviousInclination = previousWall.Inclination,
            NewInclination = currentWall.Inclination,
            ReferenceMap = currentWall.ReferenceMap,
            Message = $"Mudanza de dirección: {previousWall.Color} → {currentWall.Color}",
            IsAnticipatingChartWall = true
        };
        
        return postIt;
    }
    
    public bool ShouldRenderYellowPostIt(WallYellowPostIt postIt)
    {
        if (postIt == null) return false;
        
        // Renderizar Post-it si hay cambio de dirección
        return postIt.Type != WallYellowPostItType.None;
    }
}
```

### 8.3 Lógica de Visualización

```csharp
public class PostItRenderer
{
    public void RenderPostIt(
        Etapa1Data etapa1,
        SharkData shark,
        ChartPanel chart,
        int barIndex)
    {
        PostItType postItType = DeterminePostItType(etapa1, shark);
        
        if (postItType == PostItType.None)
        {
            return; // No renderizar
        }
        
        double fplemeLevel = etapa1.IsBuyer ? 
            FplemeConstants.LEVEL_CONFIRMATION_SHORT : // -4.00 para comprador
            FplemeConstants.LEVEL_CONFIRMATION_LONG;   // +4.00 para vendedor
        
        Color postItColor = GetPostItColor(postItType);
        bool isHighlighted = IsHighlighted(postItType);
        
        // Renderizar Post-it en el nivel apropiado
        chart.DrawRectangle(
            $"PostIt_{barIndex}",
            barIndex,
            fplemeLevel - 0.5,
            barIndex + 1,
            fplemeLevel + 0.5,
            postItColor,
            isHighlighted ? 2 : 1,
            isHighlighted ? DashStyle.Solid : DashStyle.Dash);
    }
    
    private Color GetPostItColor(PostItType type)
    {
        switch (type)
        {
            case PostItType.HighlightedGreen:
            case PostItType.OpaqueGreen:
                return Colors.Green;
            case PostItType.HighlightedRed:
            case PostItType.OpaqueRed:
                return Colors.Red;
            default:
                return Colors.Transparent;
        }
    }
    
    private bool IsHighlighted(PostItType type)
    {
        return (type == PostItType.HighlightedGreen) ||
               (type == PostItType.HighlightedRed);
    }
}
```

---

## 9. APIS Y CONTRATOS DE CÓDIGO

### 9.1 Interfaz Principal de FPLEME

```csharp
public interface IFplemeEngine
{
    // Propiedades principales
    double CurrentValue { get; }
    double PreviousValue { get; }
    FplemeState CurrentState { get; }
    bool IsBuyerCycle { get; }
    bool IsSellerCycle { get; }
    
    // Métodos de actualización
    void Update(RenkoBar bar);
    void Reset();
    
    // Métodos de consulta
    bool HasReachedLevel(double level);
    bool HasExitedLevel(double level);
    int BarsSinceStateChange { get; }
}
```

### 9.2 Interfaz de ETAPA 1 Detector

```csharp
public interface IEtapa1Detector
{
    // Propiedades
    Etapa1BuyerData BuyerData { get; }
    Etapa1SellerData SellerData { get; }
    
    // Métodos de detección
    bool DetectBuyerEtapa1(FplemeData fpleme, RenkoBar[] bars);
    bool DetectSellerEtapa1(FplemeData fpleme, RenkoBar[] bars);
    
    // Métodos de validación
    bool IsValidPositiveBox(FplemeData fpleme, RenkoBar bar);
    bool IsValidNegativeBox(FplemeData fpleme, RenkoBar bar);
    
    // Métodos de invalidación
    bool IsEtapa1Invalidated(Etapa1Data etapa1, FplemeData fpleme);
}
```

### 9.2B Interfaz de ETAPA 2 Detector

```csharp
public interface IEtapa2Detector
{
    // Propiedades
    Etapa2BuyerData BuyerData { get; }
    Etapa2SellerData SellerData { get; }
    
    // Métodos de detección
    bool DetectBuyerEtapa2(FplemeData fpleme, RenkoBar currentBar);
    bool DetectSellerEtapa2(FplemeData fpleme, RenkoBar currentBar);
    
    // Métodos de confirmación
    bool ConfirmBuyerEtapa2(FplemeData fpleme, RenkoBar confirmationBar);
    bool ConfirmSellerEtapa2(FplemeData fpleme, RenkoBar confirmationBar);
    
    // Validación con SHARK
    bool ValidateEtapa2WithShark(Etapa2Data etapa2, SharkData shark);
    
    // Métodos de evaluación de escenario
    SignalQuality EvaluateEtapa2WithScenario(
        Etapa2Data etapa2,
        PpmScenario ppm,
        bool isMm,
        WallMapsData wallMaps,
        double currentPrice);
}
```

### 9.3 Interfaz de Timing de Entrada

```csharp
public interface IEntryTiming
{
    EntrySignal CalculateEntrySignal(
        Etapa1Data etapa1,
        RenkoBar[] bars,
        int currentBarIndex,
        FplemeData fpleme,
        SharkData shark);
    
    double CalculateLongEntryPrice(RenkoBar[] bars, int currentBarIndex);
    double CalculateShortEntryPrice(RenkoBar[] bars, int currentBarIndex);
    
    bool IsInvalidEntry(RenkoBar bar, TradeDirection direction, double entryPrice);
}
```

### 9.4 Interfaz de Gestión de Riesgo

```csharp
public interface IRiskManager
{
    double CalculateMinStopLoss(TradeDirection direction, RenkoBar[] bars, int currentBarIndex);
    double CalculateMaxStopLoss(TradeDirection direction, RenkoBar[] bars, int currentBarIndex);
    
    ExitReason CheckExitConditions(
        TradePosition position,
        FplemeData fpleme,
        Etapa1Data etapa1);
    
    bool IsEtapa1Invalidated(TradePosition position, FplemeData fpleme);
}
```

### 9.5 Interfaz de MAPS Engine

```csharp
public interface IMapsEngine
{
    // Propiedades principales
    MapsLine[] AllLines { get; }
    MapsLine Map0Line { get; }
    RangeLine CurrentRange { get; }
    WallMapsData WallData { get; }
    PullbackLines PullbackLines { get; }
    
    // Métodos de actualización
    void Update(RenkoBar bar, double volatility, double averageVolatility);
    void Reset();
    
    // Métodos de consulta
    MapsLine GetLine(string lineName);
    bool IsLineActive(string lineName);
    MapsColorZone GetColorZone(double price);
    ProblinePair GetActiveProbline();
}
```

### 9.6 Interfaz de The_Wall Filter

```csharp
public interface IWallMapsFilter
{
    WallMapsData GetWallData();
    WallMapsColor GetWallColor();
    
    bool IsSafeToBuy(WallMapsColor wallColor, WallMapsPosition yellowPosition = WallMapsPosition.Central);
    bool IsSafeToSell(WallMapsColor wallColor, WallMapsPosition yellowPosition = WallMapsPosition.Central);
    bool IsMarketConsolidating();
    bool IsPriceAboveWall(double price);
    bool IsPriceBelowWall(double price);
    bool IsPriceCrossingWall();
}
```

### 9.6.1 Interfaz de The_Wall del VX

```csharp
public interface IWallVxDetector
{
    WallVxData CalculateWallVx(
        MapsLine[] mapsLines,
        double currentPrice,
        double previousPrice,
        VxData vx);
    
    bool HasYellowPostIt(WallVxData currentWall, WallVxData previousWall);
    WallYellowPostIt DetectWallYellowPostIt(WallVxData currentWall, WallVxData previousWall);
    
    bool DetectWallCrossingMap(
        WallMapsData wallChart,
        WallVxData wallVx,
        MapsLine mapLine);
}
```

### 9.6.2 Interfaz de VX M2 Engine

```csharp
public interface IVxM2Engine
{
    // Propiedades principales
    VxBar[] CurrentBars { get; }
    VxBarColor GetBarColor(VxBar bar, double map0Price);
    bool IsBarGrowing(VxBar bar, VxBar previousBar);
    bool IsBarDecreasing(VxBar bar, VxBar previousBar);
    
    // Dirección del mercado
    bool IsMarketDirectionBuy(VxBar[] bars, int currentIndex);
    bool IsMarketDirectionSell(VxBar[] bars, int currentIndex);
    
    // Nomenclatura
    string GetClosestVxMap(VxBar bar, MapsLine[] mapsLines);
    
    // Colores y límites
    VxLimitLevels GetLimitLevels();
    bool IsAtBuyLimit(VxBar bar);
    bool IsAtSellLimit(VxBar bar);
    
    // Utilidad: divergencias y convergencias
    bool DetectDivergence(VxBar[] bars, MapsLine[] mapsLines, int currentIndex);
    bool DetectConvergence(VxBar[] bars, MapsLine[] mapsLines, int currentIndex);
}
```

### 9.6.3 Interfaz de VX Breakout Detector

```csharp
public interface IVxBreakoutDetector
{
    bool DetectMapBreakout(
        VxBar[] vxBars,
        MapsLine mapLine,
        int currentBarIndex);
    
    bool HasSufficientBalanceForBreakout(
        double chartPrice,
        VxBar[] vxBars,
        MapsLine mapLine,
        int currentBarIndex);
    
    bool IsNonBreakoutScenario(
        double chartPrice,
        VxBar[] vxBars,
        MapsLine upperMap,
        MapsLine lowerMap,
        int currentBarIndex);
    
    string GetBreakoutBalanceStatus(
        double chartPrice,
        VxBar[] vxBars,
        MapsLine mapLine,
        int currentBarIndex);
}
```

### 9.7 Interfaz de Probline Detector

```csharp
public interface IProblineDetector
{
    ProblinePair DetectActiveProbline(
        double currentVolatility,
        double averageVolatility,
        double price,
        MapsLine[] mapsLines);
    
    bool DidPriceReachProbline(ProblinePair probline, double price, MapsLine[] mapsLines);
    string[] GetLineNamesForProbline(ProblinePair probline);
}
```

### 9.8 Interfaz de Pullback Lines

```csharp
public interface IPullbackLines
{
    List<PullbackLine> BuyerLines { get; }
    List<PullbackLine> SellerLines { get; }
    
    bool IsPriceNearBuyerLine(double price, double tolerance = 0.01);
    bool IsPriceNearSellerLine(double price, double tolerance = 0.01);
    
    bool ConfirmBuyerAction(double price, FplemeData fpleme);
    bool ConfirmSellerAction(double price, FplemeData fpleme);
}
```

---

## 10. PSEUDOCÓDIGO Y ALGORITMOS

### 10.1 Algoritmo Principal de ETAPA 1

```
ALGORITMO: Detectar ETAPA 1 Compradora
ENTRADA: FplemeData, RenkoBar[], currentBarIndex
SALIDA: bool (ETAPA 1 detectada)

INICIO
    // Paso 1: Validar que FPLEME salió de -4.00
    SI (fpleme.PreviousValue <= -4.00) Y (fpleme.CurrentValue > -4.00) ENTONCES
        exitedMinus4 = VERDADERO
    SINO
        exitedMinus4 = FALSO
    FIN SI
    
    // Paso 2: Validar que FPLEME alcanzó 0.00
    SI (fpleme.CurrentValue >= 0.00) ENTONCES
        reachedZero = VERDADERO
    SINO
        reachedZero = FALSO
    FIN SI
    
    // Paso 3: Contar boxes positivos consecutivos
    positiveBoxCount = 0
    PARA i = currentBarIndex HASTA 0 (decrementando) HACER
        SI (bars[i].IsPositive) ENTONCES
            positiveBoxCount = positiveBoxCount + 1
        SINO
            SALIR DEL BUCLE
        FIN SI
    FIN PARA
    
    // Paso 4: Validar que está en 2º o 3º box positivo
    SI (positiveBoxCount == 2) O (positiveBoxCount == 3) ENTONCES
        correctBoxCount = VERDADERO
    SINO
        correctBoxCount = FALSO
    FIN SI
    
    // Paso 5: Validar que NO viene de nivel extremo en 1 box
    SI (fpleme.PreviousValue <= -8.00) ENTONCES
        cannotReachZeroInOneBox = VERDADERO
    SINO
        cannotReachZeroInOneBox = FALSO
    FIN SI
    
    // Paso 6: Combinar condiciones
    SI (exitedMinus4) Y (reachedZero) Y (correctBoxCount) Y (NO cannotReachZeroInOneBox) ENTONCES
        RETORNAR VERDADERO
    SINO
        RETORNAR FALSO
    FIN SI
FIN
```

### 10.2 Algoritmo de Timing de Entrada

```
ALGORITMO: Calcular Precio de Entrada LONG
ENTRADA: RenkoBar[] bars, int currentBarIndex
SALIDA: double (precio de entrada) o NaN (inválido)

INICIO
    // Buscar el box positivo anterior
    previousPositiveBox = NULO
    PARA i = currentBarIndex - 1 HASTA 0 (decrementando) HACER
        SI (bars[i].IsPositive) ENTONCES
            previousPositiveBox = bars[i]
            SALIR DEL BUCLE
        FIN SI
    FIN PARA
    
    SI (previousPositiveBox == NULO) ENTONCES
        RETORNAR NaN  // No hay box positivo anterior
    FIN SI
    
    // La base del box positivo es su Low
    entryPrice = previousPositiveBox.Low
    
    // Validar que NO estamos en el topo del box actual
    currentBar = bars[currentBarIndex]
    SI (Math.Abs(entryPrice - currentBar.High) <= tolerance) ENTONCES
        RETORNAR NaN  // Entrada inválida (en el topo)
    FIN SI
    
    RETORNAR entryPrice
FIN
```

---

## 11. CASOS DE PRUEBA Y VALIDACIONES

### 11.1 Casos de Prueba para ETAPA 1 Compradora

#### Test Case 1: ETAPA 1 Válida en 3º Box Positivo
```
PRE-CONDICIONES:
  - FPLEME[1] = -4.50 (debajo de -4.00)
  - FPLEME[0] = 0.50 (arriba de 0.00)
  - Boxes: [Negativo, Positivo, Positivo, Positivo] (3 positivos consecutivos)
  
RESULTADO ESPERADO:
  - ETAPA 1 Compradora = TRUE
  - ConfirmationBoxIndex = 3
  - IsConfirmed = TRUE
```

#### Test Case 2: ETAPA 1 Inválida desde Nivel Extremo
```
PRE-CONDICIONES:
  - FPLEME[1] = -12.00 (nivel extremo)
  - FPLEME[0] = 0.00
  - Boxes: [Negativo] (solo 1 box)
  
RESULTADO ESPERADO:
  - ETAPA 1 Compradora = FALSE
  - Razón: No puede llegar de -12.00 a 0.00 en 1 box
```

#### Test Case 3: ETAPA 1 sin Alcanzar 0.00
```
PRE-CONDICIONES:
  - FPLEME[1] = -4.50
  - FPLEME[0] = -0.50 (no alcanza 0.00)
  - Boxes: [Positivo, Positivo, Positivo]
  
RESULTADO ESPERADO:
  - ETAPA 1 Compradora = FALSE
  - Razón: No alcanzó nivel 0.00
```

### 11.2 Casos de Prueba para Timing de Entrada

#### Test Case 4: Entrada LONG Válida en Base de Box Anterior
```
PRE-CONDICIONES:
  - ETAPA 1 Compradora confirmada
  - Boxes: [Negativo, Positivo (Low=100.00), Positivo (Low=101.00), Positivo (High=102.50)]
  - currentBarIndex = 3
  
RESULTADO ESPERADO:
  - EntryPrice = 101.00 (base del 2º box positivo)
  - IsValid = TRUE
```

#### Test Case 5: Entrada LONG Inválida en Topo del Box
```
PRE-CONDICIONES:
  - ETAPA 1 Compradora confirmada
  - Boxes: [Positivo (Low=100.00, High=101.00)]
  - EntryPrice = 101.00 (topo del box)
  
RESULTADO ESPERADO:
  - IsInvalidLongEntry = TRUE
  - Razón: NO comprar en el topo del box
```

### 11.3 Casos de Prueba para ETAPA 2

#### Test Case 6: ETAPA 2 Compradora Válida
```
PRE-CONDICIONES:
  - FPLEME[1] = 5.50 (ya positivo, entre +4.00 y +8.00)
  - FPLEME[0] = 8.50 (arriba de +8.00)
  - SHARK.State = Blue
  - Box positivo en confirmación
  
RESULTADO ESPERADO:
  - ETAPA 2 Compradora = TRUE
  - IsConfirmed = TRUE
  - TimingMode puede ser Classic o Mode2_2
```

#### Test Case 7: ETAPA 2 Inválida (no es de +4.00 a +8.00)
```
PRE-CONDICIONES:
  - FPLEME[1] = 0.50
  - FPLEME[0] = 4.50
  
RESULTADO ESPERADO:
  - ETAPA 2 Compradora = FALSE
  - Razón: Esto es ETAPA 1 (de 0.00 a +4.00), no ETAPA 2
```

#### Test Case 8: Timing Clásico vs Timing 2.2 para ETAPA 2
```
PRE-CONDICIONES:
  - ETAPA 2 Compradora confirmada
  - ConfirmationBar = bars[10] (Low=100.00, High=101.00)
  - bars[9] es positivo (Low=99.00, High=100.00)
  
RESULTADO ESPERADO:
  - Classic Entry Price = 99.00 (base del box anterior)
  - Mode2_2 Entry Price = 100.00 (base del propio box que confirmó)
```

### 11.4 Casos de Prueba para Stop Loss

#### Test Case 9: STOP LONG Mínimo Correcto
```
PRE-CONDICIONES:
  - Último fondo del ciclo comprador = 100.00
  - TickSize = 0.25
  
RESULTADO ESPERADO:
  - MinStopLoss = 99.75 (fondo - TickSize)
```

#### Test Case 10: Invalidación de ETAPA 1 LONG
```
PRE-CONDICIONES:
  - Trade LONG abierto
  - FPLEME[1] = 0.50 (arriba de 0.00)
  - FPLEME[0] = -4.50 (debajo de -4.00)
  
RESULTADO ESPERADO:
  - IsEtapa1Invalidated = TRUE
  - ExitReason = Etapa1Invalidated
```

---

## 12. ESTRUCTURAS DE DATOS COMPLETAS

### 12.1 RenkoBar

```csharp
public class RenkoBar
{
    public DateTime Time { get; set; }
    public double Open { get; set; }
    public double Close { get; set; }
    public double High { get; set; }
    public double Low { get; set; }
    public bool IsPositive { get { return Close > Open; } }
    public bool IsNegative { get { return Close < Open; } }
    public double Range { get { return Math.Abs(High - Low); } }
    public bool IsClosed { get; set; }
}
```

### 12.2 EntrySignal

```csharp
public class EntrySignal
{
    public TradeDirection Direction { get; set; }
    public double EntryPrice { get; set; }
    public EntryMode EntryMode { get; set; } // Market, Limit, Stop
    public bool PlanForNextBar { get; set; }
    public SignalQuality Quality { get; set; }
    public string Warning { get; set; }
    public DateTime SignalTime { get; set; }
    public Etapa1Data Etapa1Source { get; set; }  // Si viene de ETAPA 1
    public Etapa2Data Etapa2Source { get; set; }  // Si viene de ETAPA 2
    public EntryTimingMode TimingMode { get; set; } // Solo para ETAPA 2
}
```

### 12.3 TradePosition

```csharp
public class TradePosition
{
    public TradeDirection Direction { get; set; }
    public double EntryPrice { get; set; }
    public DateTime EntryTime { get; set; }
    public double CurrentPrice { get; set; }
    public double StopLoss { get; set; }
    public double TakeProfit { get; set; }
    public Etapa1Data EntryEtapa1 { get; set; }
    public RenkoBar[] Bars { get; set; }
    public int BarIndex { get; set; }
    public ExitReason ExitReason { get; set; }
}
```

---

## 13. CONSIDERACIONES DE IMPLEMENTACIÓN

### 13.1 Look-Ahead Bias Prevention

```csharp
// ❌ INCORRECTO: Usar Close[0] antes de que el bar cierre
if (Close[0] > Open[0] && Fpleme[0] > 0.00) { ... }

// ✅ CORRECTO: Usar Close[1] o validar que el bar esté cerrado
if (BarsInProgress == 0 && CurrentBar > 0)
{
    if (Close[1] > Open[1] && Fpleme[1] > 0.00) { ... }
}
```

### 13.2 Gestión de Estados

```csharp
public class FplemeStateMachine
{
    private FplemeState currentState;
    private FplemeState previousState;
    
    public void UpdateState(double currentValue)
    {
        previousState = currentState;
        currentState = DetermineState(currentValue);
        
        if (currentState != previousState)
        {
            OnStateChanged(currentState, previousState);
        }
    }
    
    private FplemeState DetermineState(double value)
    {
        if (value >= FplemeConstants.LEVEL_EXTREME_HIGH)
            return FplemeState.ExtremeHigh;
        else if (value >= FplemeConstants.LEVEL_HIGH)
            return FplemeState.High;
        // ... más condiciones
        else
            return FplemeState.ExtremeLow;
    }
}
```

---

## 13. PARÁMETROS DE CONFIGURACIÓN

Esta sección detalla todos los parámetros configurable disponibles para cada indicador del sistema FPLEME, basados en las implementaciones de referencia (versión M7).

### 13.1 FPLEME_M7_II - Parámetros de Configuración

El indicador FPLEME_M7_II expone los siguientes parámetros booleanos de configuración:

```csharp
public class FplemeM7Configuration
{
    [Display(Name = "Paint Bars", Description = "Colorear las barras según el ciclo")]
    public bool PaintBars { get; set; } = true;
    
    [Display(Name = "Fast Mode", Description = "Modo rápido (puede afectar precisión)")]
    public bool FastMode { get; set; } = false;
    
    [Display(Name = "Track Record", Description = "Registrar/rastrear récords")]
    public bool TrackRecord { get; set; } = false;
    
    [Display(Name = "Show ETAPA 1", Description = "Mostrar visualización de ETAPA 1")]
    public bool ShowEtapa1 { get; set; } = true;
    
    [Display(Name = "Show ETAPA 2", Description = "Mostrar visualización de ETAPA 2")]
    public bool ShowEtapa2 { get; set; } = true;
    
    [Display(Name = "Show Stop", Description = "Mostrar niveles de stop loss")]
    public bool ShowStop { get; set; } = true;
    
    [Display(Name = "Show FREQ 1", Description = "Mostrar frecuencia 1")]
    public bool ShowFreq1 { get; set; } = false;
    
    [Display(Name = "Show FREQ 2", Description = "Mostrar frecuencia 2")]
    public bool ShowFreq2 { get; set; } = false;
    
    [Display(Name = "Show FREQ 3", Description = "Mostrar frecuencia 3")]
    public bool ShowFreq3 { get; set; } = false;
    
    [Display(Name = "Breakouts", Description = "Detectar y mostrar breakouts")]
    public bool Breakouts { get; set; } = false;
    
    [Display(Name = "Graph Breakouts", Description = "Graficar visualmente los breakouts")]
    public bool GraphBreakouts { get; set; } = false;
}
```

**Descripción de parámetros:**

- **PaintBars:** Activa el coloreado de las barras Renko según el estado del ciclo (comprador/vendedor)
- **FastMode:** Modo de procesamiento rápido que puede reducir la precisión pero mejora el rendimiento
- **TrackRecord:** Activa el seguimiento de récords históricos del indicador
- **ShowEtapa1:** Muestra visualmente los eventos de ETAPA 1 en el gráfico
- **ShowEtapa2:** Muestra visualmente los eventos de ETAPA 2 en el gráfico
- **ShowStop:** Muestra los niveles de stop loss calculados
- **ShowFreq1/2/3:** Muestra diferentes frecuencias o niveles de análisis
- **Breakouts:** Activa la detección de rompimientos
- **GraphBreakouts:** Visualiza gráficamente los rompimientos detectados

### 13.2 VX_M7 - Parámetros de Configuración

El indicador VX M7 (versión M7) expone los siguientes parámetros:

```csharp
public class VxM7Configuration
{
    [Display(Name = "The_Wall", Description = "Mostrar The_Wall del VX")]
    public bool TheWall { get; set; } = true;
    
    [Display(Name = "Force Lines", Description = "Mostrar líneas de fuerza")]
    public bool ForceLines { get; set; } = true;
    
    [Display(Name = "Pullbacks", Description = "Detectar y mostrar pullbacks")]
    public bool Pullbacks { get; set; } = false;
}
```

**Descripción de parámetros:**

- **TheWall:** Activa la visualización de The_Wall del VX, que utiliza las MAPS como referencia comparativa
- **ForceLines:** Muestra las líneas de fuerza o dirección del mercado
- **Pullbacks:** Activa la detección y visualización de pullbacks (líneas de compradores/vendedores)

### 13.3 MAPS_M7 - Parámetros de Configuración

El indicador MAPS M7 expone los siguientes parámetros:

```csharp
public class MapsM7Configuration
{
    [Display(Name = "Centrais", Description = "Mostrar líneas centrales (Map 0 y adyacentes)")]
    public bool Centrais { get; set; } = true;
    
    [Display(Name = "Intermediarios", Description = "Mostrar líneas intermediarias (S1-S4, i1-i4)")]
    public bool Intermediarios { get; set; } = true;
    
    [Display(Name = "Clean Mode", Description = "Modo limpio (menos visualización)")]
    public bool CleanMode { get; set; } = false;
    
    [Display(Name = "The_Wall", Description = "Mostrar The_Wall del gráfico")]
    public bool TheWall { get; set; } = true;
    
    [Display(Name = "Force Lines", Description = "Mostrar líneas de fuerza")]
    public bool ForceLines { get; set; } = false;
    
    [Display(Name = "Pullbacks", Description = "Mostrar líneas de pullback (compradores/vendedores)")]
    public bool Pullbacks { get; set; } = false;
}
```

**Descripción de parámetros:**

- **Centrais:** Activa la visualización de las líneas centrales (Map 0 y niveles cercanos)
- **Intermediarios:** Activa la visualización de líneas intermediarias (S1-S4, i1-i4 según volatilidad)
- **CleanMode:** Modo limpio que reduce la cantidad de visualización para mayor claridad
- **TheWall:** Activa la visualización de The_Wall del gráfico
- **ForceLines:** Muestra las líneas de fuerza direccional
- **Pullbacks:** Activa la visualización de las líneas de pullback (compradores/vendedores)

### 13.4 STOP_ABS_DEFAULT - Parámetros de Configuración

El indicador StopAbsV (Stop Absoluto por defecto) expone:

```csharp
public class StopAbsVConfiguration
{
    [Display(Name = "Show ABS", Description = "Mostrar valores absolutos")]
    public bool ShowAbs { get; set; } = true;
    
    [Display(Name = "Show Stops", Description = "Mostrar niveles de stop")]
    public bool ShowStops { get; set; } = true;
    
    [Display(Name = "Check", Description = "Activar verificación de stops")]
    public bool Check { get; set; } = true;
}
```

**Descripción de parámetros:**

- **ShowAbs:** Muestra los valores absolutos de stop loss
- **ShowStops:** Visualiza los niveles de stop loss calculados
- **Check:** Activa la verificación y validación de los stops

### 13.5 HERTZ_N_DEFAULT - Configuración

El indicador HERTZ utiliza valores por defecto sin parámetros configurables expuestos:

```csharp
public class HertzConfiguration
{
    // HERTZ utiliza configuración interna por defecto
    // No expone parámetros configurables en la versión M7
}
```

**Nota:** HERTZ opera con valores predeterminados internos y no requiere configuración adicional.

### 13.6 RENKOBRZ - Configuración

El indicador RENKOBRZ (Renko Bars) no expone parámetros configurables en la versión de referencia:

```csharp
public class RenkoBrzConfiguration
{
    // RENKOBRZ utiliza configuración interna
    // Parámetros de Renko (tamaño de brick) se configuran a nivel de instrumento
}
```

**Nota:** Los parámetros de Renko (tamaño de brick) se configuran directamente en las propiedades del gráfico o instrumento en NinjaTrader.

### 13.7 Valores por Defecto Recomendados

**Configuración estándar para FPLEME_M7_II:**

```csharp
var defaultFplemeConfig = new FplemeM7Configuration
{
    PaintBars = true,      // Visualización básica activada
    FastMode = false,      // Precisión sobre velocidad
    TrackRecord = false,   // Desactivado por defecto
    ShowEtapa1 = true,     // ETAPA 1 visible
    ShowEtapa2 = true,     // ETAPA 2 visible
    ShowStop = true,       // Stops visibles
    ShowFreq1 = false,     // Frecuencias opcionales
    ShowFreq2 = false,
    ShowFreq3 = false,
    Breakouts = false,     // Opcional
    GraphBreakouts = false
};
```

**Configuración estándar para VX_M7:**

```csharp
var defaultVxConfig = new VxM7Configuration
{
    TheWall = true,        // The_Wall del VX activada
    ForceLines = true,     // Líneas de fuerza activadas
    Pullbacks = false      // Pullbacks opcionales
};
```

**Configuración estándar para MAPS_M7:**

```csharp
var defaultMapsConfig = new MapsM7Configuration
{
    Centrais = true,       // Líneas centrales visibles
    Intermediarios = true, // Líneas intermediarias visibles
    CleanMode = false,     // Modo completo
    TheWall = true,        // The_Wall visible
    ForceLines = false,    // Opcional
    Pullbacks = false      // Opcional
};
```

---

## 14. CONCLUSIÓN Y PRÓXIMOS PASOS

### 14.1 Checklist de Implementación

- [ ] Implementar `IFplemeEngine` con cálculo de valores
- [ ] Implementar `IEtapa1Detector` con todas las validaciones
- [ ] Implementar `IEtapa2Detector` con detección reactiva y confirmación con SHARK
- [ ] Implementar `IEntryTiming` con reglas de posicionamiento (ETAPA 1 y ETAPA 2)
- [ ] Implementar modos de timing para ETAPA 2 (Clásico y 2.2)
- [ ] Implementar `IRiskManager` con stop loss adaptativo (ETAPA 1 y ETAPA 2)
- [ ] Integrar filtros de calidad (PPM, MM, The_Wall) para ambas etapas
- [ ] Implementar sistema de Post-its visuales
- [ ] Implementar sistema de ticks por instrumento
- [ ] Crear suite de tests unitarios (ETAPA 1 y ETAPA 2)
- [ ] Validar en backtest histórico
- [ ] Optimizar rendimiento para tiempo real

### 14.2 Notas Finales

Este documento proporciona la especificación técnica completa para implementar un sistema de trading basado en FPLEME, ETAPA 1 y ETAPA 2. Todas las reglas, validaciones y estructuras de datos están definidas para facilitar la traducción directa a código C#.

**IMPORTANTE:** Este documento debe ser la referencia única de verdad para cualquier implementación. Cualquier desviación de estas especificaciones debe ser documentada y justificada.

---

**Versión:** 2.0  
**Fecha:** 2024  
**Autor:** Especificación Técnica FPLEME  
**Estado:** Completo y Listo para Implementación


