Public Class dPatologiaWeb_uy
#Region "Atributos"
    Private m_id As Long
    Private m_id_usuario As Long
    Private m_comentario As String
    Private m_abonado As Integer
    Private m_fecha_creado As String
    Private m_fecha_emision As String
    Private m_path_excel As String
    Private m_path_pdf As String
    Private m_path_csv As String
    Private m_ficha As String
    Private m_id_estado As Integer
    Private m_id_libro As Long

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
    Public Property ID_USUARIO() As Long
        Get
            Return m_id_usuario
        End Get
        Set(ByVal value As Long)
            m_id_usuario = value
        End Set
    End Property
    Public Property COMENTARIO() As String
        Get
            Return m_comentario
        End Get
        Set(ByVal value As String)
            m_comentario = value
        End Set
    End Property
    Public Property ABONADO() As Integer
        Get
            Return m_abonado
        End Get
        Set(ByVal value As Integer)
            m_abonado = value
        End Set
    End Property
    Public Property FECHA_CREADO() As String
        Get
            Return m_fecha_creado
        End Get
        Set(ByVal value As String)
            m_fecha_creado = value
        End Set
    End Property
    Public Property FECHA_EMISION() As String
        Get
            Return m_fecha_emision
        End Get
        Set(ByVal value As String)
            m_fecha_emision = value
        End Set
    End Property
    Public Property PATH_EXCEL() As String
        Get
            Return m_path_excel
        End Get
        Set(ByVal value As String)
            m_path_excel = value
        End Set
    End Property
    Public Property PATH_PDF() As String
        Get
            Return m_path_pdf
        End Get
        Set(ByVal value As String)
            m_path_pdf = value
        End Set
    End Property
    Public Property PATH_CSV() As String
        Get
            Return m_path_csv
        End Get
        Set(ByVal value As String)
            m_path_csv = value
        End Set
    End Property
    Public Property FICHA() As String
        Get
            Return m_ficha
        End Get
        Set(ByVal value As String)
            m_ficha = value
        End Set
    End Property
    Public Property ID_ESTADO() As Integer
        Get
            Return m_id_estado
        End Get
        Set(ByVal value As Integer)
            m_id_estado = value
        End Set
    End Property
    Public Property ID_LIBRO() As Long
        Get
            Return m_id_libro
        End Get
        Set(ByVal value As Long)
            m_id_libro = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_id_usuario = 0
        m_comentario = ""
        m_abonado = 0
        m_fecha_creado = ""
        m_fecha_emision = ""
        m_path_excel = ""
        m_path_pdf = ""
        m_path_csv = ""
        m_ficha = ""
        m_id_estado = 0
        m_id_libro = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal id_usuario As Long, ByVal comentario As String, ByVal abonado As Integer, _
                   ByVal fecha_creado As String, ByVal fecha_emision As String, ByVal path_excel As String, _
                   ByVal path_pdf As String, ByVal path_csv As String, ByVal ficha As String, ByVal id_estado As Integer, _
                   ByVal id_libro As Long)
        m_id = id
        m_id_usuario = id_usuario
        m_comentario = comentario
        m_abonado = abonado
        m_fecha_creado = fecha_creado
        m_fecha_emision = fecha_emision
        m_path_excel = path_excel
        m_path_pdf = path_pdf
        m_path_csv = path_csv
        m_ficha = ficha
        m_id_estado = id_estado
        m_id_libro = id_libro
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pPatologiaWeb_uy
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pPatologiaWeb_uy
        Return c.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim c As New pPatologiaWeb_uy
        Return c.modificar2(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pPatologiaWeb_uy
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dPatologiaWeb_uy
        Dim c As New pPatologiaWeb_uy
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pPatologiaWeb_uy
        Return c.listar
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pPatologiaWeb_uy
        Return c.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim c As New pPatologiaWeb_uy
        Return c.listarporsolicitud(texto)
    End Function
End Class
