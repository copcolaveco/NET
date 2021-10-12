<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormControlDeMedios
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Apertura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaApertura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Consumido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaConsumido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descartado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaDescartado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateApertura = New System.Windows.Forms.DateTimePicker
        Me.DateConsumido = New System.Windows.Forms.DateTimePicker
        Me.CheckDescartado = New System.Windows.Forms.CheckBox
        Me.DateVencimiento = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.RadioConsumidos = New System.Windows.Forms.RadioButton
        Me.RadioDescartados = New System.Windows.Forms.RadioButton
        Me.ButtonExportar = New System.Windows.Forms.Button
        Me.CheckApertura = New System.Windows.Forms.CheckBox
        Me.CheckConsumido = New System.Windows.Forms.CheckBox
        Me.DateDescartado = New System.Windows.Forms.DateTimePicker
        Me.RadioSinAbrir = New System.Windows.Forms.RadioButton
        Me.RadioEnUso = New System.Windows.Forms.RadioButton
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.TextId = New System.Windows.Forms.TextBox
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.IdProducto, Me.Nombre, Me.Lote, Me.Vencimiento, Me.Apertura, Me.FechaApertura, Me.Consumido, Me.FechaConsumido, Me.Descartado, Me.FechaDescartado})
        Me.DataGridView1.Location = New System.Drawing.Point(238, 45)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(863, 507)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'IdProducto
        '
        Me.IdProducto.HeaderText = "IdProducto"
        Me.IdProducto.Name = "IdProducto"
        Me.IdProducto.Visible = False
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 150
        '
        'Lote
        '
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        '
        'Vencimiento
        '
        Me.Vencimiento.HeaderText = "Vencimiento"
        Me.Vencimiento.Name = "Vencimiento"
        Me.Vencimiento.Width = 80
        '
        'Apertura
        '
        Me.Apertura.HeaderText = "Apertura"
        Me.Apertura.Name = "Apertura"
        Me.Apertura.Width = 70
        '
        'FechaApertura
        '
        Me.FechaApertura.HeaderText = "Fecha"
        Me.FechaApertura.Name = "FechaApertura"
        Me.FechaApertura.Width = 80
        '
        'Consumido
        '
        Me.Consumido.HeaderText = "Consumido"
        Me.Consumido.Name = "Consumido"
        Me.Consumido.Width = 70
        '
        'FechaConsumido
        '
        Me.FechaConsumido.HeaderText = "Fecha"
        Me.FechaConsumido.Name = "FechaConsumido"
        Me.FechaConsumido.Width = 80
        '
        'Descartado
        '
        Me.Descartado.HeaderText = "Descartado"
        Me.Descartado.Name = "Descartado"
        Me.Descartado.Width = 70
        '
        'FechaDescartado
        '
        Me.FechaDescartado.HeaderText = "Fecha"
        Me.FechaDescartado.Name = "FechaDescartado"
        Me.FechaDescartado.Width = 80
        '
        'DateApertura
        '
        Me.DateApertura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateApertura.Location = New System.Drawing.Point(112, 45)
        Me.DateApertura.Name = "DateApertura"
        Me.DateApertura.Size = New System.Drawing.Size(100, 20)
        Me.DateApertura.TabIndex = 1
        '
        'DateConsumido
        '
        Me.DateConsumido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateConsumido.Location = New System.Drawing.Point(112, 71)
        Me.DateConsumido.Name = "DateConsumido"
        Me.DateConsumido.Size = New System.Drawing.Size(100, 20)
        Me.DateConsumido.TabIndex = 2
        '
        'CheckDescartado
        '
        Me.CheckDescartado.AutoSize = True
        Me.CheckDescartado.Location = New System.Drawing.Point(22, 100)
        Me.CheckDescartado.Name = "CheckDescartado"
        Me.CheckDescartado.Size = New System.Drawing.Size(81, 17)
        Me.CheckDescartado.TabIndex = 3
        Me.CheckDescartado.Text = "Descartado"
        Me.CheckDescartado.UseVisualStyleBackColor = True
        '
        'DateVencimiento
        '
        Me.DateVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateVencimiento.Location = New System.Drawing.Point(112, 123)
        Me.DateVencimiento.Name = "DateVencimiento"
        Me.DateVencimiento.Size = New System.Drawing.Size(100, 20)
        Me.DateVencimiento.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Vencimiento"
        '
        'RadioConsumidos
        '
        Me.RadioConsumidos.AutoSize = True
        Me.RadioConsumidos.Location = New System.Drawing.Point(371, 22)
        Me.RadioConsumidos.Name = "RadioConsumidos"
        Me.RadioConsumidos.Size = New System.Drawing.Size(82, 17)
        Me.RadioConsumidos.TabIndex = 9
        Me.RadioConsumidos.TabStop = True
        Me.RadioConsumidos.Text = "Consumidos"
        Me.RadioConsumidos.UseVisualStyleBackColor = True
        '
        'RadioDescartados
        '
        Me.RadioDescartados.AutoSize = True
        Me.RadioDescartados.Location = New System.Drawing.Point(459, 22)
        Me.RadioDescartados.Name = "RadioDescartados"
        Me.RadioDescartados.Size = New System.Drawing.Size(85, 17)
        Me.RadioDescartados.TabIndex = 10
        Me.RadioDescartados.TabStop = True
        Me.RadioDescartados.Text = "Descartados"
        Me.RadioDescartados.UseVisualStyleBackColor = True
        '
        'ButtonExportar
        '
        Me.ButtonExportar.Location = New System.Drawing.Point(1026, 558)
        Me.ButtonExportar.Name = "ButtonExportar"
        Me.ButtonExportar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExportar.TabIndex = 11
        Me.ButtonExportar.Text = "Exportar"
        Me.ButtonExportar.UseVisualStyleBackColor = True
        '
        'CheckApertura
        '
        Me.CheckApertura.AutoSize = True
        Me.CheckApertura.Location = New System.Drawing.Point(22, 50)
        Me.CheckApertura.Name = "CheckApertura"
        Me.CheckApertura.Size = New System.Drawing.Size(66, 17)
        Me.CheckApertura.TabIndex = 12
        Me.CheckApertura.Text = "Apertura"
        Me.CheckApertura.UseVisualStyleBackColor = True
        '
        'CheckConsumido
        '
        Me.CheckConsumido.AutoSize = True
        Me.CheckConsumido.Location = New System.Drawing.Point(22, 74)
        Me.CheckConsumido.Name = "CheckConsumido"
        Me.CheckConsumido.Size = New System.Drawing.Size(78, 17)
        Me.CheckConsumido.TabIndex = 13
        Me.CheckConsumido.Text = "Consumido"
        Me.CheckConsumido.UseVisualStyleBackColor = True
        '
        'DateDescartado
        '
        Me.DateDescartado.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDescartado.Location = New System.Drawing.Point(112, 97)
        Me.DateDescartado.Name = "DateDescartado"
        Me.DateDescartado.Size = New System.Drawing.Size(100, 20)
        Me.DateDescartado.TabIndex = 14
        '
        'RadioSinAbrir
        '
        Me.RadioSinAbrir.AutoSize = True
        Me.RadioSinAbrir.Location = New System.Drawing.Point(302, 22)
        Me.RadioSinAbrir.Name = "RadioSinAbrir"
        Me.RadioSinAbrir.Size = New System.Drawing.Size(63, 17)
        Me.RadioSinAbrir.TabIndex = 15
        Me.RadioSinAbrir.TabStop = True
        Me.RadioSinAbrir.Text = "Sin abrir"
        Me.RadioSinAbrir.UseVisualStyleBackColor = True
        '
        'RadioEnUso
        '
        Me.RadioEnUso.AutoSize = True
        Me.RadioEnUso.Location = New System.Drawing.Point(238, 22)
        Me.RadioEnUso.Name = "RadioEnUso"
        Me.RadioEnUso.Size = New System.Drawing.Size(58, 17)
        Me.RadioEnUso.TabIndex = 16
        Me.RadioEnUso.TabStop = True
        Me.RadioEnUso.Text = "En uso"
        Me.RadioEnUso.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(97, 285)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 17
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(22, 285)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(51, 20)
        Me.TextId.TabIndex = 18
        Me.TextId.Visible = False
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(22, 171)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(190, 108)
        Me.TextObservaciones.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Observaciones"
        '
        'FormControlDeMedios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1114, 592)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.RadioEnUso)
        Me.Controls.Add(Me.RadioSinAbrir)
        Me.Controls.Add(Me.DateDescartado)
        Me.Controls.Add(Me.CheckConsumido)
        Me.Controls.Add(Me.CheckApertura)
        Me.Controls.Add(Me.ButtonExportar)
        Me.Controls.Add(Me.RadioDescartados)
        Me.Controls.Add(Me.RadioConsumidos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateVencimiento)
        Me.Controls.Add(Me.CheckDescartado)
        Me.Controls.Add(Me.DateConsumido)
        Me.Controls.Add(Me.DateApertura)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormControlDeMedios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de medios"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateApertura As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateConsumido As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckDescartado As System.Windows.Forms.CheckBox
    Friend WithEvents DateVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadioConsumidos As System.Windows.Forms.RadioButton
    Friend WithEvents RadioDescartados As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonExportar As System.Windows.Forms.Button
    Friend WithEvents CheckApertura As System.Windows.Forms.CheckBox
    Friend WithEvents CheckConsumido As System.Windows.Forms.CheckBox
    Friend WithEvents DateDescartado As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadioSinAbrir As System.Windows.Forms.RadioButton
    Friend WithEvents RadioEnUso As System.Windows.Forms.RadioButton
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Apertura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaApertura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Consumido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaConsumido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descartado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaDescartado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
