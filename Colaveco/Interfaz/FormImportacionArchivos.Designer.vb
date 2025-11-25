<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImportacionArchivos
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxFicha = New System.Windows.Forms.TextBox()
        Me.dgvArchivos = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnInsertar = New System.Windows.Forms.Button()
        Me.tbxTipoInforme = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbxFechaIngreso = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        CType(Me.dgvArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ficha"
        '
        'tbxFicha
        '
        Me.tbxFicha.Location = New System.Drawing.Point(13, 30)
        Me.tbxFicha.Name = "tbxFicha"
        Me.tbxFicha.Size = New System.Drawing.Size(262, 22)
        Me.tbxFicha.TabIndex = 1
        '
        'dgvArchivos
        '
        Me.dgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArchivos.Location = New System.Drawing.Point(12, 221)
        Me.dgvArchivos.Name = "dgvArchivos"
        Me.dgvArchivos.RowTemplate.Height = 24
        Me.dgvArchivos.Size = New System.Drawing.Size(997, 193)
        Me.dgvArchivos.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Archivos encontrados"
        '
        'btnInsertar
        '
        Me.btnInsertar.Location = New System.Drawing.Point(745, 122)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(263, 23)
        Me.btnInsertar.TabIndex = 4
        Me.btnInsertar.Text = "Insertar archivos"
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'tbxTipoInforme
        '
        Me.tbxTipoInforme.Location = New System.Drawing.Point(13, 99)
        Me.tbxTipoInforme.Name = "tbxTipoInforme"
        Me.tbxTipoInforme.Size = New System.Drawing.Size(264, 22)
        Me.tbxTipoInforme.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tipo de informe"
        '
        'tbxFechaIngreso
        '
        Me.tbxFechaIngreso.Location = New System.Drawing.Point(13, 168)
        Me.tbxFechaIngreso.Name = "tbxFechaIngreso"
        Me.tbxFechaIngreso.Size = New System.Drawing.Size(262, 22)
        Me.tbxFechaIngreso.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Fecha de ingreso"
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(745, 168)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(264, 32)
        Me.btnImportar.TabIndex = 11
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(746, 29)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(263, 23)
        Me.btnBuscar.TabIndex = 12
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(746, 75)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(263, 23)
        Me.btnLimpiar.TabIndex = 13
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'FormImportacionArchivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 426)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.tbxFechaIngreso)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbxTipoInforme)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnInsertar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvArchivos)
        Me.Controls.Add(Me.tbxFicha)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormImportacionArchivos"
        Me.Text = "FormImportacionArchivos"
        CType(Me.dgvArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbxFicha As System.Windows.Forms.TextBox
    Friend WithEvents dgvArchivos As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnInsertar As System.Windows.Forms.Button
    Friend WithEvents tbxTipoInforme As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbxFechaIngreso As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
End Class
