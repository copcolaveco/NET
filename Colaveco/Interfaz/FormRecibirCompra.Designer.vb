<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRecibirCompra
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label14 = New System.Windows.Forms.Label
        Me.DateFechaRecibo = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.CheckAceptado = New System.Windows.Forms.CheckBox
        Me.ButtonRecibir = New System.Windows.Forms.Button
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Presentacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Completa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cumple = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Completar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.NoCumple = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextProveedor = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextResponsable = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.TextIdCompra = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.IdCompra = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(466, 467)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 13)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Fecha recibo"
        '
        'DateFechaRecibo
        '
        Me.DateFechaRecibo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaRecibo.Location = New System.Drawing.Point(469, 483)
        Me.DateFechaRecibo.Name = "DateFechaRecibo"
        Me.DateFechaRecibo.Size = New System.Drawing.Size(96, 20)
        Me.DateFechaRecibo.TabIndex = 49
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 467)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Observaciones"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(96, 467)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(367, 85)
        Me.TextObservaciones.TabIndex = 47
        '
        'CheckAceptado
        '
        Me.CheckAceptado.AutoSize = True
        Me.CheckAceptado.Location = New System.Drawing.Point(469, 509)
        Me.CheckAceptado.Name = "CheckAceptado"
        Me.CheckAceptado.Size = New System.Drawing.Size(72, 17)
        Me.CheckAceptado.TabIndex = 46
        Me.CheckAceptado.Text = "Aceptada"
        Me.CheckAceptado.UseVisualStyleBackColor = True
        '
        'ButtonRecibir
        '
        Me.ButtonRecibir.Location = New System.Drawing.Point(469, 529)
        Me.ButtonRecibir.Name = "ButtonRecibir"
        Me.ButtonRecibir.Size = New System.Drawing.Size(75, 23)
        Me.ButtonRecibir.TabIndex = 45
        Me.ButtonRecibir.Text = "Recibir"
        Me.ButtonRecibir.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Codigo, Me.Producto, Me.Detalle, Me.Cantidad, Me.Unidad, Me.Presentacion, Me.Precio, Me.Moneda, Me.Completa, Me.Cumple, Me.Completar, Me.NoCumple})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView2.Location = New System.Drawing.Point(12, 187)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(1195, 267)
        Me.DataGridView2.TabIndex = 44
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        Me.Id.Width = 50
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        '
        'Producto
        '
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.Width = 220
        '
        'Detalle
        '
        Me.Detalle.HeaderText = "Detalle"
        Me.Detalle.Name = "Detalle"
        Me.Detalle.Width = 220
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 60
        '
        'Unidad
        '
        Me.Unidad.HeaderText = "Unidad"
        Me.Unidad.Name = "Unidad"
        Me.Unidad.Width = 60
        '
        'Presentacion
        '
        Me.Presentacion.HeaderText = "Presentación"
        Me.Presentacion.Name = "Presentacion"
        '
        'Precio
        '
        Me.Precio.HeaderText = "Precio s/IVA"
        Me.Precio.Name = "Precio"
        Me.Precio.Width = 60
        '
        'Moneda
        '
        Me.Moneda.HeaderText = "Moneda"
        Me.Moneda.Name = "Moneda"
        Me.Moneda.Width = 50
        '
        'Completa
        '
        Me.Completa.HeaderText = "Completa"
        Me.Completa.Name = "Completa"
        Me.Completa.ReadOnly = True
        Me.Completa.Width = 60
        '
        'Cumple
        '
        Me.Cumple.HeaderText = "Cumple"
        Me.Cumple.Name = "Cumple"
        Me.Cumple.ReadOnly = True
        Me.Cumple.Width = 60
        '
        'Completar
        '
        Me.Completar.HeaderText = ""
        Me.Completar.Name = "Completar"
        Me.Completar.ReadOnly = True
        Me.Completar.Text = "completar"
        Me.Completar.UseColumnTextForButtonValue = True
        '
        'NoCumple
        '
        Me.NoCumple.HeaderText = ""
        Me.NoCumple.Name = "NoCumple"
        Me.NoCumple.ReadOnly = True
        Me.NoCumple.Text = "no cumple"
        Me.NoCumple.UseColumnTextForButtonValue = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(199, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "Responsable"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(360, 145)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "Proveedor"
        '
        'TextProveedor
        '
        Me.TextProveedor.Location = New System.Drawing.Point(360, 161)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.ReadOnly = True
        Me.TextProveedor.Size = New System.Drawing.Size(207, 20)
        Me.TextProveedor.TabIndex = 41
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 145)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 13)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Id"
        '
        'TextResponsable
        '
        Me.TextResponsable.Location = New System.Drawing.Point(202, 161)
        Me.TextResponsable.Name = "TextResponsable"
        Me.TextResponsable.ReadOnly = True
        Me.TextResponsable.Size = New System.Drawing.Size(152, 20)
        Me.TextResponsable.TabIndex = 39
        '
        'DateFecha
        '
        Me.DateFecha.Enabled = False
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(88, 161)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(108, 20)
        Me.DateFecha.TabIndex = 38
        '
        'TextIdCompra
        '
        Me.TextIdCompra.Enabled = False
        Me.TextIdCompra.Location = New System.Drawing.Point(12, 161)
        Me.TextIdCompra.Name = "TextIdCompra"
        Me.TextIdCompra.ReadOnly = True
        Me.TextIdCompra.Size = New System.Drawing.Size(60, 20)
        Me.TextIdCompra.TabIndex = 37
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCompra, Me.Proveedor, Me.Fecha})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(404, 130)
        Me.DataGridView1.TabIndex = 36
        '
        'IdCompra
        '
        Me.IdCompra.HeaderText = "Id"
        Me.IdCompra.Name = "IdCompra"
        Me.IdCompra.Width = 50
        '
        'Proveedor
        '
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.Width = 250
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        '
        'FormRecibirCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1215, 562)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.DateFechaRecibo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.CheckAceptado)
        Me.Controls.Add(Me.ButtonRecibir)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextProveedor)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextResponsable)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextIdCompra)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormRecibirCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recepción de compras"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DateFechaRecibo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents CheckAceptado As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonRecibir As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextResponsable As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextIdCompra As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents IdCompra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Presentacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Completa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cumple As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Completar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents NoCumple As System.Windows.Forms.DataGridViewButtonColumn
End Class
