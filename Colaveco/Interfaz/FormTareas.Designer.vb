<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTareas
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sector = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TextId = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.TextDescripcion = New System.Windows.Forms.TextBox
        Me.DateVencimiento = New System.Windows.Forms.DateTimePicker
        Me.ComboResponsable = New System.Windows.Forms.ComboBox
        Me.ComboSector = New System.Windows.Forms.ComboBox
        Me.ComboCreador = New System.Windows.Forms.ComboBox
        Me.CheckRealizada = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ButtonNueva = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Descripcion, Me.Vencimiento, Me.Responsable, Me.Sector, Me.Creador})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(413, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(586, 465)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 200
        '
        'Vencimiento
        '
        Me.Vencimiento.HeaderText = "Vencimiento"
        Me.Vencimiento.Name = "Vencimiento"
        Me.Vencimiento.Width = 80
        '
        'Responsable
        '
        Me.Responsable.HeaderText = "Responsable"
        Me.Responsable.Name = "Responsable"
        '
        'Sector
        '
        Me.Sector.HeaderText = "Sector"
        Me.Sector.Name = "Sector"
        '
        'Creador
        '
        Me.Creador.HeaderText = "Creador"
        Me.Creador.Name = "Creador"
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(109, 12)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(57, 20)
        Me.TextId.TabIndex = 1
        '
        'DateFecha
        '
        Me.DateFecha.Enabled = False
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(109, 38)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 2
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(109, 64)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(288, 83)
        Me.TextDescripcion.TabIndex = 3
        '
        'DateVencimiento
        '
        Me.DateVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateVencimiento.Location = New System.Drawing.Point(109, 153)
        Me.DateVencimiento.Name = "DateVencimiento"
        Me.DateVencimiento.Size = New System.Drawing.Size(100, 20)
        Me.DateVencimiento.TabIndex = 4
        '
        'ComboResponsable
        '
        Me.ComboResponsable.FormattingEnabled = True
        Me.ComboResponsable.Location = New System.Drawing.Point(109, 179)
        Me.ComboResponsable.Name = "ComboResponsable"
        Me.ComboResponsable.Size = New System.Drawing.Size(144, 21)
        Me.ComboResponsable.TabIndex = 5
        '
        'ComboSector
        '
        Me.ComboSector.FormattingEnabled = True
        Me.ComboSector.Location = New System.Drawing.Point(109, 206)
        Me.ComboSector.Name = "ComboSector"
        Me.ComboSector.Size = New System.Drawing.Size(144, 21)
        Me.ComboSector.TabIndex = 6
        '
        'ComboCreador
        '
        Me.ComboCreador.Enabled = False
        Me.ComboCreador.FormattingEnabled = True
        Me.ComboCreador.Location = New System.Drawing.Point(109, 233)
        Me.ComboCreador.Name = "ComboCreador"
        Me.ComboCreador.Size = New System.Drawing.Size(144, 21)
        Me.ComboCreador.TabIndex = 7
        '
        'CheckRealizada
        '
        Me.CheckRealizada.AutoSize = True
        Me.CheckRealizada.Location = New System.Drawing.Point(109, 260)
        Me.CheckRealizada.Name = "CheckRealizada"
        Me.CheckRealizada.Size = New System.Drawing.Size(73, 17)
        Me.CheckRealizada.TabIndex = 8
        Me.CheckRealizada.Text = "Realizada"
        Me.CheckRealizada.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Descripción"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Vencimiento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Responsable"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Sector"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Creador"
        '
        'ButtonNueva
        '
        Me.ButtonNueva.Location = New System.Drawing.Point(109, 307)
        Me.ButtonNueva.Name = "ButtonNueva"
        Me.ButtonNueva.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNueva.TabIndex = 16
        Me.ButtonNueva.Text = "Nueva"
        Me.ButtonNueva.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(190, 307)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 17
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(271, 307)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 18
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'FormTareas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 489)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNueva)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckRealizada)
        Me.Controls.Add(Me.ComboCreador)
        Me.Controls.Add(Me.ComboSector)
        Me.Controls.Add(Me.ComboResponsable)
        Me.Controls.Add(Me.DateVencimiento)
        Me.Controls.Add(Me.TextDescripcion)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormTareas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tareas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents DateVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents ComboSector As System.Windows.Forms.ComboBox
    Friend WithEvents ComboCreador As System.Windows.Forms.ComboBox
    Friend WithEvents CheckRealizada As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ButtonNueva As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Responsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creador As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
