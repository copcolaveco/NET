﻿Public Class dPedidosWeb
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_codigo As Long
    Private m_nombre As String
    Private m_direccion As String
    Private m_agencia As Integer
    Private m_telefono As String
    Private m_email As String
    Private m_cconservante As Integer
    Private m_sconservante As Integer
    Private m_agua As Integer
    Private m_sangre As Integer
    Private m_observaciones As String
    Private m_realizado As Integer
    Private m_cancelado As Integer

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
    Public Property CODIGO() As Long
        Get
            Return m_codigo
        End Get
        Set(ByVal value As Long)
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
    Public Property DIRECCION() As String
        Get
            Return m_direccion
        End Get
        Set(ByVal value As String)
            m_direccion = value
        End Set
    End Property
    Public Property AGENCIA() As Integer
        Get
            Return m_agencia
        End Get
        Set(ByVal value As Integer)
            m_agencia = value
        End Set
    End Property
    Public Property TELEFONO() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal value As String)
            m_telefono = value
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
    Public Property CCONSERVANTE() As Integer
        Get
            Return m_cconservante
        End Get
        Set(ByVal value As Integer)
            m_cconservante = value
        End Set
    End Property
    Public Property SCONSERVANTE() As Integer
        Get
            Return m_sconservante
        End Get
        Set(ByVal value As Integer)
            m_sconservante = value
        End Set
    End Property
    Public Property AGUA() As Integer
        Get
            Return m_agua
        End Get
        Set(ByVal value As Integer)
            m_agua = value
        End Set
    End Property
    Public Property SANGRE() As Integer
        Get
            Return m_sangre
        End Get
        Set(ByVal value As Integer)
            m_sangre = value
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
    Public Property REALIZADO() As Integer
        Get
            Return m_realizado
        End Get
        Set(ByVal value As Integer)
            m_realizado = value
        End Set
    End Property
    Public Property CANCELADO() As Integer
        Get
            Return m_cancelado
        End Get
        Set(ByVal value As Integer)
            m_cancelado = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_codigo = 0
        m_nombre = ""
        m_direccion = ""
        m_agencia = 0
        m_telefono = ""
        m_email = ""
        m_cconservante = 0
        m_sconservante = 0
        m_agua = 0
        m_sangre = 0
        m_observaciones = 0
        m_realizado = 0
        m_cancelado = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal codigo As Long, ByVal nombre As String, ByVal direccion As String, ByVal agencia As Integer, ByVal telefono As String, ByVal email As String, ByVal cconservante As Integer, ByVal sconservante As Integer, ByVal agua As Integer, ByVal sangre As Integer, ByVal observaciones As String, ByVal realizado As Integer, ByVal cancelado As Integer)
        m_id = id
        m_fecha = fecha
        m_codigo = codigo
        m_nombre = nombre
        m_direccion = direccion
        m_agencia = agencia
        m_telefono = telefono
        m_email = email
        m_cconservante = cconservante
        m_sconservante = sconservante
        m_agua = agua
        m_sangre = sangre
        m_observaciones = observaciones
        m_realizado = realizado
        m_cancelado = cancelado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim c As New pPedidosWeb
        Return c.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim c As New pPedidosWeb
        Return c.modificar(Me)
    End Function
    Public Function marcarrealizado() As Boolean
        Dim c As New pPedidosWeb
        Return c.marcarrealizado(Me)
    End Function
    Public Function marcarcancelado() As Boolean
        Dim c As New pPedidosWeb
        Return c.marcarcancelado(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pPedidosWeb
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dPedidosWeb
        Dim c As New pPedidosWeb
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim c As New pPedidosWeb
        Return c.listar
    End Function
End Class
