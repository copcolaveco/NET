<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNotificacionesReloj
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridNotificaciones = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEvento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.filtros = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.desde = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.hasta = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.cbxUsuario = New System.Windows.Forms.ComboBox()
        Me.cbxSinFiltros = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridNotificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridNotificaciones
        '
        Me.DataGridNotificaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridNotificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridNotificaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Usuario, Me.FechaEvento, Me.Detalle})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridNotificaciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridNotificaciones.Location = New System.Drawing.Point(16, 92)
        Me.DataGridNotificaciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridNotificaciones.Name = "DataGridNotificaciones"
        Me.DataGridNotificaciones.RowHeadersVisible = False
        Me.DataGridNotificaciones.Size = New System.Drawing.Size(1248, 474)
        Me.DataGridNotificaciones.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Usuario
        '
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.Width = 150
        '
        'FechaEvento
        '
        Me.FechaEvento.HeaderText = "Fecha evento"
        Me.FechaEvento.Name = "FechaEvento"
        Me.FechaEvento.Width = 80
        '
        'Detalle
        '
        Me.Detalle.HeaderText = "Detalle"
        Me.Detalle.Name = "Detalle"
        Me.Detalle.Width = 600
        '
        'filtros
        '
        Me.filtros.AutoSize = True
        Me.filtros.Location = New System.Drawing.Point(19, 9)
        Me.filtros.Name = "filtros"
        Me.filtros.Size = New System.Drawing.Size(46, 17)
        Me.filtros.TabIndex = 1
        Me.filtros.Text = "Filtros"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Desde"
        '
        'desde
        '
        Me.desde.Location = New System.Drawing.Point(74, 49)
        Me.desde.Name = "desde"
        Me.desde.Size = New System.Drawing.Size(115, 22)
        Me.desde.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Hasta"
        '
        'hasta
        '
        Me.hasta.Location = New System.Drawing.Point(269, 49)
        Me.hasta.Name = "hasta"
        Me.hasta.Size = New System.Drawing.Size(115, 22)
        Me.hasta.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(428, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Usuario"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(1098, 50)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Image = Global.Colaveco.My.Resources.Resources.excel
        Me.btnExcel.Location = New System.Drawing.Point(1189, 50)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnExcel.TabIndex = 9
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'cbxUsuario
        '
        Me.cbxUsuario.FormattingEnabled = True
        Me.cbxUsuario.Location = New System.Drawing.Point(491, 47)
        Me.cbxUsuario.Name = "cbxUsuario"
        Me.cbxUsuario.Size = New System.Drawing.Size(121, 24)
        Me.cbxUsuario.TabIndex = 10
        '
        'cbxSinFiltros
        '
        Me.cbxSinFiltros.AutoSize = True
        Me.cbxSinFiltros.Location = New System.Drawing.Point(638, 51)
        Me.cbxSinFiltros.Name = "cbxSinFiltros"
        Me.cbxSinFiltros.Size = New System.Drawing.Size(88, 21)
        Me.cbxSinFiltros.TabIndex = 11
        Me.cbxSinFiltros.Text = "Sin filtros"
        Me.cbxSinFiltros.UseVisualStyleBackColor = True
        '
        'FormNotificacionesReloj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1280, 581)
        Me.Controls.Add(Me.cbxSinFiltros)
        Me.Controls.Add(Me.cbxUsuario)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.hasta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.desde)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.filtros)
        Me.Controls.Add(Me.DataGridNotificaciones)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormNotificacionesReloj"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notificaciones Reloj"
        CType(Me.DataGridNotificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridNotificaciones As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaEvento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents filtros As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents cbxUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents cbxSinFiltros As System.Windows.Forms.CheckBox
End Class
