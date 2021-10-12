<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGestor
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
        Me.DateDesde = New System.Windows.Forms.DateTimePicker()
        Me.ButtonSubirCtaCte = New System.Windows.Forms.Button()
        Me.ButtonBuscarCliente = New System.Windows.Forms.Button()
        Me.TextIdCliente = New System.Windows.Forms.TextBox()
        Me.TextCliente = New System.Windows.Forms.TextBox()
        Me.ButtonCtaCtexCliente = New System.Windows.Forms.Button()
        Me.DateHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextFicha = New System.Windows.Forms.TextBox()
        Me.ButtonSubirFicha = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboEstado = New System.Windows.Forms.ComboBox()
        Me.ButtonEstado = New System.Windows.Forms.Button()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.TextComentarios = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ButtonCambiarEstado = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HerramientasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubirFichasEnMasaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ComboEstado2 = New System.Windows.Forms.ComboBox()
        Me.TextFichaHasta = New System.Windows.Forms.TextBox()
        Me.TextFichaDesde = New System.Windows.Forms.TextBox()
        Me.SubirInformes = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(21, 46)
        Me.DateDesde.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(125, 22)
        Me.DateDesde.TabIndex = 50
        '
        'ButtonSubirCtaCte
        '
        Me.ButtonSubirCtaCte.Location = New System.Drawing.Point(21, 78)
        Me.ButtonSubirCtaCte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonSubirCtaCte.Name = "ButtonSubirCtaCte"
        Me.ButtonSubirCtaCte.Size = New System.Drawing.Size(261, 28)
        Me.ButtonSubirCtaCte.TabIndex = 49
        Me.ButtonSubirCtaCte.Text = "Subir"
        Me.ButtonSubirCtaCte.UseVisualStyleBackColor = True
        '
        'ButtonBuscarCliente
        '
        Me.ButtonBuscarCliente.Location = New System.Drawing.Point(15, 59)
        Me.ButtonBuscarCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonBuscarCliente.Name = "ButtonBuscarCliente"
        Me.ButtonBuscarCliente.Size = New System.Drawing.Size(111, 28)
        Me.ButtonBuscarCliente.TabIndex = 52
        Me.ButtonBuscarCliente.Text = "Buscar cliente"
        Me.ButtonBuscarCliente.UseVisualStyleBackColor = True
        '
        'TextIdCliente
        '
        Me.TextIdCliente.Location = New System.Drawing.Point(15, 27)
        Me.TextIdCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextIdCliente.Name = "TextIdCliente"
        Me.TextIdCliente.ReadOnly = True
        Me.TextIdCliente.Size = New System.Drawing.Size(53, 22)
        Me.TextIdCliente.TabIndex = 53
        '
        'TextCliente
        '
        Me.TextCliente.Location = New System.Drawing.Point(77, 27)
        Me.TextCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextCliente.Name = "TextCliente"
        Me.TextCliente.ReadOnly = True
        Me.TextCliente.Size = New System.Drawing.Size(392, 22)
        Me.TextCliente.TabIndex = 54
        '
        'ButtonCtaCtexCliente
        '
        Me.ButtonCtaCtexCliente.Location = New System.Drawing.Point(137, 59)
        Me.ButtonCtaCtexCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonCtaCtexCliente.Name = "ButtonCtaCtexCliente"
        Me.ButtonCtaCtexCliente.Size = New System.Drawing.Size(193, 28)
        Me.ButtonCtaCtexCliente.TabIndex = 55
        Me.ButtonCtaCtexCliente.Text = "Subir cuenta corriente"
        Me.ButtonCtaCtexCliente.UseVisualStyleBackColor = True
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(156, 46)
        Me.DateHasta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(125, 22)
        Me.DateHasta.TabIndex = 56
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 17)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Desde"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(193, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 17)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Hasta"
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(8, 47)
        Me.TextFicha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(151, 23)
        Me.TextFicha.TabIndex = 59
        Me.TextFicha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonSubirFicha
        '
        Me.ButtonSubirFicha.Location = New System.Drawing.Point(273, 159)
        Me.ButtonSubirFicha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonSubirFicha.Name = "ButtonSubirFicha"
        Me.ButtonSubirFicha.Size = New System.Drawing.Size(196, 28)
        Me.ButtonSubirFicha.TabIndex = 60
        Me.ButtonSubirFicha.Text = "Subir ficha"
        Me.ButtonSubirFicha.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 17)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Ficha"
        '
        'ComboEstado
        '
        Me.ComboEstado.FormattingEnabled = True
        Me.ComboEstado.Items.AddRange(New Object() {"Abonado", "No abonado (con visualización)", "No abonado (sin visualización)"})
        Me.ComboEstado.Location = New System.Drawing.Point(168, 47)
        Me.ComboEstado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboEstado.Name = "ComboEstado"
        Me.ComboEstado.Size = New System.Drawing.Size(160, 25)
        Me.ComboEstado.TabIndex = 62
        '
        'ButtonEstado
        '
        Me.ButtonEstado.Location = New System.Drawing.Point(429, 10)
        Me.ButtonEstado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonEstado.Name = "ButtonEstado"
        Me.ButtonEstado.Size = New System.Drawing.Size(44, 26)
        Me.ButtonEstado.TabIndex = 63
        Me.ButtonEstado.Text = "Cambiar Estado"
        Me.ButtonEstado.UseVisualStyleBackColor = True
        Me.ButtonEstado.Visible = False
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(337, 48)
        Me.DateFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(131, 23)
        Me.DateFecha.TabIndex = 64
        '
        'TextComentarios
        '
        Me.TextComentarios.Location = New System.Drawing.Point(8, 98)
        Me.TextComentarios.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextComentarios.Multiline = True
        Me.TextComentarios.Name = "TextComentarios"
        Me.TextComentarios.Size = New System.Drawing.Size(460, 52)
        Me.TextComentarios.TabIndex = 65
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 79)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 17)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Comentarios"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox1.Controls.Add(Me.DateDesde)
        Me.GroupBox1.Controls.Add(Me.ButtonSubirCtaCte)
        Me.GroupBox1.Controls.Add(Me.DateHasta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 428)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(483, 123)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Subir cuentas corrientes por día"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox2.Controls.Add(Me.ButtonCtaCtexCliente)
        Me.GroupBox2.Controls.Add(Me.ButtonBuscarCliente)
        Me.GroupBox2.Controls.Add(Me.TextIdCliente)
        Me.GroupBox2.Controls.Add(Me.TextCliente)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 294)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(483, 107)
        Me.GroupBox2.TabIndex = 68
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Subir cuenta corriente por cliente"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox3.Controls.Add(Me.ButtonCambiarEstado)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.ButtonEstado)
        Me.GroupBox3.Controls.Add(Me.ButtonSubirFicha)
        Me.GroupBox3.Controls.Add(Me.TextFicha)
        Me.GroupBox3.Controls.Add(Me.TextComentarios)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.ComboEstado)
        Me.GroupBox3.Controls.Add(Me.DateFecha)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(15, 62)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(481, 194)
        Me.GroupBox3.TabIndex = 69
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Subir ficha / Cambiar estado en el gestor nuevo"
        '
        'ButtonCambiarEstado
        '
        Me.ButtonCambiarEstado.Location = New System.Drawing.Point(8, 159)
        Me.ButtonCambiarEstado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonCambiarEstado.Name = "ButtonCambiarEstado"
        Me.ButtonCambiarEstado.Size = New System.Drawing.Size(196, 28)
        Me.ButtonCambiarEstado.TabIndex = 72
        Me.ButtonCambiarEstado.Text = "Cambiar estado"
        Me.ButtonCambiarEstado.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(357, 28)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 17)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(219, 27)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Estado"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HerramientasToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(513, 28)
        Me.MenuStrip1.TabIndex = 70
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HerramientasToolStripMenuItem
        '
        Me.HerramientasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SubirFichasEnMasaToolStripMenuItem})
        Me.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem"
        Me.HerramientasToolStripMenuItem.Size = New System.Drawing.Size(110, 24)
        Me.HerramientasToolStripMenuItem.Text = "Herramientas"
        '
        'SubirFichasEnMasaToolStripMenuItem
        '
        Me.SubirFichasEnMasaToolStripMenuItem.Name = "SubirFichasEnMasaToolStripMenuItem"
        Me.SubirFichasEnMasaToolStripMenuItem.Size = New System.Drawing.Size(213, 24)
        Me.SubirFichasEnMasaToolStripMenuItem.Text = "Subir fichas en masa"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox4.Controls.Add(Me.ComboEstado2)
        Me.GroupBox4.Controls.Add(Me.TextFichaHasta)
        Me.GroupBox4.Controls.Add(Me.TextFichaDesde)
        Me.GroupBox4.Controls.Add(Me.SubirInformes)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 570)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(483, 123)
        Me.GroupBox4.TabIndex = 68
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Subir informes"
        '
        'ComboEstado2
        '
        Me.ComboEstado2.FormattingEnabled = True
        Me.ComboEstado2.Items.AddRange(New Object() {"Abonado", "No abonado (con visualización)", "No abonado (sin visualización)"})
        Me.ComboEstado2.Location = New System.Drawing.Point(245, 46)
        Me.ComboEstado2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboEstado2.Name = "ComboEstado2"
        Me.ComboEstado2.Size = New System.Drawing.Size(160, 24)
        Me.ComboEstado2.TabIndex = 73
        '
        'TextFichaHasta
        '
        Me.TextFichaHasta.Location = New System.Drawing.Point(133, 46)
        Me.TextFichaHasta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextFichaHasta.Name = "TextFichaHasta"
        Me.TextFichaHasta.Size = New System.Drawing.Size(103, 22)
        Me.TextFichaHasta.TabIndex = 74
        Me.TextFichaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextFichaDesde
        '
        Me.TextFichaDesde.Location = New System.Drawing.Point(21, 46)
        Me.TextFichaDesde.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextFichaDesde.Name = "TextFichaDesde"
        Me.TextFichaDesde.Size = New System.Drawing.Size(103, 22)
        Me.TextFichaDesde.TabIndex = 73
        Me.TextFichaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SubirInformes
        '
        Me.SubirInformes.Location = New System.Drawing.Point(21, 78)
        Me.SubirInformes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SubirInformes.Name = "SubirInformes"
        Me.SubirInformes.Size = New System.Drawing.Size(261, 28)
        Me.SubirInformes.TabIndex = 49
        Me.SubirInformes.Text = "Subir informes"
        Me.SubirInformes.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(57, 26)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 17)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Desde"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(164, 26)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 17)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Hasta"
        '
        'FormGestor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 773)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormGestor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Gestor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonSubirCtaCte As System.Windows.Forms.Button
    Friend WithEvents ButtonBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents TextIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents TextCliente As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCtaCtexCliente As System.Windows.Forms.Button
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSubirFicha As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonEstado As System.Windows.Forms.Button
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextComentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonCambiarEstado As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HerramientasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubirFichasEnMasaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TextFichaHasta As System.Windows.Forms.TextBox
    Friend WithEvents TextFichaDesde As System.Windows.Forms.TextBox
    Friend WithEvents SubirInformes As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboEstado2 As System.Windows.Forms.ComboBox
End Class
