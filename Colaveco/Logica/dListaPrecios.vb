Public Class dListaPrecios
#Region "Atributos"
    Private m_id As Integer
    Private m_codigo As String
    Private m_descripcion As String
    Private m_precio1 As Double
    Private m_precio2 As Double
    Private m_precio3 As Double
    Private m_precio4 As Double
    Private m_precio5 As Double
    Private m_precio6 As Double
    Private m_precio7 As Double
    Private m_ti As Integer
    Private m_desctecnica As String
    Private m_tipocontrol As Integer
    Private m_abreviatura As String
    Private m_acreditado As Integer
    Private m_orden As Integer
    Private m_ocultar As Integer
    Private m_paquete As Integer
    Private m_mostrar_r As Integer
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

    Public Property CODIGO() As String
        Get
            Return m_codigo
        End Get
        Set(ByVal value As String)
            m_codigo = value
        End Set
    End Property
    Public Property DESCRIPCION() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property
    Public Property PRECIO1() As Double
        Get
            Return m_precio1
        End Get
        Set(ByVal value As Double)
            m_precio1 = value
        End Set
    End Property
    Public Property PRECIO2() As Double
        Get
            Return m_precio2
        End Get
        Set(ByVal value As Double)
            m_precio2 = value
        End Set
    End Property
    Public Property PRECIO3() As Double
        Get
            Return m_precio3
        End Get
        Set(ByVal value As Double)
            m_precio3 = value
        End Set
    End Property
    Public Property PRECIO4() As Double
        Get
            Return m_precio4
        End Get
        Set(ByVal value As Double)
            m_precio4 = value
        End Set
    End Property
    Public Property PRECIO5() As Double
        Get
            Return m_precio5
        End Get
        Set(ByVal value As Double)
            m_precio5 = value
        End Set
    End Property
    Public Property PRECIO6() As Double
        Get
            Return m_precio6
        End Get
        Set(ByVal value As Double)
            m_precio6 = value
        End Set
    End Property
    Public Property PRECIO7() As Double
        Get
            Return m_precio7
        End Get
        Set(ByVal value As Double)
            m_precio7 = value
        End Set
    End Property
    Public Property TI() As Integer
        Get
            Return m_ti
        End Get
        Set(ByVal value As Integer)
            m_ti = value
        End Set
    End Property
    Public Property DESCTECNICA() As String
        Get
            Return m_desctecnica
        End Get
        Set(ByVal value As String)
            m_desctecnica = value
        End Set
    End Property
    Public Property TIPOCONTROL() As Integer
        Get
            Return m_tipocontrol
        End Get
        Set(ByVal value As Integer)
            m_tipocontrol = value
        End Set
    End Property
    Public Property ABREVIATURA() As String
        Get
            Return m_abreviatura
        End Get
        Set(ByVal value As String)
            m_abreviatura = value
        End Set
    End Property
    Public Property ACREDITADO() As Integer
        Get
            Return m_acreditado
        End Get
        Set(ByVal value As Integer)
            m_acreditado = value
        End Set
    End Property
    Public Property ORDEN() As Integer
        Get
            Return m_orden
        End Get
        Set(ByVal value As Integer)
            m_orden = value
        End Set
    End Property
    Public Property OCULTAR() As Integer
        Get
            Return m_ocultar
        End Get
        Set(ByVal value As Integer)
            m_ocultar = value
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
    Public Property MOSTRAR_R() As Integer
        Get
            Return m_mostrar_r
        End Get
        Set(ByVal value As Integer)
            m_mostrar_r = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_codigo = ""
        m_descripcion = ""
        m_precio1 = 0
        m_precio2 = 0
        m_precio3 = 0
        m_precio4 = 0
        m_precio5 = 0
        m_precio6 = 0
        m_precio7 = 0
        m_ti = 0
        m_desctecnica = ""
        m_tipocontrol = 0
        m_abreviatura = ""
        m_acreditado = 0
        m_orden = 0
        m_ocultar = 0
        m_paquete = 0
        m_mostrar_r = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal codigo As String, ByVal descripcion As String, ByVal precio1 As Double, ByVal precio2 As Double, ByVal precio3 As Double, ByVal precio4 As Double, ByVal precio5 As Double, ByVal precio6 As Double, ByVal precio7 As Double, ByVal ti As Integer, ByVal desctecnica As String, ByVal tipocontrol As Integer, ByVal abreviatura As String, ByVal acreditado As Integer, ByVal orden As Integer, ByVal ocultar As Integer, ByVal paquete As Integer, ByVal mostrar_r As Integer)
        m_id = id
        m_codigo = codigo
        m_descripcion = descripcion
        m_precio1 = precio1
        m_precio2 = precio2
        m_precio3 = precio3
        m_precio4 = precio4
        m_precio5 = precio5
        m_precio6 = precio6
        m_precio7 = precio7
        m_ti = ti
        m_desctecnica = desctecnica
        m_tipocontrol = tipocontrol
        m_abreviatura = abreviatura
        m_acreditado = acreditado
        m_orden = orden
        m_ocultar = ocultar
        m_paquete = paquete
        m_mostrar_r = mostrar_r
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pListaPrecios
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pListaPrecios
        Return p.modificar(Me, usuario)
    End Function
    Public Function marcar_acreditado(ByVal usuario As dUsuario) As Boolean
        Dim p As New pListaPrecios
        Return p.marcar_acreditado(Me, usuario)
    End Function
    Public Function desmarcar_acreditado(ByVal usuario As dUsuario) As Boolean
        Dim p As New pListaPrecios
        Return p.desmarcar_acreditado(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pListaPrecios
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dListaPrecios
        Dim p As New pListaPrecios
        Return p.buscar(Me)
    End Function
    Public Function buscarultimo() As dListaPrecios
        Dim p As New pListaPrecios
        Return p.buscarultimo(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_codigo
    End Function

    Public Function listar() As ArrayList
        Dim p As New pListaPrecios
        Return p.listar
    End Function
    Public Function listarxti(ByVal idti As Integer) As ArrayList
        Dim p As New pListaPrecios
        Return p.listarxti(idti)
    End Function
    Public Function listar_solo_analisis(ByVal idti As Integer) As ArrayList
        Dim p As New pListaPrecios
        Return p.listar_solo_analisis(idti)
    End Function
    Public Function listarpaquetes(ByVal idti As Integer) As ArrayList
        Dim p As New pListaPrecios
        Return p.listarpaquetes(idti)
    End Function
    Public Function listarparasolicitud(ByVal idti As Integer) As ArrayList
        Dim p As New pListaPrecios
        Return p.listarparasolicitud(idti)
    End Function
    Public Function listarxdescripcion(ByVal nombre As String) As ArrayList
        Dim p As New pListaPrecios
        Return p.listarxdescripcion(nombre)
    End Function
End Class
