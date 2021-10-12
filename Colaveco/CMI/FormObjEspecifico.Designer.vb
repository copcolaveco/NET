<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormObjEspecifico
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.NumericAno = New System.Windows.Forms.NumericUpDown
        Me.ComboObjGral = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ObjGral = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ano = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextNombre = New System.Windows.Forms.TextBox
        Me.TextId = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboDimension = New System.Windows.Forms.ComboBox
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonTodos = New System.Windows.Forms.Button
        CType(Me.NumericAno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(201, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Año"
        '
        'NumericAno
        '
        Me.NumericAno.Location = New System.Drawing.Point(233, 23)
        Me.NumericAno.Maximum = New Decimal(New Integer() {2030, 0, 0, 0})
        Me.NumericAno.Minimum = New Decimal(New Integer() {2013, 0, 0, 0})
        Me.NumericAno.Name = "NumericAno"
        Me.NumericAno.Size = New System.Drawing.Size(64, 20)
        Me.NumericAno.TabIndex = 30
        Me.NumericAno.Value = New Decimal(New Integer() {2013, 0, 0, 0})
        '
        'ComboObjGral
        '
        Me.ComboObjGral.FormattingEnabled = True
        Me.ComboObjGral.Location = New System.Drawing.Point(97, 76)
        Me.ComboObjGral.Name = "ComboObjGral"
        Me.ComboObjGral.Size = New System.Drawing.Size(199, 21)
        Me.ComboObjGral.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Obj. Gral."
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(140, 199)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 24
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(59, 199)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 25
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Nombre, Me.ObjGral, Me.Ano})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(314, 44)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(455, 386)
        Me.DataGridView1.TabIndex = 26
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        Me.Id.Width = 50
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Objetivo específico"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 200
        '
        'ObjGral
        '
        Me.ObjGral.HeaderText = "Objetivo gral."
        Me.ObjGral.Name = "ObjGral"
        Me.ObjGral.Width = 200
        '
        'Ano
        '
        Me.Ano.HeaderText = "Año"
        Me.Ano.Name = "Ano"
        Me.Ano.Width = 50
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Obj. Específico"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Id"
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(97, 106)
        Me.TextNombre.Multiline = True
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(199, 71)
        Me.TextNombre.TabIndex = 23
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(97, 23)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(64, 20)
        Me.TextId.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Dimensión"
        '
        'ComboDimension
        '
        Me.ComboDimension.FormattingEnabled = True
        Me.ComboDimension.Location = New System.Drawing.Point(97, 49)
        Me.ComboDimension.Name = "ComboDimension"
        Me.ComboDimension.Size = New System.Drawing.Size(199, 21)
        Me.ComboDimension.TabIndex = 33
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(221, 199)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 34
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonTodos
        '
        Me.ButtonTodos.Location = New System.Drawing.Point(694, 12)
        Me.ButtonTodos.Name = "ButtonTodos"
        Me.ButtonTodos.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTodos.TabIndex = 35
        Me.ButtonTodos.Text = "Listar todos"
        Me.ButtonTodos.UseVisualStyleBackColor = True
        '
        'FormObjEspecifico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 442)
        Me.Controls.Add(Me.ButtonTodos)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ComboDimension)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumericAno)
        Me.Controls.Add(Me.ComboObjGral)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormObjEspecifico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Objetivos específicos"
        CType(Me.NumericAno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NumericAno As System.Windows.Forms.NumericUpDown
    Friend WithEvents ComboObjGral As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObjGral As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ano As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboDimension As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonTodos As System.Windows.Forms.Button
End Class
