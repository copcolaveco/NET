<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTrazCajas
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
        Me.TextFrascos = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextGradillas = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextArmazones = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextProductor = New System.Windows.Forms.TextBox
        Me.TextCaja = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextIdProductor = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboAgencia = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextEnvio = New System.Windows.Forms.TextBox
        Me.TextId = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ListCajas = New System.Windows.Forms.ListBox
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.ListPedidos = New System.Windows.Forms.ListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextDireccion = New System.Windows.Forms.TextBox
        Me.TextTelefono = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DateFechaPosEnvio = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.TextOtros = New System.Windows.Forms.TextBox
        Me.TextEsteriles = New System.Windows.Forms.TextBox
        Me.TextSangre = New System.Windows.Forms.TextBox
        Me.TextAgua = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TextRC_compos = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label21 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextFrascos
        '
        Me.TextFrascos.Location = New System.Drawing.Point(822, 76)
        Me.TextFrascos.Name = "TextFrascos"
        Me.TextFrascos.Size = New System.Drawing.Size(52, 20)
        Me.TextFrascos.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(819, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Frascos"
        '
        'TextGradillas
        '
        Me.TextGradillas.Location = New System.Drawing.Point(764, 76)
        Me.TextGradillas.Name = "TextGradillas"
        Me.TextGradillas.Size = New System.Drawing.Size(52, 20)
        Me.TextGradillas.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(761, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Gradillas"
        '
        'TextArmazones
        '
        Me.TextArmazones.Location = New System.Drawing.Point(705, 76)
        Me.TextArmazones.Name = "TextArmazones"
        Me.TextArmazones.Size = New System.Drawing.Size(53, 20)
        Me.TextArmazones.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(702, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Armazones"
        '
        'TextProductor
        '
        Me.TextProductor.Enabled = False
        Me.TextProductor.Location = New System.Drawing.Point(385, 76)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(212, 20)
        Me.TextProductor.TabIndex = 23
        '
        'TextCaja
        '
        Me.TextCaja.Location = New System.Drawing.Point(639, 76)
        Me.TextCaja.Name = "TextCaja"
        Me.TextCaja.Size = New System.Drawing.Size(62, 20)
        Me.TextCaja.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(257, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Productor"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(636, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Nº Caja"
        '
        'DateFecha
        '
        Me.DateFecha.Enabled = False
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(326, 49)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(257, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Fecha"
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Enabled = False
        Me.TextIdProductor.Location = New System.Drawing.Point(326, 76)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(53, 20)
        Me.TextIdProductor.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(636, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Agencia"
        '
        'ComboAgencia
        '
        Me.ComboAgencia.FormattingEnabled = True
        Me.ComboAgencia.Location = New System.Drawing.Point(688, 24)
        Me.ComboAgencia.Name = "ComboAgencia"
        Me.ComboAgencia.Size = New System.Drawing.Size(163, 21)
        Me.ComboAgencia.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(877, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Envío Nº"
        '
        'TextEnvio
        '
        Me.TextEnvio.Location = New System.Drawing.Point(880, 76)
        Me.TextEnvio.Name = "TextEnvio"
        Me.TextEnvio.Size = New System.Drawing.Size(112, 20)
        Me.TextEnvio.TabIndex = 10
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(327, 20)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(75, 20)
        Me.TextId.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(257, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Id"
        '
        'ListCajas
        '
        Me.ListCajas.FormattingEnabled = True
        Me.ListCajas.Location = New System.Drawing.Point(639, 128)
        Me.ListCajas.Name = "ListCajas"
        Me.ListCajas.Size = New System.Drawing.Size(353, 212)
        Me.ListCajas.TabIndex = 41
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Location = New System.Drawing.Point(936, 101)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(56, 20)
        Me.ButtonBorrar.TabIndex = 42
        Me.ButtonBorrar.Text = "Borrar"
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ListPedidos
        '
        Me.ListPedidos.FormattingEnabled = True
        Me.ListPedidos.Location = New System.Drawing.Point(12, 27)
        Me.ListPedidos.Name = "ListPedidos"
        Me.ListPedidos.Size = New System.Drawing.Size(229, 459)
        Me.ListPedidos.TabIndex = 43
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Pedidos"
        '
        'TextDireccion
        '
        Me.TextDireccion.Enabled = False
        Me.TextDireccion.Location = New System.Drawing.Point(326, 102)
        Me.TextDireccion.Name = "TextDireccion"
        Me.TextDireccion.Size = New System.Drawing.Size(271, 20)
        Me.TextDireccion.TabIndex = 45
        '
        'TextTelefono
        '
        Me.TextTelefono.Enabled = False
        Me.TextTelefono.Location = New System.Drawing.Point(326, 128)
        Me.TextTelefono.Name = "TextTelefono"
        Me.TextTelefono.Size = New System.Drawing.Size(271, 20)
        Me.TextTelefono.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(257, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Dirección"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(257, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Teléfono"
        '
        'DateFechaPosEnvio
        '
        Me.DateFechaPosEnvio.Enabled = False
        Me.DateFechaPosEnvio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaPosEnvio.Location = New System.Drawing.Point(443, 49)
        Me.DateFechaPosEnvio.Name = "DateFechaPosEnvio"
        Me.DateFechaPosEnvio.Size = New System.Drawing.Size(100, 20)
        Me.DateFechaPosEnvio.TabIndex = 49
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(440, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 13)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "Fecha posible envío"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextObservaciones)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.TextOtros)
        Me.GroupBox1.Controls.Add(Me.TextEsteriles)
        Me.GroupBox1.Controls.Add(Me.TextSangre)
        Me.GroupBox1.Controls.Add(Me.TextAgua)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.TextRC_compos)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Location = New System.Drawing.Point(260, 164)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 291)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Frascos"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Enabled = False
        Me.TextObservaciones.Location = New System.Drawing.Point(9, 172)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(200, 108)
        Me.TextObservaciones.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 156)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Observaciones"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 130)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 13)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Otros"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Estériles"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 78)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 13)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "Sangre"
        '
        'TextOtros
        '
        Me.TextOtros.Enabled = False
        Me.TextOtros.Location = New System.Drawing.Point(78, 123)
        Me.TextOtros.Name = "TextOtros"
        Me.TextOtros.Size = New System.Drawing.Size(78, 20)
        Me.TextOtros.TabIndex = 10
        '
        'TextEsteriles
        '
        Me.TextEsteriles.Enabled = False
        Me.TextEsteriles.Location = New System.Drawing.Point(78, 97)
        Me.TextEsteriles.Name = "TextEsteriles"
        Me.TextEsteriles.Size = New System.Drawing.Size(78, 20)
        Me.TextEsteriles.TabIndex = 9
        '
        'TextSangre
        '
        Me.TextSangre.Enabled = False
        Me.TextSangre.Location = New System.Drawing.Point(78, 71)
        Me.TextSangre.Name = "TextSangre"
        Me.TextSangre.Size = New System.Drawing.Size(78, 20)
        Me.TextSangre.TabIndex = 8
        '
        'TextAgua
        '
        Me.TextAgua.Enabled = False
        Me.TextAgua.Location = New System.Drawing.Point(78, 45)
        Me.TextAgua.Name = "TextAgua"
        Me.TextAgua.Size = New System.Drawing.Size(78, 20)
        Me.TextAgua.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 52)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Agua"
        '
        'TextRC_compos
        '
        Me.TextRC_compos.Enabled = False
        Me.TextRC_compos.Location = New System.Drawing.Point(78, 19)
        Me.TextRC_compos.Name = "TextRC_compos"
        Me.TextRC_compos.Size = New System.Drawing.Size(78, 20)
        Me.TextRC_compos.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(66, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "RC Compos."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(636, 112)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 13)
        Me.Label20.TabIndex = 52
        Me.Label20.Text = "Listado de cajas"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(725, 427)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(100, 20)
        Me.DateTimePicker1.TabIndex = 53
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(636, 431)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 13)
        Me.Label21.TabIndex = 54
        Me.Label21.Text = "Fecha de envío"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(833, 424)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 23)
        Me.Button1.TabIndex = 55
        Me.Button1.Text = "Enviada / Mail"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(639, 463)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(95, 17)
        Me.CheckBox1.TabIndex = 56
        Me.CheckBox1.Text = "Enviado / Mail"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(641, 352)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 13)
        Me.Label22.TabIndex = 57
        Me.Label22.Text = "Observaciones"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(725, 352)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(267, 66)
        Me.TextBox1.TabIndex = 58
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1007, 496)
        Me.ShapeContainer1.TabIndex = 59
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 613
        Me.LineShape1.X2 = 612
        Me.LineShape1.Y1 = 15
        Me.LineShape1.Y2 = 481
        '
        'FormTrazCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 496)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.DateFechaPosEnvio)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextTelefono)
        Me.Controls.Add(Me.TextDireccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ListPedidos)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.ListCajas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.TextEnvio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboAgencia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFrascos)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextGradillas)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextArmazones)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.TextCaja)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "FormTrazCajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envíos de cajas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextFrascos As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextGradillas As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextArmazones As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents TextCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextEnvio As System.Windows.Forms.TextBox
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListCajas As System.Windows.Forms.ListBox
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ListPedidos As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TextTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateFechaPosEnvio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextOtros As System.Windows.Forms.TextBox
    Friend WithEvents TextEsteriles As System.Windows.Forms.TextBox
    Friend WithEvents TextSangre As System.Windows.Forms.TextBox
    Friend WithEvents TextAgua As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextRC_compos As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape

End Class
