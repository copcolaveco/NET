<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSubInformes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSubInformes))
        Me.TextId = New System.Windows.Forms.TextBox
        Me.TextNombre = New System.Windows.Forms.TextBox
        Me.ComboTipoInforme = New System.Windows.Forms.ComboBox
        Me.CheckGeneraPlanilla = New System.Windows.Forms.CheckBox
        Me.TextTitulo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ListSubInformes = New System.Windows.Forms.ListBox
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(103, 20)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(61, 20)
        Me.TextId.TabIndex = 0
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(103, 46)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(168, 20)
        Me.TextNombre.TabIndex = 1
        '
        'ComboTipoInforme
        '
        Me.ComboTipoInforme.FormattingEnabled = True
        Me.ComboTipoInforme.Location = New System.Drawing.Point(103, 72)
        Me.ComboTipoInforme.Name = "ComboTipoInforme"
        Me.ComboTipoInforme.Size = New System.Drawing.Size(168, 21)
        Me.ComboTipoInforme.TabIndex = 2
        '
        'CheckGeneraPlanilla
        '
        Me.CheckGeneraPlanilla.AutoSize = True
        Me.CheckGeneraPlanilla.Location = New System.Drawing.Point(103, 99)
        Me.CheckGeneraPlanilla.Name = "CheckGeneraPlanilla"
        Me.CheckGeneraPlanilla.Size = New System.Drawing.Size(96, 17)
        Me.CheckGeneraPlanilla.TabIndex = 3
        Me.CheckGeneraPlanilla.Text = "Genera planilla"
        Me.CheckGeneraPlanilla.UseVisualStyleBackColor = True
        '
        'TextTitulo
        '
        Me.TextTitulo.Location = New System.Drawing.Point(103, 122)
        Me.TextTitulo.Name = "TextTitulo"
        Me.TextTitulo.Size = New System.Drawing.Size(168, 20)
        Me.TextTitulo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Tipo de informe"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Título"
        '
        'ListSubInformes
        '
        Me.ListSubInformes.BackColor = System.Drawing.SystemColors.Info
        Me.ListSubInformes.FormattingEnabled = True
        Me.ListSubInformes.Location = New System.Drawing.Point(290, 20)
        Me.ListSubInformes.Name = "ListSubInformes"
        Me.ListSubInformes.Size = New System.Drawing.Size(203, 251)
        Me.ListSubInformes.TabIndex = 8
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(22, 243)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 6
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(103, 243)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 5
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(184, 243)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 7
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'FormSubInformes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 278)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.ListSubInformes)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextTitulo)
        Me.Controls.Add(Me.CheckGeneraPlanilla)
        Me.Controls.Add(Me.ComboTipoInforme)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.TextId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSubInformes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sub Informes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents ComboTipoInforme As System.Windows.Forms.ComboBox
    Friend WithEvents CheckGeneraPlanilla As System.Windows.Forms.CheckBox
    Friend WithEvents TextTitulo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ListSubInformes As System.Windows.Forms.ListBox
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
End Class
