Public Class dDescarteMuestras
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_ficha As Long
    Private m_idproductor As Long
    Private m_idmuestra As Integer
    Private m_cantidad As Double
    Private m_idtipoinforme As Integer
    Private m_idmotivodescarte As Integer
    Private m_valor As Double
    Private m_idinforetorno As Integer
    Private m_idautorizacion As Integer
    Private m_observaciones As String
    Private m_operador As Integer
    Private m_eliminado As Integer
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
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
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
    Public Property IDPRODUCTOR() As Long
        Get
            Return m_idproductor
        End Get
        Set(ByVal value As Long)
            m_idproductor = value
        End Set
    End Property

    Public Property IDMUESTRA() As Integer
        Get
            Return m_idmuestra
        End Get
        Set(ByVal value As Integer)
            m_idmuestra = value
        End Set
    End Property

    Public Property CANTIDAD() As Double
        Get
            Return m_cantidad
        End Get
        Set(ByVal value As Double)
            m_cantidad = value
        End Set
    End Property
    Public Property IDTIPOINFORME() As Integer
        Get
            Return m_idtipoinforme
        End Get
        Set(ByVal value As Integer)
            m_idtipoinforme = value
        End Set
    End Property

    Public Property IDMOTIVODESCARTE() As Integer
        Get
            Return m_idmotivodescarte
        End Get
        Set(ByVal value As Integer)
            m_idmotivodescarte = value
        End Set
    End Property
    Public Property VALOR() As Double
        Get
            Return m_valor
        End Get
        Set(ByVal value As Double)
            m_valor = value
        End Set
    End Property
    Public Property IDINFORETORNO() As Integer
        Get
            Return m_idinforetorno
        End Get
        Set(ByVal value As Integer)
            m_idinforetorno = value
        End Set
    End Property
    Public Property IDAUTORIZACION() As Integer
        Get
            Return m_idautorizacion
        End Get
        Set(ByVal value As Integer)
            m_idautorizacion = value
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
    Public Property OPERADOR() As Integer
        Get
            Return m_operador
        End Get
        Set(ByVal value As Integer)
            m_operador = value
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
   
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_ficha = 0
        m_idproductor = 0
        m_idmuestra = 0
        m_cantidad = 0
        m_idtipoinforme = 0
        m_idmotivodescarte = 0
        m_valor = 0
        m_idinforetorno = 0
        m_idautorizacion = 0
        m_observaciones = ""
        m_operador = 0
        m_eliminado = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal ficha As Long, ByVal idproductor As Long, ByVal idmuestra As Integer, ByVal cantidad As Double, ByVal idtipoinforme As Integer, ByVal idmotivodescarte As Integer, ByVal valor As Double, ByVal idinforetorno As Integer, ByVal idautorizacion As Integer, ByVal observaciones As String, ByVal operador As Integer, ByVal eliminado As Integer)
        m_id = id
        m_fecha = fecha
        m_ficha = ficha
        m_idproductor = idproductor
        m_idmuestra = idmuestra
        m_cantidad = cantidad
        m_idtipoinforme = idtipoinforme
        m_idmotivodescarte = idmotivodescarte
        m_valor = valor
        m_idinforetorno = idinforetorno
        m_idautorizacion = idautorizacion
        m_observaciones = observaciones
        m_operador = operador
        m_eliminado = eliminado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pDescarteMuestras
        Return s.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pDescarteMuestras
        Return s.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pDescarteMuestras
        Return s.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dDescarteMuestras
        Dim s As New pDescarteMuestras
        Return s.buscar(Me)
    End Function
    Public Function buscarxficha() As dDescarteMuestras
        Dim s As New pDescarteMuestras
        Return s.buscarxficha(Me)
    End Function

    
#End Region

    Public Overrides Function ToString() As String
        Dim pr As New dCliente
        pr.ID = m_idproductor
        pr = pr.buscar
        Return m_id & Chr(9) & m_fecha & Chr(9) & pr.NOMBRE & Chr(9) & m_observaciones
    End Function
    Public Function listar() As ArrayList
        Dim s As New pDescarteMuestras
        Return s.listar
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim s As New pDescarteMuestras
        Return s.listarporid(texto)
    End Function
    
    Public Function listarporproductor(ByVal texto As Long) As ArrayList
        Dim s As New pDescarteMuestras
        Return s.listarporproductor(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pDescarteMuestras
        Return s.listarporfecha(fechadesde, fechahasta)
    End Function
    Public Function listarporficha(ByVal texto As Long) As ArrayList
        Dim s As New pDescarteMuestras
        Return s.listarporficha(texto)
    End Function
End Class
