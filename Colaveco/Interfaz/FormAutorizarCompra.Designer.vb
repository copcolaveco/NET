<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAutorizarCompra
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
        Me.ButtonAnular = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DateAutorizacion = New System.Windows.Forms.DateTimePicker()
        Me.ButtonAutorizar = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Historial = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.PrecioAnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MonedaAnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaAnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Presentacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Eliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextProveedor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextResponsable = New System.Windows.Forms.TextBox()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.TextIdCompra = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonAnular
        '
        Me.ButtonAnular.Location = New System.Drawing.Point(275, 507)
        Me.ButtonAnular.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonAnular.Name = "ButtonAnular"
        Me.ButtonAnular.Size = New System.Drawing.Size(100, 28)
        Me.ButtonAnular.TabIndex = 37
        Me.ButtonAnular.Text = "Anular"
        Me.ButtonAnular.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 491)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 17)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Fecha autorización"
        '
        'DateAutorizacion
        '
        Me.DateAutorizacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateAutorizacion.Location = New System.Drawing.Point(16, 511)
        Me.DateAutorizacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateAutorizacion.Name = "DateAutorizacion"
        Me.DateAutorizacion.Size = New System.Drawing.Size(141, 22)
        Me.DateAutorizacion.TabIndex = 35
        '
        'ButtonAutorizar
        '
        Me.ButtonAutorizar.Location = New System.Drawing.Point(167, 507)
        Me.ButtonAutorizar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonAutorizar.Name = "ButtonAutorizar"
        Me.ButtonAutorizar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonAutorizar.TabIndex = 32
        Me.ButtonAutorizar.Text = "Autorizar"
        Me.ButtonAutorizar.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Producto, Me.Detalle, Me.Historial, Me.PrecioAnt, Me.MonedaAnt, Me.FechaAnt, Me.Cantidad, Me.Presentacion, Me.Precio, Me.Moneda, Me.Eliminar})
        Me.DataGridView2.Location = New System.Drawing.Point(16, 241)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(1291, 244)
        Me.DataGridView2.TabIndex = 31
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        Me.Id.Width = 50
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
        'Historial
        '
        Me.Historial.HeaderText = ""
        Me.Historial.Name = "Historial"
        Me.Historial.Text = "<->"
        Me.Historial.UseColumnTextForButtonValue = True
        Me.Historial.Width = 30
        '
        'PrecioAnt
        '
        Me.PrecioAnt.HeaderText = "Precio anterior s/IVA"
        Me.PrecioAnt.Name = "PrecioAnt"
        Me.PrecioAnt.Width = 60
        '
        'MonedaAnt
        '
        Me.MonedaAnt.HeaderText = "Moneda"
        Me.MonedaAnt.Name = "MonedaAnt"
        Me.MonedaAnt.Width = 50
        '
        'FechaAnt
        '
        Me.FechaAnt.HeaderText = "Fecha últ. compra"
        Me.FechaAnt.Name = "FechaAnt"
        Me.FechaAnt.Width = 80
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 80
        '
        'Presentacion
        '
        Me.Presentacion.HeaderText = "Presentación"
        Me.Presentacion.Name = "Presentacion"
        '
        'Precio
        '
        Me.Precio.HeaderText = "Precio actual s/IVA"
        Me.Precio.Name = "Precio"
        Me.Precio.Width = 80
        '
        'Moneda
        '
        Me.Moneda.HeaderText = "Moneda"
        Me.Moneda.Name = "Moneda"
        Me.Moneda.Width = 50
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = ""
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseColumnTextForButtonValue = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(265, 190)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 17)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Responsable"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(496, 190)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 17)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Proveedor"
        '
        'TextProveedor
        '
        Me.TextProveedor.Location = New System.Drawing.Point(500, 209)
        Me.TextProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.ReadOnly = True
        Me.TextProveedor.Size = New System.Drawing.Size(255, 22)
        Me.TextProveedor.TabIndex = 28
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 190)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 17)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Id"
        '
        'TextResponsable
        '
        Me.TextResponsable.Location = New System.Drawing.Point(269, 209)
        Me.TextResponsable.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextResponsable.Name = "TextResponsable"
        Me.TextResponsable.ReadOnly = True
        Me.TextResponsable.Size = New System.Drawing.Size(221, 22)
        Me.TextResponsable.TabIndex = 26
        '
        'DateFecha
        '
        Me.DateFecha.Enabled = False
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(117, 209)
        Me.DateFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(143, 22)
        Me.DateFecha.TabIndex = 25
        '
        'TextIdCompra
        '
        Me.TextIdCompra.Enabled = False
        Me.TextIdCompra.Location = New System.Drawing.Point(16, 209)
        Me.TextIdCompra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextIdCompra.Name = "TextIdCompra"
        Me.TextIdCompra.ReadOnly = True
        Me.TextIdCompra.Size = New System.Drawing.Size(79, 22)
        Me.TextIdCompra.TabIndex = 24
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCompra, Me.Proveedor, Me.Fecha})
        Me.DataGridView1.Location = New System.Drawing.Point(16, 15)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(541, 160)
        Me.DataGridView1.TabIndex = 23
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(617, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 17)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Observaciones"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(621, 34)
        Me.TextObservaciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.ReadOnly = True
        Me.TextObservaciones.Size = New System.Drawing.Size(625, 139)
        Me.TextObservaciones.TabIndex = 39
        '
        'FormAutorizarCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1323, 550)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonAnular)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.DateAutorizacion)
        Me.Controls.Add(Me.ButtonAutorizar)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextProveedor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextResponsable)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextIdCompra)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormAutorizarCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorización de compras"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonAnular As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DateAutorizacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonAutorizar As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextResponsable As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextIdCompra As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents IdCompra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Historial As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents PrecioAnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MonedaAnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaAnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Presentacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Eliminar As System.Windows.Forms.DataGridViewButtonColumn
End Class
