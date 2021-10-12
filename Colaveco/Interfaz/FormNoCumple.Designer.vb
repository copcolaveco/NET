<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNoCumple
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
        Me.TextIdLineaCompra = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.CheckPuntualidad = New System.Windows.Forms.CheckBox
        Me.CheckCalidad = New System.Windows.Forms.CheckBox
        Me.CheckCantidad = New System.Windows.Forms.CheckBox
        Me.CheckPrecio = New System.Windows.Forms.CheckBox
        Me.CheckFactura = New System.Windows.Forms.CheckBox
        Me.TextDescripcion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(104, 14)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(62, 20)
        Me.TextId.TabIndex = 0
        '
        'TextIdLineaCompra
        '
        Me.TextIdLineaCompra.Location = New System.Drawing.Point(104, 40)
        Me.TextIdLineaCompra.Name = "TextIdLineaCompra"
        Me.TextIdLineaCompra.ReadOnly = True
        Me.TextIdLineaCompra.Size = New System.Drawing.Size(62, 20)
        Me.TextIdLineaCompra.TabIndex = 1
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(104, 66)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 2
        '
        'CheckPuntualidad
        '
        Me.CheckPuntualidad.AutoSize = True
        Me.CheckPuntualidad.Location = New System.Drawing.Point(104, 92)
        Me.CheckPuntualidad.Name = "CheckPuntualidad"
        Me.CheckPuntualidad.Size = New System.Drawing.Size(82, 17)
        Me.CheckPuntualidad.TabIndex = 3
        Me.CheckPuntualidad.Text = "Puntualidad"
        Me.CheckPuntualidad.UseVisualStyleBackColor = True
        '
        'CheckCalidad
        '
        Me.CheckCalidad.AutoSize = True
        Me.CheckCalidad.Location = New System.Drawing.Point(104, 115)
        Me.CheckCalidad.Name = "CheckCalidad"
        Me.CheckCalidad.Size = New System.Drawing.Size(61, 17)
        Me.CheckCalidad.TabIndex = 4
        Me.CheckCalidad.Text = "Calidad"
        Me.CheckCalidad.UseVisualStyleBackColor = True
        '
        'CheckCantidad
        '
        Me.CheckCantidad.AutoSize = True
        Me.CheckCantidad.Location = New System.Drawing.Point(104, 138)
        Me.CheckCantidad.Name = "CheckCantidad"
        Me.CheckCantidad.Size = New System.Drawing.Size(68, 17)
        Me.CheckCantidad.TabIndex = 5
        Me.CheckCantidad.Text = "Cantidad"
        Me.CheckCantidad.UseVisualStyleBackColor = True
        '
        'CheckPrecio
        '
        Me.CheckPrecio.AutoSize = True
        Me.CheckPrecio.Location = New System.Drawing.Point(104, 161)
        Me.CheckPrecio.Name = "CheckPrecio"
        Me.CheckPrecio.Size = New System.Drawing.Size(56, 17)
        Me.CheckPrecio.TabIndex = 6
        Me.CheckPrecio.Text = "Precio"
        Me.CheckPrecio.UseVisualStyleBackColor = True
        '
        'CheckFactura
        '
        Me.CheckFactura.AutoSize = True
        Me.CheckFactura.Location = New System.Drawing.Point(104, 184)
        Me.CheckFactura.Name = "CheckFactura"
        Me.CheckFactura.Size = New System.Drawing.Size(62, 17)
        Me.CheckFactura.TabIndex = 7
        Me.CheckFactura.Text = "Factura"
        Me.CheckFactura.UseVisualStyleBackColor = True
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(104, 207)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(223, 86)
        Me.TextDescripcion.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Id línea compra"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 207)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Descripción"
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(104, 299)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(94, 24)
        Me.ButtonGuardar.TabIndex = 13
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'FormNoCumple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 341)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextDescripcion)
        Me.Controls.Add(Me.CheckFactura)
        Me.Controls.Add(Me.CheckPrecio)
        Me.Controls.Add(Me.CheckCantidad)
        Me.Controls.Add(Me.CheckCalidad)
        Me.Controls.Add(Me.CheckPuntualidad)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextIdLineaCompra)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormNoCumple"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Incumplimiento de compras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextIdLineaCompra As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckPuntualidad As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCalidad As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCantidad As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPrecio As System.Windows.Forms.CheckBox
    Friend WithEvents CheckFactura As System.Windows.Forms.CheckBox
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
End Class
