Public Class dSuelos
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fechaingreso As String
    Private m_fechaproceso As String
    Private m_muestra As String
    Private m_detallemuestra As String
    Private m_fosforobray As Double
    Private m_fosforocitrico As Double
    Private m_nitratos As Double
    Private m_phagua As Double
    Private m_phkci As Double
    Private m_potasioint As Double
    Private m_sulfatos As Double
    Private m_nitrogenovegetal As Double
    Private m_carbonoorganico As Double
    Private m_materiaorganica As Double
    Private m_pmn As Double
    Private m_calcio As Double
    Private m_magnesio As Double
    Private m_sodio As Double
    Private m_acideztitulable As Double
    Private m_cic As Double ' capacidad de intercambio catiónico
    Private m_sb As Double '% de saturación en base 
    Private m_zinc As Double
    Private m_operador As Integer
    Private m_marca As Integer

#End Region

#Region "Getters y Setters"
    Public Property ID() As Long
        Get
            Return m_id
        End Get
        Set(ByVal value As Long)
            m_id = value
        End Set
    End Property
    Public Property FICHA() As Long
        Get
            Return m_ficha
        End Get
        Set(ByVal value As Long)
            m_ficha = value
        End Set
    End Property
    Public Property FECHAINGRESO() As String
        Get
            Return m_fechaingreso
        End Get
        Set(ByVal value As String)
            m_fechaingreso = value
        End Set
    End Property
    
    Public Property FECHAPROCESO() As String
        Get
            Return m_fechaproceso
        End Get
        Set(ByVal value As String)
            m_fechaproceso = value
        End Set
    End Property
    Public Property MUESTRA() As String
        Get
            Return m_muestra
        End Get
        Set(ByVal value As String)
            m_muestra = value
        End Set
    End Property
    Public Property DETALLEMUESTRA() As String
        Get
            Return m_detallemuestra
        End Get
        Set(ByVal value As String)
            m_detallemuestra = value
        End Set
    End Property
    Public Property FOSFOROBRAY() As Double
        Get
            Return m_fosforobray
        End Get
        Set(ByVal value As Double)
            m_fosforobray = value
        End Set
    End Property
    Public Property FOSFOROCITRICO() As Double
        Get
            Return m_fosforocitrico
        End Get
        Set(ByVal value As Double)
            m_fosforocitrico = value
        End Set
    End Property
    Public Property NITRATOS() As Double
        Get
            Return m_nitratos
        End Get
        Set(ByVal value As Double)
            m_nitratos = value
        End Set
    End Property
    Public Property PHAGUA() As Double
        Get
            Return m_phagua
        End Get
        Set(ByVal value As Double)
            m_phagua = value
        End Set
    End Property
    Public Property PHKCI() As Double
        Get
            Return m_phkci
        End Get
        Set(ByVal value As Double)
            m_phkci = value
        End Set
    End Property
    Public Property POTASIOINT() As Double
        Get
            Return m_potasioint
        End Get
        Set(ByVal value As Double)
            m_potasioint = value
        End Set
    End Property
    Public Property SULFATOS() As Double
        Get
            Return m_sulfatos
        End Get
        Set(ByVal value As Double)
            m_sulfatos = value
        End Set
    End Property
    Public Property NITROGENOVEGETAL() As Double
        Get
            Return m_nitrogenovegetal
        End Get
        Set(ByVal value As Double)
            m_nitrogenovegetal = value
        End Set
    End Property
    Public Property CARBONOORGANICO() As Double
        Get
            Return m_carbonoorganico
        End Get
        Set(ByVal value As Double)
            m_carbonoorganico = value
        End Set
    End Property
    Public Property MATERIAORGANICA() As Double
        Get
            Return m_materiaorganica
        End Get
        Set(ByVal value As Double)
            m_materiaorganica = value
        End Set
    End Property
    Public Property PMN() As Double
        Get
            Return m_pmn
        End Get
        Set(ByVal value As Double)
            m_pmn = value
        End Set
    End Property
    Public Property CALCIO() As Double
        Get
            Return m_calcio
        End Get
        Set(ByVal value As Double)
            m_calcio = value
        End Set
    End Property
    Public Property MAGNESIO() As Double
        Get
            Return m_magnesio
        End Get
        Set(ByVal value As Double)
            m_magnesio = value
        End Set
    End Property
    Public Property SODIO() As Double
        Get
            Return m_sodio
        End Get
        Set(ByVal value As Double)
            m_sodio = value
        End Set
    End Property
    Public Property ACIDEZTITULABLE() As Double
        Get
            Return m_acideztitulable
        End Get
        Set(ByVal value As Double)
            m_acideztitulable = value
        End Set
    End Property
    Public Property CIC() As Double
        Get
            Return m_cic
        End Get
        Set(ByVal value As Double)
            m_cic = value
        End Set
    End Property
    Public Property SB() As Double
        Get
            Return m_sb
        End Get
        Set(ByVal value As Double)
            m_sb = value
        End Set
    End Property
    Public Property ZINC() As Double
        Get
            Return m_zinc
        End Get
        Set(ByVal value As Double)
            m_zinc = value
        End Set
    End Property
    Public Property OPERADOR() As Integer
        Get
            Return m_operador
        End Get
        Set(ByVal value As Integer)
            m_operador = value
        End Set
    End Property
    Public Property MARCA() As Integer
        Get
            Return m_marca
        End Get
        Set(ByVal value As Integer)
            m_marca = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_fechaingreso = ""
        m_fechaproceso = ""
        m_muestra = ""
        m_detallemuestra = ""
        m_fosforobray = 0
        m_fosforocitrico = 0
        m_nitratos = 0
        m_phagua = 0
        m_phkci = 0
        m_potasioint = 0
        m_sulfatos = 0
        m_nitrogenovegetal = 0
        m_carbonoorganico = 0
        m_materiaorganica = 0
        m_pmn = 0
        m_calcio = 0
        m_magnesio = 0
        m_sodio = 0
        m_acideztitulable = 0
        m_cic = 0
        m_sb = 0
        m_zinc = 0
        m_operador = 0
        m_marca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fechaingreso As String, ByVal fechaproceso As String, ByVal muestra As String, ByVal detallemuestra As String, ByVal fosforobray As Double, ByVal fosforocitrico As Double, ByVal nitratos As Double, ByVal phagua As Double, ByVal phkci As Double, ByVal potasioint As Double, ByVal sulfatos As Double, ByVal nitrogenovegetal As Double, ByVal carbonoorganico As Double, ByVal materiaorganica As Double, ByVal pmn As Double, ByVal calcio As Double, ByVal magnesio As Double, ByVal sodio As Double, ByVal acideztitulable As Double, ByVal cic As Double, ByVal sb As Double, ByVal zinc As Double, ByVal operador As Integer, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_fechaingreso = fechaingreso
        m_fechaproceso = fechaproceso
        m_muestra = muestra
        m_detallemuestra = detallemuestra
        m_fosforobray = fosforobray
        m_fosforocitrico = fosforocitrico
        m_nitratos = nitratos
        m_phagua = phagua
        m_phkci = phkci
        m_potasioint = potasioint
        m_sulfatos = sulfatos
        m_nitrogenovegetal = nitrogenovegetal
        m_carbonoorganico = carbonoorganico
        m_materiaorganica = materiaorganica
        m_pmn = pmn
        m_calcio = calcio
        m_magnesio = magnesio
        m_sodio = sodio
        m_acideztitulable = acideztitulable
        m_cic = cic
        m_sb = sb
        m_zinc = zinc
        m_operador = operador
        m_marca = marca


    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim n As New pSuelos
        Return n.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim n As New pSuelos
        Return n.modificar(Me, usuario)
    End Function
    Public Function marcar(ByVal usuario As dUsuario) As Boolean
        Dim n As New pSuelos
        Return n.marcar(Me, usuario)
    End Function
    Public Function desmarcarficha() As Boolean
        Dim n As New pSuelos
        Return n.desmarcarficha(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim n As New pSuelos
        Return n.eliminar(Me, usuario)
    End Function

    Public Function buscar() As dSuelos
        Dim n As New pSuelos
        Return n.buscar(Me)
    End Function
  

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha & " - " & m_muestra
    End Function
    Public Function listar() As ArrayList
        Dim n As New pSuelos
        Return n.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim n As New pSuelos
        Return n.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim n As New pSuelos
        Return n.listarporid(texto)
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim n As New pSuelos
        Return n.listarporfecha(desde, hasta)
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim n As New pSuelos
        Return n.listarxfecha(desde, hasta)
    End Function
    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim n As New pSuelos
        Return n.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim n As New pSuelos
        Return n.listarporsolicitud2(texto)
    End Function
    Public Function listarfechaproceso(ByVal texto As Long) As ArrayList
        Dim n As New pSuelos
        Return n.listarfechaproceso(texto)
    End Function
End Class
