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
        Me.TextId = New System.Windows.Forms.TextBox
        Me.TextLote = New System.Windows.Forms.TextBox
        Me.DateVencimiento = New System.Windows.Forms.DateTimePicker
        Me.ComboLocacion = New System.Windows.Forms.ComboBox
        Me.TextPrecio = New System.Windows.Forms.TextBox
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboMoneda = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(9, 29)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(47, 20)
        Me.TextId.TabIndex = 0
        '
        'TextLote
        '
        Me.TextLote.Location = New System.Drawing.Point(62, 29)
        Me.TextLote.Name = "TextLote"
        Me.TextLote.Size = New System.Drawing.Size(154, 20)
        Me.TextLote.TabIndex = 1
        '
        'DateVencimiento
        '
        Me.DateVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateVencimiento.Location = New System.Drawing.Point(222, 29)
        Me.DateVencimiento.Name = "DateVencimiento"
        Me.DateVencimiento.Size = New System.Drawing.Size(100, 20)
        Me.DateVencimiento.TabIndex = 2
        '
        'ComboLocacion
        '
        Me.ComboLocacion.FormattingEnabled = True
        Me.ComboLocacion.Location = New System.Drawing.Point(328, 29)
        Me.ComboLocacion.Name = "ComboLocacion"
        Me.ComboLocacion.Size = New System.Drawing.Size(243, 21)
        Me.ComboLocacion.TabIndex = 3
        '
        'TextPrecio
        '
        Me.TextPrecio.Location = New System.Drawing.Point(577, 29)
        Me.TextPrecio.Name = "TextPrecio"
        Me.TextPrecio.Size = New System.Drawing.Size(80, 20)
        Me.TextPrecio.TabIndex = 4
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(723, 26)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 5
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(125, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Lote"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(237, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Vencimiento"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(414, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Locación"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(597, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Precio"
        '
        'ComboMoneda
        '
        Me.ComboMoneda.FormattingEnabled = True
        Me.ComboMoneda.Location = New System.Drawing.Point(663, 28)
        Me.ComboMoneda.Name = "ComboMoneda"
        Me.ComboMoneda.Size = New System.Drawing.Size(54, 21)
        Me.ComboMoneda.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(671, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Moneda"
        '
        'FormCompletarCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 67)
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
End Class
