<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormActividades
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericAno = New System.Windows.Forms.NumericUpDown()
        Me.ComboObjEsp = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextNombre = New System.Windows.Forms.TextBox()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.TextMeta = New System.Windows.Forms.TextBox()
        Me.TextResponsable = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DatePlazo = New System.Windows.Forms.DateTimePicker()
        Me.TextAceptable = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboDimension = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.ButtonTodos = New System.Windows.Forms.Button()
        Me.TextIndicador = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.NumericFinaliza = New System.Windows.Forms.NumericUpDown()
        CType(Me.NumericAno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericFinaliza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(199, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Año"
        '
        'NumericAno
        '
        Me.NumericAno.Location = New System.Drawing.Point(231, 18)
        Me.NumericAno.Maximum = New Decimal(New Integer() {2030, 0, 0, 0})
        Me.NumericAno.Minimum = New Decimal(New Integer() {2013, 0, 0, 0})
        Me.NumericAno.Name = "NumericAno"
        Me.NumericAno.Size = New System.Drawing.Size(64, 20)
        Me.NumericAno.TabIndex = 41
        Me.NumericAno.Value = New Decimal(New Integer() {2013, 0, 0, 0})
        '
        'ComboObjEsp
        '
        Me.ComboObjEsp.FormattingEnabled = True
        Me.ComboObjEsp.Location = New System.Drawing.Point(84, 71)
        Me.ComboObjEsp.Name = "ComboObjEsp"
        Me.ComboObjEsp.Size = New System.Drawing.Size(211, 21)
        Me.ComboObjEsp.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Obj. Esp."
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(140, 381)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 35
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(59, 381)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 36
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(312, 44)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(660, 360)
        Me.DataGridView1.TabIndex = 37
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Actividad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Id"
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(84, 101)
        Me.TextNombre.Multiline = True
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(211, 68)
        Me.TextNombre.TabIndex = 2
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(84, 18)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(64, 20)
        Me.TextId.TabIndex = 32
        '
        'TextMeta
        '
        Me.TextMeta.Location = New System.Drawing.Point(84, 238)
        Me.TextMeta.Name = "TextMeta"
        Me.TextMeta.Size = New System.Drawing.Size(100, 20)
        Me.TextMeta.TabIndex = 4
        '
        'TextResponsable
        '
        Me.TextResponsable.Location = New System.Drawing.Point(84, 290)
        Me.TextResponsable.Name = "TextResponsable"
        Me.TextResponsable.Size = New System.Drawing.Size(211, 20)
        Me.TextResponsable.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 241)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Meta"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 293)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Responsable"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 319)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Plazo"
        '
        'DatePlazo
        '
        Me.DatePlazo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePlazo.Location = New System.Drawing.Point(84, 316)
        Me.DatePlazo.Name = "DatePlazo"
        Me.DatePlazo.Size = New System.Drawing.Size(100, 20)
        Me.DatePlazo.TabIndex = 7
        '
        'TextAceptable
        '
        Me.TextAceptable.Location = New System.Drawing.Point(84, 264)
        Me.TextAceptable.Name = "TextAceptable"
        Me.TextAceptable.Size = New System.Drawing.Size(100, 20)
        Me.TextAceptable.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 267)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Aceptable"
        '
        'ComboDimension
        '
        Me.ComboDimension.FormattingEnabled = True
        Me.ComboDimension.Location = New System.Drawing.Point(84, 44)
        Me.ComboDimension.Name = "ComboDimension"
        Me.ComboDimension.Size = New System.Drawing.Size(211, 21)
        Me.ComboDimension.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Dimensión"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(220, 381)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 56
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonTodos
        '
        Me.ButtonTodos.Location = New System.Drawing.Point(897, 16)
        Me.ButtonTodos.Name = "ButtonTodos"
        Me.ButtonTodos.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTodos.TabIndex = 57
        Me.ButtonTodos.Text = "Listar todos"
        Me.ButtonTodos.UseVisualStyleBackColor = True
        '
        'TextIndicador
        '
        Me.TextIndicador.Location = New System.Drawing.Point(84, 175)
        Me.TextIndicador.Multiline = True
        Me.TextIndicador.Name = "TextIndicador"
        Me.TextIndicador.Size = New System.Drawing.Size(211, 57)
        Me.TextIndicador.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 187)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "Indicador"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 349)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "Finaliza"
        '
        'NumericFinaliza
        '
        Me.NumericFinaliza.Location = New System.Drawing.Point(84, 342)
        Me.NumericFinaliza.Maximum = New Decimal(New Integer() {2030, 0, 0, 0})
        Me.NumericFinaliza.Minimum = New Decimal(New Integer() {2013, 0, 0, 0})
        Me.NumericFinaliza.Name = "NumericFinaliza"
        Me.NumericFinaliza.Size = New System.Drawing.Size(64, 20)
        Me.NumericFinaliza.TabIndex = 60
        Me.NumericFinaliza.Value = New Decimal(New Integer() {2013, 0, 0, 0})
        '
        'FormActividades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 419)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.NumericFinaliza)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextIndicador)
        Me.Controls.Add(Me.ButtonTodos)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboDimension)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextAceptable)
        Me.Controls.Add(Me.DatePlazo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextResponsable)
        Me.Controls.Add(Me.TextMeta)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumericAno)
        Me.Controls.Add(Me.ComboObjEsp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormActividades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actividades / Indicadores"
        CType(Me.NumericAno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericFinaliza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NumericAno As System.Windows.Forms.NumericUpDown
    Friend WithEvents ComboObjEsp As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextMeta As System.Windows.Forms.TextBox
    Friend WithEvents TextResponsable As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DatePlazo As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextAceptable As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ComboDimension As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonTodos As System.Windows.Forms.Button
    Friend WithEvents TextIndicador As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents NumericFinaliza As System.Windows.Forms.NumericUpDown
End Class
