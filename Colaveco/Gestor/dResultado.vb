Public Class dResultado
    Private m_ficha As Long
    Private m_comentarios As String
    Private m_idnet_usuario As Long
    Private m_abonado As Integer
    Private m_fecha_creado As String
    Private m_fecha_emision As String
    Private m_path_excel As String
    Private m_path_pdf As String
    Private m_path_csv As String
    Private m_id_estado As Integer
    Private m_id_libro As Long
    Private m_idnet_tipo_informe As Integer

#Region "Getters y Setters"
    Public Property ficha() As Long
        Get
            Return m_ficha
        End Get
        Set(ByVal value As Long)
            m_ficha = value
        End Set
    End Property
    Public Property comentarios() As String
        Get
            Return m_comentarios
        End Get
        Set(ByVal value As String)
            m_comentarios = value
        End Set
    End Property
    Public Property idnet_usuario() As Long
        Get
            Return m_idnet_usuario
        End Get
        Set(ByVal value As Long)
            m_idnet_usuario = value
        End Set
    End Property
    Public Property abonado() As Integer
        Get
            Return m_abonado

        End Get
        Set(ByVal value As Integer)
            m_abonado = value
        End Set
    End Property
    Public Property fecha_creado() As String
        Get
            Return m_fecha_creado
        End Get
        Set(ByVal value As String)
            m_fecha_creado = value
        End Set
    End Property
    Public Property fecha_emision() As String
        Get
            Return m_fecha_emision
        End Get
        Set(ByVal value As String)
            m_fecha_emision = value
        End Set
    End Property
    Public Property path_excel() As String
        Get
            Return m_path_excel
        End Get
        Set(ByVal value As String)
            m_path_excel = value
        End Set
    End Property
    Public Property path_pdf() As String
        Get
            Return m_path_pdf
        End Get
        Set(ByVal value As String)
            m_path_pdf = value
        End Set
    End Property
    Public Property path_csv() As String
        Get
            Return m_path_csv
        End Get
        Set(ByVal value As String)
            m_path_csv = value
        End Set
    End Property
    Public Property id_estado() As Integer
        Get
            Return m_id_estado
        End Get
        Set(ByVal value As Integer)
            m_id_estado = value
        End Set
    End Property
    Public Property id_libro() As Long
        Get
            Return m_id_libro
        End Get
        Set(ByVal value As Long)
            m_id_libro = value
        End Set
    End Property
    Public Property idnet_tipo_informe() As Integer
        Get
            Return m_idnet_tipo_informe
        End Get
        Set(ByVal value As Integer)
            m_idnet_tipo_informe = value
        End Set
    End Property
#End Region
End Class
