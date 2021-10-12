Public Class dAnalisisBD2
    Private m_codigo As Long
    Private m_ident As Long
    Private m_fecha As String
    Private m_hora As String
    Private m_id As Double
    Private m_grasa As Double
    Private m_proteina As Double
    Private m_lactosa As Double
    Private m_soltotales As Double
    Private m_celulas As Long
    Private m_crioscopia As Long
    Private m_urea As Integer
    Private m_equipo As String
    Private m_vmgrasa As Double
    Private m_vmproteina As Double
    Private m_vmlactosa As Double
    Private m_vmstotales As Double
    Private m_vmcelulas As Long
    Private m_vmcrioscopia As Long
    Private m_vmurea As Integer
    Private m_archivo As String
    Private m_fila As Long
#Region "Getters y Setters"
    Public Property CODIGO() As Long
        Get
            Return m_codigo
        End Get
        Set(ByVal value As Long)
            m_codigo = value
        End Set
    End Property
    Public Property IDENT() As Long
        Get
            Return m_ident
        End Get
        Set(ByVal value As Long)
            m_ident = value
        End Set
    End Property
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
        End Set
    End Property
    Public Property HORA() As String
        Get
            Return m_hora
        End Get
        Set(ByVal value As String)
            m_hora = value
        End Set
    End Property
    Public Property ID() As Double
        Get
            Return m_id
        End Get
        Set(ByVal value As Double)
            m_id = value
        End Set
    End Property
    Public Property GRASA() As Double
        Get
            Return m_grasa
        End Get
        Set(ByVal value As Double)
            m_grasa = value
        End Set
    End Property
    Public Property PROTEINA() As Double
        Get
            Return m_proteina
        End Get
        Set(ByVal value As Double)
            m_proteina = value
        End Set
    End Property
    Public Property LACTOSA() As Double
        Get
            Return m_lactosa
        End Get
        Set(ByVal value As Double)
            m_lactosa = value
        End Set
    End Property
    Public Property SOLTOTALES() As Double
        Get
            Return m_soltotales
        End Get
        Set(ByVal value As Double)
            m_soltotales = value
        End Set
    End Property
    Public Property CELULAS() As Long
        Get
            Return m_celulas
        End Get
        Set(ByVal value As Long)
            m_celulas = value
        End Set
    End Property
    Public Property CRIOSCOPIA() As Long
        Get
            Return m_crioscopia
        End Get
        Set(ByVal value As Long)
            m_crioscopia = value
        End Set
    End Property
    Public Property UREA() As Integer
        Get
            Return m_urea
        End Get
        Set(ByVal value As Integer)
            m_urea = value
        End Set
    End Property
    Public Property EQUIPO() As String
        Get
            Return m_equipo
        End Get
        Set(ByVal value As String)
            m_equipo = value
        End Set
    End Property
    Public Property VMGRASA() As Double
        Get
            Return m_vmgrasa
        End Get
        Set(ByVal value As Double)
            m_vmgrasa = value
        End Set
    End Property
    Public Property VMPROTEINA() As Double
        Get
            Return m_vmproteina
        End Get
        Set(ByVal value As Double)
            m_vmproteina = value
        End Set
    End Property
    Public Property VMLACTOSA() As Double
        Get
            Return m_vmlactosa
        End Get
        Set(ByVal value As Double)
            m_vmlactosa = value
        End Set
    End Property
    Public Property VMSTOTALES() As Double
        Get
            Return m_vmstotales
        End Get
        Set(ByVal value As Double)
            m_vmstotales = value
        End Set
    End Property
    Public Property VMCELULAS() As Double
        Get
            Return m_vmcelulas
        End Get
        Set(ByVal value As Double)
            m_vmcelulas = value
        End Set
    End Property
    Public Property VMCRIOSCOPIA() As Double
        Get
            Return m_vmcrioscopia
        End Get
        Set(ByVal value As Double)
            m_vmcrioscopia = value
        End Set
    End Property
    Public Property VMUREA() As Double
        Get
            Return m_vmurea
        End Get
        Set(ByVal value As Double)
            m_vmurea = value
        End Set
    End Property
    Public Property ARCHIVO() As String
        Get
            Return m_archivo
        End Get
        Set(ByVal value As String)
            m_archivo = value
        End Set
    End Property
    Public Property FILA() As Long
        Get
            Return m_fila
        End Get
        Set(ByVal value As Long)
            m_fila = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        m_codigo = 0
        m_ident = 0
        m_fecha = ""
        m_hora = ""
        m_id = 0
        m_grasa = 0
        m_proteina = 0
        m_lactosa = 0
        m_soltotales = 0
        m_celulas = 0
        m_crioscopia = 0
        m_urea = 0
        m_equipo = 0
        m_vmgrasa = 0
        m_vmproteina = 0
        m_vmlactosa = 0
        m_vmstotales = 0
        m_vmcelulas = 0
        m_vmcrioscopia = 0
        m_vmurea = 0
        m_archivo = ""
        m_fila = 0
    End Sub
    Public Sub New(ByVal codigo As Long, ByVal ident As Long, ByVal fecha As String, ByVal hora As String, ByVal id As Double, ByVal grasa As Double, ByVal proteina As Double, ByVal lactosa As Double, ByVal soltotales As Double, ByVal celulas As Long, ByVal crioscopia As Long, ByVal urea As Integer, ByVal equipo As String, ByVal vmgrasa As String, ByVal vmproteina As String, ByVal vmlactosa As String, ByVal vmstotales As String, ByVal vmcelulas As String, ByVal vmcrioscopia As String, ByVal vmurea As String, ByVal archivo As String, ByVal fila As Long)
        m_codigo = codigo
        m_ident = ident
        m_fecha = fecha
        m_hora = hora
        m_id = id
        m_grasa = grasa
        m_proteina = proteina
        m_lactosa = lactosa
        m_soltotales = soltotales
        m_celulas = celulas
        m_crioscopia = crioscopia
        m_urea = urea
        m_equipo = equipo
        m_vmgrasa = vmgrasa
        m_vmproteina = vmproteina
        m_vmlactosa = vmlactosa
        m_vmstotales = vmstotales
        m_vmcelulas = vmcelulas
        m_vmcrioscopia = vmcrioscopia
        m_vmurea = vmurea
        m_archivo = archivo
        m_fila = fila
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisisBD2
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisisBD2
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisisBD2
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAnalisisBD2
        Dim p As New pAnalisisBD2
        Return p.buscar(Me)
    End Function
    Public Function buscarxarchivo() As dAnalisisBD2
        Dim p As New pAnalisisBD2
        Return p.buscarxarchivo(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_codigo
    End Function

    Public Function listar() As ArrayList
        Dim p As New pAnalisisBD2
        Return p.listar
    End Function
    Public Function listarxarchivo(ByVal archivo As String) As ArrayList
        Dim p As New pAnalisisBD2
        Return p.listarxarchivo(archivo)
    End Function
End Class
