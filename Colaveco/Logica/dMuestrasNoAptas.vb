Public Class dMuestrasNoAptas
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_motivo As Integer
    Private m_cantidad As Integer
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
    Public Property MOTIVO() As Integer
        Get
            Return m_motivo
        End Get
        Set(ByVal value As Integer)
            m_motivo = value
        End Set
    End Property
    Public Property CANTIDAD() As Integer
        Get
            Return m_cantidad
        End Get
        Set(ByVal value As Integer)
            m_cantidad = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_motivo = 0
        m_cantidad = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal motivo As Integer, ByVal cantidad As Integer)
        m_id = id
        m_ficha = ficha
        m_motivo = motivo
        m_cantidad = cantidad

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMuestrasNoAptas
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMuestrasNoAptas
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMuestrasNoAptas
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dMuestrasNoAptas
        Dim p As New pMuestrasNoAptas
        Return p.buscar(Me)
    End Function
    Public Function buscarporficha() As dMuestrasNoAptas
        Dim p As New pMuestrasNoAptas
        Return p.buscarporficha(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Dim m As New dMuestraNoApta
        m.ID = m_motivo
        m = m.buscar

        Return m.NOMBRE & Chr(9) & m_cantidad
    End Function

    Public Function listar() As ArrayList
        Dim p As New pMuestrasNoAptas
        Return p.listar
    End Function
    Public Function listarporficha(ByVal texto As Long) As ArrayList
        Dim p As New pMuestrasNoAptas
        Return p.listarporficha(texto)
    End Function
End Class
