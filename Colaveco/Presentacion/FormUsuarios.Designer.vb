<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUsuarios
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
        Me.TextNombre = New System.Windows.Forms.TextBox
        Me.ComboSexo = New System.Windows.Forms.ComboBox
        Me.TextCI = New System.Windows.Forms.TextBox
        Me.ComboTipoUsuario = New System.Windows.Forms.ComboBox
        Me.ComboSector = New System.Windows.Forms.ComboBox
        Me.TextUsuario = New System.Windows.Forms.TextBox
        Me.TextPassword = New System.Windows.Forms.TextBox
        Me.CheckEliminado = New System.Windows.Forms.CheckBox
        Me.TextFoto = New System.Windows.Forms.TextBox
        Me.TextEntrada = New System.Windows.Forms.TextBox
        Me.TextSalida = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sexo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CI = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(124, 12)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(55, 20)
        Me.TextId.TabIndex = 0
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(124, 38)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(216, 20)
        Me.TextNombre.TabIndex = 1
        '
        'ComboSexo
        '
        Me.ComboSexo.FormattingEnabled = True
        Me.ComboSexo.Location = New System.Drawing.Point(124, 64)
        Me.ComboSexo.Name = "ComboSexo"
        Me.ComboSexo.Size = New System.Drawing.Size(55, 21)
        Me.ComboSexo.TabIndex = 2
        '
        'TextCI
        '
        Me.TextCI.Location = New System.Drawing.Point(124, 91)
        Me.TextCI.Name = "TextCI"
        Me.TextCI.Size = New System.Drawing.Size(100, 20)
        Me.TextCI.TabIndex = 3
        '
        'ComboTipoUsuario
        '
        Me.ComboTipoUsuario.FormattingEnabled = True
        Me.ComboTipoUsuario.Location = New System.Drawing.Point(124, 117)
        Me.ComboTipoUsuario.Name = "ComboTipoUsuario"
        Me.ComboTipoUsuario.Size = New System.Drawing.Size(150, 21)
        Me.ComboTipoUsuario.TabIndex = 4
        '
        'ComboSector
        '
        Me.ComboSector.FormattingEnabled = True
        Me.ComboSector.Location = New System.Drawing.Point(124, 144)
        Me.ComboSector.Name = "ComboSector"
        Me.ComboSector.Size = New System.Drawing.Size(150, 21)
        Me.ComboSector.TabIndex = 5
        '
        'TextUsuario
        '
        Me.TextUsuario.Location = New System.Drawing.Point(124, 171)
        Me.TextUsuario.Name = "TextUsuario"
        Me.TextUsuario.Size = New System.Drawing.Size(100, 20)
        Me.TextUsuario.TabIndex = 6
        '
        'TextPassword
        '
        Me.TextPassword.Location = New System.Drawing.Point(124, 197)
        Me.TextPassword.Name = "TextPassword"
        Me.TextPassword.Size = New System.Drawing.Size(100, 20)
        Me.TextPassword.TabIndex = 7
        '
        'CheckEliminado
        '
        Me.CheckEliminado.AutoSize = True
        Me.CheckEliminado.Location = New System.Drawing.Point(24, 322)
        Me.CheckEliminado.Name = "CheckEliminado"
        Me.CheckEliminado.Size = New System.Drawing.Size(71, 17)
        Me.CheckEliminado.TabIndex = 8
        Me.CheckEliminado.Text = "Eliminado"
        Me.CheckEliminado.UseVisualStyleBackColor = True
        '
        'TextFoto
        '
        Me.TextFoto.Location = New System.Drawing.Point(124, 223)
        Me.TextFoto.Name = "TextFoto"
        Me.TextFoto.Size = New System.Drawing.Size(150, 20)
        Me.TextFoto.TabIndex = 9
        '
        'TextEntrada
        '
        Me.TextEntrada.Location = New System.Drawing.Point(124, 249)
        Me.TextEntrada.Name = "TextEntrada"
        Me.TextEntrada.Size = New System.Drawing.Size(55, 20)
        Me.TextEntrada.TabIndex = 10
        '
        'TextSalida
        '
        Me.TextSalida.Location = New System.Drawing.Point(124, 275)
        Me.TextSalida.Name = "TextSalida"
        Me.TextSalida.Size = New System.Drawing.Size(55, 20)
        Me.TextSalida.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Sexo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Doc. Identidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Tipo de usuario"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Sector"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Usuario"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 200)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Contraseña"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 226)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Foto"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 252)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Horario de entrada"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 278)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Horario de salida"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(24, 376)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 23
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(105, 376)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 24
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Nombre, Me.Sexo, Me.CI})
        Me.DataGridView1.Location = New System.Drawing.Point(366, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(491, 387)
        Me.DataGridView1.TabIndex = 25
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 250
        '
        'Sexo
        '
        Me.Sexo.HeaderText = "Sexo"
        Me.Sexo.Name = "Sexo"
        Me.Sexo.Width = 50
        '
        'CI
        '
        Me.CI.HeaderText = "Doc. Identidad"
        Me.CI.Name = "CI"
        Me.CI.Width = 120
        '
        'FormUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 416)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextSalida)
        Me.Controls.Add(Me.TextEntrada)
        Me.Controls.Add(Me.TextFoto)
        Me.Controls.Add(Me.CheckEliminado)
        Me.Controls.Add(Me.TextPassword)
        Me.Controls.Add(Me.TextUsuario)
        Me.Controls.Add(Me.ComboSector)
        Me.Controls.Add(Me.ComboTipoUsuario)
        Me.Controls.Add(Me.TextCI)
        Me.Controls.Add(Me.ComboSexo)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents ComboSexo As System.Windows.Forms.ComboBox
    Friend WithEvents TextCI As System.Windows.Forms.TextBox
    Friend WithEvents ComboTipoUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents ComboSector As System.Windows.Forms.ComboBox
    Friend WithEvents TextUsuario As System.Windows.Forms.TextBox
    Friend WithEvents TextPassword As System.Windows.Forms.TextBox
    Friend WithEvents CheckEliminado As System.Windows.Forms.CheckBox
    Friend WithEvents TextFoto As System.Windows.Forms.TextBox
    Friend WithEvents TextEntrada As System.Windows.Forms.TextBox
    Friend WithEvents TextSalida As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sexo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CI As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
