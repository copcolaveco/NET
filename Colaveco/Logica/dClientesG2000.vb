Public Class dClientesG2000
#Region "Atributos"
    Private m_codigo As String
    Private m_nombre As String
    Private m_rsocial As String
    Private m_rut As String
    Private m_direccion As String
    Private m_localidad As String
    Private m_departamento As Integer
    Private m_cpostal As String
    Private m_giro As Integer
    Private m_telefonos As String
    Private m_fax As String
    Private m_email As String
    Private m_contacto As String
    Private m_observaciones As String
#End Region

#Region "Getters y Setters"
    
    Public Property CODIGO() As String
        Get
            Return m_codigo
        End Get
        Set(ByVal value As String)
            m_codigo = value
        End Set
    End Property
    Public Property NOMBRE() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property RSOCIAL() As String
        Get
            Return m_rsocial
        End Get
        Set(ByVal value As String)
            m_rsocial = value
        End Set
    End Property
    Public Property RUT() As String
        Get
            Return m_rut
        End Get
        Set(ByVal value As String)
            m_rut = value
        End Set
    End Property
    Public Property DIRECCION() As String
        Get
            Return m_direccion
        End Get
        Set(ByVal value As String)
            m_direccion = value
        End Set
    End Property
    Public Property LOCALIDAD() As String
        Get
            Return m_localidad
        End Get
        Set(ByVal value As String)
            m_localidad = value
        End Set
    End Property
    Public Property DEPARTAMENTO() As Integer
        Get
            Return m_departamento
        End Get
        Set(ByVal value As Integer)
            m_departamento = value
        End Set
    End Property
    Public Property CPOSTAL() As String
        Get
            Return m_cpostal
        End Get
        Set(ByVal value As String)
            m_cpostal = value
        End Set
    End Property
    Public Property GIRO() As Integer
        Get
            Return m_giro
        End Get
        Set(ByVal value As Integer)
            m_giro = value
        End Set
    End Property
    Public Property TELEFONOS() As String
        Get
            Return m_telefonos
        End Get
        Set(ByVal value As String)
            m_telefonos = value
        End Set
    End Property
    Public Property FAX() As String
        Get
            Return m_fax
        End Get
        Set(ByVal value As String)
            m_fax = value
        End Set
    End Property
    Public Property EMAIL() As String
        Get
            Return m_email
        End Get
        Set(ByVal value As String)
            m_email = value
        End Set
    End Property
    Public Property CONTACTO() As String
        Get
            Return m_contacto
        End Get
        Set(ByVal value As String)
            m_contacto = value
        End Set
    End Property
    Public Property OBSERVACIONES() As String
        Get
            Return m_observaciones
        End Get
        Set(ByVal value As String)
            m_observaciones = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_codigo = ""
        m_nombre = ""
        m_rsocial = ""
        m_rut = ""
        m_direccion = ""
        m_localidad = ""
        m_departamento = 0
        m_cpostal = ""
        m_giro = 0
        m_telefonos = ""
        m_fax = ""
        m_email = ""
        m_contacto = ""
        m_observaciones = ""

    End Sub
    Public Sub New(ByVal codigo As String, ByVal nombre As String, ByVal rsocial As String, ByVal rut As String, ByVal direccion As String, ByVal localidad As String, ByVal departamento As Integer, ByVal cpostal As String, ByVal giro As Integer, ByVal telefonos As String, ByVal fax As String, ByVal email As String, ByVal contacto As String, ByVal observaciones As String)
        m_codigo = codigo
        m_nombre = nombre
        m_rsocial = rsocial
        m_rut = rut
        m_direccion = direccion
        m_localidad = localidad
        m_departamento = departamento
        m_cpostal = cpostal
        m_giro = giro
        m_telefonos = telefonos
        m_fax = fax
        m_email = email
        m_contacto = contacto
        m_observaciones = observaciones
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pClientesG2000
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pClientesG2000
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pClientesG2000
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dClientesG2000
        Dim p As New pClientesG2000
        Return p.buscar(Me)
    End Function
#End Region


    Public Overrides Function ToString() As String
        Return m_nombre
    End Function
    Public Function listar() As ArrayList
        Dim p As New pClientesG2000
        Return p.listar
    End Function
    
End Class
