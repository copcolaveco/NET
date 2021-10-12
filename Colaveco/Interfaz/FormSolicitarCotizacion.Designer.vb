<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitarCotizacion
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
        Me.ComboEmail = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.TextIdLinea = New System.Windows.Forms.TextBox
        Me.TextDetalle = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Presentacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Eliminar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonNueva = New System.Windows.Forms.Button
        Me.TextResponsable = New System.Windows.Forms.TextBox
        Me.ComboUnidad = New System.Windows.Forms.ComboBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.TextCantidad = New System.Windows.Forms.TextBox
        Me.TextProveedor = New System.Windows.Forms.TextBox
        Me.ButtonBuscarProveedor = New System.Windows.Forms.Button
        Me.TextProducto = New System.Windows.Forms.TextBox
        Me.TextIdProveedor = New System.Windows.Forms.TextBox
        Me.ButtonBuscarProducto = New System.Windows.Forms.Button
        Me.TextId = New System.Windows.Forms.TextBox
        Me.ButtonAgregar = New System.Windows.Forms.Button
        Me.TextIdProducto = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.ComboMoneda = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextPrecio = New System.Windows.Forms.TextBox
        Me.DateUltimaCompra = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.ComboEmail2 = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextProveedor2 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextIdProveedor2 = New System.Windows.Forms.TextBox
        Me.ComboEmail3 = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextProveedor3 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextIdProveedor3 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.ComboPresentacion = New System.Windows.Forms.ComboBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboEmail
        '
        Me.ComboEmail.FormattingEnabled = True
        Me.ComboEmail.Location = New System.Drawing.Point(474, 37)
        Me.ComboEmail.Name = "ComboEmail"
        Me.ComboEmail.Size = New System.Drawing.Size(290, 21)
        Me.ComboEmail.TabIndex = 79
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(471, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(265, 13)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Seleccionar email para envio de solicitud de cotización"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 409)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "Observaciones"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(100, 406)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(798, 47)
        Me.TextObservaciones.TabIndex = 76
        '
        'TextIdLinea
        '
        Me.TextIdLinea.Location = New System.Drawing.Point(19, 433)
        Me.TextIdLinea.Name = "TextIdLinea"
        Me.TextIdLinea.Size = New System.Drawing.Size(46, 20)
        Me.TextIdLinea.TabIndex = 75
        '
        'TextDetalle
        '
        Me.TextDetalle.Location = New System.Drawing.Point(118, 163)
        Me.TextDetalle.Multiline = True
        Me.TextDetalle.Name = "TextDetalle"
        Me.TextDetalle.ReadOnly = True
        Me.TextDetalle.Size = New System.Drawing.Size(328, 41)
        Me.TextDetalle.TabIndex = 74
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(522, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "Unidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(449, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Cantidad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(119, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Producto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Id"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Producto, Me.Detalle, Me.Cantidad, Me.Unidad, Me.Presentacion, Me.Precio, Me.Moneda, Me.Fecha, Me.Editar, Me.Eliminar})
        Me.DataGridView1.Location = New System.Drawing.Point(19, 210)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1012, 190)
        Me.DataGridView1.TabIndex = 60
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
        Me.Producto.Width = 180
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
        Me.Unidad.Width = 50
        '
        'Presentacion
        '
        Me.Presentacion.HeaderText = "Presentación"
        Me.Presentacion.Name = "Presentacion"
        '
        'Precio
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.Precio.DefaultCellStyle = DataGridViewCellStyle1
        Me.Precio.HeaderText = "Precio últ. compra"
        Me.Precio.Name = "Precio"
        Me.Precio.Width = 60
        '
        'Moneda
        '
        Me.Moneda.HeaderText = "Moneda"
        Me.Moneda.Name = "Moneda"
        Me.Moneda.Width = 50
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha últ. compra"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Editar
        '
        Me.Editar.HeaderText = ""
        Me.Editar.Name = "Editar"
        Me.Editar.Text = "Editar"
        Me.Editar.UseColumnTextForButtonValue = True
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = ""
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseColumnTextForButtonValue = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Proveedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Id"
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(100, 459)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(150, 23)
        Me.ButtonGuardar.TabIndex = 68
        Me.ButtonGuardar.Text = "Guardar y enviar solicitud"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonNueva
        '
        Me.ButtonNueva.Location = New System.Drawing.Point(19, 459)
        Me.ButtonNueva.Name = "ButtonNueva"
        Me.ButtonNueva.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNueva.TabIndex = 67
        Me.ButtonNueva.Text = "Nueva"
        Me.ButtonNueva.UseVisualStyleBackColor = True
        '
        'TextResponsable
        '
        Me.TextResponsable.Location = New System.Drawing.Point(265, 12)
        Me.TextResponsable.Name = "TextResponsable"
        Me.TextResponsable.ReadOnly = True
        Me.TextResponsable.Size = New System.Drawing.Size(191, 20)
        Me.TextResponsable.TabIndex = 57
        '
        'ComboUnidad
        '
        Me.ComboUnidad.FormattingEnabled = True
        Me.ComboUnidad.Location = New System.Drawing.Point(525, 136)
        Me.ComboUnidad.Name = "ComboUnidad"
        Me.ComboUnidad.Size = New System.Drawing.Size(63, 21)
        Me.ComboUnidad.TabIndex = 65
        '
        'DateFecha
        '
        Me.DateFecha.Enabled = False
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(151, 12)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(108, 20)
        Me.DateFecha.TabIndex = 56
        '
        'TextCantidad
        '
        Me.TextCantidad.Location = New System.Drawing.Point(452, 137)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.Size = New System.Drawing.Size(67, 20)
        Me.TextCantidad.TabIndex = 64
        '
        'TextProveedor
        '
        Me.TextProveedor.Location = New System.Drawing.Point(174, 38)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.ReadOnly = True
        Me.TextProveedor.Size = New System.Drawing.Size(282, 20)
        Me.TextProveedor.TabIndex = 55
        '
        'ButtonBuscarProveedor
        '
        Me.ButtonBuscarProveedor.Location = New System.Drawing.Point(141, 38)
        Me.ButtonBuscarProveedor.Name = "ButtonBuscarProveedor"
        Me.ButtonBuscarProveedor.Size = New System.Drawing.Size(27, 22)
        Me.ButtonBuscarProveedor.TabIndex = 54
        Me.ButtonBuscarProveedor.Text = "^"
        Me.ButtonBuscarProveedor.UseVisualStyleBackColor = True
        '
        'TextProducto
        '
        Me.TextProducto.Location = New System.Drawing.Point(118, 137)
        Me.TextProducto.Name = "TextProducto"
        Me.TextProducto.ReadOnly = True
        Me.TextProducto.Size = New System.Drawing.Size(328, 20)
        Me.TextProducto.TabIndex = 63
        '
        'TextIdProveedor
        '
        Me.TextIdProveedor.Location = New System.Drawing.Point(75, 38)
        Me.TextIdProveedor.Name = "TextIdProveedor"
        Me.TextIdProveedor.ReadOnly = True
        Me.TextIdProveedor.Size = New System.Drawing.Size(60, 20)
        Me.TextIdProveedor.TabIndex = 53
        '
        'ButtonBuscarProducto
        '
        Me.ButtonBuscarProducto.Location = New System.Drawing.Point(85, 137)
        Me.ButtonBuscarProducto.Name = "ButtonBuscarProducto"
        Me.ButtonBuscarProducto.Size = New System.Drawing.Size(27, 22)
        Me.ButtonBuscarProducto.TabIndex = 62
        Me.ButtonBuscarProducto.Text = "^"
        Me.ButtonBuscarProducto.UseVisualStyleBackColor = True
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(75, 12)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(60, 20)
        Me.TextId.TabIndex = 52
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Location = New System.Drawing.Point(730, 172)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(59, 23)
        Me.ButtonAgregar.TabIndex = 66
        Me.ButtonAgregar.Text = "Agregar"
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'TextIdProducto
        '
        Me.TextIdProducto.Location = New System.Drawing.Point(19, 137)
        Me.TextIdProducto.Name = "TextIdProducto"
        Me.TextIdProducto.ReadOnly = True
        Me.TextIdProducto.Size = New System.Drawing.Size(60, 20)
        Me.TextIdProducto.TabIndex = 61
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(540, 161)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Moneda"
        '
        'ComboMoneda
        '
        Me.ComboMoneda.FormattingEnabled = True
        Me.ComboMoneda.Location = New System.Drawing.Point(540, 174)
        Me.ComboMoneda.Name = "ComboMoneda"
        Me.ComboMoneda.Size = New System.Drawing.Size(54, 21)
        Me.ComboMoneda.TabIndex = 83
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(449, 159)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 82
        Me.Label10.Text = "Precio ant. s/IVA"
        '
        'TextPrecio
        '
        Me.TextPrecio.Location = New System.Drawing.Point(452, 175)
        Me.TextPrecio.Name = "TextPrecio"
        Me.TextPrecio.Size = New System.Drawing.Size(80, 20)
        Me.TextPrecio.TabIndex = 81
        '
        'DateUltimaCompra
        '
        Me.DateUltimaCompra.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateUltimaCompra.Location = New System.Drawing.Point(600, 175)
        Me.DateUltimaCompra.Name = "DateUltimaCompra"
        Me.DateUltimaCompra.Size = New System.Drawing.Size(95, 20)
        Me.DateUltimaCompra.TabIndex = 85
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(597, 159)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 13)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "Fecha últ. compra"
        '
        'ComboEmail2
        '
        Me.ComboEmail2.FormattingEnabled = True
        Me.ComboEmail2.Location = New System.Drawing.Point(474, 63)
        Me.ComboEmail2.Name = "ComboEmail2"
        Me.ComboEmail2.Size = New System.Drawing.Size(290, 21)
        Me.ComboEmail2.TabIndex = 91
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 90
        Me.Label12.Text = "Proveedor"
        '
        'TextProveedor2
        '
        Me.TextProveedor2.Location = New System.Drawing.Point(174, 64)
        Me.TextProveedor2.Name = "TextProveedor2"
        Me.TextProveedor2.ReadOnly = True
        Me.TextProveedor2.Size = New System.Drawing.Size(282, 20)
        Me.TextProveedor2.TabIndex = 89
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(141, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 22)
        Me.Button1.TabIndex = 88
        Me.Button1.Text = "^"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextIdProveedor2
        '
        Me.TextIdProveedor2.Location = New System.Drawing.Point(75, 64)
        Me.TextIdProveedor2.Name = "TextIdProveedor2"
        Me.TextIdProveedor2.ReadOnly = True
        Me.TextIdProveedor2.Size = New System.Drawing.Size(60, 20)
        Me.TextIdProveedor2.TabIndex = 87
        '
        'ComboEmail3
        '
        Me.ComboEmail3.FormattingEnabled = True
        Me.ComboEmail3.Location = New System.Drawing.Point(474, 89)
        Me.ComboEmail3.Name = "ComboEmail3"
        Me.ComboEmail3.Size = New System.Drawing.Size(290, 21)
        Me.ComboEmail3.TabIndex = 96
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 95
        Me.Label13.Text = "Proveedor"
        '
        'TextProveedor3
        '
        Me.TextProveedor3.Location = New System.Drawing.Point(174, 90)
        Me.TextProveedor3.Name = "TextProveedor3"
        Me.TextProveedor3.ReadOnly = True
        Me.TextProveedor3.Size = New System.Drawing.Size(282, 20)
        Me.TextProveedor3.TabIndex = 94
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(141, 90)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(27, 22)
        Me.Button2.TabIndex = 93
        Me.Button2.Text = "^"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextIdProveedor3
        '
        Me.TextIdProveedor3.Location = New System.Drawing.Point(75, 90)
        Me.TextIdProveedor3.Name = "TextIdProveedor3"
        Me.TextIdProveedor3.ReadOnly = True
        Me.TextIdProveedor3.Size = New System.Drawing.Size(60, 20)
        Me.TextIdProveedor3.TabIndex = 92
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(597, 119)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 13)
        Me.Label14.TabIndex = 100
        Me.Label14.Text = "Presentación"
        '
        'ComboPresentacion
        '
        Me.ComboPresentacion.FormattingEnabled = True
        Me.ComboPresentacion.Location = New System.Drawing.Point(594, 135)
        Me.ComboPresentacion.Name = "ComboPresentacion"
        Me.ComboPresentacion.Size = New System.Drawing.Size(195, 21)
        Me.ComboPresentacion.TabIndex = 99
        '
        'FormSolicitarCotizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 492)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ComboPresentacion)
        Me.Controls.Add(Me.ComboEmail3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextProveedor3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextIdProveedor3)
        Me.Controls.Add(Me.ComboEmail2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextProveedor2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextIdProveedor2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DateUltimaCompra)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboMoneda)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextPrecio)
        Me.Controls.Add(Me.ComboEmail)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.TextIdLinea)
        Me.Controls.Add(Me.TextDetalle)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNueva)
        Me.Controls.Add(Me.TextResponsable)
        Me.Controls.Add(Me.ComboUnidad)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextCantidad)
        Me.Controls.Add(Me.TextProveedor)
        Me.Controls.Add(Me.ButtonBuscarProveedor)
        Me.Controls.Add(Me.TextProducto)
        Me.Controls.Add(Me.TextIdProveedor)
        Me.Controls.Add(Me.ButtonBuscarProducto)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.ButtonAgregar)
        Me.Controls.Add(Me.TextIdProducto)
        Me.Name = "FormSolicitarCotizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud de cotización"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboEmail As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents TextIdLinea As System.Windows.Forms.TextBox
    Friend WithEvents TextDetalle As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonNueva As System.Windows.Forms.Button
    Friend WithEvents TextResponsable As System.Windows.Forms.TextBox
    Friend WithEvents ComboUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TextProveedor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents TextProducto As System.Windows.Forms.TextBox
    Friend WithEvents TextIdProveedor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents TextIdProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ComboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextPrecio As System.Windows.Forms.TextBox
    Friend WithEvents DateUltimaCompra As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboEmail2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextProveedor2 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextIdProveedor2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboEmail3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextProveedor3 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextIdProveedor3 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboPresentacion As System.Windows.Forms.ComboBox
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Presentacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Eliminar As System.Windows.Forms.DataGridViewButtonColumn
End Class
