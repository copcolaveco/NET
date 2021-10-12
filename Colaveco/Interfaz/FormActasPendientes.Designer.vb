<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormActasPendientes
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdActa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tema = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Resumen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Plazo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Efectuada = New System.Windows.Forms.DataGridViewButtonColumn
        Me.RadioTodosPendientes = New System.Windows.Forms.RadioButton
        Me.RadioVencidos = New System.Windows.Forms.RadioButton
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.RadioEfectuados = New System.Windows.Forms.RadioButton
        Me.RadioTodos = New System.Windows.Forms.RadioButton
        Me.ComboGrupo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.IdActa, Me.Numero, Me.Fecha, Me.Grupo, Me.Tema, Me.Resumen, Me.Responsable, Me.Plazo, Me.Efectuada})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 51)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Size = New System.Drawing.Size(1053, 542)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'IdActa
        '
        Me.IdActa.HeaderText = "IdActa"
        Me.IdActa.Name = "IdActa"
        Me.IdActa.Visible = False
        '
        'Numero
        '
        Me.Numero.HeaderText = "Número"
        Me.Numero.Name = "Numero"
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Grupo
        '
        Me.Grupo.HeaderText = "Grupo"
        Me.Grupo.Name = "Grupo"
        '
        'Tema
        '
        Me.Tema.HeaderText = "Tema"
        Me.Tema.Name = "Tema"
        Me.Tema.Width = 80
        '
        'Resumen
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Resumen.DefaultCellStyle = DataGridViewCellStyle1
        Me.Resumen.HeaderText = "Resúmen"
        Me.Resumen.Name = "Resumen"
        Me.Resumen.Width = 360
        '
        'Responsable
        '
        Me.Responsable.HeaderText = "Responsable"
        Me.Responsable.Name = "Responsable"
        Me.Responsable.Width = 150
        '
        'Plazo
        '
        Me.Plazo.HeaderText = "Plazo"
        Me.Plazo.Name = "Plazo"
        Me.Plazo.Width = 80
        '
        'Efectuada
        '
        Me.Efectuada.HeaderText = ""
        Me.Efectuada.Name = "Efectuada"
        Me.Efectuada.Text = "Efectuada"
        Me.Efectuada.UseColumnTextForButtonValue = True
        '
        'RadioTodosPendientes
        '
        Me.RadioTodosPendientes.AutoSize = True
        Me.RadioTodosPendientes.Location = New System.Drawing.Point(73, 12)
        Me.RadioTodosPendientes.Name = "RadioTodosPendientes"
        Me.RadioTodosPendientes.Size = New System.Drawing.Size(78, 17)
        Me.RadioTodosPendientes.TabIndex = 1
        Me.RadioTodosPendientes.TabStop = True
        Me.RadioTodosPendientes.Text = "Pendientes"
        Me.RadioTodosPendientes.UseVisualStyleBackColor = True
        '
        'RadioVencidos
        '
        Me.RadioVencidos.AutoSize = True
        Me.RadioVencidos.Location = New System.Drawing.Point(157, 12)
        Me.RadioVencidos.Name = "RadioVencidos"
        Me.RadioVencidos.Size = New System.Drawing.Size(69, 17)
        Me.RadioVencidos.TabIndex = 2
        Me.RadioVencidos.TabStop = True
        Me.RadioVencidos.Text = "Vencidos"
        Me.RadioVencidos.UseVisualStyleBackColor = True
        '
        'DateFecha
        '
        Me.DateFecha.Enabled = False
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(968, 16)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(97, 20)
        Me.DateFecha.TabIndex = 3
        Me.DateFecha.Visible = False
        '
        'RadioEfectuados
        '
        Me.RadioEfectuados.AutoSize = True
        Me.RadioEfectuados.Location = New System.Drawing.Point(232, 12)
        Me.RadioEfectuados.Name = "RadioEfectuados"
        Me.RadioEfectuados.Size = New System.Drawing.Size(79, 17)
        Me.RadioEfectuados.TabIndex = 4
        Me.RadioEfectuados.TabStop = True
        Me.RadioEfectuados.Text = "Efectuados"
        Me.RadioEfectuados.UseVisualStyleBackColor = True
        '
        'RadioTodos
        '
        Me.RadioTodos.AutoSize = True
        Me.RadioTodos.Location = New System.Drawing.Point(12, 12)
        Me.RadioTodos.Name = "RadioTodos"
        Me.RadioTodos.Size = New System.Drawing.Size(55, 17)
        Me.RadioTodos.TabIndex = 5
        Me.RadioTodos.TabStop = True
        Me.RadioTodos.Text = "Todos"
        Me.RadioTodos.UseVisualStyleBackColor = True
        '
        'ComboGrupo
        '
        Me.ComboGrupo.FormattingEnabled = True
        Me.ComboGrupo.Location = New System.Drawing.Point(410, 12)
        Me.ComboGrupo.Name = "ComboGrupo"
        Me.ComboGrupo.Size = New System.Drawing.Size(181, 21)
        Me.ComboGrupo.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(368, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Grupo"
        '
        'FormActasPendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1079, 607)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboGrupo)
        Me.Controls.Add(Me.RadioTodos)
        Me.Controls.Add(Me.RadioEfectuados)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.RadioVencidos)
        Me.Controls.Add(Me.RadioTodosPendientes)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormActasPendientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de actas con ítems pendientes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents RadioTodosPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents RadioVencidos As System.Windows.Forms.RadioButton
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadioEfectuados As System.Windows.Forms.RadioButton
    Friend WithEvents RadioTodos As System.Windows.Forms.RadioButton
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdActa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tema As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resumen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Responsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Plazo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Efectuada As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ComboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
