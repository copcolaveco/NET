﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace ServiceReference1
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="Workflow", ConfigurationName:="ServiceReference1.WSCargaRecuentosSoapPort")>  _
    Public Interface WSCargaRecuentosSoapPort
        
        'CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de contenedor (WSCargaRecuentos.Execute) del mensaje ExecuteRequest no coincide con el valor predeterminado (Execute)
        <System.ServiceModel.OperationContractAttribute(Action:="Workflowaction/AWSCARGARECUENTOS.Execute", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute()>  _
        Function Execute(ByVal request As ServiceReference1.ExecuteRequest) As ServiceReference1.ExecuteResponse
    End Interface
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1067.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="Workflow")>  _
    Partial Public Class wsCargoRecuentos
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private instalacionIDField As Long
        
        Private codigoAccessoField As String
        
        Private recuentosField() As SDTRecuento_Item
        
        Private modoField As String
        
        '''<comentarios/>
        Public Property InstalacionID() As Long
            Get
                Return Me.instalacionIDField
            End Get
            Set
                Me.instalacionIDField = value
                Me.RaisePropertyChanged("InstalacionID")
            End Set
        End Property
        
        '''<comentarios/>
        Public Property CodigoAccesso() As String
            Get
                Return Me.codigoAccessoField
            End Get
            Set
                Me.codigoAccessoField = value
                Me.RaisePropertyChanged("CodigoAccesso")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)>  _
        Public Property Recuentos() As SDTRecuento_Item()
            Get
                Return Me.recuentosField
            End Get
            Set
                Me.recuentosField = value
                Me.RaisePropertyChanged("Recuentos")
            End Set
        End Property
        
        '''<comentarios/>
        Public Property Modo() As String
            Get
                Return Me.modoField
            End Get
            Set
                Me.modoField = value
                Me.RaisePropertyChanged("Modo")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1067.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="Workflow")>  _
    Partial Public Class SDTRecuento_Item
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private tambCodField As Short
        
        Private recuSemField As SByte
        
        Private recuSemFchField As Date
        
        Private pruCodField As SByte
        
        Private recuentoField As Double
        
        '''<comentarios/>
        Public Property TambCod() As Short
            Get
                Return Me.tambCodField
            End Get
            Set
                Me.tambCodField = value
                Me.RaisePropertyChanged("TambCod")
            End Set
        End Property
        
        '''<comentarios/>
        Public Property RecuSem() As SByte
            Get
                Return Me.recuSemField
            End Get
            Set
                Me.recuSemField = value
                Me.RaisePropertyChanged("RecuSem")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="date")>  _
        Public Property RecuSemFch() As Date
            Get
                Return Me.recuSemFchField
            End Get
            Set
                Me.recuSemFchField = value
                Me.RaisePropertyChanged("RecuSemFch")
            End Set
        End Property
        
        '''<comentarios/>
        Public Property PruCod() As SByte
            Get
                Return Me.pruCodField
            End Get
            Set
                Me.pruCodField = value
                Me.RaisePropertyChanged("PruCod")
            End Set
        End Property
        
        '''<comentarios/>
        Public Property Recuento() As Double
            Get
                Return Me.recuentoField
            End Get
            Set
                Me.recuentoField = value
                Me.RaisePropertyChanged("Recuento")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1067.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="Workflow")>  _
    Partial Public Class SDTRecuentos_Error_Carga_Item
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private tambCodField As Short
        
        Private recuSemField As SByte
        
        Private pruCodField As SByte
        
        Private err_CodigoField As SByte
        
        Private err_DescripcionField As String
        
        '''<comentarios/>
        Public Property TambCod() As Short
            Get
                Return Me.tambCodField
            End Get
            Set
                Me.tambCodField = value
                Me.RaisePropertyChanged("TambCod")
            End Set
        End Property
        
        '''<comentarios/>
        Public Property RecuSem() As SByte
            Get
                Return Me.recuSemField
            End Get
            Set
                Me.recuSemField = value
                Me.RaisePropertyChanged("RecuSem")
            End Set
        End Property
        
        '''<comentarios/>
        Public Property PruCod() As SByte
            Get
                Return Me.pruCodField
            End Get
            Set
                Me.pruCodField = value
                Me.RaisePropertyChanged("PruCod")
            End Set
        End Property
        
        '''<comentarios/>
        Public Property Err_Codigo() As SByte
            Get
                Return Me.err_CodigoField
            End Get
            Set
                Me.err_CodigoField = value
                Me.RaisePropertyChanged("Err_Codigo")
            End Set
        End Property
        
        '''<comentarios/>
        Public Property Err_Descripcion() As String
            Get
                Return Me.err_DescripcionField
            End Get
            Set
                Me.err_DescripcionField = value
                Me.RaisePropertyChanged("Err_Descripcion")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1067.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="Workflow")>  _
    Partial Public Class wsCargoRecuentos_Respuesta
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private instalacionIDField As Long
        
        Private erroresField() As SDTRecuentos_Error_Carga_Item
        
        Private errCodField As SByte
        
        Private errDescField As String
        
        '''<comentarios/>
        Public Property InstalacionID() As Long
            Get
                Return Me.instalacionIDField
            End Get
            Set
                Me.instalacionIDField = value
                Me.RaisePropertyChanged("InstalacionID")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)>  _
        Public Property Errores() As SDTRecuentos_Error_Carga_Item()
            Get
                Return Me.erroresField
            End Get
            Set
                Me.erroresField = value
                Me.RaisePropertyChanged("Errores")
            End Set
        End Property
        
        '''<comentarios/>
        Public Property ErrCod() As SByte
            Get
                Return Me.errCodField
            End Get
            Set
                Me.errCodField = value
                Me.RaisePropertyChanged("ErrCod")
            End Set
        End Property
        
        '''<comentarios/>
        Public Property ErrDesc() As String
            Get
                Return Me.errDescField
            End Get
            Set
                Me.errDescField = value
                Me.RaisePropertyChanged("ErrDesc")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="WSCargaRecuentos.Execute", WrapperNamespace:="Workflow", IsWrapped:=true)>  _
    Partial Public Class ExecuteRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="Workflow", Order:=0)>  _
        Public Cargarrecuentos As ServiceReference1.wsCargoRecuentos
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Cargarrecuentos As ServiceReference1.wsCargoRecuentos)
            MyBase.New
            Me.Cargarrecuentos = Cargarrecuentos
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="WSCargaRecuentos.ExecuteResponse", WrapperNamespace:="Workflow", IsWrapped:=true)>  _
    Partial Public Class ExecuteResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="Workflow", Order:=0)>  _
        Public Cargarrespuesta As ServiceReference1.wsCargoRecuentos_Respuesta
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Cargarrespuesta As ServiceReference1.wsCargoRecuentos_Respuesta)
            MyBase.New
            Me.Cargarrespuesta = Cargarrespuesta
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface WSCargaRecuentosSoapPortChannel
        Inherits ServiceReference1.WSCargaRecuentosSoapPort, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class WSCargaRecuentosSoapPortClient
        Inherits System.ServiceModel.ClientBase(Of ServiceReference1.WSCargaRecuentosSoapPort)
        Implements ServiceReference1.WSCargaRecuentosSoapPort
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function ServiceReference1_WSCargaRecuentosSoapPort_Execute(ByVal request As ServiceReference1.ExecuteRequest) As ServiceReference1.ExecuteResponse Implements ServiceReference1.WSCargaRecuentosSoapPort.Execute
            Return MyBase.Channel.Execute(request)
        End Function
        
        Public Function Execute(ByVal Cargarrecuentos As ServiceReference1.wsCargoRecuentos) As ServiceReference1.wsCargoRecuentos_Respuesta
            Dim inValue As ServiceReference1.ExecuteRequest = New ServiceReference1.ExecuteRequest()
            inValue.Cargarrecuentos = Cargarrecuentos
            Dim retVal As ServiceReference1.ExecuteResponse = CType(Me,ServiceReference1.WSCargaRecuentosSoapPort).Execute(inValue)
            Return retVal.Cargarrespuesta
        End Function
    End Class
End Namespace
