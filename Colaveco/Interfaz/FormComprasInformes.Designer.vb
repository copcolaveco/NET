<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormComprasInformes
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
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.DateTimeDesde = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeHasta = New System.Windows.Forms.DateTimePicker()
        Me.TextProveedor = New System.Windows.Forms.TextBox()
        Me.ButtonBuscarProveedor = New System.Windows.Forms.Button()
        Me.TextIdProveedor = New System.Windows.Forms.TextBox()
        Me.RadioFechas = New System.Windows.Forms.RadioButton()
        Me.RadioProveedor = New System.Windows.Forms.RadioButton()
        Me.DataGridCompras = New System.Windows.Forms.DataGridView()
        Me.Compra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridLineas = New System.Windows.Forms.DataGridView()
        Me.IdCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Presentacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recibido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Factura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ButtonExcel = New System.Windows.Forms.Button()
        Me.RadioProducto = New System.Windows.Forms.RadioButton()
        Me.TextProducto = New System.Windows.Forms.TextBox()
        Me.ButtonBuscarProducto = New System.Windows.Forms.Button()
        Me.TextIdProducto = New System.Windows.Forms.TextBox()
        Me.ComboEstado = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(482, 11)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(92, 73)
        Me.ButtonBuscar.TabIndex = 33
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'DateTimeDesde
        '
        Me.DateTimeDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimeDesde.Location = New System.Drawing.Point(110, 38)
        Me.DateTimeDesde.Name = "DateTimeDesde"
        Me.DateTimeDesde.Size = New System.Drawing.Size(92, 20)
        Me.DateTimeDesde.TabIndex = 32
        '
        'DateTimeHasta
        '
        Me.DateTimeHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimeHasta.Location = New System.Drawing.Point(208, 38)
        Me.DateTimeHasta.Name = "DateTimeHasta"
        Me.DateTimeHasta.Size = New System.Drawing.Size(92, 20)
        Me.DateTimeHasta.TabIndex = 31
        '
        'TextProveedor
        '
        Me.TextProveedor.Location = New System.Drawing.Point(200, 12)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.Size = New System.Drawing.Size(258, 20)
        Me.TextProveedor.TabIndex = 30
        '
        'ButtonBuscarProveedor
        '
        Me.ButtonBuscarProveedor.Location = New System.Drawing.Point(173, 13)
        Me.ButtonBuscarProveedor.Name = "ButtonBuscarProveedor"
        Me.ButtonBuscarProveedor.Size = New System.Drawing.Size(21, 19)
        Me.ButtonBuscarProveedor.TabIndex = 29
        Me.ButtonBuscarProveedor.Text = "^"
        Me.ButtonBuscarProveedor.UseVisualStyleBackColor = True
        '
        'TextIdProveedor
        '
        Me.TextIdProveedor.Location = New System.Drawing.Point(110, 11)
        Me.TextIdProveedor.Name = "TextIdProveedor"
        Me.TextIdProveedor.Size = New System.Drawing.Size(57, 20)
        Me.TextIdProveedor.TabIndex = 28
        '
        'RadioFechas
        '
        Me.RadioFechas.AutoSize = True
        Me.RadioFechas.Location = New System.Drawing.Point(11, 40)
        Me.RadioFechas.Name = "RadioFechas"
        Me.RadioFechas.Size = New System.Drawing.Size(60, 17)
        Me.RadioFechas.TabIndex = 27
        Me.RadioFechas.TabStop = True
        Me.RadioFechas.Text = "Fechas"
        Me.RadioFechas.UseVisualStyleBackColor = True
        '
        'RadioProveedor
        '
        Me.RadioProveedor.AutoSize = True
        Me.RadioProveedor.Location = New System.Drawing.Point(11, 13)
        Me.RadioProveedor.Name = "RadioProveedor"
        Me.RadioProveedor.Size = New System.Drawing.Size(74, 17)
        Me.RadioProveedor.TabIndex = 26
        Me.RadioProveedor.TabStop = True
        Me.RadioProveedor.Text = "Proveedor"
        Me.RadioProveedor.UseVisualStyleBackColor = True
        '
        'DataGridCompras
        '
        Me.DataGridCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridCompras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Compra, Me.Fecha, Me.Proveedor})
        Me.DataGridCompras.Location = New System.Drawing.Point(12, 128)
        Me.DataGridCompras.Name = "DataGridCompras"
        Me.DataGridCompras.RowHeadersVisible = False
        Me.DataGridCompras.Size = New System.Drawing.Size(297, 461)
        Me.DataGridCompras.TabIndex = 34
        '
        'Compra
        '
        Me.Compra.HeaderText = "Compra"
        Me.Compra.Name = "Compra"
        Me.Compra.Width = 60
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Proveedor
        '
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.Width = 150
        '
        'DataGridLineas
        '
        Me.DataGridLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCompra, Me.Codigo, Me.Producto, Me.Unidad, Me.Cantidad, Me.Presentacion, Me.Moneda, Me.Precio, Me.Recibido, Me.Factura})
        Me.DataGridLineas.Location = New System.Drawing.Point(315, 128)
        Me.DataGridLineas.Name = "DataGridLineas"
        Me.DataGridLineas.RowHeadersVisible = False
        Me.DataGridLineas.Size = New System.Drawing.Size(856, 461)
        Me.DataGridLineas.TabIndex = 35
        '
        'IdCompra
        '
        Me.IdCompra.HeaderText = "IdCompra"
        Me.IdCompra.Name = "IdCompra"
        Me.IdCompra.Visible = False
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
        Me.Producto.Width = 200
        '
        'Unidad
        '
        Me.Unidad.HeaderText = "Unidad"
        Me.Unidad.Name = "Unidad"
        Me.Unidad.Width = 60
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 60
        '
        'Presentacion
        '
        Me.Presentacion.HeaderText = "Presentación"
        Me.Presentacion.Name = "Presentacion"
        Me.Presentacion.Width = 120
        '
        'Moneda
        '
        Me.Moneda.HeaderText = "Moneda"
        Me.Moneda.Name = "Moneda"
        Me.Moneda.Width = 50
        '
        'Precio
        '
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.Width = 60
        '
        'Recibido
        '
        Me.Recibido.HeaderText = "Recibido"
        Me.Recibido.Name = "Recibido"
        Me.Recibido.Width = 50
        '
        'Factura
        '
        Me.Factura.HeaderText = "Factura"
        Me.Factura.Name = "Factura"
        '
        'ButtonExcel
        '
        Me.ButtonExcel.Image = Global.Colaveco.My.Resources.Resources.excel
        Me.ButtonExcel.Location = New System.Drawing.Point(1096, 14)
        Me.ButtonExcel.Name = "ButtonExcel"
        Me.ButtonExcel.Size = New System.Drawing.Size(75, 44)
        Me.ButtonExcel.TabIndex = 36
        Me.ButtonExcel.UseVisualStyleBackColor = True
        '
        'RadioProducto
        '
        Me.RadioProducto.AutoSize = True
        Me.RadioProducto.Location = New System.Drawing.Point(11, 67)
        Me.RadioProducto.Name = "RadioProducto"
        Me.RadioProducto.Size = New System.Drawing.Size(68, 17)
        Me.RadioProducto.TabIndex = 37
        Me.RadioProducto.TabStop = True
        Me.RadioProducto.Text = "Producto"
        Me.RadioProducto.UseVisualStyleBackColor = True
        '
        'TextProducto
        '
        Me.TextProducto.Location = New System.Drawing.Point(200, 67)
        Me.TextProducto.Name = "TextProducto"
        Me.TextProducto.Size = New System.Drawing.Size(258, 20)
        Me.TextProducto.TabIndex = 40
        '
        'ButtonBuscarProducto
        '
        Me.ButtonBuscarProducto.Location = New System.Drawing.Point(173, 68)
        Me.ButtonBuscarProducto.Name = "ButtonBuscarProducto"
        Me.ButtonBuscarProducto.Size = New System.Drawing.Size(21, 19)
        Me.ButtonBuscarProducto.TabIndex = 39
        Me.ButtonBuscarProducto.Text = "^"
        Me.ButtonBuscarProducto.UseVisualStyleBackColor = True
        '
        'TextIdProducto
        '
        Me.TextIdProducto.Location = New System.Drawing.Point(110, 66)
        Me.TextIdProducto.Name = "TextIdProducto"
        Me.TextIdProducto.Size = New System.Drawing.Size(57, 20)
        Me.TextIdProducto.TabIndex = 38
        '
        'ComboEstado
        '
        Me.ComboEstado.FormattingEnabled = True
        Me.ComboEstado.Items.AddRange(New Object() {"Recibido", "Sin recibir", "Todo"})
        Me.ComboEstado.Location = New System.Drawing.Point(110, 92)
        Me.ComboEstado.Name = "ComboEstado"
        Me.ComboEstado.Size = New System.Drawing.Size(136, 21)
        Me.ComboEstado.TabIndex = 41
        '
        'FormComprasInformes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 598)
        Me.Controls.Add(Me.ComboEstado)
        Me.Controls.Add(Me.TextProducto)
        Me.Controls.Add(Me.ButtonBuscarProducto)
        Me.Controls.Add(Me.TextIdProducto)
        Me.Controls.Add(Me.RadioProducto)
        Me.Controls.Add(Me.ButtonExcel)
        Me.Controls.Add(Me.DataGridLineas)
        Me.Controls.Add(Me.DataGridCompras)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Controls.Add(Me.DateTimeDesde)
        Me.Controls.Add(Me.DateTimeHasta)
        Me.Controls.Add(Me.TextProveedor)
        Me.Controls.Add(Me.ButtonBuscarProveedor)
        Me.Controls.Add(Me.TextIdProveedor)
        Me.Controls.Add(Me.RadioFechas)
        Me.Controls.Add(Me.RadioProveedor)
        Me.Name = "FormComprasInformes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informes de compras"
        CType(Me.DataGridCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents DateTimeDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimeHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextProveedor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents TextIdProveedor As System.Windows.Forms.TextBox
    Friend WithEvents RadioFechas As System.Windows.Forms.RadioButton
    Friend WithEvents RadioProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridCompras As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridLineas As System.Windows.Forms.DataGridView
    Friend WithEvents Compra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonExcel As System.Windows.Forms.Button
    Friend WithEvents IdCompra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Presentacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Recibido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Factura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RadioProducto As System.Windows.Forms.RadioButton
    Friend WithEvents TextProducto As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents TextIdProducto As System.Windows.Forms.TextBox
    Friend WithEvents ComboEstado As System.Windows.Forms.ComboBox
End Class
