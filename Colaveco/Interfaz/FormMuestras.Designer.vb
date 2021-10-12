<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMuestras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMuestras))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.TextNombre = New System.Windows.Forms.TextBox()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.ComboTipoInforme = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckNoUsar = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Muestra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Informe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckAcreditado = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(80, 25)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(61, 20)
        Me.TextId.TabIndex = 0
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(78, 51)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(187, 20)
        Me.TextNombre.TabIndex = 1
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(29, 161)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 3
        Me.ButtonNuevo.Text = "Nueva"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(110, 161)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 2
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Location = New System.Drawing.Point(188, 161)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBorrar.TabIndex = 4
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ComboTipoInforme
        '
        Me.ComboTipoInforme.FormattingEnabled = True
        Me.ComboTipoInforme.Location = New System.Drawing.Point(78, 77)
        Me.ComboTipoInforme.Name = "ComboTipoInforme"
        Me.ComboTipoInforme.Size = New System.Drawing.Size(187, 21)
        Me.ComboTipoInforme.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Informe"
        '
        'CheckNoUsar
        '
        Me.CheckNoUsar.AutoSize = True
        Me.CheckNoUsar.Location = New System.Drawing.Point(80, 127)
        Me.CheckNoUsar.Name = "CheckNoUsar"
        Me.CheckNoUsar.Size = New System.Drawing.Size(63, 17)
        Me.CheckNoUsar.TabIndex = 8
        Me.CheckNoUsar.Text = "No usar"
        Me.CheckNoUsar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Muestra, Me.Informe})
        Me.DataGridView1.Location = New System.Drawing.Point(289, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(366, 309)
        Me.DataGridView1.TabIndex = 9
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Muestra
        '
        Me.Muestra.HeaderText = "Muestra"
        Me.Muestra.Name = "Muestra"
        Me.Muestra.Width = 150
        '
        'Informe
        '
        Me.Informe.HeaderText = "Informe"
        Me.Informe.Name = "Informe"
        Me.Informe.Width = 200
        '
        'CheckAcreditado
        '
        Me.CheckAcreditado.AutoSize = True
        Me.CheckAcreditado.Location = New System.Drawing.Point(80, 104)
        Me.CheckAcreditado.Name = "CheckAcreditado"
        Me.CheckAcreditado.Size = New System.Drawing.Size(77, 17)
        Me.CheckAcreditado.TabIndex = 10
        Me.CheckAcreditado.Text = "Acreditado"
        Me.CheckAcreditado.UseVisualStyleBackColor = True
        '
        'FormMuestras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 346)
        Me.Controls.Add(Me.CheckAcreditado)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.CheckNoUsar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboTipoInforme)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMuestras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Muestras"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ComboTipoInforme As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckNoUsar As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Informe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckAcreditado As System.Windows.Forms.CheckBox
End Class
