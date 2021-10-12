<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRgLab101
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
        Me.components = New System.ComponentModel.Container
        Me.ComboEquipo = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.CheckCaseina = New System.Windows.Forms.CheckBox
        Me.CheckCrioscopo = New System.Windows.Forms.CheckBox
        Me.CheckUrea2 = New System.Windows.Forms.CheckBox
        Me.CheckInhibidores = New System.Windows.Forms.CheckBox
        Me.CheckCrioscopia = New System.Windows.Forms.CheckBox
        Me.CheckComposicion2 = New System.Windows.Forms.CheckBox
        Me.CheckRC2 = New System.Windows.Forms.CheckBox
        Me.CheckRB = New System.Windows.Forms.CheckBox
        Me.CheckEsporulados = New System.Windows.Forms.CheckBox
        Me.CheckPsicrotrofos = New System.Windows.Forms.CheckBox
        Me.CheckTermofilos = New System.Windows.Forms.CheckBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.ComboOperador = New System.Windows.Forms.ComboBox
        Me.ComboAnalisis = New System.Windows.Forms.ComboBox
        Me.TextCantidad = New System.Windows.Forms.TextBox
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.TextHora = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.TextId = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox7.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboEquipo
        '
        Me.ComboEquipo.FormattingEnabled = True
        Me.ComboEquipo.Items.AddRange(New Object() {"IBC"})
        Me.ComboEquipo.Location = New System.Drawing.Point(98, 117)
        Me.ComboEquipo.Name = "ComboEquipo"
        Me.ComboEquipo.Size = New System.Drawing.Size(121, 21)
        Me.ComboEquipo.TabIndex = 75
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 74
        Me.Label12.Text = "Equipo"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CheckCaseina)
        Me.GroupBox7.Controls.Add(Me.CheckCrioscopo)
        Me.GroupBox7.Controls.Add(Me.CheckUrea2)
        Me.GroupBox7.Controls.Add(Me.CheckInhibidores)
        Me.GroupBox7.Controls.Add(Me.CheckCrioscopia)
        Me.GroupBox7.Controls.Add(Me.CheckComposicion2)
        Me.GroupBox7.Controls.Add(Me.CheckRC2)
        Me.GroupBox7.Controls.Add(Me.CheckRB)
        Me.GroupBox7.Controls.Add(Me.CheckEsporulados)
        Me.GroupBox7.Controls.Add(Me.CheckPsicrotrofos)
        Me.GroupBox7.Controls.Add(Me.CheckTermofilos)
        Me.GroupBox7.Location = New System.Drawing.Point(19, 223)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(291, 169)
        Me.GroupBox7.TabIndex = 72
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Calidad"
        '
        'CheckCaseina
        '
        Me.CheckCaseina.AutoSize = True
        Me.CheckCaseina.Location = New System.Drawing.Point(159, 118)
        Me.CheckCaseina.Name = "CheckCaseina"
        Me.CheckCaseina.Size = New System.Drawing.Size(66, 17)
        Me.CheckCaseina.TabIndex = 10
        Me.CheckCaseina.Text = "Caseína"
        Me.CheckCaseina.UseVisualStyleBackColor = True
        '
        'CheckCrioscopo
        '
        Me.CheckCrioscopo.AutoSize = True
        Me.CheckCrioscopo.Location = New System.Drawing.Point(11, 120)
        Me.CheckCrioscopo.Name = "CheckCrioscopo"
        Me.CheckCrioscopo.Size = New System.Drawing.Size(133, 17)
        Me.CheckCrioscopo.TabIndex = 4
        Me.CheckCrioscopo.Text = "Crioscopía (Crióscopo)"
        Me.CheckCrioscopo.UseVisualStyleBackColor = True
        '
        'CheckUrea2
        '
        Me.CheckUrea2.AutoSize = True
        Me.CheckUrea2.Location = New System.Drawing.Point(159, 51)
        Me.CheckUrea2.Name = "CheckUrea2"
        Me.CheckUrea2.Size = New System.Drawing.Size(49, 17)
        Me.CheckUrea2.TabIndex = 7
        Me.CheckUrea2.Text = "Urea"
        Me.CheckUrea2.UseVisualStyleBackColor = True
        '
        'CheckInhibidores
        '
        Me.CheckInhibidores.AutoSize = True
        Me.CheckInhibidores.Location = New System.Drawing.Point(11, 143)
        Me.CheckInhibidores.Name = "CheckInhibidores"
        Me.CheckInhibidores.Size = New System.Drawing.Size(77, 17)
        Me.CheckInhibidores.TabIndex = 5
        Me.CheckInhibidores.Text = "Inhibidores"
        Me.CheckInhibidores.UseVisualStyleBackColor = True
        '
        'CheckCrioscopia
        '
        Me.CheckCrioscopia.AutoSize = True
        Me.CheckCrioscopia.Location = New System.Drawing.Point(11, 97)
        Me.CheckCrioscopia.Name = "CheckCrioscopia"
        Me.CheckCrioscopia.Size = New System.Drawing.Size(111, 17)
        Me.CheckCrioscopia.TabIndex = 3
        Me.CheckCrioscopia.Text = "Crioscopía (Delta)"
        Me.CheckCrioscopia.UseVisualStyleBackColor = True
        '
        'CheckComposicion2
        '
        Me.CheckComposicion2.AutoSize = True
        Me.CheckComposicion2.Location = New System.Drawing.Point(11, 74)
        Me.CheckComposicion2.Name = "CheckComposicion2"
        Me.CheckComposicion2.Size = New System.Drawing.Size(86, 17)
        Me.CheckComposicion2.TabIndex = 2
        Me.CheckComposicion2.Text = "Composición"
        Me.CheckComposicion2.UseVisualStyleBackColor = True
        '
        'CheckRC2
        '
        Me.CheckRC2.AutoSize = True
        Me.CheckRC2.Location = New System.Drawing.Point(11, 51)
        Me.CheckRC2.Name = "CheckRC2"
        Me.CheckRC2.Size = New System.Drawing.Size(41, 17)
        Me.CheckRC2.TabIndex = 1
        Me.CheckRC2.Text = "RC"
        Me.CheckRC2.UseVisualStyleBackColor = True
        '
        'CheckRB
        '
        Me.CheckRB.AutoSize = True
        Me.CheckRB.Location = New System.Drawing.Point(11, 28)
        Me.CheckRB.Name = "CheckRB"
        Me.CheckRB.Size = New System.Drawing.Size(41, 17)
        Me.CheckRB.TabIndex = 1
        Me.CheckRB.Text = "RB"
        Me.CheckRB.UseVisualStyleBackColor = True
        '
        'CheckEsporulados
        '
        Me.CheckEsporulados.AutoSize = True
        Me.CheckEsporulados.Location = New System.Drawing.Point(159, 28)
        Me.CheckEsporulados.Name = "CheckEsporulados"
        Me.CheckEsporulados.Size = New System.Drawing.Size(131, 17)
        Me.CheckEsporulados.TabIndex = 6
        Me.CheckEsporulados.Text = "Espor. Anaer. mesófilo"
        Me.CheckEsporulados.UseVisualStyleBackColor = True
        '
        'CheckPsicrotrofos
        '
        Me.CheckPsicrotrofos.AutoSize = True
        Me.CheckPsicrotrofos.Location = New System.Drawing.Point(159, 97)
        Me.CheckPsicrotrofos.Name = "CheckPsicrotrofos"
        Me.CheckPsicrotrofos.Size = New System.Drawing.Size(81, 17)
        Me.CheckPsicrotrofos.TabIndex = 9
        Me.CheckPsicrotrofos.Text = "Psicrotrofos"
        Me.CheckPsicrotrofos.UseVisualStyleBackColor = True
        '
        'CheckTermofilos
        '
        Me.CheckTermofilos.AutoSize = True
        Me.CheckTermofilos.Location = New System.Drawing.Point(159, 74)
        Me.CheckTermofilos.Name = "CheckTermofilos"
        Me.CheckTermofilos.Size = New System.Drawing.Size(74, 17)
        Me.CheckTermofilos.TabIndex = 8
        Me.CheckTermofilos.Text = "Termofilos"
        Me.CheckTermofilos.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Ficha})
        Me.DataGridView1.Location = New System.Drawing.Point(316, 39)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(207, 561)
        Me.DataGridView1.TabIndex = 71
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
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(206, 577)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 70
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(125, 577)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 69
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(44, 577)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 68
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 433)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Observaciones"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 406)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Operador"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Analisis"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 173)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Cantidad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Ficha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Hora"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Id"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(98, 430)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(183, 130)
        Me.TextObservaciones.TabIndex = 56
        '
        'ComboOperador
        '
        Me.ComboOperador.FormattingEnabled = True
        Me.ComboOperador.Location = New System.Drawing.Point(98, 403)
        Me.ComboOperador.Name = "ComboOperador"
        Me.ComboOperador.Size = New System.Drawing.Size(183, 21)
        Me.ComboOperador.TabIndex = 52
        '
        'ComboAnalisis
        '
        Me.ComboAnalisis.FormattingEnabled = True
        Me.ComboAnalisis.Location = New System.Drawing.Point(98, 196)
        Me.ComboAnalisis.Name = "ComboAnalisis"
        Me.ComboAnalisis.Size = New System.Drawing.Size(183, 21)
        Me.ComboAnalisis.TabIndex = 51
        '
        'TextCantidad
        '
        Me.TextCantidad.Location = New System.Drawing.Point(98, 170)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.Size = New System.Drawing.Size(75, 20)
        Me.TextCantidad.TabIndex = 50
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(98, 144)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(75, 20)
        Me.TextFicha.TabIndex = 49
        '
        'TextHora
        '
        Me.TextHora.Location = New System.Drawing.Point(98, 91)
        Me.TextHora.Name = "TextHora"
        Me.TextHora.Size = New System.Drawing.Size(75, 20)
        Me.TextHora.TabIndex = 48
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(98, 65)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 47
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(98, 39)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(75, 20)
        Me.TextId.TabIndex = 46
        '
        'Timer1
        '
        Me.Timer1.Interval = 60000
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(505, 18)
        Me.Label13.TabIndex = 76
        Me.Label13.Text = "Verificación del pedido del cliente, por parte del analista, en calidad de leche." & _
            ""
        '
        'FormRgLab101
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 612)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ComboEquipo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.ComboOperador)
        Me.Controls.Add(Me.ComboAnalisis)
        Me.Controls.Add(Me.TextCantidad)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.TextHora)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormRgLab101"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RG.LAB 101"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboEquipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckCaseina As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCrioscopo As System.Windows.Forms.CheckBox
    Friend WithEvents CheckUrea2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckInhibidores As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCrioscopia As System.Windows.Forms.CheckBox
    Friend WithEvents CheckComposicion2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckRC2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckRB As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEsporulados As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPsicrotrofos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckTermofilos As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents ComboOperador As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAnalisis As System.Windows.Forms.ComboBox
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents TextHora As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
