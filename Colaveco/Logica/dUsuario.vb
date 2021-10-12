Public Class dUsuario
#Region "Atributos"
    Private m_id As Integer
    Private m_nombre As String
    Private m_sexo As String
    Private m_ci As String
    Private m_tipousuario As Integer
    Private m_sector As Integer
    Private m_usuario As String
    Private m_password As String
    Private m_eliminado As Integer
    Private m_foto As String
    Private m_tipomarca As Integer
    Private m_entra As String
    Private m_sale As String
    Private m_entra2 As String
    Private m_sale2 As String
    Private m_entra3 As String
    Private m_sale3 As String
    Private m_entra4 As String
    Private m_sale4 As String
    Private m_entra5 As String
    Private m_sale5 As String
    Private m_entra6 As String
    Private m_sale6 As String
    Private m_entrac As String
    Private m_salec As String
    Private m_entrac2 As String
    Private m_salec2 As String
    Private m_entrac3 As String
    Private m_salec3 As String
    Private m_entrac4 As String
    Private m_salec4 As String
    Private m_entrac5 As String
    Private m_salec5 As String
    Private m_entrac6 As String
    Private m_salec6 As String
    Private m_entrar As String
    Private m_saler As String
    Private m_entrar2 As String
    Private m_saler2 As String
    Private m_entrar3 As String
    Private m_saler3 As String
    Private m_entrar4 As String
    Private m_saler4 As String
    Private m_entrar5 As String
    Private m_saler5 As String
    Private m_entrar6 As String
    Private m_saler6 As String
    Private m_email As String
    Private m_csalud As String
#End Region

#Region "Getters y Setters"
    Public Property ID() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
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
    Public Property SEXO() As String
        Get
            Return m_sexo
        End Get
        Set(ByVal value As String)
            m_sexo = value
        End Set
    End Property
    Public Property CI() As String
        Get
            Return m_ci
        End Get
        Set(ByVal value As String)
            m_ci = value
        End Set
    End Property
    Public Property TIPOUSUARIO() As Integer
        Get
            Return m_tipousuario
        End Get
        Set(ByVal value As Integer)
            m_tipousuario = value
        End Set
    End Property
    Public Property SECTOR() As Integer
        Get
            Return m_sector
        End Get
        Set(ByVal value As Integer)
            m_sector = value
        End Set
    End Property
    Public Property USUARIO() As String
        Get
            Return m_usuario
        End Get
        Set(ByVal value As String)
            m_usuario = value
        End Set
    End Property
    Public Property PASSWORD() As String
        Get
            Return m_password
        End Get
        Set(ByVal value As String)
            m_password = value
        End Set
    End Property
    Public Property ELIMINADO() As Integer
        Get
            Return m_eliminado
        End Get
        Set(ByVal value As Integer)
            m_eliminado = value
        End Set
    End Property
    Public Property FOTO() As String
        Get
            Return m_foto
        End Get
        Set(ByVal value As String)
            m_foto = value
        End Set
    End Property
    Public Property TIPOMARCA() As Integer
        Get
            Return m_tipomarca
        End Get
        Set(ByVal value As Integer)
            m_tipomarca = value
        End Set
    End Property
    Public Property ENTRA() As String
        Get
            Return m_entra
        End Get
        Set(ByVal value As String)
            m_entra = value
        End Set
    End Property
    Public Property SALE() As String
        Get
            Return m_sale
        End Get
        Set(ByVal value As String)
            m_sale = value
        End Set
    End Property
    Public Property ENTRA2() As String
        Get
            Return m_entra2
        End Get
        Set(ByVal value As String)
            m_entra2 = value
        End Set
    End Property
    Public Property SALE2() As String
        Get
            Return m_sale2
        End Get
        Set(ByVal value As String)
            m_sale2 = value
        End Set
    End Property
    Public Property ENTRA3() As String
        Get
            Return m_entra3
        End Get
        Set(ByVal value As String)
            m_entra3 = value
        End Set
    End Property
    Public Property SALE3() As String
        Get
            Return m_sale3
        End Get
        Set(ByVal value As String)
            m_sale3 = value
        End Set
    End Property
    Public Property ENTRA4() As String
        Get
            Return m_entra4
        End Get
        Set(ByVal value As String)
            m_entra4 = value
        End Set
    End Property
    Public Property SALE4() As String
        Get
            Return m_sale4
        End Get
        Set(ByVal value As String)
            m_sale4 = value
        End Set
    End Property
    Public Property ENTRA5() As String
        Get
            Return m_entra5
        End Get
        Set(ByVal value As String)
            m_entra5 = value
        End Set
    End Property
    Public Property SALE5() As String
        Get
            Return m_sale5
        End Get
        Set(ByVal value As String)
            m_sale5 = value
        End Set
    End Property
    Public Property ENTRA6() As String
        Get
            Return m_entra6
        End Get
        Set(ByVal value As String)
            m_entra6 = value
        End Set
    End Property
    Public Property SALE6() As String
        Get
            Return m_sale6
        End Get
        Set(ByVal value As String)
            m_sale6 = value
        End Set
    End Property
    Public Property ENTRAC() As String
        Get
            Return m_entrac
        End Get
        Set(ByVal value As String)
            m_entrac = value
        End Set
    End Property
    Public Property SALEC() As String
        Get
            Return m_salec
        End Get
        Set(ByVal value As String)
            m_salec = value
        End Set
    End Property
    Public Property ENTRAC2() As String
        Get
            Return m_entrac2
        End Get
        Set(ByVal value As String)
            m_entrac2 = value
        End Set
    End Property
    Public Property SALEC2() As String
        Get
            Return m_salec2
        End Get
        Set(ByVal value As String)
            m_salec2 = value
        End Set
    End Property
    Public Property ENTRAC3() As String
        Get
            Return m_entrac3
        End Get
        Set(ByVal value As String)
            m_entrac3 = value
        End Set
    End Property
    Public Property SALEC3() As String
        Get
            Return m_salec3
        End Get
        Set(ByVal value As String)
            m_salec3 = value
        End Set
    End Property
    Public Property ENTRAC4() As String
        Get
            Return m_entrac4
        End Get
        Set(ByVal value As String)
            m_entrac4 = value
        End Set
    End Property
    Public Property SALEC4() As String
        Get
            Return m_salec4
        End Get
        Set(ByVal value As String)
            m_salec4 = value
        End Set
    End Property
    Public Property ENTRAC5() As String
        Get
            Return m_entrac5
        End Get
        Set(ByVal value As String)
            m_entrac5 = value
        End Set
    End Property
    Public Property SALEC5() As String
        Get
            Return m_salec5
        End Get
        Set(ByVal value As String)
            m_salec5 = value
        End Set
    End Property
    Public Property ENTRAC6() As String
        Get
            Return m_entrac6
        End Get
        Set(ByVal value As String)
            m_entrac6 = value
        End Set
    End Property
    Public Property SALEC6() As String
        Get
            Return m_salec6
        End Get
        Set(ByVal value As String)
            m_salec6 = value
        End Set
    End Property
    Public Property ENTRAR() As String
        Get
            Return m_entrar
        End Get
        Set(ByVal value As String)
            m_entrar = value
        End Set
    End Property
    Public Property SALER() As String
        Get
            Return m_saler
        End Get
        Set(ByVal value As String)
            m_saler = value
        End Set
    End Property
    Public Property ENTRAR2() As String
        Get
            Return m_entrar2
        End Get
        Set(ByVal value As String)
            m_entrar2 = value
        End Set
    End Property
    Public Property SALER2() As String
        Get
            Return m_saler2
        End Get
        Set(ByVal value As String)
            m_saler2 = value
        End Set
    End Property
    Public Property ENTRAR3() As String
        Get
            Return m_entrar3
        End Get
        Set(ByVal value As String)
            m_entrar3 = value
        End Set
    End Property
    Public Property SALER3() As String
        Get
            Return m_saler3
        End Get
        Set(ByVal value As String)
            m_saler3 = value
        End Set
    End Property
    Public Property ENTRAR4() As String
        Get
            Return m_entrar4
        End Get
        Set(ByVal value As String)
            m_entrar4 = value
        End Set
    End Property
    Public Property SALER4() As String
        Get
            Return m_saler4
        End Get
        Set(ByVal value As String)
            m_saler4 = value
        End Set
    End Property
    Public Property ENTRAR5() As String
        Get
            Return m_entrar5
        End Get
        Set(ByVal value As String)
            m_entrar5 = value
        End Set
    End Property
    Public Property SALER5() As String
        Get
            Return m_saler5
        End Get
        Set(ByVal value As String)
            m_saler5 = value
        End Set
    End Property
    Public Property ENTRAR6() As String
        Get
            Return m_entrar6
        End Get
        Set(ByVal value As String)
            m_entrar6 = value
        End Set
    End Property
    Public Property SALER6() As String
        Get
            Return m_saler6
        End Get
        Set(ByVal value As String)
            m_saler6 = value
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
    Public Property CSALUD() As String
        Get
            Return m_csalud
        End Get
        Set(ByVal value As String)
            m_csalud = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_sexo = ""
        m_ci = ""
        m_tipousuario = 0
        m_sector = 0
        m_usuario = ""
        m_password = ""
        m_eliminado = 0
        m_foto = ""
        m_tipomarca = 0
        m_entra = ""
        m_sale = ""
        m_entra2 = ""
        m_sale2 = ""
        m_entra3 = ""
        m_sale3 = ""
        m_entra4 = ""
        m_sale4 = ""
        m_entra5 = ""
        m_sale5 = ""
        m_entra6 = ""
        m_sale6 = ""
        m_entrac = ""
        m_salec = ""
        m_entrac2 = ""
        m_salec2 = ""
        m_entrac3 = ""
        m_salec3 = ""
        m_entrac4 = ""
        m_salec4 = ""
        m_entrac5 = ""
        m_salec5 = ""
        m_entrac6 = ""
        m_salec6 = ""
        m_entrar = ""
        m_saler = ""
        m_entrar2 = ""
        m_saler2 = ""
        m_entrar3 = ""
        m_saler3 = ""
        m_entrar4 = ""
        m_saler4 = ""
        m_entrar5 = ""
        m_saler5 = ""
        m_entrar6 = ""
        m_saler6 = ""
        m_email = ""
        m_csalud = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal sexo As String, ByVal ci As String, ByVal tipousuario As Integer, ByVal sector As Integer, ByVal usuario As String, ByVal password As String, ByVal eliminado As Integer, ByVal foto As String, ByVal tipomarca As Integer, ByVal entra As String, ByVal sale As String, ByVal entra2 As String, ByVal sale2 As String, ByVal entra3 As String, ByVal sale3 As String, ByVal entra4 As String, ByVal sale4 As String, ByVal entra5 As String, ByVal sale5 As String, ByVal entra6 As String, ByVal sale6 As String, ByVal entrac As String, ByVal salec As String, ByVal entrac2 As String, ByVal salec2 As String, ByVal entrac3 As String, ByVal salec3 As String, ByVal entrac4 As String, ByVal salec4 As String, ByVal entrac5 As String, ByVal salec5 As String, ByVal entrac6 As String, ByVal salec6 As String, ByVal entrar As String, ByVal saler As String, ByVal entrar2 As String, ByVal saler2 As String, ByVal entrar3 As String, ByVal saler3 As String, ByVal entrar4 As String, ByVal saler4 As String, ByVal entrar5 As String, ByVal saler5 As String, ByVal entrar6 As String, ByVal saler6 As String, ByVal email As String, ByVal csalud As String)
        m_id = id
        m_nombre = nombre
        m_sexo = sexo
        m_ci = ci
        m_tipousuario = tipousuario
        m_sector = sector
        m_usuario = usuario
        m_password = password
        m_eliminado = eliminado
        m_foto = foto
        m_tipomarca = tipomarca
        m_entra = entra
        m_sale = sale
        m_entra2 = entra2
        m_sale2 = sale2
        m_entra3 = entra3
        m_sale3 = sale3
        m_entra4 = entra4
        m_sale4 = sale4
        m_entra5 = entra5
        m_sale5 = sale5
        m_entra6 = entra6
        m_sale6 = sale6
        m_entrac = entrac
        m_salec = salec
        m_entrac2 = entrac2
        m_salec2 = salec2
        m_entrac3 = entrac3
        m_salec3 = salec3
        m_entrac4 = entrac4
        m_salec4 = salec4
        m_entrac5 = entrac5
        m_salec5 = salec5
        m_entrac6 = entrac6
        m_salec6 = salec6
        m_entrar = entrar
        m_saler = saler
        m_entrar2 = entrar2
        m_saler2 = saler2
        m_entrar3 = entrar3
        m_saler3 = saler3
        m_entrar4 = entrar4
        m_saler4 = saler4
        m_entrar5 = entrar5
        m_saler5 = saler5
        m_entrar6 = entrar6
        m_saler6 = saler6
        m_email = email
        m_csalud = csalud
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pUsuario
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pUsuario
        Return p.modificar(Me, usuario)
    End Function
    Public Function guardar2(ByVal usuario As dUsuario) As Boolean
        Dim p As New pUsuario
        Return p.guardar2(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim p As New pUsuario
        Return p.modificar2(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pUsuario
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dUsuario
        Dim p As New pUsuario
        Return p.buscar(Me)
    End Function
    Public Function buscarPorNombre() As dUsuario
        Dim p As New pUsuario
        Return p.buscarPorNombre(Me)
    End Function
    Public Function buscarPorPassword() As dUsuario
        Dim p As New pUsuario
        Return p.buscarPorPassword(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim p As New pUsuario
        Return p.listar
    End Function
    Public Function listar2(ByVal idusu As Integer) As ArrayList
        Dim p As New pUsuario
        Return p.listar2(idusu)
    End Function
    Public Function listartodos() As ArrayList
        Dim p As New pUsuario
        Return p.listartodos
    End Function
    Public Function listarxusuario(ByVal usu As Integer) As ArrayList
        Dim p As New pUsuario
        Return p.listarxusuario(usu)
    End Function
End Class

