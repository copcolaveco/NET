<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFiltrarProductor
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
        Me.ComboLocalidad = New System.Windows.Forms.ComboBox()
        Me.ComboDepartamento = New System.Windows.Forms.ComboBox()
        Me.TextNombre = New System.Windows.Forms.TextBox()
        Me.CheckProlesa = New System.Windows.Forms.CheckBox()
        Me.CheckCaravanas = New System.Windows.Forms.CheckBox()
        Me.CheckContado = New System.Windows.Forms.CheckBox()
        Me.CheckMoroso = New System.Windows.Forms.CheckBox()
        Me.CheckNousar = New System.Windows.Forms.CheckBox()
        Me.CheckContrato = New System.Windows.Forms.CheckBox()
        Me.CheckSocio = New System.Windows.Forms.CheckBox()
        Me.ButtonFiltrar = New System.Windows.Forms.Button()
        Me.CheckNombre = New System.Windows.Forms.CheckBox()
        Me.CheckDepartamento = New System.Windows.Forms.CheckBox()
        Me.CheckLocalidad = New System.Windows.Forms.CheckBox()
        Me.CheckSinUsuario = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'ComboLocalidad
        '
        Me.ComboLocalidad.Enabled = False
        Me.ComboLocalidad.FormattingEnabled = True
        Me.ComboLocalidad.Location = New System.Drawing.Point(108, 70)
        Me.ComboLocalidad.Name = "ComboLocalidad"
        Me.ComboLocalidad.Size = New System.Drawing.Size(145, 21)
        Me.ComboLocalidad.TabIndex = 18
        '
        'ComboDepartamento
        '
        Me.ComboDepartamento.Enabled = False
        Me.ComboDepartamento.FormattingEnabled = True
        Me.ComboDepartamento.Location = New System.Drawing.Point(108, 43)
        Me.ComboDepartamento.Name = "ComboDepartamento"
        Me.ComboDepartamento.Size = New System.Drawing.Size(145, 21)
        Me.ComboDepartamento.TabIndex = 17
        '
        'TextNombre
        '
        Me.TextNombre.Enabled = False
        Me.TextNombre.Location = New System.Drawing.Point(108, 17)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(194, 20)
        Me.TextNombre.TabIndex = 22
        '
        'CheckProlesa
        '
        Me.CheckProlesa.AutoSize = True
        Me.CheckProlesa.Enabled = False
        Me.CheckProlesa.Location = New System.Drawing.Point(12, 210)
        Me.CheckProlesa.Name = "CheckProlesa"
        Me.CheckProlesa.Size = New System.Drawing.Size(61, 17)
        Me.CheckProlesa.TabIndex = 100
        Me.CheckProlesa.Text = "Prolesa"
        Me.CheckProlesa.UseVisualStyleBackColor = True
        '
        'CheckCaravanas
        '
        Me.CheckCaravanas.AutoSize = True
        Me.CheckCaravanas.Enabled = False
        Me.CheckCaravanas.Location = New System.Drawing.Point(12, 233)
        Me.CheckCaravanas.Name = "CheckCaravanas"
        Me.CheckCaravanas.Size = New System.Drawing.Size(177, 17)
        Me.CheckCaravanas.TabIndex = 99
        Me.CheckCaravanas.Text = "Se realiza cambio de caravanas"
        Me.CheckCaravanas.UseVisualStyleBackColor = True
        '
        'CheckContado
        '
        Me.CheckContado.AutoSize = True
        Me.CheckContado.Enabled = False
        Me.CheckContado.Location = New System.Drawing.Point(12, 118)
        Me.CheckContado.Name = "CheckContado"
        Me.CheckContado.Size = New System.Drawing.Size(89, 17)
        Me.CheckContado.TabIndex = 98
        Me.CheckContado.Text = "Solo contado"
        Me.CheckContado.UseVisualStyleBackColor = True
        '
        'CheckMoroso
        '
        Me.CheckMoroso.AutoSize = True
        Me.CheckMoroso.Enabled = False
        Me.CheckMoroso.Location = New System.Drawing.Point(12, 95)
        Me.CheckMoroso.Name = "CheckMoroso"
        Me.CheckMoroso.Size = New System.Drawing.Size(61, 17)
        Me.CheckMoroso.TabIndex = 97
        Me.CheckMoroso.Text = "Moroso"
        Me.CheckMoroso.UseVisualStyleBackColor = True
        '
        'CheckNousar
        '
        Me.CheckNousar.AutoSize = True
        Me.CheckNousar.Enabled = False
        Me.CheckNousar.Location = New System.Drawing.Point(12, 187)
        Me.CheckNousar.Name = "CheckNousar"
        Me.CheckNousar.Size = New System.Drawing.Size(159, 17)
        Me.CheckNousar.TabIndex = 96
        Me.CheckNousar.Text = "No usar / ocultar en listados"
        Me.CheckNousar.UseVisualStyleBackColor = True
        '
        'CheckContrato
        '
        Me.CheckContrato.AutoSize = True
        Me.CheckContrato.Enabled = False
        Me.CheckContrato.Location = New System.Drawing.Point(12, 141)
        Me.CheckContrato.Name = "CheckContrato"
        Me.CheckContrato.Size = New System.Drawing.Size(66, 17)
        Me.CheckContrato.TabIndex = 94
        Me.CheckContrato.Text = "Contrato"
        Me.CheckContrato.UseVisualStyleBackColor = True
        '
        'CheckSocio
        '
        Me.CheckSocio.AutoSize = True
        Me.CheckSocio.Enabled = False
        Me.CheckSocio.Location = New System.Drawing.Point(12, 164)
        Me.CheckSocio.Name = "CheckSocio"
        Me.CheckSocio.Size = New System.Drawing.Size(53, 17)
        Me.CheckSocio.TabIndex = 95
        Me.CheckSocio.Text = "Socio"
        Me.CheckSocio.UseVisualStyleBackColor = True
        '
        'ButtonFiltrar
        '
        Me.ButtonFiltrar.Location = New System.Drawing.Point(277, 263)
        Me.ButtonFiltrar.Name = "ButtonFiltrar"
        Me.ButtonFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFiltrar.TabIndex = 101
        Me.ButtonFiltrar.Text = "Filtrar"
        Me.ButtonFiltrar.UseVisualStyleBackColor = True
        '
        'CheckNombre
        '
        Me.CheckNombre.AutoSize = True
        Me.CheckNombre.Enabled = False
        Me.CheckNombre.Location = New System.Drawing.Point(12, 20)
        Me.CheckNombre.Name = "CheckNombre"
        Me.CheckNombre.Size = New System.Drawing.Size(63, 17)
        Me.CheckNombre.TabIndex = 102
        Me.CheckNombre.Text = "Nombre"
        Me.CheckNombre.UseVisualStyleBackColor = True
        '
        'CheckDepartamento
        '
        Me.CheckDepartamento.AutoSize = True
        Me.CheckDepartamento.Location = New System.Drawing.Point(12, 47)
        Me.CheckDepartamento.Name = "CheckDepartamento"
        Me.CheckDepartamento.Size = New System.Drawing.Size(93, 17)
        Me.CheckDepartamento.TabIndex = 103
        Me.CheckDepartamento.Text = "Departamento"
        Me.CheckDepartamento.UseVisualStyleBackColor = True
        '
        'CheckLocalidad
        '
        Me.CheckLocalidad.AutoSize = True
        Me.CheckLocalidad.Enabled = False
        Me.CheckLocalidad.Location = New System.Drawing.Point(12, 72)
        Me.CheckLocalidad.Name = "CheckLocalidad"
        Me.CheckLocalidad.Size = New System.Drawing.Size(72, 17)
        Me.CheckLocalidad.TabIndex = 104
        Me.CheckLocalidad.Text = "Localidad"
        Me.CheckLocalidad.UseVisualStyleBackColor = True
        '
        'CheckSinUsuario
        '
        Me.CheckSinUsuario.AutoSize = True
        Me.CheckSinUsuario.Enabled = False
        Me.CheckSinUsuario.Location = New System.Drawing.Point(12, 256)
        Me.CheckSinUsuario.Name = "CheckSinUsuario"
        Me.CheckSinUsuario.Size = New System.Drawing.Size(101, 17)
        Me.CheckSinUsuario.TabIndex = 105
        Me.CheckSinUsuario.Text = "Sin usuario web"
        Me.CheckSinUsuario.UseVisualStyleBackColor = True
        '
        'FormFiltrarProductor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 298)
        Me.Controls.Add(Me.CheckSinUsuario)
        Me.Controls.Add(Me.CheckLocalidad)
        Me.Controls.Add(Me.CheckDepartamento)
        Me.Controls.Add(Me.CheckNombre)
        Me.Controls.Add(Me.ButtonFiltrar)
        Me.Controls.Add(Me.CheckProlesa)
        Me.Controls.Add(Me.CheckCaravanas)
        Me.Controls.Add(Me.CheckContado)
        Me.Controls.Add(Me.CheckMoroso)
        Me.Controls.Add(Me.CheckNousar)
        Me.Controls.Add(Me.CheckContrato)
        Me.Controls.Add(Me.CheckSocio)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.ComboLocalidad)
        Me.Controls.Add(Me.ComboDepartamento)
        Me.Name = "FormFiltrarProductor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prodctores (filtros)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboLocalidad As System.Windows.Forms.ComboBox
    Friend WithEvents ComboDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents CheckProlesa As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCaravanas As System.Windows.Forms.CheckBox
    Friend WithEvents CheckContado As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMoroso As System.Windows.Forms.CheckBox
    Friend WithEvents CheckNousar As System.Windows.Forms.CheckBox
    Friend WithEvents CheckContrato As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSocio As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonFiltrar As System.Windows.Forms.Button
    Friend WithEvents CheckNombre As System.Windows.Forms.CheckBox
    Friend WithEvents CheckDepartamento As System.Windows.Forms.CheckBox
    Friend WithEvents CheckLocalidad As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSinUsuario As System.Windows.Forms.CheckBox
End Class
