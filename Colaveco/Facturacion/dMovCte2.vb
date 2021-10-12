Public Class dMovCte2
#Region "Atributos"
    Private m_mccnro As Long ' número de movimiento
    Private m_mccfch As String ' fecha de emisión
    Private m_mccvto As String ' vencimiento si es factura
    Private m_doccod As String 'tipo de comprobante (Fac, N/C, etc)
    Private m_mccdoc As Long ' número de comprobante
    Private m_mccdes As String ' descripción
    Private m_clicod As Long ' código del cliente
    Private m_mccimp As Double ' importe del comprobante
    Private m_mccpag As Double ' pago
    Private m_mcccod As Integer ' código del comprobante (1 - Factura / 2 - Recibo)
    Private m_mcctip As String 'si es venta va una "V"
    Private m_mcccmp As Long 'nro de la tabla donde se guarda el comprobante
#End Region

#Region "Getters y Setters"
    Public Property MCCNRO() As Long
        Get
            Return m_mccnro
        End Get
        Set(ByVal value As Long)
            m_mccnro = value
        End Set
    End Property
    Public Property MCCFCH() As String
        Get
            Return m_mccfch
        End Get
        Set(ByVal value As String)
            m_mccfch = value
        End Set
    End Property
    Public Property MCCVTO() As String
        Get
            Return m_mccvto
        End Get
        Set(ByVal value As String)
            m_mccvto = value
        End Set
    End Property
    Public Property DOCCOD() As String
        Get
            Return m_doccod
        End Get
        Set(ByVal value As String)
            m_doccod = value
        End Set
    End Property
    Public Property MCCDOC() As Long
        Get
            Return m_mccdoc
        End Get
        Set(ByVal value As Long)
            m_mccdoc = value
        End Set
    End Property
    Public Property MCCDES() As String
        Get
            Return m_mccdes
        End Get
        Set(ByVal value As String)
            m_mccdes = value
        End Set
    End Property
    Public Property CLICOD() As Long
        Get
            Return m_clicod
        End Get
        Set(ByVal value As Long)
            m_clicod = value
        End Set
    End Property
    Public Property MCCIMP() As Double
        Get
            Return m_mccimp
        End Get
        Set(ByVal value As Double)
            m_mccimp = value
        End Set
    End Property
    Public Property MCCPAG() As Double
        Get
            Return m_mccpag
        End Get
        Set(ByVal value As Double)
            m_mccpag = value
        End Set
    End Property
    Public Property MCCCOD() As Integer
        Get
            Return m_mcccod
        End Get
        Set(ByVal value As Integer)
            m_mcccod = value
        End Set
    End Property
    Public Property MCCTIP() As String
        Get
            Return m_mcctip
        End Get
        Set(ByVal value As String)
            m_mcctip = value
        End Set
    End Property
    Public Property MCCCMP() As Long
        Get
            Return m_mcccmp
        End Get
        Set(ByVal value As Long)
            m_mcccmp = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_mccnro = 0
        m_mccfch = ""
        m_mccvto = ""
        m_doccod = ""
        m_mccdoc = 0
        m_mccdes = ""
        m_clicod = 0
        m_mccimp = 0
        m_mccpag = 0
        m_mcccod = 0
        m_mcctip = ""
        m_mcccmp = 0
    End Sub
    Public Sub New(ByVal mccnro As Long, ByVal mccfch As String, ByVal mccvto As String, ByVal doccod As String, ByVal mccdoc As Long, ByVal mccdes As String, ByVal clicod As Long, ByVal mccimp As Double, ByVal mccpag As Double, ByVal mcccod As Integer, ByVal mcctip As String, ByVal mcccmp As Long)
        m_mccnro = mccnro
        m_mccfch = mccfch
        m_mccvto = mccvto
        m_doccod = doccod
        m_mccdoc = mccdoc
        m_mccdes = mccdes
        m_clicod = clicod
        m_mccimp = mccimp
        m_mccpag = mccpag
        m_mcccod = mcccod
        m_mcctip = mcctip
        m_mcccmp = mcccmp
    End Sub
#End Region

   
    Public Function listarxfecha(ByVal fecd As String) As ArrayList
        Dim p As New pMovCte2
        Return p.listarxfecha(fecd)
    End Function
    Public Function listarentrefechas(ByVal fecd As String, ByVal fech As String) As ArrayList
        Dim p As New pMovCte2
        Return p.listarentrefechas(fecd, fech)
    End Function
    Public Function listarxcliente(ByVal idcli As Integer) As ArrayList
        Dim p As New pMovCte2
        Return p.listarxcliente(idcli)
    End Function
End Class
