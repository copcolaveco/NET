<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompletarCompra
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
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.TextLote = New System.Windows.Forms.TextBox()
        Me.DateVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.ComboLocacion = New System.Windows.Forms.ComboBox()
        Me.TextPrecio = New System.Windows.Forms.TextBox()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboMoneda = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateRecibido = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextFactura = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextCodigo = New System.Windows.Forms.TextBox()
        Me.TextProducto = New System.Windows.Forms.TextBox()
        Me.CheckCambiarCantidad = New System.Windows.Forms.CheckBox()
        Me.TextCantidad = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboUnidad = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(15, 69)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(47, 20)
        Me.TextId.TabIndex = 0
        '
        'TextLote
        '
        Me.TextLote.Location = New System.Drawing.Point(181, 131)
        Me.TextLote.Name = "TextLote"
        Me.TextLote.Size = New System.Drawing.Size(154, 20)
        Me.TextLote.TabIndex = 1
        '
        'DateVencimiento
        '
        Me.DateVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateVencimiento.Location = New System.Drawing.Point(341, 131)
        Me.DateVencimiento.Name = "DateVencimiento"
        Me.DateVencimiento.Size = New System.Drawing.Size(100, 20)
        Me.DateVencimiento.TabIndex = 2
        '
        'ComboLocacion
        '
        Me.ComboLocacion.FormattingEnabled = True
        Me.ComboLocacion.Location = New System.Drawing.Point(447, 131)
        Me.ComboLocacion.Name = "ComboLocacion"
        Me.ComboLocacion.Size = New System.Drawing.Size(243, 21)
        Me.ComboLocacion.TabIndex = 3
        '
        'TextPrecio
        '
        Me.TextPrecio.Location = New System.Drawing.Point(696, 131)
        Me.TextPrecio.Name = "TextPrecio"
        Me.TextPrecio.Size = New System.Drawing.Size(80, 20)
        Me.TextPrecio.TabIndex = 4
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(842, 128)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 5
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(244, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Lote"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(356, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Vencimiento"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(533, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Locación"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(716, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Precio"
        '
        'ComboMoneda
        '
        Me.ComboMoneda.FormattingEnabled = True
        Me.ComboMoneda.Location = New System.Drawing.Point(782, 130)
        Me.ComboMoneda.Name = "ComboMoneda"
        Me.ComboMoneda.Size = New System.Drawing.Size(54, 21)
        Me.ComboMoneda.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(790, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Moneda"
        '
        'DateRecibido
        '
        Me.DateRecibido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateRecibido.Location = New System.Drawing.Point(14, 25)
        Me.DateRecibido.Name = "DateRecibido"
        Me.DateRecibido.Size = New System.Drawing.Size(100, 20)
        Me.DateRecibido.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Recibido"
        '
        'TextFactura
        '
        Me.TextFactura.Location = New System.Drawing.Point(121, 25)
        Me.TextFactura.Name = "TextFactura"
        Me.TextFactura.Size = New System.Drawing.Size(143, 20)
        Me.TextFactura.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(118, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Nro. Factura"
        '
        'TextCodigo
        '
        Me.TextCodigo.Location = New System.Drawing.Point(68, 69)
        Me.TextCodigo.Name = "TextCodigo"
        Me.TextCodigo.ReadOnly = True
        Me.TextCodigo.Size = New System.Drawing.Size(116, 20)
        Me.TextCodigo.TabIndex = 17
        '
        'TextProducto
        '
        Me.TextProducto.Location = New System.Drawing.Point(190, 69)
        Me.TextProducto.Name = "TextProducto"
        Me.TextProducto.ReadOnly = True
        Me.TextProducto.Size = New System.Drawing.Size(182, 20)
        Me.TextProducto.TabIndex = 18
        '
        'CheckCambiarCantidad
        '
        Me.CheckCambiarCantidad.AutoSize = True
        Me.CheckCambiarCantidad.Location = New System.Drawing.Point(14, 158)
        Me.CheckCambiarCantidad.Name = "CheckCambiarCantidad"
        Me.CheckCambiarCantidad.Size = New System.Drawing.Size(108, 17)
        Me.CheckCambiarCantidad.TabIndex = 19
        Me.CheckCambiarCantidad.Text = "Cambiar cantidad"
        Me.CheckCambiarCantidad.UseVisualStyleBackColor = True
        '
        'TextCantidad
        '
        Me.TextCantidad.Enabled = False
        Me.TextCantidad.Location = New System.Drawing.Point(15, 132)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.ReadOnly = True
        Me.TextCantidad.Size = New System.Drawing.Size(73, 20)
        Me.TextCantidad.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(31, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Cantidad"
        '
        'ComboUnidad
        '
        Me.ComboUnidad.Enabled = False
        Me.ComboUnidad.FormattingEnabled = True
        Me.ComboUnidad.Location = New System.Drawing.Point(94, 131)
        Me.ComboUnidad.Name = "ComboUnidad"
        Me.ComboUnidad.Size = New System.Drawing.Size(76, 21)
        Me.ComboUnidad.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(107, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Unidad"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(12, 178)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(432, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Al cambiar la cantidad, se genera una compra nueva con el faltante a modo de pend" & _
            "iente."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(74, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Código"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(187, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Producto"
        '
        'FormCompletarCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 233)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ComboUnidad)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextCantidad)
        Me.Controls.Add(Me.CheckCambiarCantidad)
        Me.Controls.Add(Me.TextProducto)
        Me.Controls.Add(Me.TextCodigo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextFactura)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DateRecibido)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboMoneda)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.TextPrecio)
        Me.Controls.Add(Me.ComboLocacion)
        Me.Controls.Add(Me.DateVencimiento)
        Me.Controls.Add(Me.TextLote)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormCompletarCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Completar compra"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextLote As System.Windows.Forms.TextBox
    Friend WithEvents DateVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboLocacion As System.Windows.Forms.ComboBox
    Friend WithEvents TextPrecio As System.Windows.Forms.TextBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateRecibido As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TextProducto As System.Windows.Forms.TextBox
    Friend WithEvents CheckCambiarCantidad As System.Windows.Forms.CheckBox
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ComboUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
