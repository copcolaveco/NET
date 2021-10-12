<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCapacitacion
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
        Me.ComboArea = New System.Windows.Forms.ComboBox
        Me.TextObjetivos = New System.Windows.Forms.TextBox
        Me.TextCapacitacion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ano = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Objetivos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ButtonNueva = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonCompletar = New System.Windows.Forms.Button
        Me.NumericAno = New System.Windows.Forms.NumericUpDown
        Me.ButtonCopia = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericAno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(125, 12)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(75, 20)
        Me.TextId.TabIndex = 0
        '
        'ComboArea
        '
        Me.ComboArea.FormattingEnabled = True
        Me.ComboArea.Location = New System.Drawing.Point(125, 65)
        Me.ComboArea.Name = "ComboArea"
        Me.ComboArea.Size = New System.Drawing.Size(171, 21)
        Me.ComboArea.TabIndex = 2
        '
        'TextObjetivos
        '
        Me.TextObjetivos.Location = New System.Drawing.Point(125, 92)
        Me.TextObjetivos.Multiline = True
        Me.TextObjetivos.Name = "TextObjetivos"
        Me.TextObjetivos.Size = New System.Drawing.Size(385, 104)
        Me.TextObjetivos.TabIndex = 3
        '
        'TextCapacitacion
        '
        Me.TextCapacitacion.Location = New System.Drawing.Point(125, 202)
        Me.TextCapacitacion.Multiline = True
        Me.TextCapacitacion.Name = "TextCapacitacion"
        Me.TextCapacitacion.Size = New System.Drawing.Size(385, 87)
        Me.TextCapacitacion.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Año"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Área"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Objetivos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Capacitación"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Ano, Me.Area, Me.Objetivos})
        Me.DataGridView1.Location = New System.Drawing.Point(525, 15)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(512, 306)
        Me.DataGridView1.TabIndex = 12
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        Me.Id.Width = 50
        '
        'Ano
        '
        Me.Ano.HeaderText = "Año"
        Me.Ano.Name = "Ano"
        Me.Ano.Width = 50
        '
        'Area
        '
        Me.Area.HeaderText = "Área"
        Me.Area.Name = "Area"
        '
        'Objetivos
        '
        Me.Objetivos.HeaderText = "Objetivos"
        Me.Objetivos.Name = "Objetivos"
        Me.Objetivos.Width = 600
        '
        'ButtonNueva
        '
        Me.ButtonNueva.Location = New System.Drawing.Point(15, 295)
        Me.ButtonNueva.Name = "ButtonNueva"
        Me.ButtonNueva.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNueva.TabIndex = 13
        Me.ButtonNueva.Text = "Nueva"
        Me.ButtonNueva.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(96, 295)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 14
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(177, 295)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 15
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonCompletar
        '
        Me.ButtonCompletar.Location = New System.Drawing.Point(258, 295)
        Me.ButtonCompletar.Name = "ButtonCompletar"
        Me.ButtonCompletar.Size = New System.Drawing.Size(137, 23)
        Me.ButtonCompletar.TabIndex = 16
        Me.ButtonCompletar.Text = "Completar capacitación"
        Me.ButtonCompletar.UseVisualStyleBackColor = True
        '
        'NumericAno
        '
        Me.NumericAno.Location = New System.Drawing.Point(125, 39)
        Me.NumericAno.Maximum = New Decimal(New Integer() {2030, 0, 0, 0})
        Me.NumericAno.Minimum = New Decimal(New Integer() {2013, 0, 0, 0})
        Me.NumericAno.Name = "NumericAno"
        Me.NumericAno.Size = New System.Drawing.Size(64, 20)
        Me.NumericAno.TabIndex = 17
        Me.NumericAno.Value = New Decimal(New Integer() {2013, 0, 0, 0})
        '
        'ButtonCopia
        '
        Me.ButtonCopia.Location = New System.Drawing.Point(15, 266)
        Me.ButtonCopia.Name = "ButtonCopia"
        Me.ButtonCopia.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCopia.TabIndex = 18
        Me.ButtonCopia.Text = "Crear copia"
        Me.ButtonCopia.UseVisualStyleBackColor = True
        '
        'FormCapacitacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 331)
        Me.Controls.Add(Me.ButtonCopia)
        Me.Controls.Add(Me.NumericAno)
        Me.Controls.Add(Me.ButtonCompletar)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNueva)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextCapacitacion)
        Me.Controls.Add(Me.TextObjetivos)
        Me.Controls.Add(Me.ComboArea)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormCapacitacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Capacitación"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericAno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents ComboArea As System.Windows.Forms.ComboBox
    Friend WithEvents TextObjetivos As System.Windows.Forms.TextBox
    Friend WithEvents TextCapacitacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonNueva As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonCompletar As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ano As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Objetivos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumericAno As System.Windows.Forms.NumericUpDown
    Friend WithEvents ButtonCopia As System.Windows.Forms.Button
End Class
