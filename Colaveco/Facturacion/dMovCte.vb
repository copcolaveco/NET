Public Class dMovCte
#Region "Atributos"
    Private m_mccvto As String ' vencimiento si es factura
    Private m_clicod As Long ' código del cliente
    Private m_mccimp As Double ' importe del comprobante
    Private m_mccpag As Double ' pago
    Private m_mcccod As Integer ' código del comprobante (1 - Factura / 2 - Recibo)
    Private m_mcccmp As Long ' número del comprobante
#End Region

#Region "Getters y Setters"
    Public Property MCCVTO() As String
        Get
            Return m_mccvto
        End Get
        Set(ByVal value As String)
            m_mccvto = value
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
        m_mccvto = ""
        m_clicod = 0
        m_mccimp = 0
        m_mccpag = 0
        m_mcccod = 0
        m_mcccmp = 0
    End Sub
    Public Sub New(ByVal mccvto As String, ByVal clicod As Long, ByVal mccimp As Double, ByVal mccpag As Double, ByVal mcccod As Integer, ByVal mcccmp As Long)
        m_mccvto = mccvto
        m_clicod = clicod
        m_mccimp = mccimp
        m_mccpag = mccpag
        m_mcccod = mcccod
        m_mcccmp = mcccmp
    End Sub
#End Region

    Public Function listarxcli(ByVal idcli As Long) As ArrayList
        Dim p As New pMovCte
        Return p.listarxcli(idcli)
    End Function
    Public Function saldosxcli(ByVal idcli As Long) As ArrayList
        Dim p As New pMovCte
        Return p.saldosxcli(idcli)
    End Function
    Public Function buscarxcomprobante() As dMovCte
        Dim p As New pMovCte
        Return p.buscarxcomprobante(Me)
    End Function
End Class
