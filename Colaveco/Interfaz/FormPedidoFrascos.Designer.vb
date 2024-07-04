<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPedidoFrascos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPedidoFrascos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.TextIdProductor = New System.Windows.Forms.TextBox()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextProductor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextDireccion = New System.Windows.Forms.TextBox()
        Me.DateFechaposEnvio = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextTelefono = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboAgencia = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckCodBarras = New System.Windows.Forms.CheckBox()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextOtros = New System.Windows.Forms.TextBox()
        Me.TextEsteriles = New System.Windows.Forms.TextBox()
        Me.TextSangre = New System.Windows.Forms.TextBox()
        Me.TextAgua = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextRC_compos = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboTecnico = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextCantidad3 = New System.Windows.Forms.TextBox()
        Me.TextCantidad2 = New System.Windows.Forms.TextBox()
        Me.TextCantidad1 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextF3 = New System.Windows.Forms.TextBox()
        Me.TextF2 = New System.Windows.Forms.TextBox()
        Me.TextF1 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextFactura3 = New System.Windows.Forms.TextBox()
        Me.TextFactura2 = New System.Windows.Forms.TextBox()
        Me.TextFactura1 = New System.Windows.Forms.TextBox()
        Me.ListPedidos = New System.Windows.Forms.ListBox()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextResponsable = New System.Windows.Forms.TextBox()
        Me.TextEmail = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextTotalRC = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CheckProlesa = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.chbFletePAgo = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha"
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(140, 11)
        Me.TextId.Margin = New System.Windows.Forms.Padding(4)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(80, 22)
        Me.TextId.TabIndex = 0
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Enabled = False
        Me.TextIdProductor.Location = New System.Drawing.Point(140, 75)
        Me.TextIdProductor.Margin = New System.Windows.Forms.Padding(4)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(61, 22)
        Me.TextIdProductor.TabIndex = 3
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(140, 43)
        Me.DateFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(137, 22)
        Me.DateFecha.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 79)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Productor"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(211, 75)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 25)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = "^"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextProductor
        '
        Me.TextProductor.Enabled = False
        Me.TextProductor.Location = New System.Drawing.Point(248, 75)
        Me.TextProductor.Margin = New System.Windows.Forms.Padding(4)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(303, 22)
        Me.TextProductor.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 144)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Dirección envío"
        '
        'TextDireccion
        '
        Me.TextDireccion.Location = New System.Drawing.Point(140, 140)
        Me.TextDireccion.Margin = New System.Windows.Forms.Padding(4)
        Me.TextDireccion.Name = "TextDireccion"
        Me.TextDireccion.Size = New System.Drawing.Size(411, 22)
        Me.TextDireccion.TabIndex = 4
        '
        'DateFechaposEnvio
        '
        Me.DateFechaposEnvio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaposEnvio.Location = New System.Drawing.Point(341, 43)
        Me.DateFechaposEnvio.Margin = New System.Windows.Forms.Padding(4)
        Me.DateFechaposEnvio.Name = "DateFechaposEnvio"
        Me.DateFechaposEnvio.Size = New System.Drawing.Size(137, 22)
        Me.DateFechaposEnvio.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(337, 20)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Fecha posible de envío"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(16, 176)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Teléfono"
        '
        'TextTelefono
        '
        Me.TextTelefono.Location = New System.Drawing.Point(140, 172)
        Me.TextTelefono.Margin = New System.Windows.Forms.Padding(4)
        Me.TextTelefono.Name = "TextTelefono"
        Me.TextTelefono.Size = New System.Drawing.Size(273, 22)
        Me.TextTelefono.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 240)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Agencia"
        '
        'ComboAgencia
        '
        Me.ComboAgencia.FormattingEnabled = True
        Me.ComboAgencia.Location = New System.Drawing.Point(141, 236)
        Me.ComboAgencia.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboAgencia.Name = "ComboAgencia"
        Me.ComboAgencia.Size = New System.Drawing.Size(221, 24)
        Me.ComboAgencia.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chbFletePAgo)
        Me.GroupBox1.Controls.Add(Me.CheckCodBarras)
        Me.GroupBox1.Controls.Add(Me.TextObservaciones)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextOtros)
        Me.GroupBox1.Controls.Add(Me.TextEsteriles)
        Me.GroupBox1.Controls.Add(Me.TextSangre)
        Me.GroupBox1.Controls.Add(Me.TextAgua)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TextRC_compos)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 335)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(535, 233)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Frascos"
        '
        'CheckCodBarras
        '
        Me.CheckCodBarras.AutoSize = True
        Me.CheckCodBarras.ForeColor = System.Drawing.Color.Black
        Me.CheckCodBarras.Location = New System.Drawing.Point(13, 27)
        Me.CheckCodBarras.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckCodBarras.Name = "CheckCodBarras"
        Me.CheckCodBarras.Size = New System.Drawing.Size(166, 21)
        Me.CheckCodBarras.TabIndex = 16
        Me.CheckCodBarras.Text = "Con códigos de barra"
        Me.CheckCodBarras.UseVisualStyleBackColor = True
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(236, 75)
        Me.TextObservaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(265, 132)
        Me.TextObservaciones.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(232, 55)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 17)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Observaciones"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(8, 192)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 17)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Otros"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(8, 160)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 17)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Estériles"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(8, 128)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 17)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Sangre"
        '
        'TextOtros
        '
        Me.TextOtros.Location = New System.Drawing.Point(104, 183)
        Me.TextOtros.Margin = New System.Windows.Forms.Padding(4)
        Me.TextOtros.Name = "TextOtros"
        Me.TextOtros.Size = New System.Drawing.Size(103, 22)
        Me.TextOtros.TabIndex = 14
        '
        'TextEsteriles
        '
        Me.TextEsteriles.Location = New System.Drawing.Point(104, 151)
        Me.TextEsteriles.Margin = New System.Windows.Forms.Padding(4)
        Me.TextEsteriles.Name = "TextEsteriles"
        Me.TextEsteriles.Size = New System.Drawing.Size(103, 22)
        Me.TextEsteriles.TabIndex = 13
        '
        'TextSangre
        '
        Me.TextSangre.Location = New System.Drawing.Point(104, 119)
        Me.TextSangre.Margin = New System.Windows.Forms.Padding(4)
        Me.TextSangre.Name = "TextSangre"
        Me.TextSangre.Size = New System.Drawing.Size(103, 22)
        Me.TextSangre.TabIndex = 12
        '
        'TextAgua
        '
        Me.TextAgua.Location = New System.Drawing.Point(104, 87)
        Me.TextAgua.Margin = New System.Windows.Forms.Padding(4)
        Me.TextAgua.Name = "TextAgua"
        Me.TextAgua.Size = New System.Drawing.Size(103, 22)
        Me.TextAgua.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 96)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 17)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Agua"
        '
        'TextRC_compos
        '
        Me.TextRC_compos.Location = New System.Drawing.Point(104, 55)
        Me.TextRC_compos.Margin = New System.Windows.Forms.Padding(4)
        Me.TextRC_compos.Name = "TextRC_compos"
        Me.TextRC_compos.Size = New System.Drawing.Size(103, 22)
        Me.TextRC_compos.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(8, 63)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "RC Compos."
        '
        'ComboTecnico
        '
        Me.ComboTecnico.FormattingEnabled = True
        Me.ComboTecnico.Location = New System.Drawing.Point(140, 270)
        Me.ComboTecnico.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboTecnico.Name = "ComboTecnico"
        Me.ComboTecnico.Size = New System.Drawing.Size(221, 24)
        Me.ComboTecnico.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(16, 273)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 17)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Técnico"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextCantidad3)
        Me.GroupBox2.Controls.Add(Me.TextCantidad2)
        Me.GroupBox2.Controls.Add(Me.TextCantidad1)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TextF3)
        Me.GroupBox2.Controls.Add(Me.TextF2)
        Me.GroupBox2.Controls.Add(Me.TextF1)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.TextFactura3)
        Me.GroupBox2.Controls.Add(Me.TextFactura2)
        Me.GroupBox2.Controls.Add(Me.TextFactura1)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 575)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(535, 134)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Facturar a:"
        '
        'TextCantidad3
        '
        Me.TextCantidad3.Location = New System.Drawing.Point(397, 87)
        Me.TextCantidad3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextCantidad3.Name = "TextCantidad3"
        Me.TextCantidad3.Size = New System.Drawing.Size(104, 22)
        Me.TextCantidad3.TabIndex = 21
        '
        'TextCantidad2
        '
        Me.TextCantidad2.Location = New System.Drawing.Point(397, 55)
        Me.TextCantidad2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextCantidad2.Name = "TextCantidad2"
        Me.TextCantidad2.Size = New System.Drawing.Size(104, 22)
        Me.TextCantidad2.TabIndex = 19
        '
        'TextCantidad1
        '
        Me.TextCantidad1.Location = New System.Drawing.Point(397, 23)
        Me.TextCantidad1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextCantidad1.Name = "TextCantidad1"
        Me.TextCantidad1.Size = New System.Drawing.Size(104, 22)
        Me.TextCantidad1.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(413, 0)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 17)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "Cantidad"
        '
        'TextF3
        '
        Me.TextF3.Enabled = False
        Me.TextF3.Location = New System.Drawing.Point(121, 87)
        Me.TextF3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextF3.Name = "TextF3"
        Me.TextF3.Size = New System.Drawing.Size(265, 22)
        Me.TextF3.TabIndex = 26
        '
        'TextF2
        '
        Me.TextF2.Enabled = False
        Me.TextF2.Location = New System.Drawing.Point(121, 55)
        Me.TextF2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextF2.Name = "TextF2"
        Me.TextF2.Size = New System.Drawing.Size(265, 22)
        Me.TextF2.TabIndex = 25
        '
        'TextF1
        '
        Me.TextF1.Enabled = False
        Me.TextF1.Location = New System.Drawing.Point(121, 23)
        Me.TextF1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextF1.Name = "TextF1"
        Me.TextF1.Size = New System.Drawing.Size(265, 22)
        Me.TextF1.TabIndex = 24
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(84, 55)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(29, 25)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "^"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(84, 87)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 25)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "^"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(84, 23)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 25)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "^"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextFactura3
        '
        Me.TextFactura3.Location = New System.Drawing.Point(13, 89)
        Me.TextFactura3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextFactura3.Name = "TextFactura3"
        Me.TextFactura3.Size = New System.Drawing.Size(61, 22)
        Me.TextFactura3.TabIndex = 20
        '
        'TextFactura2
        '
        Me.TextFactura2.Location = New System.Drawing.Point(13, 57)
        Me.TextFactura2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextFactura2.Name = "TextFactura2"
        Me.TextFactura2.Size = New System.Drawing.Size(61, 22)
        Me.TextFactura2.TabIndex = 18
        '
        'TextFactura1
        '
        Me.TextFactura1.Location = New System.Drawing.Point(13, 25)
        Me.TextFactura1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextFactura1.Name = "TextFactura1"
        Me.TextFactura1.Size = New System.Drawing.Size(61, 22)
        Me.TextFactura1.TabIndex = 16
        '
        'ListPedidos
        '
        Me.ListPedidos.BackColor = System.Drawing.SystemColors.Info
        Me.ListPedidos.FormattingEnabled = True
        Me.ListPedidos.ItemHeight = 16
        Me.ListPedidos.Location = New System.Drawing.Point(576, 123)
        Me.ListPedidos.Margin = New System.Windows.Forms.Padding(4)
        Me.ListPedidos.Name = "ListPedidos"
        Me.ListPedidos.Size = New System.Drawing.Size(368, 564)
        Me.ListPedidos.TabIndex = 24
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.ForeColor = System.Drawing.Color.Black
        Me.ButtonNuevo.Location = New System.Drawing.Point(31, 720)
        Me.ButtonNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(100, 28)
        Me.ButtonNuevo.TabIndex = 23
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.ForeColor = System.Drawing.Color.Black
        Me.ButtonGuardar.Location = New System.Drawing.Point(139, 720)
        Me.ButtonGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonGuardar.TabIndex = 22
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.ForeColor = System.Drawing.Color.Black
        Me.ButtonEliminar.Location = New System.Drawing.Point(247, 720)
        Me.ButtonEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonEliminar.TabIndex = 23
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(16, 306)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 17)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Responsable"
        '
        'TextResponsable
        '
        Me.TextResponsable.Location = New System.Drawing.Point(140, 303)
        Me.TextResponsable.Margin = New System.Windows.Forms.Padding(4)
        Me.TextResponsable.Name = "TextResponsable"
        Me.TextResponsable.Size = New System.Drawing.Size(273, 22)
        Me.TextResponsable.TabIndex = 9
        '
        'TextEmail
        '
        Me.TextEmail.Location = New System.Drawing.Point(140, 204)
        Me.TextEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.TextEmail.Name = "TextEmail"
        Me.TextEmail.Size = New System.Drawing.Size(411, 22)
        Me.TextEmail.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(16, 208)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 17)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "E-mail"
        '
        'TextTotalRC
        '
        Me.TextTotalRC.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalRC.ForeColor = System.Drawing.Color.Red
        Me.TextTotalRC.Location = New System.Drawing.Point(576, 30)
        Me.TextTotalRC.Margin = New System.Windows.Forms.Padding(4)
        Me.TextTotalRC.Name = "TextTotalRC"
        Me.TextTotalRC.ReadOnly = True
        Me.TextTotalRC.Size = New System.Drawing.Size(229, 41)
        Me.TextTotalRC.TabIndex = 53
        Me.TextTotalRC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(572, 11)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(234, 17)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Frascos RC pedidos para esa fecha"
        '
        'CheckProlesa
        '
        Me.CheckProlesa.AutoSize = True
        Me.CheckProlesa.ForeColor = System.Drawing.Color.Black
        Me.CheckProlesa.Location = New System.Drawing.Point(141, 112)
        Me.CheckProlesa.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckProlesa.Name = "CheckProlesa"
        Me.CheckProlesa.Size = New System.Drawing.Size(104, 21)
        Me.CheckProlesa.TabIndex = 55
        Me.CheckProlesa.Text = "Por Prolesa"
        Me.CheckProlesa.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(573, 84)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(97, 17)
        Me.Label18.TabIndex = 57
        Me.Label18.Text = "Buscar cliente"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(678, 79)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(29, 25)
        Me.Button5.TabIndex = 58
        Me.Button5.Text = "^"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'chbFletePAgo
        '
        Me.chbFletePAgo.AutoSize = True
        Me.chbFletePAgo.ForeColor = System.Drawing.Color.Black
        Me.chbFletePAgo.Location = New System.Drawing.Point(192, 30)
        Me.chbFletePAgo.Margin = New System.Windows.Forms.Padding(4)
        Me.chbFletePAgo.Name = "chbFletePAgo"
        Me.chbFletePAgo.Size = New System.Drawing.Size(97, 21)
        Me.chbFletePAgo.TabIndex = 59
        Me.chbFletePAgo.Text = "Flete pago"
        Me.chbFletePAgo.UseVisualStyleBackColor = True
        '
        'FormPedidoFrascos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 761)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.CheckProlesa)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TextTotalRC)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TextEmail)
        Me.Controls.Add(Me.TextResponsable)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.ListPedidos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ComboTecnico)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ComboAgencia)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextTelefono)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DateFechaposEnvio)
        Me.Controls.Add(Me.TextDireccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.Red
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormPedidoFrascos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos de frascos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextDireccion As System.Windows.Forms.TextBox
    Friend WithEvents DateFechaposEnvio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextOtros As System.Windows.Forms.TextBox
    Friend WithEvents TextEsteriles As System.Windows.Forms.TextBox
    Friend WithEvents TextSangre As System.Windows.Forms.TextBox
    Friend WithEvents TextAgua As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextRC_compos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ComboTecnico As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextF3 As System.Windows.Forms.TextBox
    Friend WithEvents TextF2 As System.Windows.Forms.TextBox
    Friend WithEvents TextF1 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextFactura3 As System.Windows.Forms.TextBox
    Friend WithEvents TextFactura2 As System.Windows.Forms.TextBox
    Friend WithEvents TextFactura1 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextCantidad3 As System.Windows.Forms.TextBox
    Friend WithEvents TextCantidad2 As System.Windows.Forms.TextBox
    Friend WithEvents TextCantidad1 As System.Windows.Forms.TextBox
    Friend WithEvents ListPedidos As System.Windows.Forms.ListBox
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextResponsable As System.Windows.Forms.TextBox
    Friend WithEvents TextEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CheckCodBarras As System.Windows.Forms.CheckBox
    Friend WithEvents TextTotalRC As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CheckProlesa As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents chbFletePAgo As System.Windows.Forms.CheckBox
End Class
