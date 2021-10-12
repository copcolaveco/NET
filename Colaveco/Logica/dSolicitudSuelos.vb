Public Class dSolicitudSuelos
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_muestra As String
    Private m_paquete As Integer
    Private m_nitratos As Integer
    Private m_mineralizacion As Integer
    Private m_fosforobray As Integer
    Private m_fosforocitrico As Integer
    Private m_phagua As Integer
    Private m_phkci As Integer
    Private m_materiaorg As Integer
    Private m_potasioint As Integer
    Private m_sulfatos As Integer
    Private m_nitrogenovegetal As Integer
    Private m_calcio As Integer
    Private m_magnesio As Integer
    Private m_sodio As Integer
    Private m_acideztitulable As Double
    Private m_cic As Double
    Private m_sb As Double
    Private m_muestreo As Integer
    Private m_zinc As Integer
    Private m_isusaestandar As Integer
    Private m_isusazinc As Integer

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
    Public Property MUESTRA() As String
        Get
            Return m_muestra
        End Get
        Set(ByVal value As String)
            m_muestra = value
        End Set
    End Property
    Public Property PAQUETE() As Integer
        Get
            Return m_paquete
        End Get
        Set(ByVal value As Integer)
            m_paquete = value
        End Set
    End Property
    Public Property NITRATOS() As Integer
        Get
            Return m_nitratos
        End Get
        Set(ByVal value As Integer)
            m_nitratos = value
        End Set
    End Property
    Public Property MINERALIZACION() As Integer
        Get
            Return m_mineralizacion
        End Get
        Set(ByVal value As Integer)
            m_mineralizacion = value
        End Set
    End Property
    Public Property FOSFOROBRAY() As Integer
        Get
            Return m_fosforobray
        End Get
        Set(ByVal value As Integer)
            m_fosforobray = value
        End Set
    End Property
    Public Property FOSFOROCITRICO() As Integer
        Get
            Return m_fosforocitrico
        End Get
        Set(ByVal value As Integer)
            m_fosforocitrico = value
        End Set
    End Property
    Public Property PHAGUA() As Integer
        Get
            Return m_phagua
        End Get
        Set(ByVal value As Integer)
            m_phagua = value
        End Set
    End Property
    Public Property PHKCI() As Integer
        Get
            Return m_phkci
        End Get
        Set(ByVal value As Integer)
            m_phkci = value
        End Set
    End Property
    Public Property MATERIAORG() As Integer
        Get
            Return m_materiaorg
        End Get
        Set(ByVal value As Integer)
            m_materiaorg = value
        End Set
    End Property
    Public Property POTASIOINT() As Integer
        Get
            Return m_potasioint
        End Get
        Set(ByVal value As Integer)
            m_potasioint = value
        End Set
    End Property
    Public Property SULFATOS() As Integer
        Get
            Return m_sulfatos
        End Get
        Set(ByVal value As Integer)
            m_sulfatos = value
        End Set
    End Property
    Public Property NITROGENOVEGETAL() As Integer
        Get
            Return m_nitrogenovegetal
        End Get
        Set(ByVal value As Integer)
            m_nitrogenovegetal = value
        End Set
    End Property
    Public Property CALCIO() As Integer
        Get
            Return m_calcio
        End Get
        Set(ByVal value As Integer)
            m_calcio = value
        End Set
    End Property
    Public Property MAGNESIO() As Integer
        Get
            Return m_magnesio
        End Get
        Set(ByVal value As Integer)
            m_magnesio = value
        End Set
    End Property
    Public Property SODIO() As Integer
        Get
            Return m_sodio
        End Get
        Set(ByVal value As Integer)
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
    Public Property MUESTREO() As Integer
        Get
            Return m_muestreo
        End Get
        Set(ByVal value As Integer)
            m_muestreo = value
        End Set
    End Property
    Public Property ZINC() As Integer
        Get
            Return m_zinc
        End Get
        Set(ByVal value As Integer)
            m_zinc = value
        End Set
    End Property
    Public Property ISUSAESTANDAR() As Integer
        Get
            Return m_isusaestandar
        End Get
        Set(ByVal value As Integer)
            m_isusaestandar = value
        End Set
    End Property
    Public Property ISUSAZINC() As Integer
        Get
            Return m_isusazinc
        End Get
        Set(ByVal value As Integer)
            m_isusazinc = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_muestra = ""
        m_paquete = 0
        m_nitratos = 0
        m_mineralizacion = 0
        m_fosforobray = 0
        m_fosforocitrico = 0
        m_phagua = 0
        m_phkci = 0
        m_materiaorg = 0
        m_potasioint = 0
        m_sulfatos = 0
        m_nitrogenovegetal = 0
        m_calcio = 0
        m_magnesio = 0
        m_sodio = 0
        m_acideztitulable = 0
        m_cic = 0
        m_sb = 0
        m_muestreo = 0
        m_zinc = 0
        m_isusaestandar = 0
        m_isusazinc = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal muestra As String, ByVal paquete As Integer, ByVal nitratos As Integer, ByVal mineralizacion As Integer, ByVal fosforobray As Integer, ByVal fosforocitrico As Integer, ByVal phagua As Integer, ByVal phkci As Integer, ByVal materiaorg As Integer, ByVal potasioint As Integer, ByVal sulfatos As Integer, ByVal nitrogenovegetal As Integer, ByVal calcio As Integer, ByVal magnesio As Integer, ByVal sodio As Integer, ByVal acideztitulable As Double, ByVal cic As Double, ByVal sb As Double, ByVal muestreo As Integer, ByVal zinc As Integer, ByVal isusaestandar As Integer, ByVal isusazinc As Integer)
        m_id = id
        m_ficha = ficha
        m_muestra = muestra
        m_paquete = paquete
        m_nitratos = nitratos
        m_mineralizacion = mineralizacion
        m_fosforobray = fosforobray
        m_fosforocitrico = fosforocitrico
        m_phagua = phagua
        m_phkci = phkci
        m_materiaorg = materiaorg
        m_potasioint = potasioint
        m_sulfatos = sulfatos
        m_nitrogenovegetal = nitrogenovegetal
        m_calcio = calcio
        m_magnesio = magnesio
        m_sodio = sodio
        m_acideztitulable = acideztitulable
        m_cic = cic
        m_sb = sb
        m_muestreo = muestreo
        m_zinc = zinc
        m_isusaestandar = isusaestandar
        m_isusazinc = isusazinc
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim ss As New pSolicitudSuelos
        Return ss.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim ss As New pSolicitudSuelos
        Return ss.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim ss As New pSolicitudSuelos
        Return ss.eliminar(Me, usuario)
    End Function

    Public Function buscar() As dSolicitudSuelos
        Dim ss As New pSolicitudSuelos
        Return ss.buscar(Me)
    End Function
    Public Function buscarxfichaxmuestra() As dSolicitudSuelos
        Dim ss As New pSolicitudSuelos
        Return ss.buscarxfichaxmuestra(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_muestra
    End Function
    Public Function listar() As ArrayList
        Dim ss As New pSolicitudSuelos
        Return ss.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim ss As New pSolicitudSuelos
        Return ss.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim ss As New pSolicitudSuelos
        Return ss.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim ss As New pSolicitudSuelos
        Return ss.listarporsolicitud(texto)
    End Function
End Class
