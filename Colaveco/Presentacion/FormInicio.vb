Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports System.Net

Public Class FormInicio
    Public nombre_pc As String = ""
    Private productorweb_com As String = ""
    Private copiaproductorweb_com As String = ""
    Private idproductorweb_com As Long = 0
    Private copiaidproductorweb_com As Long = 0
    Private idficha As Long = 0
    Private tipoinforme As Integer = 0
    Private _usuario As dUsuario
    Private email As String = ""
    Private email2 As String = ""
    Private celular As String = ""
    Private nficha As Long = 0
    Private mensaje As String = ""
    Private excel As Integer = 0
    Private pdf As Integer = 0
    Private csv As Integer = 0
    Private enviar_copia As String = ""
    Private _abonado As Integer = 0
    Private _comentarios As String = ""
    Private _moroso As Integer = 0
    Private _tipoinforme As Long = 0

#Region "Sesión y control de usuarios"
    Private _sesion As New dSesion
    Public Property Sesion() As dSesion
        Get
            Return _sesion
        End Get
        Set(ByVal value As dSesion)
            _sesion = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        nombre_pc = My.Computer.Name

        If nombre_pc = "ROBOT" Then
            'importar()
            cargarfichasparasubir()
            cargarfichassubidas()
            Timer3.Enabled = True
        ElseIf nombre_pc = "IT" Then
            DateFecha.Value = Now
            bloquearVentana()
            abrirSesion()
            cargartareasp()
            cargartareas()
            cargartareasG()
            cargarnoticias()
            cargaractas()
            cargarfichasparasubir()
            cargarfichassubidas()
            If Sesion.Usuario.SECTOR = 2 Then
                control_inhibidores()
            End If
            Timer1.Enabled = True
            Timer2.Enabled = True
            Timer3.Enabled = True
        Else
            DateFecha.Value = Now
            bloquearVentana()
            abrirSesion()
            cargartareasp()
            cargartareas()
            cargartareasG()
            cargaractas()
            cargarnoticias()
            cargarfichasparasubir()
            cargarfichassubidas()
            If Sesion.Usuario.SECTOR = 2 Then
                control_inhibidores()
            End If
            Timer1.Enabled = True
            Timer2.Enabled = True

        End If
        

    End Sub

    Public Sub cargarnoticias()
        Dim n As New dNoticias
        Dim hoy As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim hoy2 As String = ""
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        hoy2 = Format(hoy, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = n.listarxfecha(hoy2)
        'DataGridNoticias.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                'DataGridNoticias.Rows.Add(lista.Count)
            End If
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each n In lista
                    'DataGridNoticias(columna, fila).Value = n.ID
                    'columna = columna + 1
                    'DataGridNoticias(columna, fila).Value = n.DESCRIPCION
                    'columna = columna + 1
                    'DataGridNoticias(columna, fila).Value = n.FECHA
                    'columna = 0
                    'fila = fila + 1
                    MsgBox(n.DESCRIPCION)
                Next
            End If
        End If
    End Sub
    Public Sub cargaractas()
        Dim a As New dActasItem
        Dim idusuario As Integer = Sesion.Usuario.ID
        Dim hoy As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim hoy2 As String = ""
        hoy2 = Format(hoy, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = a.listarxtitular(idusuario)
        
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    If a.PLAZO <= hoy Then
                        MsgBox("Existen tareas que vencieron o vencen hoy! (Ver Registros/Actas/ítems pendientes)")
                        Exit Sub
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub cargartareasp()
        Dim t As New dTareas
        Dim lista As New ArrayList
        Dim idusuario As Integer = 0
        Dim idcreador As Integer = 0
        Dim idsector As Integer = 0
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        Dim usuario As New dUsuario
        usuario = Sesion.Usuario
        idusuario = usuario.ID
        idsector = usuario.SECTOR
        lista = t.listarxusuario(idusuario)
        DataGridtareasP.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridtareasP.Rows.Add(lista.Count)
            End If
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    DataGridtareasP(columna, fila).Value = t.ID
                    columna = columna + 1
                    DataGridtareasP(columna, fila).Value = t.DESCRIPCION
                    columna = columna + 1
                    DataGridtareasP(columna, fila).Value = t.FINALIZACION
                    columna = columna + 1
                    Dim usuario2 As New dUsuario
                    usuario2.ID = t.USUARIO
                    usuario2 = usuario2.buscar
                    If Not usuario2 Is Nothing Then
                        DataGridtareasP(columna, fila).Value = usuario2.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridtareasP(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    usuario2 = Nothing
                    'Dim sector As New dSectores
                    'sector.ID = t.SECTOR
                    'sector = sector.buscar
                    'If Not sector Is Nothing Then
                    '    DataGridtareasP(columna, fila).Value = sector.NOMBRE
                    '    columna = columna + 1
                    'Else
                    '    DataGridtareasP(columna, fila).Value = ""
                    '    columna = columna + 1
                    'End If
                    'sector = Nothing
                    Dim creador As New dUsuario
                    creador.ID = t.CREADOR
                    creador = creador.buscar
                    If Not creador Is Nothing Then
                        DataGridtareasP(columna, fila).Value = creador.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridtareasP(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    creador = Nothing
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Private Sub cargartareas()
        Dim t As New dTareas
        Dim lista As New ArrayList
        Dim idusuario As Integer = 0
        Dim idcreador As Integer = 0
        Dim idsector As Integer = 0
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        Dim usuario As New dUsuario
        usuario = Sesion.Usuario
        idusuario = usuario.ID
        idsector = usuario.SECTOR
        lista = t.listarxsector(idsector)
        DataGridTareas.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridTareas.Rows.Add(lista.Count)
            End If
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    DataGridTareas(columna, fila).Value = t.ID
                    columna = columna + 1
                    DataGridTareas(columna, fila).Value = t.DESCRIPCION
                    columna = columna + 1
                    DataGridTareas(columna, fila).Value = t.FINALIZACION
                    columna = columna + 1
                    'Dim usuario2 As New dUsuario
                    'usuario2.ID = t.USUARIO
                    'usuario2 = usuario2.buscar
                    'If Not usuario2 Is Nothing Then
                    '    DataGridtareasP(columna, fila).Value = usuario2.NOMBRE
                    '    columna = columna + 1
                    'Else
                    '    DataGridtareasP(columna, fila).Value = ""
                    '    columna = columna + 1
                    'End If
                    'usuario2 = Nothing
                    Dim sector As New dSectores
                    sector.ID = t.SECTOR
                    sector = sector.buscar
                    If Not sector Is Nothing Then
                        DataGridTareas(columna, fila).Value = sector.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridTareas(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    sector = Nothing
                    Dim creador As New dUsuario
                    creador.ID = t.CREADOR
                    creador = creador.buscar
                    If Not creador Is Nothing Then
                        DataGridTareas(columna, fila).Value = creador.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridTareas(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    creador = Nothing
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Private Sub cargartareasG()
        Dim t As New dTareas
        Dim lista As New ArrayList
        Dim idusuario As Integer = 0
        Dim idcreador As Integer = 0
        Dim idsector As Integer = 0
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        Dim usuario As New dUsuario
        usuario = Sesion.Usuario
        idusuario = usuario.ID
        idsector = usuario.SECTOR
        lista = t.listargenerales
        DataGridTareasG.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridTareasG.Rows.Add(lista.Count)
            End If
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    DataGridTareasG(columna, fila).Value = t.ID
                    columna = columna + 1
                    DataGridTareasG(columna, fila).Value = t.DESCRIPCION
                    columna = columna + 1
                    DataGridTareasG(columna, fila).Value = t.FINALIZACION
                    columna = columna + 1
                    'Dim usuario2 As New dUsuario
                    'usuario2.ID = t.USUARIO
                    'usuario2 = usuario2.buscar
                    'If Not usuario2 Is Nothing Then
                    '    DataGridtareasP(columna, fila).Value = usuario2.NOMBRE
                    '    columna = columna + 1
                    'Else
                    '    DataGridtareasP(columna, fila).Value = ""
                    '    columna = columna + 1
                    'End If
                    'usuario2 = Nothing
                    Dim sector As New dSectores
                    sector.ID = t.SECTOR
                    sector = sector.buscar
                    If Not sector Is Nothing Then
                        DataGridTareasG(columna, fila).Value = sector.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridTareasG(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    sector = Nothing
                    Dim creador As New dUsuario
                    creador.ID = t.CREADOR
                    creador = creador.buscar
                    If Not creador Is Nothing Then
                        DataGridTareasG(columna, fila).Value = creador.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridTareasG(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    creador = Nothing
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Public Sub abrirSesion()
        Dim v As New FormLogin
        v.ShowDialog()
        'v.TextCI.Focus()
        If Not v.Usuario Is Nothing Then
            Sesion.Usuario = v.Usuario
            If Sesion.abrirSesion() Then
                Sesion = Sesion.buscarUltimaSesion
                desbloquearVentana()
            End If
        End If
    End Sub
    Public Sub cerrarSesion()
        If Not Sesion Is Nothing Then
            If Sesion.ID > 0 Then
                If MsgBox("Se cerrará la sesión, ¿confirma?", MsgBoxStyle.YesNo, "Atención") = MsgBoxResult.Yes Then
                    If Not Sesion Is Nothing Then
                        If Sesion.ID > 0 Then
                            If Sesion.cerrarSesion() Then
                                'Sesion = Nothing
                                Sesion = New dSesion
                                'bloquearVentana()
                                Me.Close()
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub bloquearVentana()
        MantenimientoToolStripMenuItem.Enabled = False
        FrascosToolStripMenuItem1.Enabled = False
        CerrarSesiónToolStripMenuItem.Enabled = False
        AnálisisToolStripMenuItem.Enabled = False
        InformesToolStripMenuItem.Enabled = False
        AdministraciónToolStripMenuItem.Enabled = False
        ITToolStripMenuItem.Enabled = False
        AbrirSesiónToolStripMenuItem.Enabled = True
        ControlesToolStripMenuItem.Enabled = False
        EstadísticasATBToolStripMenuItem.Enabled = False
        RegistrosToolStripMenuItem.Enabled = False
        AutorizarCompraToolStripMenuItem.Enabled = False
        DirecciónToolStripMenuItem.Enabled = False
        CapacitaciónToolStripMenuItem1.Enabled = False
        PersonalToolStripMenuItem.Enabled = False
        RelojToolStripMenuItem1.Enabled = False
        LicenciadíasToolStripMenuItem.Enabled = False
        FeriadosToolStripMenuItem.Enabled = False
        FuncionariosToolStripMenuItem.Enabled = False
        InformesRelojToolStripMenuItem.Enabled = False
        ButtonSolicitudAnalisis.Enabled = False

        DataGridViewParaSubir.Visible = False
        DataGridViewSubidas.Visible = False
        Label1.Visible = False
        Label4.Visible = False
    End Sub
    Public Sub desbloquearVentana()

        ' *** Se bloquea todo.
        MantenimientoToolStripMenuItem.Enabled = False
        FrascosToolStripMenuItem1.Enabled = False
        CerrarSesiónToolStripMenuItem.Enabled = False
        AnálisisToolStripMenuItem.Enabled = False
        InformesToolStripMenuItem.Enabled = False
        AdministraciónToolStripMenuItem.Enabled = False
        ITToolStripMenuItem.Enabled = False
        AbrirSesiónToolStripMenuItem.Enabled = True
        ControlesToolStripMenuItem.Enabled = False
        EstadísticasATBToolStripMenuItem.Enabled = False
        RegistrosToolStripMenuItem.Enabled = False
        DirecciónToolStripMenuItem.Enabled = False
        CapacitaciónToolStripMenuItem1.Enabled = False
        PersonalToolStripMenuItem.Enabled = False
        RelojToolStripMenuItem1.Enabled = False
        LicenciadíasToolStripMenuItem.Enabled = False
        FeriadosToolStripMenuItem.Enabled = False
        FuncionariosToolStripMenuItem.Enabled = False
        InformesRelojToolStripMenuItem.Enabled = False
        ButtonSolicitudAnalisis.Enabled = False

        DataGridViewParaSubir.Visible = False
        DataGridViewSubidas.Visible = False
        Label1.Visible = False
        Label4.Visible = False


        ' *** Según usuario se desbloquean las secciones correspondientes.-
        Dim u As dUsuario = Sesion.Usuario
        Me.Text = "Colaveco NET" '& u.NOMBRE

        Me.ToolStripStatusLabel3.Text = u.NOMBRE

        If Not u Is Nothing Then

            If u.TIPOUSUARIO = 99 Then 'si el usuario es del tipo administrador
                comprobarcomprascanceladas()
                comprobarlineacompracancelada()
                'Menú MANTENIMIENTO.
                MantenimientoToolStripMenuItem.Enabled = True

                'Menú ANALISIS.
                AnálisisToolStripMenuItem.Enabled = True

                'Menú TRAZABILIDAD.
                FrascosToolStripMenuItem1.Enabled = True

                'Menú INFORMES
                InformesToolStripMenuItem.Enabled = True

                'Administración
                AdministraciónToolStripMenuItem.Enabled = True
                ButtonSolicitudAnalisis.Enabled = True
                'Direccion
                If u.USUARIO = "DH" Or u.USUARIO = "PB" Then
                    DirecciónToolStripMenuItem.Enabled = True
                Else
                    DirecciónToolStripMenuItem.Enabled = False
                End If
                'Compras
                If u.USUARIO = "DH" Or u.USUARIO = "CA" Then
                    comprobarcompras()
                    AutorizarCompraToolStripMenuItem.Enabled = True
                End If
                'IT
                If u.USUARIO = "PB" Then
                    ITToolStripMenuItem.Enabled = True
                    AutorizarCompraToolStripMenuItem.Enabled = True

                    DataGridViewParaSubir.Visible = True
                    DataGridViewSubidas.Visible = True
                    Label1.Visible = True
                    Label4.Visible = True
                Else
                    ITToolStripMenuItem.Enabled = False

                End If

                'Controles
                ControlesToolStripMenuItem.Enabled = True
                'Estadísticas
                EstadísticasATBToolStripMenuItem.Enabled = True
                'Registros
                RegistrosToolStripMenuItem.Enabled = True
                'Capacitacion
                CapacitaciónToolStripMenuItem1.Enabled = True
                'Personal
                PersonalToolStripMenuItem.Enabled = True


            ElseIf u.TIPOUSUARIO = 98 Then 'si el usuario es del tipo analista
                comprobarcomprascanceladas()
                comprobarlineacompracancelada()
                'Menú MANTENIMIENTO.
                MantenimientoToolStripMenuItem.Enabled = True
                'Menú ANALISIS.
                AnálisisToolStripMenuItem.Enabled = True
                'SolicitudDeAnálisisToolStripMenuItem1.Enabled = True

                'Menú TRAZABILIDAD.
                'FrascosToolStripMenuItem1.Enabled = True

                'Menú INFORMES
                'InformesToolStripMenuItem.Enabled = True

                'Menú IMPORTADOR
                'ImportadorToolStripMenuItem.Enabled = True

                'Administración
                'AdministraciónToolStripMenuItem.Enabled = True

                'IT
                'ITToolStripMenuItem.Enabled = True

                'Controles
                ControlesToolStripMenuItem.Enabled = True
                'Estadísticas
                EstadísticasATBToolStripMenuItem.Enabled = True
                'Registros
                RegistrosToolStripMenuItem.Enabled = True
                'Capacitacion
                CapacitaciónToolStripMenuItem1.Enabled = True
                'Personal
                PersonalToolStripMenuItem.Enabled = True


            ElseIf u.TIPOUSUARIO = 97 Then 'si el usuario es del tipo administrativo
                comprobarcomprascanceladas()
                comprobarlineacompracancelada()
                'Menú MANTENIMIENTO.
                MantenimientoToolStripMenuItem.Enabled = True

                'Menú ANALISIS.
                'AnálisisToolStripMenuItem.Enabled = True

                'Menú TRAZABILIDAD.
                'FrascosToolStripMenuItem1.Enabled = True

                'Menú INFORMES
                InformesToolStripMenuItem.Enabled = True

                'Menú IMPORTADOR

                'Administración
                AdministraciónToolStripMenuItem.Enabled = True
                ButtonSolicitudAnalisis.Enabled = True

                'IT
                'ITToolStripMenuItem.Enabled = True

                'Controles
                'ControlesToolStripMenuItem.Enabled = True
                'Estadísticas
                EstadísticasATBToolStripMenuItem.Enabled = True
                'Registros
                RegistrosToolStripMenuItem.Enabled = True
                'Capacitacion
                CapacitaciónToolStripMenuItem1.Enabled = True
                'Personal
                PersonalToolStripMenuItem.Enabled = True

                DataGridViewParaSubir.Visible = True
                DataGridViewSubidas.Visible = True
                Label1.Visible = True
                Label4.Visible = True

            ElseIf u.TIPOUSUARIO = 96 Then 'si el usuario es del tipo auxiliar
                comprobarcomprascanceladas()
                comprobarlineacompracancelada()
                'Menú MANTENIMIENTO.
                MantenimientoToolStripMenuItem.Enabled = True

                'Menú ANALISIS.
                'AnálisisToolStripMenuItem.Enabled = True
                'SolicitudDeAnálisisToolStripMenuItem1.Enabled = True

                'Menú TRAZABILIDAD.
                FrascosToolStripMenuItem1.Enabled = True

                'Menú INFORMES
                'InformesToolStripMenuItem.Enabled = True

                'Menú IMPORTADOR
                'ImportadorToolStripMenuItem.Enabled = True

                'Administración
                'AdministraciónToolStripMenuItem.Enabled = True

                'IT
                'ITToolStripMenuItem.Enabled = True

                'Controles
                'ControlesToolStripMenuItem.Enabled = True
                'Estadísticas
                EstadísticasATBToolStripMenuItem.Enabled = True
                'Registros
                RegistrosToolStripMenuItem.Enabled = True
                'Capacitacion
                CapacitaciónToolStripMenuItem1.Enabled = True
                'Personal
                PersonalToolStripMenuItem.Enabled = True
            End If

            nombre_pc = My.Computer.Name
            If nombre_pc = "EXPEDICION" Or nombre_pc = "IT" Or nombre_pc = "ADMINISTRACION" Then
                If u.USUARIO = "JG" Or u.USUARIO = "PB" Then
                    RelojToolStripMenuItem1.Enabled = True
                    LicenciadíasToolStripMenuItem.Enabled = True
                    FeriadosToolStripMenuItem.Enabled = True
                    FuncionariosToolStripMenuItem.Enabled = True
                    InformesRelojToolStripMenuItem.Enabled = True
                Else
                    RelojToolStripMenuItem1.Enabled = True
                End If
            End If

                CerrarSesiónToolStripMenuItem.Enabled = True

            End If
    End Sub

#End Region
    Private Sub comprobarcompras()
        Dim c As New dCompras
        Dim lista As New ArrayList
        lista = c.listarsinautorizar
        Dim aviso As Integer = 0
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    Dim lc As New dLineaCompra
                    lc.IDCOMPRA = c.ID
                    lc = lc.buscarxidcompra
                    If Not lc Is Nothing Then
                        aviso = 1
                    End If
                    lc = Nothing
                Next
            End If
        End If
        If aviso = 1 Then
            MsgBox("Hay compras sin autorizar!")
        End If
    End Sub
    Private Sub comprobarcomprascanceladas()
        Dim cc As New dCancelaCompra
        Dim u As dUsuario = Sesion.Usuario
        Dim nombre As String = ""
        Dim proveedor As String = ""
        Dim idcompra As Long = 0
        Dim idcancelacompra As Long = 0
        Dim lista As New ArrayList
        lista = cc.listarxusuario(u.ID)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each cc In lista
                    idcancelacompra = cc.ID
                    Dim usuarios As New dUsuario
                    usuarios.ID = cc.USUARIOCANCELA
                    usuarios = usuarios.buscar
                    If Not usuarios Is Nothing Then
                        nombre = usuarios.NOMBRE
                    End If
                    idcompra = cc.IDCOMPRA
                    Dim p As New dProveedores
                    p.ID = cc.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        proveedor = p.NOMBRE
                    End If

                    Dim result = MessageBox.Show("El usuario " & nombre & " ha cancelado la compra Nº " & idcompra & " ,al proveedor " & proveedor & " , desea marcar este mensaje como visto?", "Atención!", MessageBoxButtons.YesNoCancel)
                    If result = DialogResult.Cancel Then
                        Exit Sub
                    ElseIf result = DialogResult.No Then
                        Exit Sub
                    ElseIf result = DialogResult.Yes Then
                        cc.ID = idcancelacompra
                        cc.marcarvisto()
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub comprobarlineacompracancelada()
        Dim clc As New dCancelaLCompra
        Dim c As New dCompras
        Dim u As dUsuario = Sesion.Usuario
        Dim nombre As String = ""
        Dim proveedor As String = ""
        Dim producto As String = ""
        Dim idcompra As Long = 0
        Dim idcancelalcompra As Long = 0
        Dim lista As New ArrayList
        lista = clc.listarxusuario(u.ID)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each clc In lista
                    idcancelalcompra = clc.ID

                    Dim usuarios As New dUsuario
                    usuarios.ID = clc.USUARIOCANCELA
                    usuarios = usuarios.buscar
                    If Not usuarios Is Nothing Then
                        nombre = usuarios.NOMBRE
                    End If
                    idcompra = clc.IDCOMPRA
                    Dim p As New dProveedores
                    p.ID = clc.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        proveedor = p.NOMBRE
                    End If
                    Dim pro As New dProductos
                    pro.ID = clc.PRODUCTO
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        producto = pro.NOMBRE
                    End If


                    Dim result = MessageBox.Show("El usuario " & nombre & " ha cancelado la compra del producto " & producto & " ,de la compra Nº " & idcompra & " ,al proveedor " & proveedor & " , desea marcar este mensaje como visto?", "Atención!", MessageBoxButtons.YesNoCancel)
                    If result = DialogResult.Cancel Then
                        'Exit Sub
                    ElseIf result = DialogResult.No Then
                        'Exit Sub
                    ElseIf result = DialogResult.Yes Then
                        clc.ID = idcancelalcompra
                        clc.marcarvisto()
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub ProductorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductorToolStripMenuItem.Click
        Dim v As New FormProductor(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub AbrirSesiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirSesiónToolStripMenuItem.Click
        abrirSesion()
    End Sub

    Private Sub CerrarSesiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSesiónToolStripMenuItem.Click
        cerrarSesion()
    End Sub

    Private Sub CajasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CajasToolStripMenuItem1.Click
        Dim v As New FormEnvioCajas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub MantenimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoToolStripMenuItem.Click

    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub EmpresasDeTransportesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpresasDeTransportesToolStripMenuItem.Click
        Dim v As New FormEmpresaT(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub TécnicosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TécnicosToolStripMenuItem.Click
        Dim v As New FormTecnicos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub PedidosFrascosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidosFrascosToolStripMenuItem.Click
        Dim v As New FormPedidoFrascos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub SolicitudDeAnálisisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormSolicitudAnalisis(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub SubInformesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubInformesToolStripMenuItem.Click
        Dim v As New FormSubInformes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub MuestrasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MuestrasToolStripMenuItem.Click
        Dim v As New FormMuestras(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub PedidosAutomáticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidosAutomáticosToolStripMenuItem.Click
        Dim v As New FormPedidosAutomaticos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub FrascosRotosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrascosRotosToolStripMenuItem.Click
        Dim v As New FormFrascosRotos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CajasSinDevolverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AntibiogramasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AntibiogramasToolStripMenuItem.Click
        Dim v As New FormAntibiogramas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub MicroOrganismoAislado24HsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MicroOrganismoAislado24HsToolStripMenuItem.Click
        Dim v As New FormMOA24(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub MicroOrganismoAislado48HsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MicroOrganismoAislado48HsToolStripMenuItem.Click
        Dim v As New FormMOA48(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub AguaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AguaToolStripMenuItem.Click
        Dim v As New FormAgua(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub AntibiogramaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DescarteDeMuestrasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormDescarteMuestras(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub SolicitudDeAnálisisToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub NuevaSolicitudToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormSolicitudAnalisis(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub DescarteDeMuestrasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormDescarteMuestras(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ProdúctosYSubprodúctosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProdúctosYSubprodúctosToolStripMenuItem.Click
        Dim v As New FormSubproductos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormSolicitudAnalisis(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub FormInicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CajasSinDevolverToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CajasEnviadasPorClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormInformeEnvioxCliente(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CalidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CalidadToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CalidadDeLecheToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalidadDeLecheToolStripMenuItem.Click
        Dim v As New FormInformeCalidadLeche(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub InhibidoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InhibidoresToolStripMenuItem.Click
        Dim v As New FormInhibidores(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ImportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormImportador()
        v.Show()
    End Sub

    Private Sub ControlLecheroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlLecheroToolStripMenuItem.Click
        Dim v As New FormInformeControlLechero(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub SincronizarFichaConCaravanasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormSincronizaFichaCaravana(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub SubirInformesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubirInformesToolStripMenuItem1.Click
        Dim v As New FormSubirInformes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub VerResultadosInhibidoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormInformeInhibidores()
        v.Show()
    End Sub

    Private Sub InformesPendientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub VisualizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TiemposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiemposToolStripMenuItem.Click
        Dim v As New FormTiempos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub InformesPendientesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormInformesPendientes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub PALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PALToolStripMenuItem.Click
        Dim v As New FormPal(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub MarcarSolicitudToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormMarcarSolicitudSubida(Sesion.Usuario)
        v.Show()
    End Sub


    Private Sub ContadorDeAnaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormContadorAnalisisEmpresas()
        v.Show()
    End Sub

    Private Sub CopiarArchivosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarArchivosToolStripMenuItem.Click
        Dim v As New FormPruebas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITToolStripMenuItem.Click

    End Sub

    Private Sub CajasEnviadasPorFechaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EliminarImportaciónDeControlLecheroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormEliminarControlLechero(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EliminarSolicitudDeAnálisisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormEliminarSolicitud(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub DevoluciónDeFrascosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevoluciónDeFrascosToolStripMenuItem.Click
        Dim v As New FormFrascosDevueltos(Sesion.Usuario)
        v.Show()

    End Sub

    Private Sub HistorialDePedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormBuscarPedidos(Sesion.Usuario)
        v.Show()

    End Sub

    Private Sub CompletarEnvíosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompletarEnvíosToolStripMenuItem.Click
        Dim v As New FormCompletarEnvios(Sesion.Usuario)
        v.Show()

    End Sub

    Private Sub CompletarEnvíosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormCompletarEnvios(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EnvíosDeFrascosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormInformeFrascosEnviados()
        v.Show()

    End Sub

    Private Sub FrascosRotosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormInformeFrascosRotos()
        v.Show()
    End Sub

    Private Sub EnvíosDeCajasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvíosDeCajasToolStripMenuItem.Click
        Dim v As New FormInformeEnvioxCliente(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EnvíosDeFrascosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvíosDeFrascosToolStripMenuItem1.Click
        Dim v As New FormInformeFrascosEnviados()
        v.Show()
    End Sub

    Private Sub FrascosRotosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrascosRotosToolStripMenuItem2.Click
        Dim v As New FormInformeFrascosRotos()
        v.Show()
    End Sub

    Private Sub HistorialDePedidosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistorialDePedidosToolStripMenuItem1.Click
        Dim v As New FormBuscarPedidos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CajasSinDevolverToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CajasSinDevolverToolStripMenuItem2.Click
        Dim v As New FormInformesCajas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub PedidosDeFrascosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormPedidoFrascos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EnvíosDeCajasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormInformeEnvioxCliente(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub AnálisisToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnálisisToolStripMenuItem1.Click
        Dim v As New FormAnalisis(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub DBFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBFToolStripMenuItem.Click
        'Dim v As New Form1()
        'v.show()
    End Sub

    Private Sub PedidosAutomáticosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormPedidosAutomaticos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub NoticiasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormNoticias(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ReclamosSugerenciasYNoConformidadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReclamosSugerenciasYNoConformidadesToolStripMenuItem.Click
        Dim v As New FormReclamos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub MaterialDeReferenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialDeReferenciaToolStripMenuItem.Click
        Dim v As New FormMaterialDeReferencia(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub GráficaMaterialDeReferenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GráficaMaterialDeReferenciaToolStripMenuItem.Click
        Dim v As New FormMaterialdeReferenciaBD()
        v.Show()
    End Sub

    Private Sub SQLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ValoresEmpresaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValoresEmpresaToolStripMenuItem.Click
        Dim v As New FormValoresEmpresa
        v.Show()
    End Sub

    Private Sub ValoresVacaIndividualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValoresVacaIndividualToolStripMenuItem.Click
        Dim v As New FormValoresVacaIndividual
        v.Show()
    End Sub

    Private Sub IBCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IBCToolStripMenuItem.Click
        Dim v As New FormControlIBC
        v.Show()
    End Sub


    Private Sub IBCToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IBCToolStripMenuItem1.Click
        Dim v As New FormGraficaControlIBC
        v.Show()
    End Sub

    Private Sub ControlDeInformesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeInformesToolStripMenuItem.Click
        Dim v As New FormControldeInformes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CapacitaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapacitaciónToolStripMenuItem.Click

    End Sub

    Private Sub DevoluciónDeFrascosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormFrascosDevueltos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub DevoluciónDeFrascosToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevoluciónDeFrascosToolStripMenuItem3.Click
        Dim v As New FormFrascosDevueltos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CompletarCapacitaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompletarCapacitaciónToolStripMenuItem.Click
        Dim v As New FormCapacitacion2(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CapacitaciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapacitaciónToolStripMenuItem1.Click

    End Sub

    Private Sub CompletarNºDeSinaveleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim solicitud As Long = 0
        Dim v As New FormSinaveleFicha(Sesion.Usuario, solicitud)
        v.Show()
    End Sub

    Private Sub BuscarCajasPorNúmeroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarCajasPorNúmeroToolStripMenuItem.Click
        Dim v As New FormBuscarCajas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EstadísticasATBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadísticasATBToolStripMenuItem.Click
        Dim v As New FormEstadisticaAntibiograma()
        v.Show()
    End Sub

    Private Sub RecibirCajasPorNúmeroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormBuscarCajas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub DatosCalidadDeLecheToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SolicitudesParaITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitudesParaITToolStripMenuItem.Click
        Dim v As New FormSolicitudIT(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub PALToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PALToolStripMenuItem1.Click
        Dim v As New FormInformePAL(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CopiarArchivosDeCalidadContableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormCopiarArchivosCalidad()
        v.Show()
    End Sub

    Private Sub SolicitudesITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormListarSolicitudesIT(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub AmbientalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmbientalToolStripMenuItem.Click
        Dim v As New FormAmbiental(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EstadísticasCalidadDeLecheEXEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadísticasCalidadDeLecheEXEToolStripMenuItem.Click
        Dim v As New FormEstadisticasCalidad_exe()
        v.Show()
    End Sub

    Private Sub MaterialDeReferenciamediasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialDeReferenciamediasToolStripMenuItem.Click
        Dim v As New FormMaterialReferenciaMedias()
        v.Show()
    End Sub

    Private Sub BacteriologíaDeTanqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BacteriologíaDeTanqueToolStripMenuItem.Click
        Dim v As New FormBacteriologia(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CMIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMIToolStripMenuItem.Click
        Dim v As New FormCMI(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub IngresosSinSolicitudToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormListadoIngresosSinSolicitud(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ListadoDeCajasVerdesSinDevolverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormListadoCajasVerdesSinDevolver(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub FrascosDeSangreSinFacturarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormFrascosSangreSinFacturar(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ListadoDeSolicitudesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormListadoDeSolicitudes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CompletarEnvíosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompletarEnvíosToolStripMenuItem2.Click
        Dim v As New FormCompletarEnvios(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CompletarNºDeSinaveleToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompletarNºDeSinaveleToolStripMenuItem1.Click
        Dim solicitud As Long = 0
        Dim v As New FormSinaveleFicha(Sesion.Usuario, solicitud)
        v.Show()
    End Sub

    Private Sub ContadorDeAnálisisEmpresasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContadorDeAnálisisEmpresasToolStripMenuItem.Click
        Dim v As New FormContadorAnalisisEmpresas()
        v.Show()
    End Sub

    Private Sub CopiarArchivosDeCalidadMoiraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarArchivosDeCalidadMoiraToolStripMenuItem.Click
        Dim v As New FormCopiarArchivosCalidad()
        v.Show()
    End Sub

    Private Sub EliminarImportaciónDeControlLecheroToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarImportaciónDeControlLecheroToolStripMenuItem1.Click
        Dim v As New FormEliminarControlLechero(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EliminarSolicitudDeAnálisisToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarSolicitudDeAnálisisToolStripMenuItem1.Click
        Dim v As New FormEliminarSolicitud(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EnvíosDeCajasToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvíosDeCajasToolStripMenuItem2.Click
        Dim v As New FormInformeEnvioxCliente(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub PedidosDeFrascosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidosDeFrascosToolStripMenuItem1.Click
        Dim v As New FormPedidoFrascos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub PedidosAutomáticoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidosAutomáticoToolStripMenuItem.Click
        Dim v As New FormPedidosAutomaticos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub RecibirCajasPorNúmeroToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecibirCajasPorNúmeroToolStripMenuItem1.Click
        Dim v As New FormBuscarCajas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub IngresosSinSolicitudToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresosSinSolicitudToolStripMenuItem1.Click
        Dim v As New FormListadoIngresosSinSolicitud(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ListadoDeCajasVerdesSinDevolverToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeCajasVerdesSinDevolverToolStripMenuItem1.Click
        Dim v As New FormListadoCajasVerdesSinDevolver(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ListadoDeFrascosDeSangreSinFacturarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeFrascosDeSangreSinFacturarToolStripMenuItem.Click
        Dim v As New FormFrascosSangreSinFacturar(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ListadoDeSolicitudesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormListadoDeSolicitudes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ImportarBentleyDeltaIBCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarBentleyDeltaIBCToolStripMenuItem.Click
        Dim v As New FormImportador
        v.Show()
    End Sub

    Private Sub SolicitudDeAnálisisToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitudDeAnálisisToolStripMenuItem.Click
        Dim v As New FormSolicitudAnalisis(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub DescarteDeMuestrasToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescarteDeMuestrasToolStripMenuItem.Click
        Dim v As New FormDescarteMuestras(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub VerResultadosDeInhibidoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerResultadosDeInhibidoresToolStripMenuItem.Click
        Dim v As New FormInformeInhibidores()
        v.Show()
    End Sub

    Private Sub InformesPendientesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformesPendientesToolStripMenuItem.Click
        Dim v As New FormInformesPendientes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub MarcarSolicitudToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcarSolicitudToolStripMenuItem1.Click
        Dim v As New FormMarcarSolicitudSubida(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub SincronizarFichaConCaravanasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SincronizarFichaConCaravanasToolStripMenuItem1.Click
        Dim v As New FormSincronizaFichaCaravana(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub BuscarCajasPorNúmeroToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarCajasPorNúmeroToolStripMenuItem1.Click
        Dim v As New FormBuscarCajas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub TareasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormTareas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub TareasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TareasToolStripMenuItem1.Click
        Dim v As New FormTareas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'cargarnoticias()
        cargartareas()
        cargartareasp()
        cargarfichasparasubir()
        cargarfichassubidas()
    End Sub

    Private Sub NoticiasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoticiasToolStripMenuItem1.Click
        Dim v As New FormNoticias(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ListadoDeCajasVerdesYConservadorasSinDevolverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeCajasVerdesYConservadorasSinDevolverToolStripMenuItem.Click
        Dim v As New FormListadoCajasVerdesSinDevolver(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ButtonSolicitudAnalisis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSolicitudAnalisis.Click
        Dim v As New FormSolicitudAnalisis(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormProveedores(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ListadoDeSolicitudesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeSolicitudesToolStripMenuItem.Click
        Dim v As New FormListadoDeSolicitudes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormProductos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ComprasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComprasToolStripMenuItem.Click

    End Sub

    Private Sub CategoríasproductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormCategoria(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub RealizarCompraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RealizarCompraToolStripMenuItem.Click
        Dim v As New FormCompras(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub AutorizarCompraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutorizarCompraToolStripMenuItem.Click
        Dim v As New FormAutorizarCompra(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub RecibirCompraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecibirCompraToolStripMenuItem.Click
        Dim v As New FormRecibirCompra(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub SolicitudDeCotizaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitudDeCotizaciónToolStripMenuItem.Click
        Dim v As New FormSolicitarCotizacion(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub VerResultadosDePALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerResultadosDePALToolStripMenuItem.Click
        Dim v As New FormVerResultadosPAL(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ComprasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CategoríasproductosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoríasproductosToolStripMenuItem1.Click
        Dim v As New FormCategoria(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ProveedoresToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProveedoresToolStripMenuItem1.Click
        Dim v As New FormProveedores(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ComprasToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComprasToolStripMenuItem1.Click

    End Sub

    Private Sub UnidadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnidadesToolStripMenuItem.Click
        Dim v As New FormUnidades(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub PresentacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PresentacionesToolStripMenuItem.Click
        Dim v As New FormPresentaciones(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub LocaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocaciónToolStripMenuItem.Click
        Dim v As New FormLocacion(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosToolStripMenuItem1.Click
        Dim v As New FormProductos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ObjetivosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjetivosToolStripMenuItem.Click
        Dim v As New FormCapacitacion(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CompletarCapacitaciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompletarCapacitaciónToolStripMenuItem1.Click
        Dim v As New FormCapacitacion2(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub InformesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformesToolStripMenuItem2.Click
        Dim v As New FormInformesCapacitacion
        v.Show()
    End Sub

    Private Sub MuestrasDescartadasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MuestrasDescartadasToolStripMenuItem.Click
        Dim v As New FormInformeMuestrasDescartadas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub TiemposDeEnvíosDeInformesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiemposDeEnvíosDeInformesToolStripMenuItem.Click
        Dim v As New FormTiemposEnviosInformes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ListadoDeInformesSubidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeInformesSubidosToolStripMenuItem.Click
        Dim v As New FormInformesSubidos()
        v.Show()
    End Sub

    Private Sub CambiarNºTamboHerramientaClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarNºTamboHerramientaClientesToolStripMenuItem.Click
        Dim v As New FormEditarNumeroTambo()
        v.Show()
    End Sub

    Private Sub InformeDeRCYRBPorEmpresaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeDeRCYRBPorEmpresaToolStripMenuItem.Click
        Dim v As New FormInformeRCRB()
        v.Show()
    End Sub

    Private Sub ImportarPetriscanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarPetriscanToolStripMenuItem.Click
        Dim v As New FormPetriscan
        v.Show()
    End Sub

    Private Sub DataGridtareasP_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridtareasP.CellContentClick

    End Sub

    Private Sub LeucosisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeucosisToolStripMenuItem.Click
        Dim v As New FormLeucosis(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub LeucosisToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeucosisToolStripMenuItem1.Click
        Dim v As New FormInformeLeucosis(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub BrucelosisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrucelosisToolStripMenuItem.Click
        Dim v As New FormInformeBrucelosis(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ListadoDeComprasAutorizadasYSinAutorizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeComprasAutorizadasYSinAutorizarToolStripMenuItem.Click
        Dim v As New FormListadodeCompras(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub BrucelosisToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrucelosisToolStripMenuItem1.Click
        Dim v As New FormBrucelosis(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EnviarCorreoAClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarCorreoAClienteToolStripMenuItem.Click
        Dim v As New FormEnviarMensajes()
        v.Show()
    End Sub

    Private Sub EnviarCorreoAClienteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarCorreoAClienteToolStripMenuItem1.Click
        Dim v As New FormEnviarMensajes()
        v.Show()
    End Sub

    Private Sub NutriciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NutriciónToolStripMenuItem.Click
        Dim v As New FormNutricion(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub NutriciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NutriciónToolStripMenuItem1.Click
        Dim v As New FormInformeNutricion(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub SuelosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuelosToolStripMenuItem.Click
        Dim v As New FormSuelos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub SuelosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuelosToolStripMenuItem1.Click
        Dim v As New FormInformeSuelos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EsporuladosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EsporuladosToolStripMenuItem.Click
        Dim v As New FormEsporulados(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub PsicrótrofosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PsicrótrofosToolStripMenuItem.Click
        Dim v As New FormPsicrotrofos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub DeltaBentleyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ControlBentleyDeltaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlBentleyDeltaToolStripMenuItem.Click
        Dim v As New FormControlBentleyDelta()
        v.Show()
    End Sub

    Private Sub VerResultadosBrucelosisEnLecheToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerResultadosBrucelosisEnLecheToolStripMenuItem.Click
        Dim v As New FormBuscarBrucelosisLeche(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ColavecoSecaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColavecoSecaleToolStripMenuItem.Click
        Dim v As New FormSecale(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ColavecoSecaleMatReferenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColavecoSecaleMatReferenciaToolStripMenuItem.Click
        Dim v As New FormColavecoSecale()
        v.Show()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Sesion.Usuario.SECTOR = 2 Then
            control_inhibidores()
        End If
    End Sub
    Private Sub control_inhibidores()
        Dim inhc As New dInhibidoresControl
        Dim lista As New ArrayList
        lista = inhc.listarsinmarca
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each inhc In lista
                    Dim result = MessageBox.Show("La muestra " & inhc.MUESTRA & " " & "de la ficha " & inhc.FICHA & ", " & "dió positivo en inhibidores, desea marcar este aviso como leído?", "INHIBIDOR POSITIVO - ATENCIÓN!", MessageBoxButtons.YesNoCancel)
                    If result = DialogResult.Cancel Then
                        Exit Sub
                    ElseIf result = DialogResult.No Then
                        Exit Sub
                    ElseIf result = DialogResult.Yes Then
                        inhc.OPERADOR = Sesion.Usuario.ID
                        inhc.MARCA = 1
                        inhc.marcar()
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub ControlDeMediosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeMediosToolStripMenuItem.Click
        Dim v As New FormControlDeMedios(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ClaseDeAlimentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaseDeAlimentoToolStripMenuItem.Click
        Dim v As New FormNutricionClase(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub AlimentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlimentoToolStripMenuItem.Click
        Dim v As New FormNutricionAlimento(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EstadísticasDeNutriciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MarcarClientesComoMorososToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcarClientesComoMorososToolStripMenuItem.Click
        Dim v As New FormClientesMorosos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ControlDeMuestrasDuplicadasEnArchivosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeMuestrasDuplicadasEnArchivosToolStripMenuItem.Click
        Dim v As New FormControlMuestrasDuplicadas()
        v.Show()
    End Sub

    Private Sub preinforme_control(ByVal id_sol As Long)
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        Dim c As New dControl

        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dProductor
        Dim tec As New dTecnicos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        '*****************************
        Dim idsol As Long = id_sol 'ficha
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        'sa.marcar(Usuario)

        '*****************************
        Dim fila As Integer
        Dim columna As Integer
       
        fila = 1
        columna = 2

        '*** ENCABEZADO ********************************************************************************
        '***********************************************************************************************

        ''Poner Titulos
        'x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
        ' Microsoft.Office.Core.MsoTriState.msoFalse, _
        'Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)


        x1hoja.Cells(1, 1).columnwidth = 7
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 7
        x1hoja.Cells(1, 7).columnwidth = 4
        x1hoja.Cells(1, 8).columnwidth = 7
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 5
        x1hoja.Cells(1, 12).columnwidth = 5
        x1hoja.Cells(1, 13).columnwidth = 7
        x1hoja.Range("A1", "D1").Merge()

        'columna = 4
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Formula = "Parque El Retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'x1hoja.Range("B4", "C4").Merge()
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy.uy"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'x1hoja.Range("A5", "M5").Merge()
        'fila = fila + 2
        'columna = 1
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        'x1hoja.Cells(fila, columna).Formula = "INFORME DEL RECUENTO CELULAR Y COMPOSICIÓN DE VACAS INDIVIDUALES"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 9
        'fila = fila + 2
        'columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 2
        'x1hoja.Cells(fila, columna).formula = sa.ID
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 5
        'x1hoja.Cells(fila, columna).Formula = "Métodos y estándares:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 7
        'fila = fila + 1
        'columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Cliente:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 2
        'pro.ID = sa.IDPRODUCTOR
        'pro = pro.buscar
        'x1hoja.Cells(fila, columna).formula = pro.NOMBRE
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 5
        'x1hoja.Range("H8", "M8").Merge()
        'x1hoja.Range("H8", "M8").Borders.Color = RGB(0, 0, 0)
        'x1hoja.Cells(fila, columna).formula = "R. Celular x 1000cel/mL (Mét. IR - ISO 13366-2:2006)"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'fila = fila + 1
        'columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Dirección:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 2
        'If pro.DIRECCION <> "" Then
        '    x1hoja.Cells(fila, columna).formula = pro.DIRECCION
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 8
        'Else
        '    x1hoja.Cells(fila, columna).formula = "No aportado"
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 8
        'End If
        'columna = columna + 5
        'x1hoja.Range("H9", "M9").Merge()
        'x1hoja.Range("H9", "M9").Borders.Color = RGB(0, 0, 0)
        'x1hoja.Cells(fila, columna).formula = "Gr, Pr, Lc % peso/vol.(Mét. IR - IDF 141C:2000)"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'fila = fila + 1
        'columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 7
        'columna = columna + 2
        'x1hoja.Range("C10", "D10").Merge()
        'x1hoja.Cells(fila, columna).formula = sa.FECHAINGRESO
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 5
        'x1hoja.Range("H10", "M10").Merge()
        'x1hoja.Range("H10", "M10").Borders.Color = RGB(0, 0, 0)
        'x1hoja.Cells(fila, columna).formula = "MUN mg/dL (Mét. IR - Boletín FIL 393:2003"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'fila = fila + 1
        'columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Fecha emisión:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 7
        'columna = columna + 2
        'x1hoja.Range("C11", "D11").Merge()
        'Dim fecha As Date = Now()
        'Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        'x1hoja.Cells(fila, columna).formula = fecha2
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 5
        'x1hoja.Cells(fila, columna).formula = "Gr = Grasa, Pr = Proteina, Lc = Lactosa"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'fila = fila + 1
        'columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Paratécnico:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 7
        'columna = columna + 2

        'Dim paratecnico As String = ""
        'If idparatecnico1 = 1 Then
        '    paratecnico = paratecnico + "Diego Arenas - "
        'End If
        'If idparatecnico2 = 1 Then
        '    paratecnico = paratecnico + "Lorena Nidegger - "
        'End If
        'If idparatecnico3 = 1 Then
        '    paratecnico = paratecnico + "Claudia García - "
        'End If
        'If idparatecnico4 = 1 Then
        '    paratecnico = paratecnico + "Erika Silva - "
        'End If
        'If paratecnico <> "" Then
        '    x1hoja.Cells(fila, columna).formula = paratecnico
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 8

        'Else
        '    x1hoja.Cells(fila, columna).formula = ""
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 8

        'End If


        'columna = columna + 5
        'x1hoja.Cells(fila, columna).formula = "MUN = Nitrogeno ureico"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'fila = fila + 1
        'columna = 1
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 7
        'columna = columna + 5

        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 2
        'x1hoja.Cells(fila, columna).formula = "Rc = Recuento celular"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        fila = 15
        columna = 1


        '*** FIN DEL ENCABEZADO ***********************************************************************************
        '**********************************************************************************************************

        lista = c.listarporsolicitud(idsol)
        lista2 = c.listarporrc(idsol)

        x1hoja.Cells(fila, columna).Formula = "Listado ordenado por identificación"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 7
        x1hoja.Cells(fila, columna).Formula = "Listado ordenado decreciente por Recuento celular"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8

        fila = fila + 1
        columna = 1
        Dim filaguia As Integer = fila



        x1hoja.Cells(fila, columna).Formula = "Ident."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Rc*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Gr*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Pr*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Lc"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "MUN"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter

        columna = 1
        fila = fila + 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then


                For Each c In lista
                    If c.MUESTRA <> "" Then
                        x1hoja.Cells(fila, columna).formula = Trim(c.MUESTRA)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If c.RC = -1 Then
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        If c.RC < 4 Then
                            x1hoja.Cells(fila, columna).formula = "4"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = c.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    End If
                    If c.GRASA = -1 Or c.GRASA = 0 Then
                        columna = columna - 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1

                        x1hoja.Cells(fila, columna).formula = "MUESTRA NO APTA **"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        Dim valgrasa = Val(c.GRASA)
                        If valgrasa < 2 Or valgrasa > 5.5 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        x1hoja.Cells(fila, columna).formula = c.GRASA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        Dim valproteina = Val(c.PROTEINA)
                        If valproteina < 2 Or valproteina > 4.5 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        x1hoja.Cells(fila, columna).formula = c.PROTEINA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = c.LACTOSA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    Dim cs As New dControlSolicitud
                    cs.IDSOLICITUD = idsol
                    cs = cs.buscar
                    If Not cs Is Nothing Then
                        If cs.UREA = 1 Then
                            If c.UREA = -1 Or c.UREA = 0 Then
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                Dim valorurea As Integer
                                valorurea = c.UREA * 0.466
                                x1hoja.Cells(fila, columna).formula = FormatNumber(valorurea, 0)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    cs = Nothing
                    columna = 1
                    fila = fila + 1
                Next
                'Referencias
                fila = fila + 1
                columna = 1
            End If
            '****** ORDENADO POR RC ************************************************************************
            Dim libreinfeccion As Integer = 0
            Dim posibleinfeccion As Integer = 0
            Dim probableinfeccion As Integer = 0

            fila = filaguia
            columna = 8
            x1hoja.Cells(fila, columna).Formula = "Ident."
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Rc*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Gr*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Pr*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Lc"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "MUN"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter

            columna = 8
            fila = fila + 1

            If Not lista2 Is Nothing Then
                If lista2.Count > 0 Then


                    For Each c In lista2
                        If c.MUESTRA <> "" Then
                            x1hoja.Cells(fila, columna).formula = Trim(c.MUESTRA)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If c.RC = -1 Then
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            If c.RC < 4 Then
                                x1hoja.Cells(fila, columna).formula = "4"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = c.RC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        End If
                        'If c.RC < 150 Then
                        '    libreinfeccion = libreinfeccion + 1
                        'ElseIf c.RC <= 150 Or c.RC < 400 Then
                        '    posibleinfeccion = posibleinfeccion + 1
                        'ElseIf c.RC >= 400 Then
                        '    probableinfeccion = probableinfeccion + 1
                        'End If
                        If c.GRASA = -1 Or c.GRASA = 0 Then
                            columna = columna - 1
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1

                            x1hoja.Cells(fila, columna).formula = "MUESTRA NO APTA **"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            Dim valgrasa = Val(c.GRASA)
                            If valgrasa < 2 Or valgrasa > 5.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = c.GRASA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            Dim valproteina = Val(c.PROTEINA)
                            If valproteina < 2 Or valproteina > 4.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = c.PROTEINA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = c.LACTOSA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        Dim cs As New dControlSolicitud
                        cs.IDSOLICITUD = idsol
                        cs = cs.buscar
                        If Not cs Is Nothing Then
                            If cs.UREA = 1 Then
                                If c.UREA = -1 Or c.UREA = 0 Then
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna + 1
                                Else
                                    Dim valorurea As Integer
                                    valorurea = c.UREA * 0.466
                                    x1hoja.Cells(fila, columna).formula = FormatNumber(valorurea, 0)
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna + 1
                                End If
                            Else
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        cs = Nothing
                        columna = 8
                        fila = fila + 1
                    Next
                    'Referencias
                    fila = fila + 1
                    columna = 1
                End If


                '******* CALCULO PRECIO ************************************************************************

                'Dim listamuestras As New ArrayList
                'listamuestras = c.listarporsolicitud(idsol)
                'Dim total As Double
                'Dim ana As New dAnalisis
                'Dim minimomuestras As Integer = 0

                'Dim idtimbre As Integer = 86
                'Dim idrc_comp As Integer = 116
                'Dim idrc_comp_urea As Integer = 117

                'Dim preciotimbre As Double
                'Dim preciorc_comp As Double
                'Dim preciorc_comp_urea As Double


                'ana.ID = idtimbre
                'ana = ana.buscar
                'preciotimbre = ana.COSTO


                'ana.ID = idrc_comp
                'ana = ana.buscar
                'preciorc_comp = ana.COSTO

                'ana.ID = idrc_comp_urea
                'ana = ana.buscar
                'preciorc_comp_urea = ana.COSTO

                '*** CUENTA MUESTRAS NO APTAS ***************************************
                'Dim mna As New dMuestrasNoAptas
                'Dim cuenta_mna As Integer = 0
                'Dim faltan As Integer = 0
                'lista3 = mna.listarporficha(idsol)
                'If Not lista3 Is Nothing Then
                '    If lista3.Count > 0 Then
                '        For Each mna In lista3
                '            cuenta_mna = cuenta_mna + mna.CANTIDAD
                '            If mna.MOTIVO = 4 Or mna.MOTIVO = 6 Then
                '                faltan = faltan + 1
                '            End If
                '        Next
                '    End If
                'End If
                '********************************************************************

                'Dim muestras As Integer = 0
                'Dim muestrastotales As Integer = 0
                'Dim muestrasanalizadas As Integer = 0
                'Dim total2 As Double = 0
                'muestras = listamuestras.Count
                'muestrasanalizadas = listamuestras.Count

                'Descuento al total de muestras las marcadas como faltan
                'muestras = muestras - faltan

                'If muestras < 20 Then
                '    muestras = 20
                '    minimomuestras = 1
                'Else
                '    If cuenta_mna > 0 Then
                '        muestras = muestras - cuenta_mna
                '        muestrastotales = muestras + cuenta_mna
                '        If muestras < 20 Then
                '            muestras = 20
                '            cuenta_mna = muestrastotales - muestras
                '        End If
                '    End If
                'End If

                'Dim subtipo As Integer
                'subtipo = sa.IDSUBINFORME

                'If subtipo = 1 Then
                '    total = muestras * preciorc_comp
                '    total2 = (cuenta_mna * preciorc_comp) * 0.5
                'ElseIf subtipo = 32 Then
                '    total = muestras * preciorc_comp_urea
                '    total2 = (cuenta_mna * preciorc_comp_urea) * 0.5
                'End If

                'If minimomuestras = 0 Then
                '    total = total + total2 + preciotimbre
                'Else
                '    total = total + preciotimbre
                'End If

                'columna = 1

                'If sa.OBSERVACIONES <> "" Then
                '    x1hoja.Cells(fila, columna).formula = "Observaciones:"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Font.Bold = True
                '    fila = fila + 1
                '    If sa.OBSERVACIONES <> "" Then
                '        x1hoja.Cells(fila, columna).formula = sa.OBSERVACIONES
                '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '        x1hoja.Cells(fila, columna).Font.Size = 8
                '        x1hoja.Cells(fila, columna).Font.Bold = False
                '        fila = fila + 1
                '    Else
                '        x1hoja.Cells(fila, columna).formula = "Sin observaciones."
                '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '        x1hoja.Cells(fila, columna).Font.Size = 8
                '        x1hoja.Cells(fila, columna).Font.Bold = False
                '        fila = fila + 1
                '    End If
                '    fila = fila + 1
                'End If

                'x1hoja.Cells(fila, columna).formula = "Total de muestras recibidas:" & " " & muestrasanalizadas
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 6
                'x1hoja.Cells(fila, columna).formula = ""
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).formula = "Valor fuera de rango (<2 o >4,5 Proteína"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'columna = 1
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & Math.Round(total, 0)
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 7
                'x1hoja.Cells(fila, columna).formula = "<2 o >5,5 Grasa)"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'columna = 1
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y timbre CJPPU"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 6
                'x1hoja.Cells(fila, columna).formula = "-"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).formula = "Análisis no requerido"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'fila = fila + 2
                'columna = 1


                'x1libro.Worksheets(1).cells(fila, columna).select()
                'x1libro.ActiveSheet.pictures.Insert("c:\Debug\dario.jpg").select()
                'x1libro.Worksheets(1).cells(2, 1).select()


                'columna = columna + 6
                'x1hoja.Cells(fila, columna).formula = "Interpretación de recuento celular"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna - 5
                'fila = fila + 1
                'Dim vallibreinfeccion As Integer = 0
                'Dim valposibleinfeccion As Integer = 0
                'Dim valprobableinfeccion As Integer = 0
                'vallibreinfeccion = (libreinfeccion / muestras) * 100
                'valposibleinfeccion = (posibleinfeccion / muestras) * 100
                'valprobableinfeccion = (probableinfeccion / muestras) * 100
                'x1hoja.Cells(fila, columna).formula = "<150: probablemente libre de infección:" & " " & libreinfeccion & " " & "(" & Math.Round(vallibreinfeccion, 0) & " %" & ")"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna - 5
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "150-400: posiblemente infectadas:" & " " & posibleinfeccion & " " & "(" & Math.Round(valposibleinfeccion, 0) & " %" & ")"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna - 5
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = ">400: probablemente infectadas:" & " " & probableinfeccion & " " & "(" & Math.Round(valprobableinfeccion, 0) & " %" & ")"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna - 5
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "R.Blowey & P. Edmonson, (1995)"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)

                '** SI HAY MUESTRAS NO APTAS ***************************************
                'If cuenta_mna > 0 Then
                '    columna = 1
                '    fila = fila + 1
                '    x1hoja.Cells(fila, columna).formula = "(**) No apta por:"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Font.Bold = True
                '    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                '    columna = columna + 1
                '    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                '    columna = columna + 1
                '    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                '    columna = columna + 1
                '    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                '    columna = 1
                '    fila = fila + 1
                '    Dim muestrasna As New dMuestrasNoAptas
                '    Dim muestrana As New dMuestraNoApta
                '    Dim motivomna As Integer = 0
                '    Dim cantidadmna As Integer = 0
                '    lista3 = muestrasna.listarporficha(idsol)
                '    If Not lista3 Is Nothing Then
                '        If lista3.Count > 0 Then
                '            For Each muestrasna In lista3
                '                motivomna = muestrasna.MOTIVO
                '                muestrana.ID = motivomna
                '                muestrana = muestrana.buscar()
                '                x1hoja.Cells(fila, columna).formula = muestrana.NOMBRE
                '                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '                x1hoja.Cells(fila, columna).Font.Size = 8
                '                x1hoja.Cells(fila, columna).Font.Bold = False
                '                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                '                columna = columna + 1
                '                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                '                columna = columna + 1
                '                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                '                columna = columna + 1
                '                cantidadmna = muestrasna.CANTIDAD
                '                x1hoja.Cells(fila, columna).formula = cantidadmna
                '                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '                x1hoja.Cells(fila, columna).Font.Size = 8
                '                x1hoja.Cells(fila, columna).Font.Bold = False
                '                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                '                columna = 1
                '                fila = fila + 1
                '            Next
                '        End If
                '    End If
                '    x1hoja.Cells(fila, columna).formula = "Muestras no aptas = 50% importe del análisis"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Font.Bold = True
                'End If



                '*******************************************************************
                'columna = 1
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO."
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Los resultados consignados se refieren exclusivamente a la muestra recibida."
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe,"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "asi como el plan y procedimientos de muestreo aplicados por el cliente. Dr. Darío Hirigoyen (Director)."
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6



            End If
        End If




        'PROTEGE LA HOJA DE EXCEL
        'x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)

        'GUARDA EL ARCHIVO DE EXCEL
        'x1hoja.SaveAs("\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CONTROL\" & idsol & ".xls")
        x1hoja.SaveAs("\\ROBOT\PRE INFORMES\CONTROL\" & idsol & ".xls")

        'Marcar como creado

        Dim preinf As New dPreinformes
        preinf.FICHA = idsol
        preinf.marcarcreado()
        preinf = Nothing

        'Dim preinfcon As New dPreinformeControl
        'preinfcon.FICHA = idsol
        'preinfcon.marcarcreado()
        'preinfcon = Nothing


        x1app.Visible = False
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub preinforme_calidad(ByVal id_sol As Long)
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'Dim c As New dCalidad
        Dim csm As New dCalidadSolicitudMuestra

        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dProductor
        Dim tec As New dTecnicos
        Dim lista As New ArrayList
        'contador_rc = 0
        '*****************************
        Dim idsol As Long = id_sol 'TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        'sa.marcar(Usuario)

        '*****************************
        Dim fila As Integer
        Dim columna As Integer

        fila = 1
        columna = 2


        '*********************** ENCABEZADO ************************************************************************
        '***********************************************************************************************************

        ''Poner Titulos
        'x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
        ' Microsoft.Office.Core.MsoTriState.msoFalse, _
        ' Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)


        'x1hoja.Shapes.AddPicture("c:\Debug\oua.jpg", _
        ' Microsoft.Office.Core.MsoTriState.msoFalse, _
        'Microsoft.Office.Core.MsoTriState.msoCTrue, 400, 140, 80, 35)



        x1hoja.Cells(1, 1).columnwidth = 7
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 5
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 8
        x1hoja.Cells(1, 12).columnwidth = 6
        x1hoja.Cells(1, 13).columnwidth = 8
        'x1hoja.Range("A1", "D1").Merge()

        'columna = 4
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Formula = "Parque El Retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'x1hoja.Range("B4", "C4").Merge()
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'x1hoja.Range("D5", "L5").Merge()
        'fila = fila + 2
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        'x1hoja.Cells(fila, columna).Formula = "INFORME - ANÁLISIS DE LECHE"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 9
        'fila = fila + 2
        'columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 2
        'x1hoja.Cells(fila, columna).formula = sa.ID
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 5
        'x1hoja.Cells(fila, columna).Formula = "Métodos y estándares:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 7
        'fila = fila + 1
        'columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Cliente:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 2
        'pro.ID = sa.IDPRODUCTOR
        'pro = pro.buscar
        'x1hoja.Cells(fila, columna).formula = pro.NOMBRE
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 5
        'x1hoja.Range("H8", "M11").Merge()
        'x1hoja.Range("H8", "M11").Borders.Color = RGB(0, 0, 0)
        'x1hoja.Range("H8", "M11").WrapText = True
        'x1hoja.Cells(fila, columna).formula = "R. Celular*(ISO13366-2:2006); Grasa*, Proteína*, Lactosa (IDF141C:2000), Crioscopía, Urea, Citrato, Caseína (Boletín FIL 393/2003); Sólidos totales* (Boletín FIL 208/1987): Método IR; R. Bacteriano: Método IBC (citometría de flujo); Inhibidores: Método Delvo Test (PE.LAB.17); Psicrótrofos: Téc. rápida en placa (ISO 8552/FIL 132:2004 mod.); Esporulados Anaerobios: NMP (INTI Lácteos mod)."
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 6
        'fila = fila + 1
        'columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Dirección:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 2
        'If pro.DIRECCION <> "" Then
        '    x1hoja.Cells(fila, columna).formula = pro.DIRECCION
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 8
        'Else
        '    x1hoja.Cells(fila, columna).formula = "No aportado"
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 8
        'End If
        'fila = fila + 1
        'columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 7
        'columna = columna + 2
        'x1hoja.Range("C10", "D10").Merge()
        'x1hoja.Cells(fila, columna).formula = sa.FECHAINGRESO
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'fila = fila + 1
        'columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Fecha emisión:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 7
        'columna = columna + 2
        'x1hoja.Range("C11", "D11").Merge()
        'Dim fecha As Date = Now()
        'Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        'x1hoja.Cells(fila, columna).formula = fecha2
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'fila = fila + 1
        'columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Paratécnico:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 7
        'columna = columna + 2
        'Dim paratecnico As String = ""
        'If idparatecnico1 = 1 Then
        '    paratecnico = paratecnico + "Diego Arenas - "
        'End If
        'If idparatecnico2 = 1 Then
        '    paratecnico = paratecnico + "Lorena Nidegger - "
        'End If
        'If idparatecnico3 = 1 Then
        '    paratecnico = paratecnico + "Claudia García - "
        'End If
        'If idparatecnico4 = 1 Then
        '    paratecnico = paratecnico + "Erika Silva - "
        'End If
        'If paratecnico <> "" Then
        '    x1hoja.Cells(fila, columna).formula = paratecnico
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 8
        '    fila = fila + 1
        '    columna = 1
        'Else
        '    x1hoja.Cells(fila, columna).formula = ""
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 8
        '    fila = fila + 1
        '    columna = 1
        'End If
        'x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de la/s muestra/s:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 6
        'Dim valtemperatura = Val(sa.TEMPERATURA)
        'If valtemperatura < 1 Or valtemperatura > 7 Then
        '    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        'End If
        'x1hoja.Cells(fila, columna).formula = sa.TEMPERATURA & " " & "Cº"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 4
        'x1hoja.Range("K13", "M13").Merge()
        'x1hoja.Range("K13", "M13").Borders.Color = RGB(0, 0, 0)
        'x1hoja.Range("K13", "M13").WrapText = True
        'x1hoja.Cells(fila, columna).formula = "* Ensayos acreditados ISO 17.025 por O.U.A."
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 6

        lista = csm.listarporsolicitud(idsol)

        'fila = fila + 2
        fila = 15
        columna = 1

        '*** FIN DEL ENCABEZADO************************************************************************************
        '**********************************************************************************************************

        x1hoja.Cells(fila, columna).Formula = "Ident."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Rc*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "R Bact."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Gr*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Pr*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Lc"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "ST*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Cr"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "MUN"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Inh"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Esp. Anaer."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Psicro."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Caseína"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = 1
        fila = fila + 1

        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("A16", "A17").Merge()
        x1hoja.Range("A16", "A17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("A16", "A17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("A16", "A17").WrapText = True
        x1hoja.Cells(fila, columna).formula = ""
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("B16", "B17").Merge()
        x1hoja.Range("B16", "B17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("B16", "B17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("B16", "B17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1.000 cel/mL"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("C16", "C17").Merge()
        x1hoja.Range("C16", "C17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("C16", "C17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("C16", "C17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1.000 eq. UFC/ml"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("D16", "D17").Merge()
        x1hoja.Range("D16", "D17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("D16", "D17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("D16", "D17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "% peso/vol"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("E16", "E17").Merge()
        x1hoja.Range("E16", "E17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("E16", "E17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("E16", "E17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "% peso/vol"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("F16", "F17").Merge()
        x1hoja.Range("F16", "F17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("F16", "F17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("F16", "F17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "% peso/vol"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("G16", "G17").Merge()
        x1hoja.Range("G16", "G17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("G16", "G17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("G16", "G17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "% peso/vol"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("H16", "H17").Merge()
        x1hoja.Range("H16", "H17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("H16", "H17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("H16", "H17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "(ºC)"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("I16", "I17").Merge()
        x1hoja.Range("I16", "I17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("I16", "I17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("I16", "I17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "mg/dl"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("J16", "J17").Merge()
        x1hoja.Range("J16", "J17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("J16", "J17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("J16", "J17").WrapText = True
        x1hoja.Cells(fila, columna).formula = ""
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("K16", "K17").Merge()
        x1hoja.Range("K16", "K17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("K16", "K17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("K16", "K17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "NMP/L"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("L16", "L17").Merge()
        x1hoja.Range("L16", "L17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("L16", "L17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("L16", "L17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1000 UFC/ml UFC/mL "
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("M16", "M17").Merge()
        x1hoja.Range("M16", "M17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("M16", "M17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("M16", "M17").WrapText = True
        x1hoja.Cells(fila, columna).formula = ""
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = 1
        fila = fila + 2


        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                'Dim cs As New dCalidadSolicitudMuestra
                'cs.IDSOLICITUD = idsol
                'cs = cs.buscar



                For Each csm In lista

                    Dim c As New dCalidad
                    c.FICHA = idsol
                    c.MUESTRA = Trim(csm.MUESTRA)
                    c = c.buscarxfichaxmuestra

                    If csm.MUESTRA <> "" Then
                        x1hoja.Cells(fila, columna).formula = Trim(csm.MUESTRA)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.RC = 1 Then
                        If Not c Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = c.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            If c.RC < 100 Then
                                'contador_rc = contador_rc + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    'x1hoja.Cells(fila, columna).formula = "-"
                    'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'columna = columna + 1
                    If csm.RB = 1 Then
                        Dim ibc As New dIbc
                        ibc.FICHA = idsol
                        ibc.MUESTRA = Trim(csm.MUESTRA)
                        ibc = ibc.buscarxfichaxmuestra
                        If Not ibc Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = ibc.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.COMPOSICION = 1 Then
                        If Not c Is Nothing Then
                            Dim valgrasa As Double = Val(c.GRASA)
                            If valgrasa < 2 Or valgrasa > 4.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = c.GRASA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.COMPOSICION = 1 Then
                        If Not c Is Nothing Then
                            Dim valproteina As Double = Val(c.PROTEINA)
                            If valproteina < 2 Or valproteina > 3.8 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = c.PROTEINA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1

                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If

                    If csm.COMPOSICION = 1 Then
                        If Not c Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = c.LACTOSA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.COMPOSICION = 1 Then
                        If Not c Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = c.ST
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.CRIOSCOPIA = 1 Or csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                        If Not c Is Nothing Then
                            If c.CRIOSCOPIA <> -1 Then
                                Dim valcrioscopia As Double = Val(c.CRIOSCOPIA) * -1 / 1000
                                If valcrioscopia > -0.51 Or valcrioscopia < -0.54 Then
                                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                End If
                                x1hoja.Cells(fila, columna).formula = valcrioscopia.ToString("##,##0.000")
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.UREA = 1 Then
                        If Not c Is Nothing Then
                            If c.UREA <> -1 Then
                                Dim valorurea As Integer
                                valorurea = c.UREA * 0.466
                                x1hoja.Cells(fila, columna).formula = valorurea
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    'x1hoja.Cells(fila, columna).formula = "-"
                    'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'columna = columna + 1
                    Dim inh As New dInhibidores
                    inh.FICHA = idsol
                    inh.MUESTRA = Trim(csm.MUESTRA)
                    inh = inh.buscarxfichaxmuestra
                    If Not inh Is Nothing Then
                        If inh.RESULTADO = 0 Then
                            x1hoja.Cells(fila, columna).formula = "Negativo"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 6
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "Positivo"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 6
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    'ESPORULADOS*******************************************************************************
                    Dim esp As New dEsporulados
                    esp.FICHA = idsol
                    esp.MUESTRA = Trim(csm.MUESTRA)
                    esp = esp.buscarxfichaxmuestra
                    If Not esp Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = esp.RESULTADO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    'PSICROTROFOS*******************************************************************************
                    Dim psi As New dPsicrotrofos
                    psi.FICHA = idsol
                    psi.MUESTRA = Trim(csm.MUESTRA)
                    psi = psi.buscarxfichaxmuestra
                    If Not psi Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = psi.PROMEDIO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If


                    If csm.CASEINA = 1 Then
                        If Not c Is Nothing Then
                            If c.CASEINA <> -1 Then
                                Dim valorcaseina As Double
                                valorcaseina = c.CASEINA
                                x1hoja.Cells(fila, columna).formula = valorcaseina
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                    End If

                    columna = 1
                    fila = fila + 1
                Next

                'Referencias
                fila = fila + 1
                columna = 1

                '******* CALCULO PRECIO ************************************************************************

                'Dim listamuestras As New ArrayList
                'listamuestras = csm.listarporsolicitud(idsol)
                'Dim total As Double
                'Dim ana As New dAnalisis

                'Dim idtimbre As Integer = 86
                'Dim idrb As Integer = 1
                'Dim idrc As Integer = 2
                'Dim idcomposicion As Integer = 3
                'Dim idinhibidores As Integer = 5
                'Dim idurea As Integer = 60
                'Dim idcrioscopia As Integer = 4
                'Dim idesporulados As Integer = 8
                'Dim idpsicrotrofos As Integer = 61
                'Dim idtermofilos As Integer = 62
                'Dim idbact_cel_comp As Integer = 100
                'Dim idbact_cel As Integer = 101
                'Dim idcrioscopia_crioscopo As Integer = 102
                'Dim idcaseina As Integer = 118
                'Dim idCalcar_composicion_crioscopia As Integer = 103
                'Dim idCalcar_RC As Integer = 104
                'Dim idCalcar_RB As Integer = 105
                'Dim idEcolat_composicion As Integer = 106
                'Dim idEcolat_RC As Integer = 107
                'Dim idEcolat_RB As Integer = 108
                'Dim idIndulacsaC_composicion As Integer = 109
                'Dim idIndulacsaC_RC As Integer = 110
                'Dim idIndulacsaC_RB As Integer = 111
                'Dim idIndulacsaS_composicion As Integer = 112
                'Dim idIndulacsaS_RC As Integer = 113
                'Dim idIndulacsaS_RB As Integer = 114
                'Dim idIndulacsaS_inhibidores As Integer = 115

                'Dim preciotimbre As Double
                'Dim preciorb As Double
                'Dim preciorc As Double
                'Dim preciocomposicion As Double
                'Dim precioinhibidores As Double
                'Dim preciourea As Double
                'Dim preciocrioscopia As Double
                'Dim precioesporulados As Double
                'Dim preciopsicrotrofos As Double
                'Dim preciotermofilos As Double
                'Dim preciobact_cel_comp As Double
                'Dim preciobact_cel As Double
                'Dim preciocrioscopia_crioscopo As Double
                'Dim preciocaseina As Double
                'Dim precioCalcar_composicion_crioscopia As Double
                'Dim precioCalcar_RC As Double
                'Dim precioCalcar_RB As Double
                'Dim precioEcolat_composicion As Double
                'Dim precioEcolat_RC As Double
                'Dim precioEcolat_RB As Double
                'Dim precioIndulacsaC_composicion As Double
                'Dim precioIndulacsaC_RC As Double
                'Dim precioIndulacsaC_RB As Double
                'Dim precioIndulacsaS_composicion As Double
                'Dim precioIndulacsaS_RC As Double
                'Dim precioIndulacsaS_RB As Double
                'Dim precioIndulacsaS_inhibidores As Double


                'If sa.IDPRODUCTOR = 219 Then
                '    ana.ID = idCalcar_composicion_crioscopia
                '    ana = ana.buscar
                '    precioCalcar_composicion_crioscopia = ana.COSTO

                '    ana.ID = idCalcar_RC
                '    ana = ana.buscar
                '    precioCalcar_RC = ana.COSTO

                '    ana.ID = idCalcar_RB
                '    ana = ana.buscar
                '    precioCalcar_RB = ana.COSTO
                'End If
                'If sa.IDPRODUCTOR = 143 Then
                '    ana.ID = idEcolat_composicion
                '    ana = ana.buscar
                '    precioEcolat_composicion = ana.COSTO

                '    ana.ID = idEcolat_RC
                '    ana = ana.buscar
                '    precioEcolat_RC = ana.COSTO

                '    ana.ID = idEcolat_RB
                '    ana = ana.buscar
                '    precioEcolat_RB = ana.COSTO
                'End If
                'If sa.IDPRODUCTOR = 150 Then
                '    ana.ID = idIndulacsaC_composicion
                '    ana = ana.buscar
                '    precioIndulacsaC_composicion = ana.COSTO

                '    ana.ID = idIndulacsaC_RC
                '    ana = ana.buscar
                '    precioIndulacsaC_RC = ana.COSTO

                '    ana.ID = idIndulacsaC_RB
                '    ana = ana.buscar
                '    precioIndulacsaC_RB = ana.COSTO
                'End If
                'If sa.IDPRODUCTOR = 2705 Then
                '    ana.ID = idIndulacsaS_composicion
                '    ana = ana.buscar
                '    precioIndulacsaS_composicion = ana.COSTO

                '    ana.ID = idIndulacsaS_RC
                '    ana = ana.buscar
                '    precioIndulacsaS_RC = ana.COSTO

                '    ana.ID = idIndulacsaS_RB
                '    ana = ana.buscar
                '    precioIndulacsaS_RB = ana.COSTO

                '    ana.ID = idIndulacsaS_inhibidores
                '    ana = ana.buscar
                '    precioIndulacsaS_inhibidores = ana.COSTO
                'End If

                'ana.ID = idtimbre
                'ana = ana.buscar
                'preciotimbre = ana.COSTO

                'ana.ID = idrb
                'ana = ana.buscar
                'preciorb = ana.COSTO

                'ana.ID = idrc
                'ana = ana.buscar
                'preciorc = ana.COSTO

                'ana.ID = idcomposicion
                'ana = ana.buscar
                'preciocomposicion = ana.COSTO

                'ana.ID = idinhibidores
                'ana = ana.buscar
                'precioinhibidores = ana.COSTO

                'ana.ID = idurea
                'ana = ana.buscar
                'preciourea = ana.COSTO

                'ana.ID = idcrioscopia
                'ana = ana.buscar
                'preciocrioscopia = ana.COSTO

                'ana.ID = idesporulados
                'ana = ana.buscar
                'precioesporulados = ana.COSTO

                'ana.ID = idpsicrotrofos
                'ana = ana.buscar
                'preciopsicrotrofos = ana.COSTO

                'ana.ID = idtermofilos
                'ana = ana.buscar
                'preciotermofilos = ana.COSTO

                'ana.ID = idbact_cel_comp
                'ana = ana.buscar
                'preciobact_cel_comp = ana.COSTO

                'ana.ID = idbact_cel
                'ana = ana.buscar
                'preciobact_cel = ana.COSTO

                'ana.ID = idcrioscopia_crioscopo
                'ana = ana.buscar
                'preciocrioscopia_crioscopo = ana.COSTO

                'ana.ID = idcaseina
                'ana = ana.buscar
                'preciocaseina = ana.COSTO

                'Dim muestras As Integer
                'muestras = listamuestras.Count

                'Dim cuentarb As Integer = 0
                'Dim cuentarb2 As Integer = 0
                'Dim cuentarc As Integer = 0
                'Dim cuentarc2 As Integer = 0
                'Dim cuentacomposicion As Integer = 0
                'Dim cuentacrioscopia As Integer = 0
                'Dim cuentainhibidores As Integer = 0
                'Dim cuentaesporulados As Integer = 0
                'Dim cuentaurea As Integer = 0
                'Dim cuentatermofilos As Integer = 0
                'Dim cuentapsicrotrofos As Integer = 0
                'Dim cuentacrioscopia_crioscopo As Integer = 0
                'Dim cuentacaseina As Integer = 0
                'Dim cuentarb_rc As Integer = 0
                'Dim cuentarb_rc2 As Integer = 0
                'Dim cuentarb_rc_composicion = 0


                'Dim listam As New ArrayList
                'listam = csm.listarrb(idsol)
                'If Not listam Is Nothing Then
                '    cuentarb = listam.Count
                '    cuentarb2 = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarrc(idsol)
                'If Not listam Is Nothing Then
                '    cuentarc = listam.Count
                '    cuentarc2 = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarcomposicion(idsol)
                'If Not listam Is Nothing Then
                '    cuentacomposicion = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarcrioscopia(idsol)
                'If Not listam Is Nothing Then
                '    cuentacrioscopia = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarinhibidores(idsol)
                'If Not listam Is Nothing Then
                '    cuentainhibidores = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listaresporulados(idsol)
                'If Not listam Is Nothing Then
                '    cuentaesporulados = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarurea(idsol)
                'If Not listam Is Nothing Then
                '    cuentaurea = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listartermofilos(idsol)
                'If Not listam Is Nothing Then
                '    cuentatermofilos = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarpsicrotrofos(idsol)
                'If Not listam Is Nothing Then
                '    cuentapsicrotrofos = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarcrioscopia_crioscopo(idsol)
                'If Not listam Is Nothing Then
                '    cuentacrioscopia_crioscopo = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listar_caseina(idsol)
                'If Not listam Is Nothing Then
                '    cuentacaseina = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarrb_rc(idsol)
                'If sa.IDPRODUCTOR = 219 Or sa.IDPRODUCTOR = 143 Or sa.IDPRODUCTOR = 150 Or sa.IDPRODUCTOR = 2705 Then

                'Else
                '    If Not listam Is Nothing Then
                '        cuentarb_rc = listam.Count

                '    End If
                '    listam = Nothing
                '    listam = csm.listarrb_rc_composicion(idsol)
                '    If Not listam Is Nothing Then

                '        cuentarb_rc_composicion = listam.Count


                '        If cuentarb_rc > cuentarb_rc_composicion Then

                '        Else
                '            cuentarb_rc = 0
                '        End If

                '    End If
                '    listam = Nothing
                'End If

                'If sa.IDPRODUCTOR = 219 Then
                '    If cuentarb > 0 Then
                '        total = total + (cuentarb * precioCalcar_RB)
                '    End If
                '    If cuentarc > 0 Then
                '        total = total + (cuentarc * precioCalcar_RC)
                '    End If
                '    If cuentacomposicion > 0 And cuentacrioscopia > 0 Then
                '        total = total + (cuentacomposicion * precioCalcar_composicion_crioscopia)
                '    End If
                '    If cuentainhibidores > 0 Then
                '        total = total + (cuentainhibidores * precioinhibidores)
                '    End If
                '    If cuentaesporulados > 0 Then
                '        total = total + (cuentaesporulados * precioesporulados)
                '    End If
                '    If cuentaurea > 0 Then
                '        total = total + (cuentaurea * preciourea)
                '    End If
                '    If cuentatermofilos > 0 Then
                '        total = total + (cuentatermofilos * preciotermofilos)
                '    End If
                '    If cuentapsicrotrofos > 0 Then
                '        total = total + (cuentapsicrotrofos * preciopsicrotrofos)
                '    End If
                '    If cuentacrioscopia_crioscopo > 0 Then
                '        total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
                '    End If
                '    If cuentacaseina > 0 Then
                '        total = total + (cuentacaseina * preciocaseina)
                '    End If

                'ElseIf sa.IDPRODUCTOR = 143 Then
                '    If cuentarb > 0 Then
                '        total = total + (cuentarb * precioEcolat_RB)
                '    End If
                '    If cuentarc > 0 Then
                '        total = total + (cuentarc * precioEcolat_RC)
                '    End If
                '    If cuentacomposicion > 0 Then
                '        total = total + (cuentacomposicion * precioEcolat_composicion)
                '    End If
                '    If cuentacrioscopia > 0 Then
                '        total = total + (cuentacrioscopia * preciocrioscopia)
                '    End If
                '    If cuentainhibidores > 0 Then
                '        total = total + (cuentainhibidores * precioinhibidores)
                '    End If
                '    If cuentaesporulados > 0 Then
                '        total = total + (cuentaesporulados * precioesporulados)
                '    End If
                '    If cuentaurea > 0 Then
                '        total = total + (cuentaurea * preciourea)
                '    End If
                '    If cuentatermofilos > 0 Then
                '        total = total + (cuentatermofilos * preciotermofilos)
                '    End If
                '    If cuentapsicrotrofos > 0 Then
                '        total = total + (cuentapsicrotrofos * preciopsicrotrofos)
                '    End If
                '    If cuentacrioscopia_crioscopo > 0 Then
                '        total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
                '    End If
                '    If cuentacaseina > 0 Then
                '        total = total + (cuentacaseina * preciocaseina)
                '    End If

                'ElseIf sa.IDPRODUCTOR = 150 Then
                '    If cuentarb > 0 Then
                '        total = total + (cuentarb * precioIndulacsaC_RB)
                '    End If
                '    If cuentarc > 0 Then
                '        total = total + (cuentarc * precioIndulacsaC_RC)
                '    End If
                '    If cuentacomposicion > 0 Then
                '        total = total + (cuentacomposicion * precioIndulacsaC_composicion)
                '    End If
                '    If cuentacrioscopia > 0 Then
                '        total = total + (cuentacrioscopia * preciocrioscopia)
                '    End If
                '    If cuentainhibidores > 0 Then
                '        total = total + (cuentainhibidores * precioinhibidores)
                '    End If
                '    If cuentaesporulados > 0 Then
                '        total = total + (cuentaesporulados * precioesporulados)
                '    End If
                '    If cuentaurea > 0 Then
                '        total = total + (cuentaurea * preciourea)
                '    End If
                '    If cuentatermofilos > 0 Then
                '        total = total + (cuentatermofilos * preciotermofilos)
                '    End If
                '    If cuentapsicrotrofos > 0 Then
                '        total = total + (cuentapsicrotrofos * preciopsicrotrofos)
                '    End If
                '    If cuentacrioscopia_crioscopo > 0 Then
                '        total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
                '    End If
                '    If cuentacaseina > 0 Then
                '        total = total + (cuentacaseina * preciocaseina)
                '    End If

                'ElseIf sa.IDPRODUCTOR = 2705 Then
                '    If cuentarb > 0 Then
                '        total = total + (cuentarb * precioIndulacsaS_RB)
                '    End If
                '    If cuentarc > 0 Then
                '        total = total + (cuentarc * precioIndulacsaS_RC)
                '    End If
                '    If cuentacomposicion > 0 Then
                '        total = total + (cuentacomposicion * precioIndulacsaS_composicion)
                '    End If
                '    If cuentacrioscopia > 0 Then
                '        total = total + (cuentacrioscopia * preciocrioscopia)
                '    End If
                '    If cuentainhibidores > 0 Then
                '        total = total + (cuentainhibidores * precioIndulacsaS_inhibidores)
                '    End If
                '    If cuentaesporulados > 0 Then
                '        total = total + (cuentaesporulados * precioesporulados)
                '    End If
                '    If cuentaurea > 0 Then
                '        total = total + (cuentaurea * preciourea)
                '    End If
                '    If cuentatermofilos > 0 Then
                '        total = total + (cuentatermofilos * preciotermofilos)
                '    End If
                '    If cuentapsicrotrofos > 0 Then
                '        total = total + (cuentapsicrotrofos * preciopsicrotrofos)
                '    End If
                '    If cuentacrioscopia_crioscopo > 0 Then
                '        total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
                '    End If
                '    If cuentacaseina > 0 Then
                '        total = total + (cuentacaseina * preciocaseina)
                '    End If

                'Else
                '    If cuentarb_rc_composicion > 0 Then
                '        total = total + (cuentarb_rc_composicion * preciobact_cel_comp)
                '    End If
                '    If cuentarb_rc > cuentarb_rc_composicion Then
                '        cuentarb_rc = cuentarb_rc - cuentarb_rc_composicion
                '        total = total + (cuentarb_rc * preciobact_cel)
                '    End If
                '    If cuentarb > 0 Then
                '        cuentarb = cuentarb - cuentarb_rc_composicion - cuentarb_rc
                '        total = total + (cuentarb * preciorb)
                '    End If
                '    If cuentarc > 0 Then
                '        cuentarc = cuentarc - cuentarb_rc_composicion - cuentarb_rc
                '        total = total + (cuentarc * preciorc)
                '    End If
                '    If cuentacomposicion > 0 Then
                '        cuentacomposicion = cuentacomposicion - cuentarb_rc_composicion
                '        total = total + (cuentacomposicion * preciocomposicion)
                '    End If

                '    If cuentacrioscopia > 0 Then
                '        total = total + (cuentacrioscopia * preciocrioscopia)
                '    End If
                '    If cuentainhibidores > 0 Then
                '        total = total + (cuentainhibidores * precioinhibidores)
                '    End If
                '    If cuentaesporulados > 0 Then
                '        total = total + (cuentaesporulados * precioesporulados)
                '    End If
                '    If cuentaurea > 0 Then
                '        total = total + (cuentaurea * preciourea)
                '    End If
                '    If cuentatermofilos > 0 Then
                '        total = total + (cuentatermofilos * preciotermofilos)
                '    End If
                '    If cuentapsicrotrofos > 0 Then
                '        total = total + (cuentapsicrotrofos * preciopsicrotrofos)
                '    End If
                '    If cuentacrioscopia_crioscopo > 0 Then
                '        total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
                '    End If
                '    If cuentacaseina > 0 Then
                '        total = total + (cuentacaseina * preciocaseina)
                '    End If

                'End If


                'total = Math.Round((total + preciotimbre), 0, MidpointRounding.AwayFromZero)


                '***********************************************************************************************
                'columna = 1

                'If sa.OBSERVACIONES <> "" Then
                '    x1hoja.Cells(fila, columna).formula = "Observaciones:"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Font.Bold = True
                '    fila = fila + 1
                '    If sa.OBSERVACIONES <> "" Then
                '        x1hoja.Cells(fila, columna).formula = sa.OBSERVACIONES
                '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '        x1hoja.Cells(fila, columna).Font.Size = 8
                '        x1hoja.Cells(fila, columna).Font.Bold = False
                '        fila = fila + 1
                '    Else
                '        x1hoja.Cells(fila, columna).formula = "Sin observaciones."
                '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '        x1hoja.Cells(fila, columna).Font.Size = 8
                '        x1hoja.Cells(fila, columna).Font.Bold = False
                '        fila = fila + 1
                '    End If
                '    fila = fila + 1
                'End If

                'x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 6
                'x1hoja.Cells(fila, columna).formula = ""
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).formula = "Valor fuera de rango (<2 o >3,8 Proteína, >4,5 Grasa % y"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'columna = 1
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y timbre CJPPU"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 7
                'x1hoja.Cells(fila, columna).formula = "Crioscopía < -0,510ºC > -0,540ºC, < 1º y > 7º Temp. de arribo)"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'columna = 1
                'fila = fila + 1
                'x1libro.Worksheets(1).cells(fila, columna).select()
                'x1libro.ActiveSheet.pictures.Insert("c:\Debug\dario.jpg").select()
                'x1libro.Worksheets(1).cells(2, 1).select()
                'columna = columna + 7
                'x1hoja.Cells(fila, columna).formula = "La indicación ''Fuera de rango''. está fuera del alcance de la acreditación"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft

                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna - 1
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "-"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).formula = "Análisis no requerido"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'fila = fila + 2
                'x1hoja.Cells(fila, columna).formula = "Rc = rec. Celular, R Bact. = Rec. Bacteriano,"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Gr = Grasa, Pr = Proteína, Lc = Lactosa, ST = Sólidos Totales,"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Cr = Crioscopía, MUN = Nitrogeno ureico en leche,"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Inh = Inihibidores, Esp = Esporulados Anaerobios,"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Psicro = Psicrótrofos"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'columna = 1
                'fila = fila + 2

                'x1hoja.Cells(fila, columna).formula = "Laboratorio habilitado RNL 0029 - MGAP"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'fila = fila + 2

                'x1hoja.Cells(fila, columna).formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO."
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Los resultados consignados se refieren exclusivamente a la muestra recibida."
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe,"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "asi como el plan y procedimientos de muestreo aplicados por el cliente. Dr. Darío Hirigoyen (Director)."
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6



            End If
        End If




        'PROTEGE LA HOJA DE EXCEL
        'x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)

        'GUARDA EL ARCHIVO DE EXCEL
        'x1hoja.SaveAs("\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CALIDAD\" & idsol & ".xls")
        x1hoja.SaveAs("\\ROBOT\PRE INFORMES\CALIDAD\" & idsol & ".xls")

        'Marcar como creado
        Dim preinf As New dPreinformes
        preinf.FICHA = idsol
        preinf.marcarcreado()
        preinf = Nothing

        'Dim preinfcal As New dPreinformeCalidad
        'preinfcal.FICHA = idsol
        'preinfcal.marcarcreado()
        'preinfcal = Nothing



        x1app.Visible = False
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

    End Sub
    Private Sub creartxt()
        Dim idficha As Long = 1 'TextFicha.Text.Trim
        Dim oSW As New StreamWriter("\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & idficha & ".txt")
        Dim c As New dControl
        Dim lista4 As New ArrayList
        lista4 = c.listarporsolicitud(idficha)
        Dim secuencial As Integer = 1

        If Not lista4 Is Nothing Then
            If lista4.Count > 0 Then
                Dim cs As New dControlSolicitud
                cs.IDSOLICITUD = idficha
                cs = cs.buscar
                Dim Linea As String = ""

                For Each c In lista4
                    Linea = Linea & secuencial & Chr(9)
                    If c.MUESTRA <> "" Then
                        Linea = Linea & c.MUESTRA + Chr(9)
                    Else
                        Linea = Linea & "-" & Chr(9)
                    End If
                    If c.GRASA = -1 Or c.GRASA = 0 Then
                        Linea = Linea & "-" & Chr(9)
                    Else
                        Dim valgrasa = Val(c.GRASA)
                        Linea = Linea & valgrasa & Chr(9)
                    End If
                    If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
                        Linea = Linea & "-" & Chr(9)
                    Else
                        Dim valproteina = Val(c.PROTEINA)
                        Linea = Linea & valproteina & Chr(9)
                    End If
                    If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
                        Linea = Linea & "-" & Chr(9)
                    Else
                        Linea = Linea & c.LACTOSA & Chr(9)
                    End If
                    'If cs.UREA = 1 Then
                    'If c.UREA = -1 Or c.UREA = 0 Then
                    'Linea = Linea & vbNewLine
                    'Else
                    'Dim valorurea As Integer
                    'valorurea = c.UREA * 0.466
                    'Linea = Linea & valorurea & vbNewLine
                    'End If
                    'Else
                    'Linea = Linea & vbNewLine
                    'End If
                    Linea = Linea & "0" & Chr(9)
                    If c.RC = -1 Then
                        Linea = Linea & "-" '& vbNewLine
                    Else
                        If c.GRASA = -1 Or c.GRASA = 0 Then
                            Linea = Linea & "-" & Chr(9)
                        Else
                            If c.RC < 4 Then
                                Linea = Linea & "4" ' & vbNewLine
                            Else
                                Linea = Linea & c.RC ' & vbNewLine
                            End If
                        End If
                    End If
                    oSW.WriteLine(Linea)
                    Linea = ""
                    secuencial = secuencial + 1
                Next
            End If
        End If

        Dim sa2 As New dSolicitudAnalisis
        sa2.ID = idficha
        sa2.NMUESTRAS = secuencial - 1
        oSW.Flush()
    End Sub
    Private Sub importar()
        ImportarBentleyDeltaIBCToolStripMenuItem.PerformClick()
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        DateFecha.Value = Now
        If nombre_pc = "ROBOT" Or nombre_pc = "IT" Then
            importar()

            Dim pi As New dPreinformes
            Dim lista As New ArrayList
            Dim creapreinformecalidad As Integer = 1

            lista = pi.listarsinmarcar

            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each pi In lista
                        If pi.TIPO = 10 Then
                            Dim csm As New dCalidadSolicitudMuestra
                            Dim listacsm As New ArrayList
                            Dim ficha As Long = pi.FICHA
                            listacsm = csm.listarporsolicitud(ficha)
                            If Not listacsm Is Nothing Then
                                creapreinformecalidad = 1
                                For Each csm In listacsm
                                    If csm.RB = 1 Then
                                        Dim ibc As New dIbc
                                        ibc.FICHA = csm.IDSOLICITUD
                                        ibc.MUESTRA = csm.MUESTRA
                                        ibc = ibc.buscarxfichaxmuestra
                                        If Not ibc Is Nothing Then

                                        Else
                                            creapreinformecalidad = 0
                                            Exit For
                                        End If
                                        ibc = Nothing
                                    End If
                                    If csm.PSICROTROFOS = 1 Then
                                        Dim psi As New dPsicrotrofos
                                        psi.FICHA = csm.IDSOLICITUD
                                        psi.MUESTRA = csm.MUESTRA
                                        psi = psi.buscarxfichaxmuestra
                                        If Not psi Is Nothing Then

                                        Else
                                            creapreinformecalidad = 0
                                            Exit For
                                        End If
                                        psi = Nothing
                                    End If
                                    If csm.ESPORULADOS = 1 Then
                                        Dim esp As New dEsporulados
                                        esp.FICHA = csm.IDSOLICITUD
                                        esp.MUESTRA = csm.MUESTRA
                                        esp = esp.buscarxfichaxmuestra
                                        If Not esp Is Nothing Then

                                        Else
                                            creapreinformecalidad = 0
                                            Exit For
                                        End If
                                        esp = Nothing
                                    End If
                                    If csm.INHIBIDORES = 1 Then
                                        Dim inh As New dInhibidores
                                        inh.FICHA = csm.IDSOLICITUD
                                        inh.MUESTRA = csm.MUESTRA
                                        inh = inh.buscarxfichaxmuestra
                                        If Not inh Is Nothing Then
                                            If inh.MARCA = 0 Then
                                                creapreinformecalidad = 0
                                                Exit For
                                            End If
                                        Else
                                            creapreinformecalidad = 0
                                            Exit For
                                        End If
                                        inh = Nothing
                                    End If

                                Next
                            End If
                            If creapreinformecalidad = 1 Then
                                preinforme_calidad(ficha)
                            End If
                        End If
                    Next
                End If
            End If

            pre_informe_control()
            'subir_informes()
            subir_informes2()
            cargarfichasparasubir()
            cargarfichassubidas()
        End If






        'If nombre_pc = "ROBOT" Or nombre_pc = "IT" Then
        '    importar()

        '    Dim pical As New dPreinformeCalidad
        '    Dim listacalidad As New ArrayList
        '    Dim creapreinformecalidad As Integer = 1

        '    listacalidad = pical.listarsinmarcar

        '    If Not listacalidad Is Nothing Then
        '        If listacalidad.Count > 0 Then
        '            For Each pical In listacalidad
        '                Dim csm As New dCalidadSolicitudMuestra
        '                Dim listacsm As New ArrayList
        '                Dim ficha As Long = pical.FICHA
        '                listacsm = csm.listarporsolicitud(ficha)
        '                If Not listacsm Is Nothing Then
        '                    creapreinformecalidad = 1
        '                    For Each csm In listacsm
        '                        If csm.RB = 1 Then
        '                            Dim ibc As New dIbc
        '                            ibc.FICHA = csm.IDSOLICITUD
        '                            ibc.MUESTRA = csm.MUESTRA
        '                            ibc = ibc.buscarxfichaxmuestra
        '                            If Not ibc Is Nothing Then

        '                            Else
        '                                creapreinformecalidad = 0
        '                                Exit For
        '                            End If
        '                            ibc = Nothing
        '                        End If
        '                        If csm.PSICROTROFOS = 1 Then
        '                            Dim psi As New dPsicrotrofos
        '                            psi.FICHA = csm.IDSOLICITUD
        '                            psi.MUESTRA = csm.MUESTRA
        '                            psi = psi.buscarxfichaxmuestra
        '                            If Not psi Is Nothing Then

        '                            Else
        '                                creapreinformecalidad = 0
        '                                Exit For
        '                            End If
        '                            psi = Nothing
        '                        End If
        '                        If csm.ESPORULADOS = 1 Then
        '                            Dim esp As New dEsporulados
        '                            esp.FICHA = csm.IDSOLICITUD
        '                            esp.MUESTRA = csm.MUESTRA
        '                            esp = esp.buscarxfichaxmuestra
        '                            If Not esp Is Nothing Then

        '                            Else
        '                                creapreinformecalidad = 0
        '                                Exit For
        '                            End If
        '                            esp = Nothing
        '                        End If
        '                        If csm.INHIBIDORES = 1 Then
        '                            Dim inh As New dInhibidores
        '                            inh.FICHA = csm.IDSOLICITUD
        '                            inh.MUESTRA = csm.MUESTRA
        '                            inh = inh.buscarxfichaxmuestra
        '                            If Not inh Is Nothing Then
        '                                If inh.MARCA = 0 Then
        '                                    creapreinformecalidad = 0
        '                                    Exit For
        '                                End If
        '                            Else
        '                                creapreinformecalidad = 0
        '                                Exit For
        '                            End If
        '                            inh = Nothing
        '                        End If
        '                    Next
        '                End If
        '                If creapreinformecalidad = 1 Then
        '                    preinforme_calidad(ficha)
        '                End If
        '            Next
        '        End If
        '    End If

        '    pre_informe_control()
        '    subir_informes()
        '    cargarfichasparasubir()
        '    cargarfichassubidas()
        'End If
    End Sub
    Private Sub pre_informe_calidad()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        Dim creapreinformecalidad As Integer = 1
        Dim id_sol As Long = 0
        lista = pi.listarsinmarcarcalidad
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pi In lista
                    Dim csm As New dCalidadSolicitudMuestra
                    Dim listacsm As New ArrayList
                    Dim ficha As Long = pi.FICHA
                    listacsm = csm.listarporsolicitud(ficha)
                    If Not listacsm Is Nothing Then
                        creapreinformecalidad = 1
                        For Each csm In listacsm
                            If csm.RB = 1 Then
                                Dim ibc As New dIbc
                                ibc.FICHA = csm.IDSOLICITUD
                                ibc.MUESTRA = csm.MUESTRA
                                ibc = ibc.buscarxfichaxmuestra
                                If Not ibc Is Nothing Then

                                Else
                                    creapreinformecalidad = 0
                                    Exit For
                                End If
                                ibc = Nothing
                            End If
                            If csm.PSICROTROFOS = 1 Then
                                Dim psi As New dPsicrotrofos
                                psi.FICHA = csm.IDSOLICITUD
                                psi.MUESTRA = csm.MUESTRA
                                psi = psi.buscarxfichaxmuestra
                                If Not psi Is Nothing Then

                                Else
                                    creapreinformecalidad = 0
                                    Exit For
                                End If
                                psi = Nothing
                            End If
                            If csm.ESPORULADOS = 1 Then
                                Dim esp As New dEsporulados
                                esp.FICHA = csm.IDSOLICITUD
                                esp.MUESTRA = csm.MUESTRA
                                esp = esp.buscarxfichaxmuestra
                                If Not esp Is Nothing Then

                                Else
                                    creapreinformecalidad = 0
                                    Exit For
                                End If
                                esp = Nothing
                            End If
                            If csm.INHIBIDORES = 1 Then
                                Dim inh As New dInhibidores
                                inh.FICHA = csm.IDSOLICITUD
                                inh.MUESTRA = csm.MUESTRA
                                inh = inh.buscarxfichaxmuestra
                                If Not inh Is Nothing Then
                                    If inh.MARCA = 0 Then
                                        creapreinformecalidad = 0
                                        Exit For
                                    End If
                                Else
                                    creapreinformecalidad = 0
                                    Exit For
                                End If
                                inh = Nothing
                            End If
                        Next
                    End If
                    If creapreinformecalidad = 1 Then

                        preinforme_calidad(ficha)
                    End If
                Next
            End If
        End If
        pi = Nothing
        lista = Nothing
    End Sub
    Private Sub pre_informe_control()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        Dim id_sol As Long = 0
        lista = pi.listarsinmarcarcontrol
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pi In lista
                    id_sol = pi.FICHA
                    preinforme_control(id_sol)
                Next
            End If
        End If
        pi = Nothing
        lista = Nothing
    End Sub

    Private Sub ControlLecheroNUEVOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlLecheroNUEVOToolStripMenuItem.Click
        Dim v As New FormInformeControlLechero2(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pre_informe_calidad()
        pre_informe_control()
    End Sub

    Private Sub CalidadDeLecheNUEVOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalidadDeLecheNUEVOToolStripMenuItem.Click
        Dim v As New FormInformeCalidadLeche2(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub SubirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubirToolStripMenuItem.Click
        Dim v As New FormSubirInformes2(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub subir_informes()
        Dim picalidad As New dPreinformeCalidad
        Dim picontrol As New dPreinformeControl
        Dim listacalidad As New ArrayList
        Dim listacontrol As New ArrayList
        listacalidad = picalidad.listarparasubir
        listacontrol = picontrol.listarparasubir
        If Not listacalidad Is Nothing Then
            If listacalidad.Count > 0 Then
                For Each picalidad In listacalidad
                    idficha = picalidad.FICHA
                    enviar_copia = picalidad.COPIA
                    _abonado = picalidad.ABONADO
                    _comentarios = picalidad.COMENTARIO

                    Dim sa As New dSolicitudAnalisis
                    sa.ID = idficha
                    sa = sa.buscar
                    If Not sa Is Nothing Then
                        Dim p As New dProductor
                        tipoinforme = sa.IDTIPOINFORME
                        p.ID = sa.IDPRODUCTOR
                        p = p.buscar
                        If Not p Is Nothing Then
                            If p.MOROSO = 1 Then
                                _moroso = 1
                            End If
                            productorweb_com = p.USUARIO_WEB
                            Dim pw_com As New dProductorWeb_com
                            pw_com.USUARIO = productorweb_com
                            pw_com = pw_com.buscar
                            If Not pw_com Is Nothing Then
                                idproductorweb_com = pw_com.ID
                                'email = RTrim(pw_com.ENVIAR_EMAIL)
                                email = Replace(pw_com.ENVIAR_EMAIL, " ", "")
                                celular = Replace(pw_com.ENVIAR_SMS, " ", "")
                            End If

                            sa = Nothing
                        End If
                    End If





controlexcel:
                    subirFicheroXls()
                    existeXls()
                    If excel = 1 Then
                        GoTo controlexcel
                    End If
                    moverexcel()

controlpdf:
                    subirFicheroPdf()
                    existePdf()
                    If pdf = 1 Then
                        GoTo controlpdf
                    End If
                    moverpdf()




                    modificarRegistro()
                    Dim fechaactual As Date = Now()
                    Dim _fecha As String
                    _fecha = Format(fechaactual, "yyyy-MM-dd")
                    picalidad.marcarsubido(_fecha)

                    If tipoinforme = 15 Then
                        enviaremail()
                    End If


                    Dim s As New dSolicitudAnalisis
                    Dim fechaenvio As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                    Dim fecenv As String
                    fecenv = Format(fechaenvio, "yyyy-MM-dd")
                    s.ID = idficha
                    s.actualizarfechaenvio2(fecenv)
                    enviomail()
                    enviosms()
                    s.marcar2()
                    s = Nothing
                Next
            End If
        End If

        If Not listacontrol Is Nothing Then
            If listacontrol.Count > 0 Then
                For Each picontrol In listacontrol
                    idficha = picontrol.FICHA
                    enviar_copia = picontrol.COPIA
                    _abonado = picontrol.ABONADO
                    _comentarios = picontrol.COMENTARIO

                    Dim sa As New dSolicitudAnalisis
                    sa.ID = idficha
                    sa = sa.buscar
                    If Not sa Is Nothing Then
                        Dim p As New dProductor
                        tipoinforme = sa.IDTIPOINFORME
                        p.ID = sa.IDPRODUCTOR
                        p = p.buscar
                        If Not p Is Nothing Then
                            productorweb_com = p.USUARIO_WEB
                            Dim pw_com As New dProductorWeb_com
                            pw_com.USUARIO = productorweb_com
                            pw_com = pw_com.buscar
                            If Not pw_com Is Nothing Then
                                idproductorweb_com = pw_com.ID
                                email = RTrim(pw_com.ENVIAR_EMAIL)
                                celular = Replace(pw_com.ENVIAR_SMS, " ", "")
                            End If

                            sa = Nothing
                        End If
                    End If

controlexcel2:
                    subirFicheroXls()
                    existeXls()
                    If excel = 1 Then
                        GoTo controlexcel2
                    End If
                    moverexcel()

controlpdf2:
                    subirFicheroPdf()
                    existePdf()
                    If pdf = 1 Then
                        GoTo controlpdf2
                    End If
                    moverpdf()

controlcsv2:
                    subirFicheroCsv()
                    existeCsv()
                    If csv = 1 Then
                        GoTo controlcsv2
                    End If
                    movertxt()

                    modificarRegistro()
                    Dim fechaactual As Date = Now()
                    Dim _fecha As String
                    _fecha = Format(fechaactual, "yyyy-MM-dd")
                    picontrol.marcarsubido(_fecha)

                    If tipoinforme = 15 Then
                        enviaremail()
                    End If


                    Dim s As New dSolicitudAnalisis
                    Dim fechaenvio As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                    Dim fecenv As String
                    fecenv = Format(fechaenvio, "yyyy-MM-dd")
                    s.ID = idficha
                    s.actualizarfechaenvio2(fecenv)
                    enviomail()
                    enviosms()
                    s.marcar2()
                    s = Nothing
                Next
            End If
        End If
    End Sub
    Private Sub subir_informes2()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        Dim subidoxls As Integer = 0
        Dim subidopdf As Integer = 0
        Dim subidotxt As Integer = 0
        lista = pi.listarparasubir
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pi In lista
                    idficha = pi.FICHA
                    _tipoinforme = pi.TIPO
                    enviar_copia = pi.COPIA
                    _abonado = pi.ABONADO
                    _comentarios = pi.COMENTARIO

                    Dim sa As New dSolicitudAnalisis
                    sa.ID = idficha
                    sa = sa.buscar
                    If Not sa Is Nothing Then
                        Dim p As New dProductor
                        tipoinforme = sa.IDTIPOINFORME
                        p.ID = sa.IDPRODUCTOR
                        p = p.buscar
                        If Not p Is Nothing Then
                            If p.MOROSO = 1 Then
                                _moroso = 1
                            End If
                            productorweb_com = p.USUARIO_WEB
                            Dim pw_com As New dProductorWeb_com
                            pw_com.USUARIO = productorweb_com
                            pw_com = pw_com.buscar
                            If Not pw_com Is Nothing Then
                                idproductorweb_com = pw_com.ID
                                email = RTrim(pw_com.ENVIAR_EMAIL)
                                celular = Replace(pw_com.ENVIAR_SMS, " ", "")
                            End If

                            sa = Nothing
                        End If
                    End If





controlexcel:
                    subirFicheroXls()
                    existeXls()
                    If excel = 1 Then
                        GoTo controlexcel
                    End If
                    'moverexcel()
                    subidoxls = 1

controlpdf:
                    subirFicheroPdf()
                    existePdf()
                    If pdf = 1 Then
                        GoTo controlpdf
                    End If
                    'moverpdf()
                    subidopdf = 1

                    If pi.TIPO = 1 Then
controltxt:
                        subirFicheroCsv()
                        existeCsv()
                        If csv = 1 Then
                            GoTo controltxt
                        End If
                        movertxt()
                    End If



                    modificarRegistro()
                    Dim fechaactual As Date = Now()
                    Dim _fecha As String
                    _fecha = Format(fechaactual, "yyyy-MM-dd")
                    pi.marcarsubido(_fecha)

                    If tipoinforme = 15 Then
                        enviaremail()
                        enviaremail2()
                    End If


                    Dim s As New dSolicitudAnalisis
                    Dim fechaenvio As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                    Dim fecenv As String
                    fecenv = Format(fechaenvio, "yyyy-MM-dd")
                    s.ID = idficha
                    s.actualizarfechaenvio2(fecenv)
                    enviomail()
                    enviosms()
                    s.marcar2()
                    s = Nothing

                    If subidoxls = 1 And subidopdf = 1 Then
                        moverexcel()
                        moverpdf()
                    End If

                Next
            End If
        End If
    End Sub
    Private Sub enviocopia()

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim enviarcopia As String = ""
        Dim fichero As String = ""
        Dim tipo As String = ""
        enviarcopia = enviar_copia
        If tipoinforme = 1 Then
            fichero = "\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & idficha & ".xls"
            tipo = "Control lechero"
        ElseIf tipoinforme = 3 Then
            fichero = "\\SRVCOLAVECO\D\NET\AGUA\" & idficha & ".xls"
            tipo = "Agua"
        ElseIf tipoinforme = 4 Then
            fichero = "\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            tipo = "Antibiograma"
        ElseIf tipoinforme = 5 Then
            fichero = "\\SRVCOLAVECO\D\NET\PAL\" & idficha & ".xls"
            tipo = "PAL"
        ElseIf tipoinforme = 6 Then
            fichero = "\\SRVCOLAVECO\D\NET\PARASITOLOGIA\" & idficha & ".xls"
            tipo = "Parasitología"
        ElseIf tipoinforme = 7 Then
            fichero = "\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & idficha & ".xls"
            tipo = "Subproductos"
        ElseIf tipoinforme = 8 Then
            fichero = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & idficha & ".xls"
            tipo = "Serología"
        ElseIf tipoinforme = 9 Then
            fichero = "\\SRVCOLAVECO\D\NET\PATOLOGIA\" & idficha & ".xls"
            tipo = "Patología"
        ElseIf tipoinforme = 10 Then
            fichero = "\\SRVCOLAVECO\D\NET\CALIDAD\" & idficha & ".xls"
            tipo = "Calidad de leche"
        ElseIf tipoinforme = 11 Then
            fichero = "\\SRVCOLAVECO\D\NET\AMBIENTAL\" & idficha & ".xls"
            tipo = "Prueba ambiental"
        ElseIf tipoinforme = 12 Then
            fichero = "\\SRVCOLAVECO\D\NET\LACTOMETROS\" & idficha & ".xls"
            tipo = "Lactómetros"
        ElseIf tipoinforme = 13 Then
            fichero = "\\SRVCOLAVECO\D\NET\AGRONUTRICION\" & idficha & ".xls"
            tipo = "Agro-nutrición"
        ElseIf tipoinforme = 14 Then
            fichero = "\\SRVCOLAVECO\D\NET\Agro - Suelos\" & idficha & ".xls"
            tipo = "Agro-suelos"
        ElseIf tipoinforme = 15 Then
            fichero = "\\SRVCOLAVECO\D\NET\Brucelosis en leche\" & idficha & ".xls"
            tipo = "Brucelosis en leche"
        ElseIf tipoinforme = 99 Then
            fichero = "\\SRVCOLAVECO\D\NET\OTROS\" & idficha & ".xls"
            tipo = "Otros"
        End If

        If enviarcopia <> "" Then

            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            _Message.[To].Add(enviarcopia)
            '_Message.[To].Add("pepobaez@gmail.com")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Informe" & " " & idficha & " - " & tipo
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "Adjunto informe:" & " " & tipo
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False


            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = fichero 'My.Application.Info.DirectoryPath & fichero 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                '_SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try


            _SMTP.Send(_Message)
            'MessageBox.Show("Pedidos enviados!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If




    End Sub
    Public Function existeXls() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "CLV1582782"
        If tipoinforme = 1 Then
            fichero = "\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            fichero = "\\SRVCOLAVECO\D\NET\AGUA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            fichero = "\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 5 Then
            fichero = "\\SRVCOLAVECO\D\NET\PAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy.uy/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            fichero = "\\SRVCOLAVECO\D\NET\PARASITOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            fichero = "\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            fichero = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            fichero = "\\SRVCOLAVECO\D\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            fichero = "\\SRVCOLAVECO\D\NET\CALIDAD\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            fichero = "\\SRVCOLAVECO\D\NET\AMBIENTAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 12 Then
            fichero = "\\SRVCOLAVECO\D\NET\LACTOMETROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            fichero = "\\SRVCOLAVECO\D\NET\AGRO - NUTRICION\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Then
            fichero = "\\SRVCOLAVECO\D\NET\Agro - Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            fichero = "\\SRVCOLAVECO\D\NET\Brucelosis en leche\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"

        ElseIf tipoinforme = 99 Then
            fichero = "\\SRVCOLAVECO\D\NET\OTROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".xls"
        End If

        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(destino)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp

        peticionFTP.UsePassive = False

        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            excel = 0
            Return True

        Catch ex As Exception
            mensaje = mensaje & " excel(com) - "
            excel = 1
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function
    Public Function existePdf() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "CLV1582782"
        If tipoinforme = 1 Then
            fichero = "\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            fichero = "\\SRVCOLAVECO\D\NET\AGUA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            fichero = "\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 5 Then
            fichero = "\\SRVCOLAVECO\D\NET\PAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            fichero = "\\SRVCOLAVECO\D\NET\PARASITOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            fichero = "\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            fichero = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            fichero = "\\SRVCOLAVECO\D\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            fichero = "\\SRVCOLAVECO\D\NET\CALIDAD\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            fichero = "\\SRVCOLAVECO\D\NET\AMBIENTAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 12 Then
            fichero = "\\SRVCOLAVECO\D\NET\LACTOMETROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            fichero = "\\SRVCOLAVECO\D\NET\AGRONUTRICION\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Then
            fichero = "\\SRVCOLAVECO\D\NET\Agro - Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            fichero = "\\SRVCOLAVECO\D\NET\Brucelosis en leche\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            fichero = "\\SRVCOLAVECO\D\NET\OTROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".pdf"
        End If

        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(destino)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp

        peticionFTP.UsePassive = False

        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            pdf = 0
            Return True
        Catch ex As Exception
            mensaje = mensaje & " pdf(com) - "
            pdf = 1
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function
    Public Function existeCsv() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "CLV1582782"
        If tipoinforme = 1 Then
            fichero = "\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
        ElseIf tipoinforme = 3 Then
            fichero = "\\SRVCOLAVECO\D\NET\AGUA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".txt"
        ElseIf tipoinforme = 4 Then
            fichero = "\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".txt"
        ElseIf tipoinforme = 5 Then
            fichero = "\\SRVCOLAVECO\D\NET\PAL\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".txt"
        ElseIf tipoinforme = 6 Then
            fichero = "\\SRVCOLAVECO\D\NET\PARASITOLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".txt"
        ElseIf tipoinforme = 7 Then
            fichero = "\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".txt"
        ElseIf tipoinforme = 8 Then
            fichero = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".txt"
        ElseIf tipoinforme = 9 Then
            fichero = "\\SRVCOLAVECO\D\NET\PATOLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".txt"
        ElseIf tipoinforme = 10 Then
            fichero = "\\SRVCOLAVECO\D\NET\CALIDAD\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".txt"
        ElseIf tipoinforme = 11 Then
            fichero = "\\SRVCOLAVECO\D\NET\AMBIENTAL\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".txt"
        ElseIf tipoinforme = 12 Then
            fichero = "\\SRVCOLAVECO\D\NET\LACTOMETROS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".txt"
        ElseIf tipoinforme = 13 Then
            fichero = "\\SRVCOLAVECO\D\NET\AGRONUTRICION\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".txt"
        ElseIf tipoinforme = 99 Then
            fichero = "\\SRVCOLAVECO\D\NET\OTROS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".txt"
        End If

        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(destino)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp

        peticionFTP.UsePassive = False

        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            csv = 0
            Return True
        Catch ex As Exception
            mensaje = mensaje & " csv(com) - "
            csv = 1
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function



    Public Function subirFicheroXls() As String

        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "CLV1582782"
        'Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/1"
        If tipoinforme = 1 Then
            'fichero = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            'fichero = "\\SRVCOLAVECO\D\NET\AGUA\" & idficha & ".xls"
            fichero = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            'fichero = "\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            fichero = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 5 Then
            fichero = "\\SRVCOLAVECO\D\NET\PAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            fichero = "\\SRVCOLAVECO\D\NET\PARASITOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            'fichero = "\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & idficha & ".xls"
            fichero = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            fichero = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            fichero = "\\SRVCOLAVECO\D\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            'fichero = "\\SRVCOLAVECO\D\NET\CALIDAD\" & idficha & ".xls"
            'fichero = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            fichero = "\\SRVCOLAVECO\D\NET\AMBIENTAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 12 Then
            fichero = "\\SRVCOLAVECO\D\NET\LACTOMETROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            fichero = "\\SRVCOLAVECO\D\NET\AGRO - NUTRICION\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Then
            crea_agro_suelos_com()
            fichero = "\\SRVCOLAVECO\D\NET\Agro - Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            crea_brucelosis_leche_com()
            fichero = "\\SRVCOLAVECO\D\NET\Brucelosis en leche\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            fichero = "\\SRVCOLAVECO\D\NET\OTROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".xls"
        End If


        Dim infoFichero As New FileInfo(fichero)

        Dim uri As String
        uri = destino

        ' Si no existe el directorio, lo creamos
        'If Not existeObjeto(dir) Then
        'creaDirectorio(dir)
        'End If

        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del fichero que vamos a subir
        peticionFTP = CType(FtpWebRequest.Create(New Uri(destino)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        peticionFTP.KeepAlive = False
        peticionFTP.UsePassive = False

        ' Seleccionamos el comando que vamos a utilizar: Subir un fichero
        peticionFTP.Method = WebRequestMethods.Ftp.UploadFile

        ' Especificamos el tipo de transferencia de datos
        peticionFTP.UseBinary = True

        ' Informamos al servidor sobre el tamaño del fichero que vamos a subir
        peticionFTP.ContentLength = infoFichero.Length

        ' Fijamos un buffer de 150KB
        Dim longitudBuffer As Integer
        longitudBuffer = 153600
        Dim lector As Byte() = New Byte(153600) {}

        Dim num As Integer

        ' Abrimos el fichero para subirlo
        Dim fs As FileStream
        fs = infoFichero.OpenRead()

        Try
            Dim escritor As Stream
            escritor = peticionFTP.GetRequestStream()

            ' Leemos 150 KB del fichero en cada iteración
            num = fs.Read(lector, 0, longitudBuffer)

            While (num <> 0)
                ' Escribimos el contenido del flujo de lectura en el
                ' flujo de escritura del comando FTP
                escritor.Write(lector, 0, num)
                num = fs.Read(lector, 0, longitudBuffer)
            End While

            escritor.Close()
            fs.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function

    Public Function subirFicheroPdf() As String

        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "CLV1582782"
        'Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/1"
        If tipoinforme = 1 Then
            'fichero = "\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            'fichero = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            'fichero = "\\SRVCOLAVECO\D\NET\AGUA\" & idficha & ".pdf"
            fichero = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            'fichero = "\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            fichero = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 5 Then
            fichero = "\\SRVCOLAVECO\D\NET\PAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            fichero = "\\SRVCOLAVECO\D\NET\PARASITOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            'fichero = "\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & idficha & ".pdf"
            fichero = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            fichero = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            fichero = "\\SRVCOLAVECO\D\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            'fichero = "\\SRVCOLAVECO\D\NET\CALIDAD\" & idficha & ".pdf"
            'fichero = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            fichero = "\\SRVCOLAVECO\D\NET\AMBIENTAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 12 Then
            fichero = "\\SRVCOLAVECO\D\NET\LACTOMETROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            fichero = "\\SRVCOLAVECO\D\NET\AGRO - NUTRICION\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Then
            fichero = "\\SRVCOLAVECO\D\NET\Agro - Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            fichero = "\\SRVCOLAVECO\D\NET\Brucelosis en leche\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            fichero = "\\SRVCOLAVECO\D\NET\OTROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".pdf"
        End If


        Dim infoFichero As New FileInfo(fichero)

        Dim uri As String
        uri = destino

        ' Si no existe el directorio, lo creamos
        'If Not existeObjeto(dir) Then
        'creaDirectorio(dir)
        'End If

        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del fichero que vamos a subir
        peticionFTP = CType(FtpWebRequest.Create(New Uri(destino)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        peticionFTP.KeepAlive = False
        peticionFTP.UsePassive = False

        ' Seleccionamos el comando que vamos a utilizar: Subir un fichero
        peticionFTP.Method = WebRequestMethods.Ftp.UploadFile

        ' Especificamos el tipo de transferencia de datos
        peticionFTP.UseBinary = True

        ' Informamos al servidor sobre el tamaño del fichero que vamos a subir
        peticionFTP.ContentLength = infoFichero.Length

        ' Fijamos un buffer de 150KB
        Dim longitudBuffer As Integer
        longitudBuffer = 153600
        Dim lector As Byte() = New Byte(153600) {}

        Dim num As Integer

        ' Abrimos el fichero para subirlo
        Dim fs As FileStream
        fs = infoFichero.OpenRead()

        Try
            Dim escritor As Stream
            escritor = peticionFTP.GetRequestStream()

            ' Leemos 150 KB del fichero en cada iteración
            num = fs.Read(lector, 0, longitudBuffer)

            While (num <> 0)
                ' Escribimos el contenido del flujo de lectura en el
                ' flujo de escritura del comando FTP
                escritor.Write(lector, 0, num)
                num = fs.Read(lector, 0, longitudBuffer)
            End While

            escritor.Close()
            fs.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function
    Public Function subirFicheroCsv() As String

        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "CLV1582782"
        'Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/1"
        If tipoinforme = 1 Then

            fichero = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
            'ElseIf tipoinforme = 3 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\AGUA\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".txt"
            'ElseIf tipoinforme = 4 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".txt"
            'ElseIf tipoinforme = 5 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\PAL\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".txt"
            'ElseIf tipoinforme = 6 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\PARASITOLOGIA\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".txt"
            'ElseIf tipoinforme = 7 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".txt"
            'ElseIf tipoinforme = 8 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\SEROLOGIA\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".txt"
            'ElseIf tipoinforme = 9 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\PATOLOGIA\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".txt"
            'ElseIf tipoinforme = 10 Then
            '    fichero = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".txt"
            'ElseIf tipoinforme = 11 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\AMBIENTAL\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".txt"
            'ElseIf tipoinforme = 12 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\LACTOMETROS\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".txt"
            'ElseIf tipoinforme = 13 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\AGRO - NUTRICION\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".txt"
            'ElseIf tipoinforme = 14 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\Agro - Suelos\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".txt"
            'ElseIf tipoinforme = 15 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\Brucelosis en leche\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".txt"
            'ElseIf tipoinforme = 99 Then
            '    fichero = "\\SRVCOLAVECO\D\NET\OTROS\" & idficha & ".txt"
            '    destino = "ftp://colaveco.com.uy/www/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".txt"
        End If


        Dim infoFichero As New FileInfo(fichero)

        Dim uri As String
        uri = destino

        ' Si no existe el directorio, lo creamos
        'If Not existeObjeto(dir) Then
        'creaDirectorio(dir)
        'End If

        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del fichero que vamos a subir
        peticionFTP = CType(FtpWebRequest.Create(New Uri(destino)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        peticionFTP.KeepAlive = False
        peticionFTP.UsePassive = False

        ' Seleccionamos el comando que vamos a utilizar: Subir un fichero
        peticionFTP.Method = WebRequestMethods.Ftp.UploadFile

        ' Especificamos el tipo de transferencia de datos
        peticionFTP.UseBinary = True

        ' Informamos al servidor sobre el tamaño del fichero que vamos a subir
        peticionFTP.ContentLength = infoFichero.Length

        ' Fijamos un buffer de 150KB
        Dim longitudBuffer As Integer
        longitudBuffer = 153600
        Dim lector As Byte() = New Byte(153600) {}

        Dim num As Integer

        ' Abrimos el fichero para subirlo
        Dim fs As FileStream
        fs = infoFichero.OpenRead()

        Try
            Dim escritor As Stream
            escritor = peticionFTP.GetRequestStream()

            ' Leemos 150 KB del fichero en cada iteración
            num = fs.Read(lector, 0, longitudBuffer)

            While (num <> 0)
                ' Escribimos el contenido del flujo de lectura en el
                ' flujo de escritura del comando FTP
                escritor.Write(lector, 0, num)
                num = fs.Read(lector, 0, longitudBuffer)
            End While

            escritor.Close()
            fs.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function




    Public Sub modificarRegistro()

        If tipoinforme = 1 Then 'SI EL TIPO DE INFORME ES DE CONTROL LECHERO
            Dim cw_com As New dControlLecheroWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado
            'If _moroso = 1 Then
            '    abonado = 0
            'End If

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"

            Dim id_estado As Integer = 3

            cw_com.FICHA = idficha
            cw_com = cw_com.buscar
            If Not cw_com Is Nothing Then
                If comentarios <> "" Then
                    cw_com.COMENTARIO = comentarios
                End If
                cw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                cw_com.FECHA_EMISION = fechaemi
                cw_com.PATH_EXCEL = path_excel
                cw_com.PATH_PDF = path_pdf
                cw_com.PATH_CSV = path_csv
                cw_com.ID_ESTADO = id_estado
                If (cw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim cweb_com As New dControlLecheroWeb_com
                cweb_com.ID_USUARIO = idproductorweb_com

                If comentarios <> "" Then
                    cweb_com.COMENTARIO = comentarios
                End If
                cweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                cweb_com.FECHA_CREADO = fechaemi
                cweb_com.FECHA_EMISION = fechaemi
                cweb_com.PATH_EXCEL = path_excel
                cweb_com.PATH_PDF = path_pdf
                cweb_com.PATH_CSV = path_csv
                cweb_com.FICHA = idficha
                cweb_com.ID_ESTADO = id_estado
                cweb_com.ID_LIBRO = idficha
                If (cweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 3 Then 'SI EL TIPO DE INFORME ES DE AGUA
            Dim aw_com As New dAguaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".txt"
            Dim id_estado As Integer = 3
            aw_com.FICHA = idficha
            aw_com = aw_com.buscar
            If Not aw_com Is Nothing Then
                If comentarios <> "" Then
                    aw_com.COMENTARIO = comentarios
                End If
                aw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aw_com.FECHA_EMISION = fechaemi
                aw_com.PATH_EXCEL = path_excel
                aw_com.PATH_PDF = path_pdf
                aw_com.PATH_CSV = path_csv
                aw_com.ID_ESTADO = id_estado
                If (aw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim aweb_com As New dAguaWeb_com
                aweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    aweb_com.COMENTARIO = comentarios
                End If
                aweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aweb_com.FECHA_CREADO = fechaemi
                aweb_com.FECHA_EMISION = fechaemi
                aweb_com.PATH_EXCEL = path_excel
                aweb_com.PATH_PDF = path_pdf
                aweb_com.PATH_CSV = path_csv
                aweb_com.FICHA = idficha
                aweb_com.ID_ESTADO = id_estado
                aweb_com.ID_LIBRO = idficha
                If (aweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 4 Then 'SI EL TIPO DE INFORME ES DE BACTERIOLOGÍA Y ANTIBIOGRAMA
            Dim aw_com As New dAntibiogramaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            aw_com.FICHA = idficha
            aw_com = aw_com.buscar
            If Not aw_com Is Nothing Then
                If comentarios <> "" Then
                    aw_com.COMENTARIO = comentarios
                End If
                aw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aw_com.FECHA_EMISION = fechaemi
                aw_com.PATH_EXCEL = path_excel
                aw_com.PATH_PDF = path_pdf
                aw_com.PATH_CSV = path_csv
                aw_com.ID_ESTADO = id_estado
                If (aw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim aweb_com As New dAntibiogramaWeb_com
                aweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    aweb_com.COMENTARIO = comentarios
                End If
                aweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aweb_com.FECHA_CREADO = fechaemi
                aweb_com.FECHA_EMISION = fechaemi
                aweb_com.PATH_EXCEL = path_excel
                aweb_com.PATH_PDF = path_pdf
                aweb_com.PATH_CSV = path_csv
                aweb_com.FICHA = idficha
                aweb_com.ID_ESTADO = id_estado
                aweb_com.ID_LIBRO = idficha
                If (aweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 5 Then 'SI EL TIPO DE INFORME ES DE PAL
            Dim palw_com As New dPalWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            palw_com.FICHA = idficha
            palw_com = palw_com.buscar
            If Not palw_com Is Nothing Then
                If comentarios <> "" Then
                    palw_com.COMENTARIO = comentarios
                End If
                palw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                palw_com.FECHA_EMISION = fechaemi
                palw_com.PATH_EXCEL = path_excel
                palw_com.PATH_PDF = path_pdf
                palw_com.PATH_CSV = path_csv
                palw_com.ID_ESTADO = id_estado
                If (palw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim palweb_com As New dPalWeb_com
                palweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    palweb_com.COMENTARIO = comentarios
                End If
                palweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                palweb_com.FECHA_CREADO = fechaemi
                palweb_com.FECHA_EMISION = fechaemi
                palweb_com.PATH_EXCEL = path_excel
                palweb_com.PATH_PDF = path_pdf
                palweb_com.PATH_CSV = path_csv
                palweb_com.FICHA = idficha
                palweb_com.ID_ESTADO = id_estado
                palweb_com.ID_LIBRO = idficha
                If (palweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 6 Then 'SI EL TIPO DE INFORME ES DE PARASITOLOGÍA
            Dim paw_com As New dParasitologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            paw_com.FICHA = idficha
            paw_com = paw_com.buscar
            If Not paw_com Is Nothing Then
                If comentarios <> "" Then
                    paw_com.COMENTARIO = comentarios
                End If
                paw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                paw_com.FECHA_EMISION = fechaemi
                paw_com.PATH_EXCEL = path_excel
                paw_com.PATH_PDF = path_pdf
                paw_com.PATH_CSV = path_csv
                paw_com.ID_ESTADO = id_estado
                If (paw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim pweb_com As New dParasitologiaWeb_com
                pweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    pweb_com.COMENTARIO = comentarios
                End If
                pweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                pweb_com.FECHA_CREADO = fechaemi
                pweb_com.FECHA_EMISION = fechaemi
                pweb_com.PATH_EXCEL = path_excel
                pweb_com.PATH_PDF = path_pdf
                pweb_com.PATH_CSV = path_csv
                pweb_com.FICHA = idficha
                pweb_com.ID_ESTADO = id_estado
                pweb_com.ID_LIBRO = idficha
                If (pweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 7 Then 'SI EL TIPO DE INFORME ES DE PRODÚCTOS LÁCTEOS
            Dim spw_com As New dSubproductosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            spw_com.FICHA = idficha
            spw_com = spw_com.buscar
            If Not spw_com Is Nothing Then
                If comentarios <> "" Then
                    spw_com.COMENTARIO = comentarios
                End If
                spw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                spw_com.FECHA_EMISION = fechaemi
                spw_com.PATH_EXCEL = path_excel
                spw_com.PATH_PDF = path_pdf
                spw_com.PATH_CSV = path_csv
                spw_com.ID_ESTADO = id_estado
                If (spw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim spweb_com As New dSubproductosWeb_com
                spweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    spweb_com.COMENTARIO = comentarios
                End If
                spweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                spweb_com.FECHA_CREADO = fechaemi
                spweb_com.FECHA_EMISION = fechaemi
                spweb_com.PATH_EXCEL = path_excel
                spweb_com.PATH_PDF = path_pdf
                spweb_com.PATH_CSV = path_csv
                spweb_com.FICHA = idficha
                spweb_com.ID_ESTADO = id_estado
                spweb_com.ID_LIBRO = idficha
                If (spweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

        ElseIf tipoinforme = 8 Then 'SI EL TIPO DE INFORME ES DE SEROLOGÍA
            Dim sw_com As New dSerologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            sw_com.FICHA = idficha
            sw_com = sw_com.buscar
            If Not sw_com Is Nothing Then
                If comentarios <> "" Then
                    sw_com.COMENTARIO = comentarios
                End If
                sw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                sw_com.FECHA_EMISION = fechaemi
                sw_com.PATH_EXCEL = path_excel
                sw_com.PATH_PDF = path_pdf
                sw_com.PATH_CSV = path_csv
                sw_com.ID_ESTADO = id_estado
                If (sw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim sweb_com As New dSerologiaWeb_com
                sweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    sweb_com.COMENTARIO = comentarios
                End If
                sweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                sweb_com.FECHA_CREADO = fechaemi
                sweb_com.FECHA_EMISION = fechaemi
                sweb_com.PATH_EXCEL = path_excel
                sweb_com.PATH_PDF = path_pdf
                sweb_com.PATH_CSV = path_csv
                sweb_com.FICHA = idficha
                sweb_com.ID_ESTADO = id_estado
                sweb_com.ID_LIBRO = idficha
                If (sweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

        ElseIf tipoinforme = 9 Then 'SI EL TIPO DE INFORME ES DE PATOLOGÍA - TOXICOLOGÍA
            Dim patw_com As New dPatologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            patw_com.FICHA = idficha
            patw_com = patw_com.buscar
            If Not patw_com Is Nothing Then
                If comentarios <> "" Then
                    patw_com.COMENTARIO = comentarios
                End If
                patw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                patw_com.FECHA_EMISION = fechaemi
                patw_com.PATH_EXCEL = path_excel
                patw_com.PATH_PDF = path_pdf
                patw_com.PATH_CSV = path_csv
                patw_com.ID_ESTADO = id_estado
                If (patw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim patoweb_com As New dPatologiaWeb_com
                patoweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    patoweb_com.COMENTARIO = comentarios
                End If
                patoweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                patoweb_com.FECHA_CREADO = fechaemi
                patoweb_com.FECHA_EMISION = fechaemi
                patoweb_com.PATH_EXCEL = path_excel
                patoweb_com.PATH_PDF = path_pdf
                patoweb_com.PATH_CSV = path_csv
                patoweb_com.FICHA = idficha
                patoweb_com.ID_ESTADO = id_estado
                patoweb_com.ID_LIBRO = idficha
                If (patoweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

        ElseIf tipoinforme = 10 Then 'SI EL TIPO DE INFORME ES DE CALIDAD
            Dim cw_com As New dCalidadWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado
            'If _moroso = 1 Then
            '    abonado = 0
            'End If

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
            'Dim path_csv As String = ""
            'path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            cw_com.FICHA = idficha
            cw_com = cw_com.buscar
            If Not cw_com Is Nothing Then
                If comentarios <> "" Then
                    cw_com.COMENTARIO = comentarios
                End If
                cw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                cw_com.FECHA_EMISION = fechaemi
                cw_com.PATH_EXCEL = path_excel
                cw_com.PATH_PDF = path_pdf
                'cw_com.PATH_CSV = path_csv
                cw_com.ID_ESTADO = id_estado
                If (cw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim calweb_com As New dCalidadWeb_com
                calweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    calweb_com.COMENTARIO = comentarios
                End If
                calweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                calweb_com.FECHA_CREADO = fechaemi
                calweb_com.FECHA_EMISION = fechaemi
                calweb_com.PATH_EXCEL = path_excel
                calweb_com.PATH_PDF = path_pdf
                'calweb_com.PATH_CSV = path_csv
                calweb_com.FICHA = idficha
                calweb_com.ID_ESTADO = id_estado
                calweb_com.ID_LIBRO = idficha
                If (calweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 11 Then 'SI EL TIPO DE INFORME ES AMBIENTAL
            Dim aw_com As New dAmbientalWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            aw_com.FICHA = idficha
            aw_com = aw_com.buscar
            If Not aw_com Is Nothing Then
                If comentarios <> "" Then
                    aw_com.COMENTARIO = comentarios
                End If
                aw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aw_com.FECHA_EMISION = fechaemi
                aw_com.PATH_EXCEL = path_excel
                aw_com.PATH_PDF = path_pdf
                aw_com.PATH_CSV = path_csv
                aw_com.ID_ESTADO = id_estado
                If (aw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim aweb_com As New dAmbientalWeb_com
                aweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    aweb_com.COMENTARIO = comentarios
                End If
                aweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aweb_com.FECHA_CREADO = fechaemi
                aweb_com.FECHA_EMISION = fechaemi
                aweb_com.PATH_EXCEL = path_excel
                aweb_com.PATH_PDF = path_pdf
                aweb_com.PATH_CSV = path_csv
                aweb_com.FICHA = idficha
                aweb_com.ID_ESTADO = id_estado
                aweb_com.ID_LIBRO = idficha
                If (aweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

        ElseIf tipoinforme = 12 Then 'SI EL TIPO DE INFORME ES DE LACTÓMETROS
            Dim lw_com As New dLactometrosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            lw_com.FICHA = idficha
            lw_com = lw_com.buscar
            If Not lw_com Is Nothing Then
                If comentarios <> "" Then
                    lw_com.COMENTARIO = comentarios
                End If
                lw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                lw_com.FECHA_EMISION = fechaemi
                lw_com.PATH_EXCEL = path_excel
                lw_com.PATH_PDF = path_pdf
                lw_com.PATH_CSV = path_csv
                lw_com.ID_ESTADO = id_estado
                If (lw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim lactweb_com As New dLactometrosWeb_com
                lactweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    lactweb_com.COMENTARIO = comentarios
                End If
                lactweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                lactweb_com.FECHA_CREADO = fechaemi
                lactweb_com.FECHA_EMISION = fechaemi
                lactweb_com.PATH_EXCEL = path_excel
                lactweb_com.PATH_PDF = path_pdf
                lactweb_com.PATH_CSV = path_csv
                lactweb_com.FICHA = idficha
                lactweb_com.ID_ESTADO = id_estado
                lactweb_com.ID_LIBRO = idficha
                If (lactweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

        ElseIf tipoinforme = 13 Then 'SI EL TIPO DE INFORME ES DE AGRO NUTRICIÓN
            Dim aw_com As New dAgroNutricionWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            aw_com.FICHA = idficha
            aw_com = aw_com.buscar
            If Not aw_com Is Nothing Then
                If comentarios <> "" Then
                    aw_com.COMENTARIO = comentarios
                End If
                aw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aw_com.FECHA_EMISION = fechaemi
                aw_com.PATH_EXCEL = path_excel
                aw_com.PATH_PDF = path_pdf
                aw_com.PATH_CSV = path_csv
                aw_com.ID_ESTADO = id_estado
                If (aw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim aweb_com As New dAgroNutricionWeb_com
                aweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    aweb_com.COMENTARIO = comentarios
                End If
                aweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aweb_com.FECHA_CREADO = fechaemi
                aweb_com.FECHA_EMISION = fechaemi
                aweb_com.PATH_EXCEL = path_excel
                aweb_com.PATH_PDF = path_pdf
                aweb_com.PATH_CSV = path_csv
                aweb_com.FICHA = idficha
                aweb_com.ID_ESTADO = id_estado
                aweb_com.ID_LIBRO = idficha
                If (aweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 14 Then 'SI EL TIPO DE INFORME ES DE AGRO SUELOS
            Dim aw_com As New dAgroSuelosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            aw_com.FICHA = idficha
            aw_com = aw_com.buscar
            If Not aw_com Is Nothing Then
                If comentarios <> "" Then
                    aw_com.COMENTARIO = comentarios
                End If
                aw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aw_com.FECHA_EMISION = fechaemi
                aw_com.PATH_EXCEL = path_excel
                aw_com.PATH_PDF = path_pdf
                aw_com.PATH_CSV = path_csv
                aw_com.ID_ESTADO = id_estado
                If (aw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim aweb_com As New dAgroSuelosWeb_com
                aweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    aweb_com.COMENTARIO = comentarios
                End If
                aweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aweb_com.FECHA_CREADO = fechaemi
                aweb_com.FECHA_EMISION = fechaemi
                aweb_com.PATH_EXCEL = path_excel
                aweb_com.PATH_PDF = path_pdf
                aweb_com.PATH_CSV = path_csv
                aweb_com.FICHA = idficha
                aweb_com.ID_ESTADO = id_estado
                aweb_com.ID_LIBRO = idficha
                If (aweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 15 Then 'SI EL TIPO DE INFORME ES DE AGRO SUELOS
            Dim bw_com As New dBrucelosisLecheWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            bw_com.FICHA = idficha
            bw_com = bw_com.buscar
            If Not bw_com Is Nothing Then
                If comentarios <> "" Then
                    bw_com.COMENTARIO = comentarios
                End If
                bw_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                bw_com.FECHA_EMISION = fechaemi
                bw_com.PATH_EXCEL = path_excel
                bw_com.PATH_PDF = path_pdf
                bw_com.PATH_CSV = path_csv
                bw_com.ID_ESTADO = id_estado
                If (bw_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim bweb_com As New dBrucelosisLecheWeb_com
                bweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    bweb_com.COMENTARIO = comentarios
                End If
                bweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                bweb_com.FECHA_CREADO = fechaemi
                bweb_com.FECHA_EMISION = fechaemi
                bweb_com.PATH_EXCEL = path_excel
                bweb_com.PATH_PDF = path_pdf
                bweb_com.PATH_CSV = path_csv
                bweb_com.FICHA = idficha
                bweb_com.ID_ESTADO = id_estado
                bweb_com.ID_LIBRO = idficha
                If (bweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 99 Then 'SI EL TIPO DE INFORME ES DE OTROS SERVICIOS
            Dim ow_com As New dOtrosServiciosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If _comentarios.Length > 0 Then
                comentarios = _comentarios
            End If
            Dim abonado As Integer = _abonado

            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/www/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".txt"
            Dim id_estado As Integer = 3

            ow_com.FICHA = idficha
            ow_com = ow_com.buscar
            If Not ow_com Is Nothing Then
                If comentarios <> "" Then
                    ow_com.COMENTARIO = comentarios
                End If
                ow_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                ow_com.FECHA_EMISION = fechaemi
                ow_com.PATH_EXCEL = path_excel
                ow_com.PATH_PDF = path_pdf
                ow_com.PATH_CSV = path_csv
                ow_com.ID_ESTADO = id_estado
                If (ow_com.modificar2()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim oweb_com As New dOtrosServiciosWeb_com
                oweb_com.ID_USUARIO = idproductorweb_com
                If comentarios <> "" Then
                    oweb_com.COMENTARIO = comentarios
                End If
                oweb_com.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                oweb_com.FECHA_CREADO = fechaemi
                oweb_com.FECHA_EMISION = fechaemi
                oweb_com.PATH_EXCEL = path_excel
                oweb_com.PATH_PDF = path_pdf
                oweb_com.PATH_CSV = path_csv
                oweb_com.FICHA = idficha
                oweb_com.ID_ESTADO = id_estado
                oweb_com.ID_LIBRO = idficha
                If (oweb_com.guardar()) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
    End Sub

    Private Sub enviomail()

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim sa As New dSolicitudAnalisis
        Dim p As New dProductor
        Dim ti As New dTipoInforme
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        nficha = idficha
        sa.ID = nficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                nombre_productor = p.NOMBRE
            End If
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                tipo_analisis = ti.NOMBRE
            End If
        End If
        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com.uy")
            Try
                _Message.[To].Add(email)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try

            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Informe"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""

            _Message.Body = "El informe Nº " & " " & nficha & " - " & tipo_analisis & " (" & nombre_productor & ")," & "se ha subido a la web. Gracias."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = My.Application.Info.DirectoryPath & "archivo" 'archivo que se quiere adjuntar ‘
            'Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            '_Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
        nficha = 0

    End Sub
    Private Sub enviosms()
        Dim num1 As String = ""
        Dim num2 As String = ""
        Dim email1 As String = ""
        Dim email2 As String = ""
        Dim sms As String = ""
        Dim sms1 As String = ""
        Dim sms2 As String = ""
        Dim cel1 As String = ""
        Dim cel2 As String = ""
        Dim largotexto As Integer = 0
        Dim celular1 As String = ""
        Dim celular2 As String = ""
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim texto As String = celular
        Dim cantcaracteres As Integer = Len(texto)
        If celular <> "" Then
            largotexto = celular.Length
        End If
        nficha = idficha

        Dim posicion As Integer
        Dim posicion1 As Integer
        Dim posicion2 As Integer
        posicion = InStr(celular, ",")
        If posicion > 0 Then
            posicion1 = posicion - 1
            posicion2 = posicion + 1
            cel1 = Mid(celular, 1, posicion1)
            cel2 = Mid(celular, posicion2, largotexto)

            If Mid(cel1, 1, 2) = "09" Then
                celular1 = cel1.Remove(0, 2)
            Else
                celular1 = cel1
            End If

            email = celular1
            num1 = Mid(celular1, 1, 1)

            If num1 = "9" Or num1 = "8" Or num1 = "1" Then
                'ancel es numero (sin 09 inicial + pin)
                sms1 = email & "@antelinfo.com.uy"
            ElseIf num1 = "3" Or num1 = "4" Or num1 = "5" Then
                'movistar es numero (sin 0 inicial + pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular1 = celular.Remove(0, 1)
                End If
                email = celular1
                sms1 = email & "@sms.movistar.com.uy"
            ElseIf num1 = "6" Or num1 = "7" Then
                'claro es numero (sin 0 inicial sin pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular2 = celular.Remove(0, 1)
                End If
                email = celular1
                sms1 = email & "@sms.ctimovil.com.uy"
            End If
            '*****************************************
            If Mid(cel2, 1, 2) = "09" Then
                celular2 = cel2.Remove(0, 2)
            Else
                celular2 = cel2
            End If

            email2 = celular2
            num2 = Mid(celular2, 1, 1)

            If num2 = "9" Or num2 = "8" Or num2 = "1" Then
                'ancel es numero (sin 09 inicial + pin)
                sms2 = email2 & "@antelinfo.com.uy"
            ElseIf num2 = "3" Or num2 = "4" Or num2 = "5" Then
                'movistar es numero (sin 0 inicial + pin)
                If Mid(celular2, 1, 1) = "0" Then
                    celular2 = celular2.Remove(0, 1)
                End If
                email2 = celular2
                sms2 = email2 & "@sms.movistar.com.uy"
            ElseIf num2 = "6" Or num2 = "7" Then
                'claro es numero (sin 0 inicial sin pin)
                If Mid(celular2, 1, 1) = "0" Then
                    celular2 = celular2.Remove(0, 1)
                End If
                email2 = celular2
                sms2 = email2 & "@sms.ctimovil.com.uy"
            End If
            sms = sms1 & "," & sms2
        Else

            'Dim celular As String = ""

            'celular = TextCelular1.Text.Trim
            nficha = idficha
            If Mid(celular, 1, 2) = "09" Then
                celular2 = celular.Remove(0, 2)
            Else
                celular2 = celular
            End If

            email = celular2
            num1 = Mid(celular2, 1, 1)

            If num1 = "9" Or num1 = "8" Or num1 = "1" Then
                'ancel es numero (sin 09 inicial + pin)
                sms = email & "@antelinfo.com.uy"
            ElseIf num1 = "3" Or num1 = "4" Or num1 = "5" Then
                'movistar es numero (sin 0 inicial + pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular2 = celular.Remove(0, 1)
                End If
                email = celular2
                sms = email & "@sms.movistar.com.uy"
            ElseIf num1 = "6" Or num1 = "7" Then
                'claro es numero (sin 0 inicial sin pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular2 = celular.Remove(0, 1)
                End If
                email = celular2
                sms = email & "@sms.ctimovil.com.uy"
            End If

        End If

        Dim sa As New dSolicitudAnalisis
        Dim p As New dProductor
        Dim ti As New dTipoInforme
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        nficha = idficha
        sa.ID = nficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                nombre_productor = p.NOMBRE
            End If
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                tipo_analisis = ti.NOMBRE
            End If
        End If

        If sms <> "" Then

            'CONFIGURACIÓN DEL STMP 
            '_SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com.uy")
            _Message.[To].Add(sms)
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "El informe Nº " & " " & nficha & " - " & tipo_analisis & " (" & nombre_productor & ")," & "se ha subido a la web. Gracias."
            '_Message.Subject = "El informe número " & " " & nficha & ", " & "se ha subido a la web. Gracias."
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            '_Message.Body = "Colaveco ha publicado un informe. Ingrese al sitio http://www.colaveco.com.uy"
            '_Message.Body = "Colaveco ha publicado un informe. Ingrese al sitio http://www.colaveco.com.uy"
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = My.Application.Info.DirectoryPath & "archivo" 'archivo que se quiere adjuntar ‘
            'Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            '_Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Mensaje enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
        texto = ""

    End Sub
    Private Sub enviaremail() 'ENVIA EMAIL A MGAP (BRUCELOSIS)
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = idficha
        email = "unepi@mgap.gub.uy"

        If email <> "" Then

            'CONFIGURACIÓN DEL STMP 
            '_SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com.uy")
            _Message.[To].Add(email)
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Colaveco - Brucelosis en leche"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            _Message.Body = "Adjuntamos informe de Brucelsois en leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\SRVCOLAVECO\D\NET\Brucelosis en leche\" & archivo & ".xls" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""

    End Sub
    Private Sub enviaremail2() 'ENVIA EMAIL A MGAP (BRUCELOSIS)
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = idficha
        email = "agarin@mgap.gub.uy"

        If email <> "" Then

            'CONFIGURACIÓN DEL STMP 
            '_SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com.uy")
            _Message.[To].Add(email)
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Colaveco - Brucelosis en leche"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            _Message.Body = "Adjuntamos informe de Brucelsois en leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\SRVCOLAVECO\D\NET\Brucelosis en leche\" & archivo & ".xls" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""

    End Sub
    Public Sub crea_brucelosis_leche_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "CLV1582782"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/" & carpeta & "/brucelosis_leche/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_agro_suelos_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "CLV1582782"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/" & carpeta & "/agro_suelos/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'subir_informes()
        subir_informes2()
    End Sub
    Private Sub moverexcel()
        If tipoinforme = 10 Then
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\SRVCOLAVECO\D\NET\CALIDAD\" & idficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 1 Then
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & idficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 3 Then
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\SRVCOLAVECO\D\NET\AGUA\" & idficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 4 Then
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & idficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 7 Then
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & idficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub moverpdf()
        If tipoinforme = 10 Then
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\SRVCOLAVECO\D\NET\CALIDAD\" & idficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 1 Then
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & idficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 3 Then
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\SRVCOLAVECO\D\NET\AGUA\" & idficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 4 Then
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & idficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 7 Then
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & idficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub movertxt()
        If tipoinforme = 1 Then
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & idficha & ".txt"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".txt"
            Dim sRutaDestino As String = "\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & idficha & ".txt"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'subir_informes()
        subir_informes2()
    End Sub

   

    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'subir_informes()
        subir_informes2()
    End Sub

    Private Sub SubirInformesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubirInformesToolStripMenuItem2.Click
        'subir_informes()
        subir_informes2()
    End Sub

    Private Sub ImportarToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarToolStripMenuItem.Click
        importar()
    End Sub
    Private Sub creapreinformesmanual()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        Dim creapreinformecalidad As Integer = 1

        lista = pi.listarsinmarcarcalidad

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pi In lista
                    Dim csm As New dCalidadSolicitudMuestra
                    Dim listacsm As New ArrayList
                    Dim ficha As Long = pi.FICHA
                    listacsm = csm.listarporsolicitud(ficha)
                    If Not listacsm Is Nothing Then
                        creapreinformecalidad = 1
                        For Each csm In listacsm
                            If csm.RB = 1 Then
                                Dim ibc As New dIbc
                                ibc.FICHA = csm.IDSOLICITUD
                                ibc.MUESTRA = csm.MUESTRA
                                ibc = ibc.buscarxfichaxmuestra
                                If Not ibc Is Nothing Then

                                Else
                                    creapreinformecalidad = 0
                                    Exit For
                                End If
                                ibc = Nothing
                            End If
                            If csm.PSICROTROFOS = 1 Then
                                Dim psi As New dPsicrotrofos
                                psi.FICHA = csm.IDSOLICITUD
                                psi.MUESTRA = csm.MUESTRA
                                psi = psi.buscarxfichaxmuestra
                                If Not psi Is Nothing Then

                                Else
                                    creapreinformecalidad = 0
                                    Exit For
                                End If
                                psi = Nothing
                            End If
                            If csm.ESPORULADOS = 1 Then
                                Dim esp As New dEsporulados
                                esp.FICHA = csm.IDSOLICITUD
                                esp.MUESTRA = csm.MUESTRA
                                esp = esp.buscarxfichaxmuestra
                                If Not esp Is Nothing Then

                                Else
                                    creapreinformecalidad = 0
                                    Exit For
                                End If
                                esp = Nothing
                            End If
                            If csm.INHIBIDORES = 1 Then
                                Dim inh As New dInhibidores
                                inh.FICHA = csm.IDSOLICITUD
                                inh.MUESTRA = csm.MUESTRA
                                inh = inh.buscarxfichaxmuestra
                                If Not inh Is Nothing Then
                                    If inh.MARCA = 0 Then
                                        creapreinformecalidad = 0
                                        Exit For
                                    End If
                                Else
                                    creapreinformecalidad = 0
                                    Exit For
                                End If
                                inh = Nothing
                            End If
                        Next
                    End If
                    If creapreinformecalidad = 1 Then
                        preinforme_calidad(ficha)
                    End If
                Next
            End If
        End If
       

        pre_informe_control()
    End Sub

    Private Sub CreaPreInformesManualmenteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreaPreInformesManualmenteToolStripMenuItem.Click
        creapreinformesmanual()
    End Sub

    Private Sub RelojToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelojToolStripMenuItem1.Click
        Dim v As New FormReloj
        v.Show()
    End Sub

    Private Sub VerPlanDeLicenciaAnualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerPlanDeLicenciaAnualToolStripMenuItem.Click
        Dim v As New FormPlanLicencias
        v.Show()
    End Sub

    Private Sub PilotosFQBDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PilotosFQBDToolStripMenuItem.Click

    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormUsuarios(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub cargarfichasparasubir()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        lista = pi.listarparasubir
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridViewParaSubir.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridViewParaSubir.Rows.Add(lista.Count)
                For Each pi In lista
                    DataGridViewParaSubir(columna, fila).Value = pi.ID
                    columna = columna + 1
                    DataGridViewParaSubir(columna, fila).Value = pi.FICHA
                    columna = columna + 1
                    If pi.TIPO = 1 Then
                        DataGridViewParaSubir(columna, fila).Value = "Control"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 3 Then
                        DataGridViewParaSubir(columna, fila).Value = "Agua"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 4 Then
                        DataGridViewParaSubir(columna, fila).Value = "ATB"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 7 Then
                        DataGridViewParaSubir(columna, fila).Value = "Subproductos"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 10 Then
                        DataGridViewParaSubir(columna, fila).Value = "Calidad"
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridViewParaSubir(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If

       
        'Dim pical As New dPreinformeCalidad
        'Dim picon As New dPreinformeControl
        'Dim listacal As New ArrayList
        'Dim listacon As New ArrayList
        'listacal = pical.listarparasubir
        'listacon = picon.listarparasubir
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0

        'DataGridViewParaSubir.Rows.Clear()


        'If Not listacal Is Nothing Then
        '    If listacal.Count > 0 Then
        '        DataGridViewParaSubir.Rows.Add(listacal.Count)
        '        For Each pical In listacal
        '            DataGridViewParaSubir(columna, fila).Value = pical.ID
        '            columna = columna + 1
        '            DataGridViewParaSubir(columna, fila).Value = pical.FICHA
        '            columna = columna + 1
        '            DataGridViewParaSubir(columna, fila).Value = "Calidad"
        '            columna = 0
        '            fila = fila + 1
        '        Next
        '    End If
        'End If

        'If Not listacon Is Nothing Then
        '    If listacon.Count > 0 Then
        '        DataGridViewParaSubir.Rows.Add(listacon.Count)
        '        For Each picon In listacon
        '            DataGridViewParaSubir(columna, fila).Value = picon.ID
        '            columna = columna + 1
        '            DataGridViewParaSubir(columna, fila).Value = picon.FICHA
        '            columna = columna + 1
        '            DataGridViewParaSubir(columna, fila).Value = "Control"
        '            columna = 0
        '            fila = fila + 1
        '        Next
        '    End If
        'End If

    End Sub
    Private Sub cargarfichassubidas()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        lista = pi.listarsubidas
        Dim fila As Integer = 0
        Dim columna As Integer = 0

        DataGridViewSubidas.Rows.Clear()


        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridViewSubidas.Rows.Add(lista.Count)
                For Each pi In lista
                    DataGridViewSubidas(columna, fila).Value = pi.ID
                    columna = columna + 1
                    DataGridViewSubidas(columna, fila).Value = pi.FICHA
                    columna = columna + 1
                    DataGridViewSubidas(columna, fila).Value = pi.FECHA
                    columna = columna + 1
                    If pi.TIPO = 1 Then
                        DataGridViewSubidas(columna, fila).Value = "Control"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 3 Then
                        DataGridViewSubidas(columna, fila).Value = "Agua"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 4 Then
                        DataGridViewSubidas(columna, fila).Value = "ATB"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 7 Then
                        DataGridViewSubidas(columna, fila).Value = "Subproductos"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 10 Then
                        DataGridViewSubidas(columna, fila).Value = "Calidad"
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridViewSubidas(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    
                Next
            End If
        End If

       
        DataGridViewSubidas.Sort(DataGridViewSubidas.Columns(2), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub LicenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LicenciaToolStripMenuItem.Click
        Dim v As New FormLicencias(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ControlDeGrasaYProteínaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeGrasaYProteínaToolStripMenuItem.Click
        Dim v As New FormControlGrasaProteina(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub InformesRelojToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformesRelojToolStripMenuItem.Click
        Dim v As New FormInformes
        v.Show()
    End Sub

    Private Sub GrasaYProteínaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrasaYProteínaToolStripMenuItem.Click
        Dim v As New FormGraficaGrasaProteina
        v.Show()
    End Sub

    Private Sub NuevaActaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaActaToolStripMenuItem.Click
        Dim v As New FormActas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ItemsSinEfectuarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemsSinEfectuarToolStripMenuItem.Click
        Dim v As New FormActasPendientes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub FuncionariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FuncionariosToolStripMenuItem.Click
        Dim v As New FormUsuarios(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub LicenciadíasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LicenciadíasToolStripMenuItem.Click
        Dim v As New FormLicenciaAnual(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub FeriadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FeriadosToolStripMenuItem.Click
        Dim v As New FormFeriados(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub AguaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AguaToolStripMenuItem1.Click
        Dim v As New FormInformeAgua(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub SubproductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubproductosToolStripMenuItem.Click
        Dim v As New FormInformeSubproductos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub BacteriologíaYAntibiogramaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BacteriologíaYAntibiogramaToolStripMenuItem.Click
        Dim v As New FormInformeAntibiograma(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub soloibc()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        '**********************************************************************************
        Dim El_Ping
        Dim eco As New System.Net.NetworkInformation.Ping
        Dim res As System.Net.NetworkInformation.PingReply
        Dim ip As Net.IPAddress

        ip = Net.IPAddress.Parse("192.168.1.50")
        res = eco.Send(ip)

        If res.Status = System.Net.NetworkInformation.IPStatus.Success Then

            El_Ping = (My.Computer.Network.Ping("ibc1123"))


        End If


        'If (My.Computer.Network.Ping("ibc1123")) = True Then
        'El_Ping = (My.Computer.Network.Ping("ibc1123"))
        'End If
        'Acá mandamos los mensajes para las 2 posibilidades
        If El_Ping = False Then
            'si no se pudo acceder ,avisamos
            'MsgBox("El servidor no está disponible.", MsgBoxStyle.Critical, "Error")
        Else
            'MsgBox("Servidor disponible.", MsgBoxStyle.Information, "Aviso")
            Dim folder As New DirectoryInfo("\\Ibc1123\Carol")
            For Each file As FileInfo In folder.GetFiles("*.csv")
                'ListBox1.Items.Add(file.Name)
                nombrearchivo = file.Name
                linea = 1
                extension = Microsoft.VisualBasic.Right(file.Name, 3)
                Dim objReader2 As New StreamReader("\\Ibc1123\Carol\" & file.Name)
                Dim sLine As String = ""
                'Dim arrText As New ArrayList()
                Dim arraytext() As String

                Dim ficha As String = ""
                Dim ficha2 As String = ""
                Dim ficha3 As String
                Dim muestra As String = ""
                Dim idibc As Integer = 0
                Dim ibc As Long = 0
                Dim rb As Integer = 0

                ' *** SI EL ARCHIVO ES CSV **************************************************************************************
                If extension = "csv" Or extension = "CSV" Then
                    Dim c As New dImpIbc()
                    Do
                        sLine = objReader2.ReadLine()

                        If Not sLine Is Nothing Then
                            'arrText.Add(sLine)
                            arraytext = Split(sLine, ",")
                            Dim muestra2 As String
                            Dim muestrax As String

                            If Trim(arraytext(1)) <> "" Then
                                muestra = arraytext(1)
                                muestrax = Replace(muestra, Chr(34), "")
                                If muestrax <> "" Then
                                    muestra2 = muestrax
                                Else
                                    muestra = arraytext(7)
                                    muestrax = Replace(muestra, Chr(34), "")
                                    If muestrax <> "" Then
                                        muestra2 = muestrax
                                    Else
                                        muestra2 = "error"
                                    End If
                                End If
                            Else
                                If arraytext.Length > 7 Then
                                    muestra = arraytext(7)
                                    muestrax = Replace(muestra, Chr(34), "")
                                    If muestrax <> "" Then
                                        muestra2 = muestrax
                                    Else
                                        muestra2 = "error"
                                    End If
                                Else
                                    muestra2 = "error"
                                End If

                            End If

                            'muestra2 = Replace(muestra, Chr(34), "")

                            If Trim(arraytext(2)) <> "" Then
                                idibc = arraytext(2)
                            Else
                                idibc = -1
                            End If
                            If Trim(arraytext(4)) <> "" Then
                                ibc = arraytext(4)
                            Else
                                ibc = -1
                            End If
                            If Trim(arraytext(5)) <> "" Then
                                rb = arraytext(5)
                            Else
                                rb = -1
                            End If

                            ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                            ficha3 = Mid(file.Name, 1, 1)
                            If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Then
                                ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                            Else
                                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                            End If
                            If Mid(ficha, 1, 1) = "l" Or Mid(ficha, 1, 1) = "L" Then
                                'Dim MyString As String = ficha
                                'ficha3 = MyString.Remove(1, 1)
                                Dim MyString As String = ficha
                                Dim MyChar As Char() = {"l"c, "L"c}
                                Dim NewString As String = MyString.TrimStart(MyChar)
                                ficha3 = NewString
                            Else
                                ficha3 = ficha
                            End If
                            Dim fechaoriginal As Date = Now()
                            Dim fecha As String
                            fecha = Format(fechaoriginal, "yyyy-MM-dd")

                            c.FICHA = ficha3
                            c.MUESTRA = muestra2
                            c.IDIBC = idibc
                            c.IBC = ibc
                            c.RB = rb
                            c.FECHA = fecha
                            c.guardar()
                        End If
                        linea = linea + 1
                    Loop Until sLine Is Nothing
                    objReader2.Close()
                End If

                '*** MOVER ARCHIVO ***********************************************************************
                Dim sArchivoOrigen As String = "\\Ibc1123\Carol\" & nombrearchivo
                'Dim sRutaDestino1 As String = "d:\documentos\secretaria\analisis\leche\ibc\" & nombrearchivo
                Dim sRutaDestino1 As String = "Y:\documentos\secretaria\analisis\leche\ibc\" & nombrearchivo
                Dim sRutaDestino As String = "\\Ibc1123\Carol\pasados\" & nombrearchivo

                Try
                    ' Mover el fichero.si existe lo sobreescribe  
                    My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                    sRutaDestino1, _
                                                    True)

                    My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                    sRutaDestino, _
                                                    True)
                    'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                    ' errores  
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                End Try
            Next
        End If
        '***********************************************************************************

    End Sub

    Private Sub ImportarSoloIBCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarSoloIBCToolStripMenuItem.Click
        soloibc()
        MsgBox("Importado!")
    End Sub

    Private Sub MarcarFichasRosaDeBengalaComoSubidasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcarFichasRosaDeBengalaComoSubidasToolStripMenuItem.Click
        Dim v As New FormRosaBengalaDescarte(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub DescartarMuestrasRosaDeBengToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescartarMuestrasRosaDeBengToolStripMenuItem.Click
        Dim v As New FormRosaBengalaDescarte(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CalidadDeLecheToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalidadDeLecheToolStripMenuItem1.Click
        Dim v As New FormEstadisticasCalidad()
        v.Show()
    End Sub

    Private Sub NutriciónToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NutriciónToolStripMenuItem3.Click
        Dim v As New FormEstadisticaNutricion(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub SuelosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuelosToolStripMenuItem2.Click
        Dim v As New FormEstadisticaSuelos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ContadorDeAnálisisEmpresasNUEVOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContadorDeAnálisisEmpresasNUEVOToolStripMenuItem.Click
        Dim v As New FormContadorAnalisisEmpresas2
        v.Show()
    End Sub

    Private Sub DescarteMuestrasRosaDeBengalaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescarteMuestrasRosaDeBengalaToolStripMenuItem.Click
        Dim v As New FormRosaBengalaDescarte(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EstadísticasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadísticasToolStripMenuItem1.Click
        Dim v As New FormEstadisticaCompras(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub RGLAB31ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGLAB31ToolStripMenuItem.Click
        Dim v As New FormRgLab31(Sesion.Usuario)
        v.Show()
    End Sub
End Class