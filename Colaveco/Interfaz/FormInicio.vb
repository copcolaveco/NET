Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports System.Net

Public Class FormInicio


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
    Private subido As Integer = 0
    Private carpeta As Long = 0
    Private compraid As Long = 0
    Private tipoinformeweb As String
    Private nmuestrasweb As Integer
    Private muestraweb As String
    Private subtipoinformeweb As String
    Private observacionesweb As String
    Private nombreproductorweb As String


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
        If nombre_pc = "SRVDATOS" Then
            cadena = "Server=localhost;Database=colaveco;Uid=root;Pwd=root;Convert Zero Datetime=True"
        ElseIf nombre_pc = "PC" Then
            cadena = "Server=localhost;Database=colaveco;Uid=root;Pwd=p@$$w0rd;Convert Zero Datetime=True"
        Else
            cadena = "Server=192.168.1.20;Database=colaveco;Uid=root;Pwd=root;Convert Zero Datetime=True"
        End If

        If nombre_pc = "IT" Then
            DateFecha.Value = Now
            bloquearVentana()
            abrirSesion()
            cargartareasp()
            cargartareaspr()
            cargartareas()
            cargartareasr()
            cargartareasG()
            cargarnoticias()
            cargarnoticias2()
            chequearcsalud()
            cargaractas()
            buscarcomunicaciontecnica()
            cargarfichasparasubir()
            cargarfichassubidas()
            cargarAutorizaciones()
            cargarNotificaciones()
            'chequear_pedidos()
            'chequear_envios()
            If Sesion.Usuario.SECTOR = 2 Then
                control_inhibidores()
            End If
            'Timer1.Enabled = True
            'Timer2.Enabled = True
            'Timer3.Enabled = True
            'Timer4.Enabled = True
            listarpedidosweb()
            listarpedidospendientes()
            controles_ibc()
        Else
            DateFecha.Value = Now
            bloquearVentana()
            abrirSesion()
            cargartareasp()
            cargartareaspr()
            cargartareas()
            cargartareasr()
            cargartareasG()
            cargaractas()
            buscarcomunicaciontecnica()
            cargarnoticias()
            cargarnoticias2()
            chequearcsalud()
            cargarfichasparasubir()
            cargarfichassubidas()
            cargarAutorizaciones()
            cargarNotificaciones()
            'chequear_pedidos()
            'chequear_envios()
            If Sesion.Usuario.SECTOR = 2 Then
                control_inhibidores()
            End If
            Timer1.Enabled = True
            Timer2.Enabled = True
            listarpedidosweb()
            listarpedidospendientes()
            If Sesion.Usuario.USUARIO = "CA" Then
                Dim usu As New dUsuario
                Dim listausu As New ArrayList
                listausu = usu.listar

            End If
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
        Dim dia As Integer = 0
        Dim mes As Integer = 0
        dia = Now.Day
        mes = Now.Month
        lista = n.listarxfecha(dia, mes)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each n In lista
                    MsgBox(n.DESCRIPCION)
                Next
            End If
        End If
    End Sub
    Public Sub cargarnoticias2()
        Dim n As New dNoticias2
        Dim lista As New ArrayList
        lista = n.listarxusuario(Sesion.Usuario.ID)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each n In lista
                    MsgBox(n.DESCRIPCION)
                Next
            End If
        End If
        Dim n2 As New dNoticias2
        Dim lista2 As New ArrayList
        lista2 = n2.listargeneral()
        If Not lista2 Is Nothing Then
            If lista2.Count > 0 Then
                For Each n2 In lista2
                    MsgBox(n2.DESCRIPCION)
                Next
            End If
        End If
    End Sub
    Public Sub chequearcsalud()
        Dim u As New dUsuario
        u.ID = Sesion.Usuario.ID
        u = u.buscar
        Dim hoy As Date = Now
        Dim csalud As Date = u.CSALUD
        If csalud < hoy Then
            MsgBox("Su carnet de salud venció el " & csalud)
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
    Public Sub buscarcomunicaciontecnica()
        Dim c As New dComunicacionTecnica
        Dim idusuario As Integer = Sesion.Usuario.ID
        Dim lista As New ArrayList
        lista = c.listarsinver(idusuario)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                MsgBox("Existen comunicaciones técnicas para completar!")
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
                    If t.REALIZADA = 1 Then
                        DataGridtareasP(columna, fila).Style.BackColor = Color.Yellow
                    End If
                    DataGridtareasP(columna, fila).Value = t.ID
                    columna = columna + 1
                    If t.REALIZADA = 1 Then
                        DataGridtareasP(columna, fila).Style.BackColor = Color.Yellow
                    End If
                    DataGridtareasP(columna, fila).Value = t.DESCRIPCION
                    columna = columna + 1
                    If t.REALIZADA = 1 Then
                        DataGridtareasP(columna, fila).Style.BackColor = Color.Yellow
                    End If
                    DataGridtareasP(columna, fila).Value = t.FINALIZACION
                    columna = columna + 1
                    Dim usuario2 As New dUsuario
                    usuario2.ID = t.USUARIO
                    usuario2 = usuario2.buscar
                    If Not usuario2 Is Nothing Then
                        If t.REALIZADA = 1 Then
                            DataGridtareasP(columna, fila).Style.BackColor = Color.Yellow
                        End If
                        DataGridtareasP(columna, fila).Value = usuario2.NOMBRE
                        columna = columna + 1
                    Else
                        If t.REALIZADA = 1 Then
                            DataGridtareasP(columna, fila).Style.BackColor = Color.Yellow
                        End If
                        DataGridtareasP(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    usuario2 = Nothing
                    Dim creador As New dUsuario
                    creador.ID = t.CREADOR
                    creador = creador.buscar
                    If Not creador Is Nothing Then
                        If t.REALIZADA = 1 Then
                            DataGridtareasP(columna, fila).Style.BackColor = Color.Yellow
                        End If
                        DataGridtareasP(columna, fila).Value = creador.NOMBRE
                        columna = columna + 1
                    Else
                        If t.REALIZADA = 1 Then
                            DataGridtareasP(columna, fila).Style.BackColor = Color.Yellow
                        End If
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
    Private Sub cargartareaspr()
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
        lista = t.listarxusuarior(idusuario)
        DataGridTareasPR.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridTareasPR.Rows.Add(lista.Count)
            End If
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    If t.REALIZADA = 1 Then
                        DataGridTareasPR(columna, fila).Style.BackColor = Color.SkyBlue
                    End If
                    DataGridTareasPR(columna, fila).Value = t.ID
                    columna = columna + 1
                    If t.REALIZADA = 1 Then
                        DataGridTareasPR(columna, fila).Style.BackColor = Color.SkyBlue
                    End If
                    DataGridTareasPR(columna, fila).Value = t.DESCRIPCION
                    columna = columna + 1
                    If t.REALIZADA = 1 Then
                        DataGridTareasPR(columna, fila).Style.BackColor = Color.SkyBlue
                    End If
                    DataGridTareasPR(columna, fila).Value = t.FINALIZACION
                    columna = columna + 1
                    Dim usuario2 As New dUsuario
                    usuario2.ID = t.USUARIO
                    usuario2 = usuario2.buscar
                    If Not usuario2 Is Nothing Then
                        If t.REALIZADA = 1 Then
                            DataGridTareasPR(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        DataGridTareasPR(columna, fila).Value = usuario2.NOMBRE
                        columna = columna + 1
                    Else
                        If t.REALIZADA = 1 Then
                            DataGridTareasPR(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        DataGridTareasPR(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    usuario2 = Nothing
                    Dim creador As New dUsuario
                    creador.ID = t.CREADOR
                    creador = creador.buscar
                    If Not creador Is Nothing Then
                        If t.REALIZADA = 1 Then
                            DataGridTareasPR(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        DataGridTareasPR(columna, fila).Value = creador.NOMBRE
                        columna = columna + 1
                    Else
                        If t.REALIZADA = 1 Then
                            DataGridTareasPR(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        DataGridTareasPR(columna, fila).Value = ""
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
                    If t.REALIZADA = 1 Then
                        DataGridTareas(columna, fila).Style.BackColor = Color.Yellow
                    End If
                    DataGridTareas(columna, fila).Value = t.ID
                    columna = columna + 1
                    If t.REALIZADA = 1 Then
                        DataGridTareas(columna, fila).Style.BackColor = Color.Yellow
                    End If
                    DataGridTareas(columna, fila).Value = t.DESCRIPCION
                    columna = columna + 1
                    If t.REALIZADA = 1 Then
                        DataGridTareas(columna, fila).Style.BackColor = Color.Yellow
                    End If
                    DataGridTareas(columna, fila).Value = t.FINALIZACION
                    columna = columna + 1
                    Dim sector As New dSectores
                    sector.ID = t.SECTOR
                    sector = sector.buscar
                    If Not sector Is Nothing Then
                        If t.REALIZADA = 1 Then
                            DataGridTareas(columna, fila).Style.BackColor = Color.Yellow
                        End If
                        DataGridTareas(columna, fila).Value = sector.NOMBRE
                        columna = columna + 1
                    Else
                        If t.REALIZADA = 1 Then
                            DataGridTareas(columna, fila).Style.BackColor = Color.Yellow
                        End If
                        DataGridTareas(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    sector = Nothing
                    Dim creador As New dUsuario
                    creador.ID = t.CREADOR
                    creador = creador.buscar
                    If Not creador Is Nothing Then
                        If t.REALIZADA = 1 Then
                            DataGridTareas(columna, fila).Style.BackColor = Color.Yellow
                        End If
                        DataGridTareas(columna, fila).Value = creador.NOMBRE
                        columna = columna + 1
                    Else
                        If t.REALIZADA = 1 Then
                            DataGridTareas(columna, fila).Style.BackColor = Color.Yellow
                        End If
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
    Private Sub cargartareasr()
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
        lista = t.listarxsectorr(idsector)
        DataGridTareasR.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridTareasR.Rows.Add(lista.Count)
            End If
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    If t.REALIZADA = 1 Then
                        DataGridTareasR(columna, fila).Style.BackColor = Color.SkyBlue
                    End If
                    DataGridTareasR(columna, fila).Value = t.ID
                    columna = columna + 1
                    If t.REALIZADA = 1 Then
                        DataGridTareasR(columna, fila).Style.BackColor = Color.SkyBlue
                    End If
                    DataGridTareasR(columna, fila).Value = t.DESCRIPCION
                    columna = columna + 1
                    If t.REALIZADA = 1 Then
                        DataGridTareasR(columna, fila).Style.BackColor = Color.SkyBlue
                    End If
                    DataGridTareasR(columna, fila).Value = t.FINALIZACION
                    columna = columna + 1
                    Dim sector As New dSectores
                    sector.ID = t.SECTOR
                    sector = sector.buscar
                    If Not sector Is Nothing Then
                        If t.REALIZADA = 1 Then
                            DataGridTareasR(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        DataGridTareasR(columna, fila).Value = sector.NOMBRE
                        columna = columna + 1
                    Else
                        If t.REALIZADA = 1 Then
                            DataGridTareasR(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        DataGridTareasR(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    sector = Nothing
                    Dim creador As New dUsuario
                    creador.ID = t.CREADOR
                    creador = creador.buscar
                    If Not creador Is Nothing Then
                        If t.REALIZADA = 1 Then
                            DataGridTareasR(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        DataGridTareasR(columna, fila).Value = creador.NOMBRE
                        columna = columna + 1
                    Else
                        If t.REALIZADA = 1 Then
                            DataGridTareasR(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        DataGridTareasR(columna, fila).Value = ""
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
        Dim hoy As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim hoy2 As String = ""
        hoy2 = Format(hoy, "yyyy-MM-dd")
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
        lista = t.listargenerales(hoy2)
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
                                Sesion = New dSesion
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
        EstadísticasToolStripMenuItem.Enabled = False
        RegistrosToolStripMenuItem.Enabled = False
        AutorizarCompraToolStripMenuItem.Enabled = False
        DirecciónToolStripMenuItem.Enabled = False
        CapacitaciónToolStripMenuItem1.Enabled = False
        PersonalToolStripMenuItem.Enabled = False
        AutorizacionesToolStripMenuItem.Enabled = False
        RelojToolStripMenuItem1.Enabled = False
        LicenciadíasToolStripMenuItem.Enabled = False
        FeriadosToolStripMenuItem.Enabled = False
        FuncionariosToolStripMenuItem.Enabled = False
        InformesRelojToolStripMenuItem.Enabled = False
        ButtonSolicitudAnalisis.Enabled = False
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
        AutorizacionesToolStripMenuItem.Enabled = False
        RelojToolStripMenuItem1.Enabled = False
        LicenciadíasToolStripMenuItem.Enabled = False
        FeriadosToolStripMenuItem.Enabled = False
        FuncionariosToolStripMenuItem.Enabled = False
        InformesRelojToolStripMenuItem.Enabled = False
        ButtonSolicitudAnalisis.Enabled = False
        EnviarComprasToolStripMenuItem.Enabled = False
        EstadísticasToolStripMenuItem.Enabled = False

        ' *** Según usuario se desbloquean las secciones correspondientes.-
        Dim u As dUsuario = Sesion.Usuario
        Me.Text = "Colaveco NET - " & u.NOMBRE
        If Not u Is Nothing Then
            If u.TIPOUSUARIO = 99 Then 'si el usuario es del tipo supervisor
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
                'Autorizaciones
                If u.USUARIO = "MCF" Or u.USUARIO = "CA" Or u.USUARIO = "SA" Then
                    Label1.Visible = True
                    DataGridAutorizaciones.Visible = True
                Else
                    Label1.Visible = False
                    DataGridAutorizaciones.Visible = False
                End If
                'Notificaciones
                If u.USUARIO = "SA" Then
                    Label2.Visible = True
                    DataGridNotificaciones.Visible = True
                Else
                    Label2.Visible = False
                    DataGridNotificaciones.Visible = False
                End If
                'Administración
                AdministraciónToolStripMenuItem.Enabled = True
                ButtonSolicitudAnalisis.Enabled = True
                'Direccion
                If u.USUARIO = "MCF" Or u.USUARIO = "SA" Or u.USUARIO = "CA" Or u.USUARIO = "AP" Then
                    DirecciónToolStripMenuItem.Enabled = True
                Else
                    DirecciónToolStripMenuItem.Enabled = False
                End If
                'Compras
                If u.USUARIO = "MCF" Or u.USUARIO = "CA" Or u.USUARIO = "AP" Or u.USUARIO = "MC" Then
                    comprobarcompras()
                    AutorizarCompraToolStripMenuItem.Enabled = True
                    EnviarComprasToolStripMenuItem.Enabled = True
                End If
                If u.USUARIO = "MCF" Then
                    comprobarlicencias()
                End If
                'IT
                If u.USUARIO = "SA" Or u.USUARIO = "AP" Then
                    ITToolStripMenuItem.Enabled = True
                    AutorizarCompraToolStripMenuItem.Enabled = True
                    EnviarComprasToolStripMenuItem.Enabled = True
                Else
                    ITToolStripMenuItem.Enabled = False
                End If
                'Controles
                ControlesToolStripMenuItem.Enabled = True
                'Estadísticas
                EstadísticasATBToolStripMenuItem.Enabled = True
                EstadísticasToolStripMenuItem.Enabled = True
                'Registros
                RegistrosToolStripMenuItem.Enabled = True
                'Capacitacion
                CapacitaciónToolStripMenuItem1.Enabled = True
                'Personal
                PersonalToolStripMenuItem.Enabled = True
                'Autorizaciones
                AutorizacionesToolStripMenuItem.Enabled = True
            ElseIf u.TIPOUSUARIO = 98 Then 'si el usuario es del tipo analista
                comprobarcomprascanceladas()
                comprobarlineacompracancelada()
                'Menú MANTENIMIENTO.
                MantenimientoToolStripMenuItem.Enabled = True
                'Menú ANALISIS.
                AnálisisToolStripMenuItem.Enabled = True
                'Controles
                ControlesToolStripMenuItem.Enabled = True
                'Estadísticas
                EstadísticasToolStripMenuItem.Enabled = True
                EstadísticasATBToolStripMenuItem.Enabled = True
                'Registros
                RegistrosToolStripMenuItem.Enabled = True
                'Capacitacion
                CapacitaciónToolStripMenuItem1.Enabled = True
                'Personal
                PersonalToolStripMenuItem.Enabled = True
                If u.USUARIO = "JG" Then
                    AutorizacionesToolStripMenuItem.Enabled = True
                End If
            ElseIf u.TIPOUSUARIO = 97 Then 'si el usuario es del tipo administrativo
                comprobarcomprascanceladas()
                comprobarlineacompracancelada()
                'Menú MANTENIMIENTO.
                MantenimientoToolStripMenuItem.Enabled = True
                'Menú INFORMES
                InformesToolStripMenuItem.Enabled = True
                'Menú IMPORTADOR
                'Administración
                AdministraciónToolStripMenuItem.Enabled = True
                ButtonSolicitudAnalisis.Enabled = True
                'Estadísticas
                EstadísticasATBToolStripMenuItem.Enabled = True
                'Registros
                RegistrosToolStripMenuItem.Enabled = True
                'Capacitacion
                CapacitaciónToolStripMenuItem1.Enabled = True
                'Personal
                PersonalToolStripMenuItem.Enabled = True
                If u.USUARIO = "GB" Or u.USUARIO = "M" Then
                    Label1.Visible = True
                    DataGridAutorizaciones.Visible = True
                    Label2.Visible = True
                    DataGridNotificaciones.Visible = True
                    'Autorizaciones
                    AutorizacionesToolStripMenuItem.Enabled = True
                Else
                    Label1.Visible = False
                    DataGridAutorizaciones.Visible = False
                    'Autorizaciones
                    AutorizacionesToolStripMenuItem.Enabled = False
                End If
                If u.USUARIO = "GB" Then
                    AnálisisToolStripMenuItem.Enabled = True
                End If
                '****************************************************
                'Si el usuario es Noelia habilita la pestaña IT
                If u.USUARIO = "NG" Then
                    ITToolStripMenuItem.Enabled = True
                    AutorizarCompraToolStripMenuItem.Enabled = True
                Else
                    ITToolStripMenuItem.Enabled = False
                End If
                '****************************************************
            ElseIf u.TIPOUSUARIO = 96 Then 'si el usuario es del tipo auxiliar
                comprobarcomprascanceladas()
                comprobarlineacompracancelada()
                'Menú TRAZABILIDAD.
                FrascosToolStripMenuItem1.Enabled = True
                BuscarCajasPorNúmeroToolStripMenuItem.Enabled = False
                'Estadísticas
                EstadísticasATBToolStripMenuItem.Enabled = True
                'Registros
                RegistrosToolStripMenuItem.Enabled = True
                'Capacitacion
                CapacitaciónToolStripMenuItem1.Enabled = True
                'Personal
                PersonalToolStripMenuItem.Enabled = True
            ElseIf u.TIPOUSUARIO = 95 Then 'si el usuario es del tipo temporal
                'Menú MANTENIMIENTO.
                MantenimientoToolStripMenuItem.Enabled = False
                'Capacitacion
                CapacitaciónToolStripMenuItem1.Enabled = False
                If u.USUARIO = "M" Then
                    PersonalToolStripMenuItem.Enabled = True
                    RelojToolStripMenuItem1.Enabled = True
                    LicenciadíasToolStripMenuItem.Enabled = True
                    FeriadosToolStripMenuItem.Enabled = True
                    FuncionariosToolStripMenuItem.Enabled = True
                    InformesRelojToolStripMenuItem.Enabled = True
                    DirecciónToolStripMenuItem.Enabled = True
                Else
                    RelojToolStripMenuItem1.Enabled = True
                End If
            End If
            nombre_pc = My.Computer.Name
            If nombre_pc = "SUELOS" Then
                RelojToolStripMenuItem1.Enabled = True
                LicenciadíasToolStripMenuItem.Enabled = True
                FeriadosToolStripMenuItem.Enabled = True
                FuncionariosToolStripMenuItem.Enabled = True
                InformesRelojToolStripMenuItem.Enabled = True
            End If
            If nombre_pc = "IT" Or nombre_pc = "ADMINISTRACION" Or nombre_pc = "SRVDATOS" Or nombre_pc = "CALIDAD" Then
                If u.USUARIO = "JG" Then
                    AutorizacionesToolStripMenuItem.Enabled = True
                End If
                If u.USUARIO = "JG" Or u.USUARIO = "GB" Or u.USUARIO = "SA" Or u.USUARIO = "CA" Or u.USUARIO = "M" Then
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

                    ElseIf result = DialogResult.No Then

                    ElseIf result = DialogResult.Yes Then
                        clc.ID = idcancelalcompra
                        clc.marcarvisto()
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub ProductorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductorToolStripMenuItem.Click
        Dim v As New FormProductor(Sesion.Usuario, idprod)
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
    Private Sub EmpresasDeTransportesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpresasDeTransportesToolStripMenuItem.Click
        Dim v As New FormEmpresaT(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub TécnicosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TécnicosToolStripMenuItem.Click
        Dim v As New FormTecnicos(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub PedidosFrascosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormPedidoFrascos(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub SolicitudDeAnálisisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormSolicitudAnalisis(Sesion.Usuario, 0)
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
    Private Sub PedidosAutomáticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormPedidosAutomaticos(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub FrascosRotosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrascosRotosToolStripMenuItem.Click
        Dim v As New FormFrascosRotos(Sesion.Usuario)
        v.Show()
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
    Private Sub DescarteDeMuestrasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormDescarteMuestras(Sesion.Usuario, 0)
        v.Show()
    End Sub
    Private Sub NuevaSolicitudToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormSolicitudAnalisis(Sesion.Usuario, 0)
        v.Show()
    End Sub
    Private Sub DescarteDeMuestrasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormDescarteMuestras(Sesion.Usuario, 0)
        v.Show()
    End Sub
    Private Sub ProdúctosYSubprodúctosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormSubproductos(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormSolicitudAnalisis(Sesion.Usuario, 0)
        v.Show()
    End Sub
    Private Sub CajasEnviadasPorClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormInformeEnvioxCliente(Sesion.Usuario)
        v.Show()
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
    Private Sub TiemposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiemposToolStripMenuItem.Click
        Dim v As New FormTiempos(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub InformesPendientesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormInformesPendientes(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub PALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub AmbientalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub BacteriologíaDeTanqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub ContadorDeAnálisisEmpresasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormContadorAnalisisEmpresas()
        v.Show()
    End Sub
    Private Sub CopiarArchivosDeCalidadMoiraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub RecibirCajasPorNúmeroToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        Dim v As New FormSolicitudAnalisis(Sesion.Usuario, 0)
        v.Show()
    End Sub
    Private Sub DescarteDeMuestrasToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescarteDeMuestrasToolStripMenuItem.Click
        Dim v As New FormDescarteMuestras(Sesion.Usuario, 0)
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
        cargartareas()
        cargartareasp()
        cargarfichasparasubir()
        cargarfichassubidas()
        listarpedidosweb()
        listarpedidospendientes()
        cargarAutorizaciones()
        cargarNotificaciones()
        desmarcar_pedidos_automaticos()
    End Sub
    Private Sub desmarcar_pedidos_automaticos()
        Dim hoy As Date = Now
        Dim dia As Integer = 0
        dia = hoy.Day
        If dia > 25 Then
            Dim p As New dPedidosAuto
            p.desmarcartodos()
        End If
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
        Dim v As New FormSolicitudAnalisis(Sesion.Usuario, 0)
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
    Private Sub CategoríasproductosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoríasproductosToolStripMenuItem1.Click
        Dim v As New FormCategoria(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub ProveedoresToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProveedoresToolStripMenuItem1.Click
        Dim v As New FormProveedores(Sesion.Usuario)
        v.Show()
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
    Private Sub TiemposDeEnvíosDeInformesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub NutriciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormNutricion(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub NutriciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NutriciónToolStripMenuItem1.Click
        Dim v As New FormInformeNutricion(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub SuelosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(2)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)
        Dim c As New dControl
        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        '*****************************
        Dim idsol As Long = id_sol 'ficha
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 2

        '*** ENCABEZADO ********************************************************************************
        '***********************************************************************************************
        'Poner Titulos
        x1hoja.Cells(1, 1).columnwidth = 5
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 3
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 5
        x1hoja.Cells(1, 12).columnwidth = 5
        x1hoja.Cells(1, 13).columnwidth = 5
        x1hoja.Cells(1, 14).columnwidth = 5
        x1hoja.Cells(1, 15).columnwidth = 5
        x1hoja.Range("A1", "D1").Merge()
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
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Caseina"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 6
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
                    cs.FICHA = idsol
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
                                If valorurea > 20 Or valorurea < 9 Then
                                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                End If
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
                        If cs.CASEINA = 1 Then
                            If c.CASEINA = -1 Or c.UREA = 0 Then
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = c.CASEINA
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
            columna = 9
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
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Caseina"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 6
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = 9
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
                        cs.FICHA = idsol
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
                                    If valorurea > 20 Or valorurea < 9 Then
                                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                    End If
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
                            If cs.CASEINA = 1 Then
                                If c.CASEINA = -1 Or c.CASEINA = 0 Then
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = c.CASEINA
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
                        columna = 9
                        fila = fila + 1
                    Next
                    'Referencias
                    fila = fila + 1
                    columna = 1
                End If
            End If
        End If
        'PROTEGE LA HOJA DE EXCEL
        'x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'x1hoja.SaveAs("C:\PREINFORMES\CONTROL\" & idsol & ".xls")
        Dim preinf As New dPreinformes
        preinf.FICHA = idsol
        preinf.marcarcreado()
        preinf = Nothing
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
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(2)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)
        Dim csm As New dCalidadSolicitudMuestra
        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList
        '*****************************
        Dim idsol As Long = id_sol 'TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 2
        '*********************** ENCABEZADO ************************************************************************
        '***********************************************************************************************************
        'Poner Titulos
        x1hoja.Cells(1, 1).columnwidth = 6 '7
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 5
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 6 '8
        x1hoja.Cells(1, 12).columnwidth = 6
        x1hoja.Cells(1, 13).columnwidth = 6 '8
        x1hoja.Cells(1, 14).columnwidth = 5
        lista = csm.listarporsolicitud(idsol)
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
        x1hoja.Cells(fila, columna).Formula = "R Bact.*"
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
        x1hoja.Cells(fila, columna).Formula = "Esp.Ana."
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
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Afla.M1"
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
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("N16", "N17").Merge()
        x1hoja.Range("N16", "N17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("N16", "N17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("N16", "N17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "ppb"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = 1
        fila = fila + 2
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
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
                                If valcrioscopia > -0.512 Or valcrioscopia < -0.54 Then
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
                                If valorurea > 20 Or valorurea < 9 Then
                                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                End If
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
                    'AFLATOXINA M1*******************************************************************************
                    Dim m As New dMicotoxinasLeche
                    m.FICHA = idsol
                    m.MUESTRA = Trim(csm.MUESTRA)
                    m = m.buscarxfichaxmuestra
                    If Not m Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = m.RESULTADO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
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
            End If
        End If
        'PROTEGE LA HOJA DE EXCEL
        'x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'x1hoja.SaveAs("\\192.168.1.10\E\NET\PREINFORMES\CALIDAD\" & idsol & ".xls")
        'x1hoja.SaveAs("C:\PREINFORMES\CALIDAD\" & idsol & ".xls")
        'Marcar como creado
        Dim preinf As New dPreinformes
        preinf.FICHA = idsol
        preinf.marcarcreado()
        preinf = Nothing
        x1app.Visible = False
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub creartxt()
        Dim idficha As Long = 1 'TextFicha.Text.Trim
        Dim oSW As New StreamWriter("\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".txt")
        Dim c As New dControl
        Dim lista4 As New ArrayList
        lista4 = c.listarporsolicitud(idficha)
        Dim secuencial As Integer = 1
        If Not lista4 Is Nothing Then
            If lista4.Count > 0 Then
                Dim cs As New dControlSolicitud
                cs.FICHA = idficha
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
        If nombre_pc = "ROBOT" Then
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
                                        ibc.FICHA = csm.FICHA
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
                                        psi.FICHA = csm.FICHA
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
                                        esp.FICHA = csm.FICHA
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
                                        inh.FICHA = csm.FICHA
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
            subir_informes_control()
            subir_informes_agua()
            subir_informes_atb()
            subir_informes_subproductos()
            subir_informes_calidad()
            subir_informes_brucelosis()
            cargarfichasparasubir()
            cargarfichassubidas()
            'Enviar correos a proveedores
            Dim fecha As Date
            fecha = DateFecha.Value.ToString("yyyy-MM-dd")
            If fecha.DayOfWeek = DayOfWeek.Thursday Then
                Dim hoy As Date = Now
                Dim hora As Integer = 0
                Dim minuto As Integer = 0
                hora = hoy.Hour
                minuto = hoy.Minute
                If hora > 9 Then
                    enviarcompras()
                End If
                Dim dia As Integer = 0
                dia = hoy.Day
            End If
            'mover archivos subidos
            Dim hoy2 As Date = Now
            Dim hora2 As Integer = 0
            hora2 = hoy2.Hour
            If hora2 = 20 Then
                moverarchivossubidos()
            End If
        End If
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
                                ibc.FICHA = csm.ficha
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
                                psi.FICHA = csm.ficha
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
                                esp.FICHA = csm.ficha
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
                                inh.FICHA = csm.ficha
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
                        Dim p As New dCliente
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
                                email = Replace(pw_com.ENVIAR_EMAIL, " ", "")
                                celular = Replace(pw_com.ENVIAR_SMS, " ", "")
                                carpeta = idproductorweb_com
                                crea_carpeta()
                            End If
                            sa = Nothing
                        End If
                    End If
controlexcel:
                    If nombre_pc = "ROBOT" Then
                        subirFicheroXls()
                    Else
                        subirFicheroXls_otrapc()
                    End If
                    existeXls()
                    If excel = 1 Then
                        GoTo controlexcel
                    End If
                    moverexcel()
controlpdf:
                    If nombre_pc = "ROBOT" Then
                        subirFicheroPdf()
                    Else
                        subirFicheroPdf_otrapc()
                    End If
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
                    s.marcar2()
                    s = Nothing
                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = idficha
                    est.ESTADO = 8
                    est.FECHA = fecenv
                    est.guardar2()
                    est = Nothing
                    '****************************
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
                        Dim p As New dCliente
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
                                carpeta = idproductorweb_com
                                crea_carpeta()
                            End If
                            sa = Nothing
                        End If
                    End If
controlexcel2:      If nombre_pc = "ROBOT" Then
                        subirFicheroXls()
                    Else
                        subirFicheroXls_otrapc()
                    End If
                    existeXls()
                    If excel = 1 Then
                        GoTo controlexcel2
                    End If
                    moverexcel()
controlpdf2:
                    If nombre_pc = "ROBOT" Then
                        subirFicheroPdf()
                    Else
                        subirFicheroPdf_otrapc()
                    End If
                    existePdf()
                    If pdf = 1 Then
                        GoTo controlpdf2
                    End If
                    moverpdf()
controlcsv2:
                    If nombre_pc = "ROBOT" Then
                        subirFicheroCsv()
                    Else
                        subirFicheroCsv_otrapc()
                    End If
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
                    s.marcar2()
                    s = Nothing
                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = idficha
                    est.ESTADO = 8
                    est.FECHA = fecenv
                    est.guardar2()
                    est = Nothing
                    '****************************
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
                    Dim cifq As New dControlInformesFQ
                    Dim ficha As Long = 0
                    cifq.FICHA = pi.FICHA
                    cifq = cifq.buscarxficha
                    If Not cifq Is Nothing Then
                        If cifq.CONTROLADO = 1 Then
                            idficha = pi.FICHA
                            _tipoinforme = pi.TIPO
                            enviar_copia = pi.COPIA
                            _abonado = pi.ABONADO
                            _comentarios = pi.COMENTARIO
                            Dim sa As New dSolicitudAnalisis
                            sa.ID = idficha
                            sa = sa.buscar
                            If Not sa Is Nothing Then
                                Dim p As New dCliente
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
                                        carpeta = idproductorweb_com
                                        crea_carpeta()
                                    End If
                                    sa = Nothing
                                End If
                            End If
controlexcel:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroXls()
                            Else
                                subirFicheroXls_otrapc()
                            End If
                            existeXls()
                            If excel = 1 Then
                                GoTo controlexcel
                            End If
                            subidoxls = 1
controlpdf:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroPdf()
                            Else
                                subirFicheroPdf_otrapc()
                            End If
                            existePdf()
                            If pdf = 1 Then
                                GoTo controlpdf
                            End If
                            subidopdf = 1
                            If pi.TIPO = 1 Then
controltxt:
                                If nombre_pc = "ROBOT" Then
                                    subirFicheroCsv()
                                Else
                                    subirFicheroCsv_otrapc()
                                End If
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
                            s.marcar2()
                            s = Nothing
                            If subidoxls = 1 And subidopdf = 1 Then
                                If nombre_pc = "ROBOT" Then
                                    moverexcel()
                                    moverpdf()
                                Else
                                    moverexcel_otrapc()
                                    moverpdf_otrapc()
                                End If
                                ' Grabar estado de la ficha
                                Dim est As New dEstados
                                est.FICHA = idficha
                                est.ESTADO = 8
                                est.FECHA = fecenv
                                est.guardar2()
                                est = Nothing
                                '****************************
                            End If
                        Else
                        End If
                    Else
                    End If
                    cifq = Nothing
                Next
            End If
        End If
        cargarfichasparasubir()
        cargarfichassubidas()
    End Sub
    Private Sub subir_informes2b()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        Dim subidoxls As Integer = 0
        Dim subidopdf As Integer = 0
        Dim subidotxt As Integer = 0
        lista = pi.listarparasubirmicro
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pi In lista
                    Dim cimicro As New dControlInformesMicro
                    Dim ficha As Long = 0
                    cimicro.FICHA = pi.FICHA
                    cimicro = cimicro.buscarxficha
                    If Not cimicro Is Nothing Then
                        If cimicro.CONTROLADO = 1 Then
                            idficha = pi.FICHA
                            _tipoinforme = pi.TIPO
                            enviar_copia = pi.COPIA
                            _abonado = pi.ABONADO
                            _comentarios = pi.COMENTARIO
                            Dim sa As New dSolicitudAnalisis
                            sa.ID = idficha
                            sa = sa.buscar
                            If Not sa Is Nothing Then
                                Dim p As New dCliente
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
                                        carpeta = idproductorweb_com
                                        crea_carpeta()
                                    End If
                                    sa = Nothing
                                End If
                            End If
controlexcel:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroXls()
                            Else
                                subirFicheroXls_otrapc()
                            End If
                            existeXls()
                            If excel = 1 Then
                                GoTo controlexcel
                            End If
                            subidoxls = 1
controlpdf:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroPdf()
                            Else
                                subirFicheroPdf_otrapc()
                            End If
                            existePdf()
                            If pdf = 1 Then
                                GoTo controlpdf
                            End If
                            subidopdf = 1
                            If pi.TIPO = 1 Then
controltxt:
                                If nombre_pc = "ROBOT" Then
                                    subirFicheroCsv()
                                Else
                                    subirFicheroCsv_otrapc()
                                End If
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
                            s.marcar2()
                            s = Nothing
                            If subidoxls = 1 And subidopdf = 1 Then
                                If nombre_pc = "ROBOT" Then
                                    moverexcel()
                                    moverpdf()
                                Else
                                    moverexcel_otrapc()
                                    moverpdf_otrapc()
                                End If
                            End If
                        Else
                        End If
                    Else
                    End If
                    cimicro = Nothing
                Next
            End If
        End If
        cargarfichasparasubir()
        cargarfichassubidas()
    End Sub
    Public Sub crea_carpeta()
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta
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
    Private Sub subir_informes_control()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        Dim subidoxls As Integer = 0
        Dim subidopdf As Integer = 0
        Dim subidotxt As Integer = 0
        lista = pi.listarparasubircontrol
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pi In lista
                    Dim cifq As New dControlInformesFQ
                    Dim ficha As Long = 0
                    cifq.FICHA = pi.FICHA
                    cifq = cifq.buscarxficha
                    If Not cifq Is Nothing Then
                        If cifq.CONTROLADO = 1 Then
                            idficha = pi.FICHA
                            _tipoinforme = pi.TIPO
                            enviar_copia = pi.COPIA
                            _abonado = pi.ABONADO
                            _comentarios = pi.COMENTARIO
                            Dim sa As New dSolicitudAnalisis
                            sa.ID = idficha
                            sa = sa.buscar
                            If Not sa Is Nothing Then
                                Dim p As New dCliente
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
                                        carpeta = idproductorweb_com
                                        crea_carpeta()
                                    End If
                                    sa = Nothing
                                End If
                            End If
controlexcel:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroXls()
                            Else
                                subirFicheroXls_otrapc()
                            End If
                            existeXls()
                            If excel = 1 Then
                                GoTo controlexcel
                            End If
                            subidoxls = 1
controlpdf:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroPdf()
                            Else
                                subirFicheroPdf_otrapc()
                            End If
                            existePdf()
                            If pdf = 1 Then
                                GoTo controlpdf
                            End If
                            subidopdf = 1
                            If pi.TIPO = 1 Then
controltxt:
                                If nombre_pc = "ROBOT" Then
                                    subirFicheroCsv()
                                Else
                                    subirFicheroCsv_otrapc()
                                End If
                                existeCsv()
                                If csv = 1 Then
                                    GoTo controltxt
                                End If
                                If nombre_pc = "ROBOT" Then
                                    movertxt()
                                Else
                                    movertxt_otrapc()
                                End If
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
                            s.marcar2()
                            s = Nothing
                            If subidoxls = 1 And subidopdf = 1 Then
                                If nombre_pc = "ROBOT" Then
                                    moverexcel()
                                    moverpdf()
                                Else
                                    moverexcel_otrapc()
                                    moverpdf_otrapc()
                                End If
                                ' Grabar estado de la ficha
                                Dim est As New dEstados
                                est.FICHA = idficha
                                est.ESTADO = 8
                                est.FECHA = fecenv
                                est.guardar2()
                                est = Nothing
                                '****************************
                            End If
                        Else
                        End If
                    Else
                        idficha = pi.FICHA
                        _tipoinforme = pi.TIPO
                        enviar_copia = pi.COPIA
                        _abonado = pi.ABONADO
                        _comentarios = pi.COMENTARIO
                        Dim sa As New dSolicitudAnalisis
                        sa.ID = idficha
                        sa = sa.buscar
                        If Not sa Is Nothing Then
                            Dim p As New dCliente
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
                                    carpeta = idproductorweb_com
                                    crea_carpeta()
                                End If
                                sa = Nothing
                            End If
                        End If
controlexcel2:
                        If nombre_pc = "ROBOT" Then
                            subirFicheroXls()
                        Else
                            subirFicheroXls_otrapc()
                        End If
                        existeXls()
                        If excel = 1 Then
                            GoTo controlexcel2
                        End If
                        subidoxls = 1
controlpdf2:
                        If nombre_pc = "ROBOT" Then
                            subirFicheroPdf()
                        Else
                            subirFicheroPdf_otrapc()
                        End If
                        existePdf()
                        If pdf = 1 Then
                            GoTo controlpdf2
                        End If
                        subidopdf = 1
                        If pi.TIPO = 1 Then
controltxt2:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroCsv()
                            Else
                                subirFicheroCsv_otrapc()
                            End If
                            existeCsv()
                            If csv = 1 Then
                                GoTo controltxt2
                            End If
                            If nombre_pc = "ROBOT" Then
                                movertxt()
                            Else
                                movertxt_otrapc()
                            End If
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
                        s.marcar2()
                        s = Nothing
                        If subidoxls = 1 And subidopdf = 1 Then
                            If nombre_pc = "Robot" Then
                                moverexcel()
                                moverpdf()
                            Else
                                moverexcel_otrapc()
                                moverpdf_otrapc()
                            End If
                            ' Grabar estado de la ficha
                            Dim est As New dEstados
                            est.FICHA = idficha
                            est.ESTADO = 8
                            est.FECHA = fecenv
                            est.guardar2()
                            est = Nothing
                            '****************************
                        End If
                    End If
                    cifq = Nothing
                Next
            End If
        End If
        cargarfichasparasubir()
        cargarfichassubidas()
    End Sub
    Private Sub subir_informes_agua()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        Dim subidoxls As Integer = 0
        Dim subidopdf As Integer = 0
        Dim subidotxt As Integer = 0
        lista = pi.listarparasubiragua
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pi In lista
                    Dim cimicro As New dControlInformesMicro
                    Dim ficha As Long = 0
                    cimicro.FICHA = pi.FICHA
                    cimicro = cimicro.buscarxficha
                    If Not cimicro Is Nothing Then
                        If cimicro.CONTROLADO = 1 Then
                            idficha = pi.FICHA
                            _tipoinforme = pi.TIPO
                            enviar_copia = pi.COPIA
                            _abonado = pi.ABONADO
                            _comentarios = pi.COMENTARIO
                            Dim sa As New dSolicitudAnalisis
                            sa.ID = idficha
                            sa = sa.buscar
                            If Not sa Is Nothing Then
                                Dim p As New dCliente
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
                                        carpeta = idproductorweb_com
                                        crea_carpeta()
                                    End If
                                    sa = Nothing
                                End If
                            End If
controlexcel:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroXls()
                            Else
                                subirFicheroXls_otrapc()
                            End If
                            existeXls()
                            If excel = 1 Then
                                GoTo controlexcel
                            End If
                            subidoxls = 1
controlpdf:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroPdf()
                            Else
                                subirFicheroPdf_otrapc()
                            End If
                            existePdf()
                            If pdf = 1 Then
                                GoTo controlpdf
                            End If
                            subidopdf = 1
                            If pi.TIPO = 1 Then
controltxt:
                                If nombre_pc = "ROBOT" Then
                                    subirFicheroCsv()
                                Else
                                    subirFicheroCsv_otrapc()
                                End If
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
                            s.marcar2()
                            s = Nothing
                            If subidoxls = 1 And subidopdf = 1 Then
                                If nombre_pc = "ROBOT" Then
                                    moverexcel()
                                    moverpdf()
                                Else
                                    moverexcel_otrapc()
                                    moverpdf_otrapc()
                                End If
                                ' Grabar estado de la ficha
                                Dim est As New dEstados
                                est.FICHA = idficha
                                est.ESTADO = 8
                                est.FECHA = fecenv
                                est.guardar2()
                                est = Nothing
                                '****************************
                            End If
                        Else
                        End If
                    Else
                        idficha = pi.FICHA
                        _tipoinforme = pi.TIPO
                        enviar_copia = pi.COPIA
                        _abonado = pi.ABONADO
                        _comentarios = pi.COMENTARIO
                        Dim sa As New dSolicitudAnalisis
                        sa.ID = idficha
                        sa = sa.buscar
                        If Not sa Is Nothing Then
                            Dim p As New dCliente
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
                                    carpeta = idproductorweb_com
                                    crea_carpeta()
                                End If
                                sa = Nothing
                            End If
                        End If
controlexcel2:
                        If nombre_pc = "ROBOT" Then
                            subirFicheroXls()
                        Else
                            subirFicheroXls_otrapc()
                        End If
                        existeXls()
                        If excel = 1 Then
                            GoTo controlexcel2
                        End If
                        subidoxls = 1
controlpdf2:
                        If nombre_pc = "ROBOT" Then
                            subirFicheroPdf()
                        Else
                            subirFicheroPdf_otrapc()
                        End If
                        existePdf()
                        If pdf = 1 Then
                            GoTo controlpdf2
                        End If
                        subidopdf = 1
                        If pi.TIPO = 1 Then
controltxt2:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroCsv()
                            Else
                                subirFicheroCsv_otrapc()
                            End If
                            existeCsv()
                            If csv = 1 Then
                                GoTo controltxt2
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
                        s.marcar2()
                        s = Nothing
                        If subidoxls = 1 And subidopdf = 1 Then
                            If nombre_pc = "ROBOT" Then
                                moverexcel()
                                moverpdf()
                            Else
                                moverexcel_otrapc()
                                moverpdf_otrapc()
                            End If
                            ' Grabar estado de la ficha
                            Dim est As New dEstados
                            est.FICHA = idficha
                            est.ESTADO = 8
                            est.FECHA = fecenv
                            est.guardar2()
                            est = Nothing
                            '****************************
                        End If
                    End If
                    cimicro = Nothing
                Next
            End If
        End If
        cargarfichasparasubir()
        cargarfichassubidas()
    End Sub
    Private Sub subir_informes_atb()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        Dim subidoxls As Integer = 0
        Dim subidopdf As Integer = 0
        Dim subidotxt As Integer = 0
        lista = pi.listarparasubiratb
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pi In lista
                    Dim cimicro As New dControlInformesMicro
                    Dim ficha As Long = 0
                    cimicro.FICHA = pi.FICHA
                    cimicro = cimicro.buscarxficha
                    If Not cimicro Is Nothing Then
                        If cimicro.CONTROLADO = 1 Then
                            idficha = pi.FICHA
                            _tipoinforme = pi.TIPO
                            enviar_copia = pi.COPIA
                            _abonado = pi.ABONADO
                            _comentarios = pi.COMENTARIO
                            Dim sa As New dSolicitudAnalisis
                            sa.ID = idficha
                            sa = sa.buscar
                            If Not sa Is Nothing Then
                                Dim p As New dCliente
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
                                        carpeta = idproductorweb_com
                                        crea_carpeta()
                                    End If
                                    sa = Nothing
                                End If
                            End If
controlexcel:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroXls()
                            Else
                                subirFicheroXls_otrapc()
                            End If
                            existeXls()
                            If excel = 1 Then
                                GoTo controlexcel
                            End If
                            subidoxls = 1
controlpdf:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroPdf()
                            Else
                                subirFicheroPdf_otrapc()
                            End If
                            existePdf()
                            If pdf = 1 Then
                                GoTo controlpdf
                            End If
                            subidopdf = 1
                            If pi.TIPO = 1 Then
controltxt:
                                If nombre_pc = "ROBOT" Then
                                    subirFicheroCsv()
                                Else
                                    subirFicheroCsv_otrapc()
                                End If
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
                            s.marcar2()
                            s = Nothing
                            If subidoxls = 1 And subidopdf = 1 Then
                                If nombre_pc = "ROBOT" Then
                                    moverexcel()
                                    moverpdf()
                                Else
                                    moverexcel_otrapc()
                                    moverpdf_otrapc()
                                End If
                                ' Grabar estado de la ficha
                                Dim est As New dEstados
                                est.FICHA = idficha
                                est.ESTADO = 8
                                est.FECHA = fecenv
                                est.guardar2()
                                est = Nothing
                                '****************************
                            End If
                        Else
                        End If
                    Else
                        idficha = pi.FICHA
                        _tipoinforme = pi.TIPO
                        enviar_copia = pi.COPIA
                        _abonado = pi.ABONADO
                        _comentarios = pi.COMENTARIO
                        Dim sa As New dSolicitudAnalisis
                        sa.ID = idficha
                        sa = sa.buscar
                        If Not sa Is Nothing Then
                            Dim p As New dCliente
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
                                    carpeta = idproductorweb_com
                                    crea_carpeta()
                                End If
                                sa = Nothing
                            End If
                        End If
controlexcel2:
                        If nombre_pc = "ROBOT" Then
                            subirFicheroXls()
                        Else
                            subirFicheroXls_otrapc()
                        End If
                        existeXls()
                        If excel = 1 Then
                            GoTo controlexcel2
                        End If
                        subidoxls = 1
controlpdf2:
                        If nombre_pc = "ROBOT" Then
                            subirFicheroPdf()
                        Else
                            subirFicheroPdf_otrapc()
                        End If
                        existePdf()
                        If pdf = 1 Then
                            GoTo controlpdf2
                        End If
                        subidopdf = 1
                        If pi.TIPO = 1 Then
controltxt2:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroCsv()
                            Else
                                subirFicheroCsv_otrapc()
                            End If
                            existeCsv()
                            If csv = 1 Then
                                GoTo controltxt2
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
                        s.marcar2()
                        s = Nothing
                        If subidoxls = 1 And subidopdf = 1 Then
                            If nombre_pc = "ROBOT" Then
                                moverexcel()
                                moverpdf()
                            Else
                                moverexcel_otrapc()
                                moverpdf_otrapc()
                            End If
                            ' Grabar estado de la ficha
                            Dim est As New dEstados
                            est.FICHA = idficha
                            est.ESTADO = 8
                            est.FECHA = fecenv
                            est.guardar2()
                            est = Nothing
                            '****************************
                        End If
                    End If
                    cimicro = Nothing
                Next
            End If
        End If
        cargarfichasparasubir()
        cargarfichassubidas()
    End Sub
    Private Sub subir_informes_subproductos()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        Dim subidoxls As Integer = 0
        Dim subidopdf As Integer = 0
        Dim subidotxt As Integer = 0
        lista = pi.listarparasubirsubproductos
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pi In lista
                    Dim cimicro As New dControlInformesMicro
                    Dim ficha As Long = 0
                    cimicro.FICHA = pi.FICHA
                    cimicro = cimicro.buscarxficha
                    If Not cimicro Is Nothing Then
                        If cimicro.CONTROLADO = 1 Then
                            idficha = pi.FICHA
                            _tipoinforme = pi.TIPO
                            enviar_copia = pi.COPIA
                            _abonado = pi.ABONADO
                            _comentarios = pi.COMENTARIO
                            Dim sa As New dSolicitudAnalisis
                            sa.ID = idficha
                            sa = sa.buscar
                            If Not sa Is Nothing Then
                                Dim p As New dCliente
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
                                        carpeta = idproductorweb_com
                                        crea_carpeta()
                                    End If
                                    sa = Nothing
                                End If
                            End If
controlexcel:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroXls()
                            Else
                                subirFicheroXls_otrapc()
                            End If
                            existeXls()
                            If excel = 1 Then
                                GoTo controlexcel
                            End If
                            subidoxls = 1
controlpdf:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroPdf()
                            Else
                                subirFicheroPdf_otrapc()
                            End If
                            existePdf()
                            If pdf = 1 Then
                                GoTo controlpdf
                            End If
                            subidopdf = 1
                            If pi.TIPO = 1 Then
controltxt:
                                If nombre_pc = "ROBOT" Then
                                    subirFicheroCsv()
                                Else
                                    subirFicheroCsv_otrapc()
                                End If
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
                            s.marcar2()
                            s = Nothing
                            If subidoxls = 1 And subidopdf = 1 Then
                                If nombre_pc = "ROBOT" Then
                                    moverexcel()
                                    moverpdf()
                                Else
                                    moverexcel_otrapc()
                                    moverpdf_otrapc()
                                End If
                                ' Grabar estado de la ficha
                                Dim est As New dEstados
                                est.FICHA = idficha
                                est.ESTADO = 8
                                est.FECHA = fecenv
                                est.guardar2()
                                est = Nothing
                                '****************************
                            End If
                        Else
                        End If
                    Else
                        idficha = pi.FICHA
                        _tipoinforme = pi.TIPO
                        enviar_copia = pi.COPIA
                        _abonado = pi.ABONADO
                        _comentarios = pi.COMENTARIO
                        Dim sa As New dSolicitudAnalisis
                        sa.ID = idficha
                        sa = sa.buscar
                        If Not sa Is Nothing Then
                            Dim p As New dCliente
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
                                    carpeta = idproductorweb_com
                                    crea_carpeta()
                                End If
                                sa = Nothing
                            End If
                        End If
controlexcel2:
                        If nombre_pc = "ROBOT" Then
                            subirFicheroXls()
                        Else
                            subirFicheroXls_otrapc()
                        End If
                        existeXls()
                        If excel = 1 Then
                            GoTo controlexcel2
                        End If
                        subidoxls = 1
controlpdf2:
                        If nombre_pc = "ROBOT" Then
                            subirFicheroPdf()
                        Else
                            subirFicheroPdf_otrapc()
                        End If
                        existePdf()
                        If pdf = 1 Then
                            GoTo controlpdf2
                        End If
                        subidopdf = 1
                        If pi.TIPO = 1 Then
controltxt2:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroCsv_otrapc()
                            Else
                                subirFicheroCsv()
                            End If
                            existeCsv()
                            If csv = 1 Then
                                GoTo controltxt2
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
                        'enviomail()
                        enviosms()
                        s.marcar2()
                        s = Nothing
                        If subidoxls = 1 And subidopdf = 1 Then
                            If nombre_pc = "ROBOT" Then
                                moverexcel()
                                moverpdf()
                            Else
                                moverexcel_otrapc()
                                moverpdf_otrapc()
                            End If
                            ' Grabar estado de la ficha
                            Dim est As New dEstados
                            est.FICHA = idficha
                            est.ESTADO = 8
                            est.FECHA = fecenv
                            est.guardar2()
                            est = Nothing
                            '****************************
                        End If
                    End If
                    cimicro = Nothing
                Next
            End If
        End If
        cargarfichasparasubir()
        cargarfichassubidas()
    End Sub
    Private Sub subir_informes_calidad()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        Dim subidoxls As Integer = 0
        Dim subidopdf As Integer = 0
        Dim subidotxt As Integer = 0
        lista = pi.listarparasubircalidad
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pi In lista
                    Dim cifq As New dControlInformesFQ
                    Dim cimicro As New dControlInformesMicro
                    Dim ficha As Long = 0
                    cifq.FICHA = pi.FICHA
                    cifq = cifq.buscarxficha
                    cimicro.FICHA = pi.FICHA
                    cimicro = cimicro.buscarxficha
                    Dim control As Integer = 0
                    Dim control2 As Integer = 0
                    If Not cifq Is Nothing Then
                        If cifq.CONTROLADO = 1 Then
                            control = 1
                        Else
                            control = 0
                        End If
                    Else
                        control = 1
                    End If
                    If Not cimicro Is Nothing Then
                        If cimicro.CONTROLADO = 1 Then
                            control2 = 1
                        Else
                            control2 = 0
                        End If
                    Else
                        control2 = 1
                    End If
                    If control = 1 And control2 = 1 Then
                        idficha = pi.FICHA
                        _tipoinforme = pi.TIPO
                        enviar_copia = pi.COPIA
                        _abonado = pi.ABONADO
                        _comentarios = pi.COMENTARIO
                        Dim sa As New dSolicitudAnalisis
                        sa.ID = idficha
                        sa = sa.buscar
                        If Not sa Is Nothing Then
                            Dim p As New dCliente
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
                                    carpeta = idproductorweb_com
                                    crea_carpeta()
                                End If
                                sa = Nothing
                            End If
                        End If
controlexcel:
                        If nombre_pc = "ROBOT" Then
                            subirFicheroXls()
                        Else
                            subirFicheroXls_otrapc()
                        End If
                        existeXls()
                        If excel = 1 Then
                            GoTo controlexcel
                        End If
                        subidoxls = 1
controlpdf:
                        If nombre_pc = "ROBOT" Then
                            subirFicheroPdf()
                        Else
                            subirFicheroPdf_otrapc()
                        End If
                        existePdf()
                        If pdf = 1 Then
                            GoTo controlpdf
                        End If
                        subidopdf = 1
                        If pi.TIPO = 1 Then
controltxt:
                            If nombre_pc = "ROBOT" Then
                                subirFicheroCsv()
                            Else
                                subirFicheroCsv_otrapc()
                            End If
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
                        s.marcar2()
                        s = Nothing
                        If subidoxls = 1 And subidopdf = 1 Then
                            If nombre_pc = "ROBOT" Then
                                moverexcel()
                                moverpdf()
                            Else
                                moverexcel_otrapc()
                                moverpdf_otrapc()
                            End If
                            ' Grabar estado de la ficha
                            Dim est As New dEstados
                            est.FICHA = idficha
                            est.ESTADO = 8
                            est.FECHA = fecenv
                            est.guardar2()
                            est = Nothing
                            '****************************
                        End If
                    End If
                    cifq = Nothing
                Next
            End If
        End If
        cargarfichasparasubir()
        cargarfichassubidas()
    End Sub
    Private Sub subir_informes_brucelosis()
        Dim pi As New dPreinformes
        Dim lista As New ArrayList
        Dim subidoxls As Integer = 0
        Dim subidopdf As Integer = 0
        Dim subidotxt As Integer = 0
        lista = pi.listarparasubirbrucelosis
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
                        Dim p As New dCliente
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
                                carpeta = idproductorweb_com
                                crea_carpeta()
                            End If
                            sa = Nothing
                        End If
                    End If
controlexcel:
                    If nombre_pc = "ROBOT" Then
                        subirFicheroXls()
                    Else
                        subirFicheroXls_otrapc()
                    End If
                    existeXls()
                    If excel = 1 Then
                        GoTo controlexcel
                    End If
                    subidoxls = 1
controlpdf:
                    If nombre_pc = "ROBOT" Then
                        subirFicheroPdf()
                    Else
                        subirFicheroPdf_otrapc()
                    End If
                    existePdf()
                    If pdf = 1 Then
                        GoTo controlpdf
                    End If
                    subidopdf = 1
                    If pi.TIPO = 1 Then
controltxt:
                        If nombre_pc = "ROBOT" Then
                            subirFicheroCsv()
                        Else
                            subirFicheroCsv_otrapc()
                        End If
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
                    s.marcar2()
                    s = Nothing
                    If subidoxls = 1 And subidopdf = 1 Then
                        If nombre_pc = "ROBOT" Then
                            moverexcel()
                            moverpdf()
                        Else
                            moverexcel_otrapc()
                            moverpdf_otrapc()
                        End If
                        ' Grabar estado de la ficha
                        Dim est As New dEstados
                        est.FICHA = idficha
                        est.ESTADO = 8
                        est.FECHA = fecenv
                        est.guardar2()
                        est = Nothing
                        '****************************
                    End If
                Next
            End If
        End If
        cargarfichasparasubir()
        cargarfichassubidas()
    End Sub
    Private Sub enviocopia()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim enviarcopia As String = ""
        Dim fichero As String = ""
        Dim tipo As String = ""
        enviarcopia = enviar_copia
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".xls"
            tipo = "Control lechero"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".xls"
            tipo = "Agua"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            tipo = "Antibiograma"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".xls"
            tipo = "PAL"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".xls"
            tipo = "Parasitología"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".xls"
            tipo = "Alimentos"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".xls"
            tipo = "Serología"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".xls"
            tipo = "Patología"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".xls"
            tipo = "Calidad de leche"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".xls"
            tipo = "Prueba ambiental"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".xls"
            tipo = "Lactómetros"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".xls"
            tipo = "Nutrición"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".xls"
            tipo = "Suelos"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".xls"
            tipo = "Brucelosis en leche"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".xls"
            tipo = "Otros"
        End If
        If enviarcopia <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
            _SMTP.Host = "170.249.199.66"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            _Message.[To].Add(enviarcopia)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
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
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy.uy/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".xls"
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
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".pdf"
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
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".txt"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".txt"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".txt"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".txt"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".txt"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".txt"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".txt"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".txt"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".txt"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".txt"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".txt"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".txt"
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
        Dim pass As String = "NUEVA**!!COL22"
        'Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/1"
        If tipoinforme = 1 Then
            crea_control_lechero_com()
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            crea_agua_com()
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            crea_antibiograma_com()
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            crea_parasitologia_com()
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            crea_productos_subproductos_com()
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            crea_serologia_com()
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            crea_patologia_com()
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            crea_calidad_de_leche_com()
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            crea_ambiental_com()
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            crea_agro_nutricion_com()
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            crea_brucelosis_leche_com()
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            crea_otros_servicios_com()
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".xls"
        End If
        Dim infoFichero As New FileInfo(fichero)
        Dim uri As String
        uri = destino
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
    Public Function subirFicheroXls_otrapc() As String
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        'Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/1"
        If tipoinforme = 1 Then
            crea_control_lechero_com()
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            crea_agua_com()
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            crea_antibiograma_com()
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            crea_parasitologia_com()
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            crea_productos_subproductos_com()
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            crea_serologia_com()
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            crea_patologia_com()
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            crea_calidad_de_leche_com()
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            crea_ambiental_com()
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 12 Then

            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            crea_agro_nutricion_com()
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            crea_brucelosis_leche_com()
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            crea_otros_servicios_com()
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".xls"
        End If
        Dim infoFichero As New FileInfo(fichero)
        Dim uri As String
        uri = destino
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
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".pdf"
        End If
        Dim infoFichero As New FileInfo(fichero)
        Dim uri As String
        uri = destino
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
        'peticionFTP.ContentLength = infoFichero.Length
        '**********************************************************************
        Try
            peticionFTP.ContentLength = infoFichero.Length
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
        '**********************************************************************
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
    Public Function subirFicheroPdf_otrapc() As String
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".pdf"
        End If
        Dim infoFichero As New FileInfo(fichero)
        Dim uri As String
        uri = destino
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
        'peticionFTP.ContentLength = infoFichero.Length
        '**********************************************************************
        Try
            peticionFTP.ContentLength = infoFichero.Length
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
        '**********************************************************************
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
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".txt"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
        End If
        Dim infoFichero As New FileInfo(fichero)
        Dim uri As String
        uri = destino
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
    Public Function subirFicheroCsv_otrapc() As String
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            'fichero = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".txt"
            fichero = "\\ROBOT\\INFORMES PARA SUBIR\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
        End If
        Dim infoFichero As New FileInfo(fichero)
        Dim uri As String
        uri = destino
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
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".txt"
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".txt"
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".txt"
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".txt"
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
        ElseIf tipoinforme = 7 Then 'SI EL TIPO DE INFORME ES DE ALIMENTOS E INDICADORES
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".txt"
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".txt"
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".txt"
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
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
            'Dim path_csv As String = ""
            'path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".txt"
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".txt"
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".txt"
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
        ElseIf tipoinforme = 13 Then 'SI EL TIPO DE INFORME ES DE NUTRICIÓN
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".txt"
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
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then 'SI EL TIPO DE INFORME ES DE SUELOS
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".txt"
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
        ElseIf tipoinforme = 15 Then 'SI EL TIPO DE INFORME ES DE BRUCELOSIS EN LECHE
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".txt"
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
            path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".xls"
            Dim path_pdf As String = ""
            path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".pdf"
            Dim path_csv As String = ""
            path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".txt"
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
        Dim p As New dCliente
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
        Dim texto As String = ""
        texto = "Nos es grato comunicarle que el informe Nº " & " " & nficha & " - " & tipo_analisis & " (" & nombre_productor & ")," & "se encuentra disponible en la web/app de Colaveco." & vbCrLf _
            & "Para poder acceder a los resultados debe ir a www.colaveco.com.uy/gestor y digitar su usuario y contraseña." & vbCrLf _
            & "Sino cuenta con usuario y contraseña, favor solicitarla en administración al correo electrónico colaveco@gmail.com o al teléfono 4554 5311." & vbCrLf _
            & "Agradecemos su confianza y quedamos a sus órdenes." & vbCrLf & vbCrLf _
            & "Sin mas, saluda muy atte." & vbCrLf & vbCrLf _
            & "Administración - COLAVECO"
        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
            _SMTP.Host = "170.249.199.66"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com.uy")
            Try
                _Message.[To].Add(email)
                _Message.[To].Add("envios@colaveco.com.uy")
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Informe" & " Nº " & nficha & " - Colaveco"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = texto
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
        Dim p As New dCliente
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
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
            _SMTP.Host = "170.249.199.66"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com.uy")
            _Message.[To].Add(sms)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "El informe Nº " & " " & nficha & " - " & tipo_analisis & " (" & nombre_productor & ")," & "se ha subido a la web/app. Gracias."
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            '_Message.Body = "Colaveco ha publicado un informe. Ingrese al sitio http://www.colaveco.com.uy/gestor"
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
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
            _SMTP.Host = "170.249.199.66"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com.uy")
            _Message.[To].Add(email)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Colaveco - Brucelosis en leche"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "Adjuntamos informe de Brucelsois en leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & archivo & ".xls" 'archivo que se quiere adjuntar ‘
            Dim _File As String = ""
            If nombre_pc = "ROBOT" Then
                _File = "C:\INFORMES PARA SUBIR\" & archivo & ".pdf" 'archivo que se quiere adjuntar ‘
            Else
                _File = "\\ROBOT\\INFORMES PARA SUBIR\" & archivo & ".pdf" 'archivo que se quiere adjuntar ‘
            End If
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        email = "decano@fvet.edu.uy"
        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
            _SMTP.Host = "170.249.199.66"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com.uy")
            _Message.[To].Add(email)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Colaveco - Brucelosis en leche"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "Adjuntamos informe de Brucelsois en leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & archivo & ".xls" 'archivo que se quiere adjuntar ‘
            Dim _File As String = ""
            If nombre_pc = "ROBOT" Then
                _File = "C:\INFORMES PARA SUBIR\" & archivo & ".pdf" 'archivo que se quiere adjuntar ‘
            Else
                _File = "\\ROBOT\\INFORMES PARA SUBIR\" & archivo & ".pdf" 'archivo que se quiere adjuntar ‘
            End If
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
    End Sub
    Public Sub crea_brucelosis_leche_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/brucelosis_leche/"
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
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/agro_suelos/"
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
    Public Sub crea_control_lechero_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/control_lechero/"
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
    Public Sub crea_agua_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/agua/"
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
    Public Sub crea_antibiograma_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/antibiograma/"
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
    Public Sub crea_parasitologia_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/parasitologia/"
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
    Public Sub crea_productos_subproductos_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/productos_subproductos/"
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
    Public Sub crea_serologia_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/serologia/"
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
    Public Sub crea_patologia_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/patologia/"
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
    Public Sub crea_calidad_de_leche_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/calidad_de_leche/"
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
    Public Sub crea_ambiental_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/ambiental/"
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
    Public Sub crea_agro_nutricion_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/agro_nutricion/"
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
    Public Sub crea_otros_servicios_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/otros_servicios/"
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
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 1 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 3 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 4 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 7 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 15 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub moverexcel_otrapc()
        If tipoinforme = 10 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 1 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 3 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 4 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 7 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 15 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".xls"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub moverpdf()
        If tipoinforme = 10 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 1 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 3 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 4 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 7 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 15 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub moverpdf_otrapc()
        If tipoinforme = 10 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 1 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 3 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 4 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 7 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        ElseIf tipoinforme = 15 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".pdf"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub movertxt()
        If tipoinforme = 1 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".txt"
            Dim sArchivoOrigen As String = "C:\INFORMES PARA SUBIR\" & idficha & ".txt"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".txt"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub movertxt_otrapc()
        If tipoinforme = 1 Then
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & idficha & ".txt"
            Dim sArchivoOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".txt"
            Dim sRutaDestino As String = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".txt"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                'MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        subir_informes2()
    End Sub
    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        subir_informes2()
    End Sub
    Private Sub SubirInformesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubirInformesToolStripMenuItem2.Click
        subir_informes_control()
        subir_informes_agua()
        subir_informes_atb()
        subir_informes_subproductos()
        subir_informes_calidad()
        subir_informes_brucelosis()
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
                                ibc.FICHA = csm.FICHA
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
                                psi.FICHA = csm.FICHA
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
                                esp.FICHA = csm.FICHA
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
                                inh.FICHA = csm.FICHA
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
                            If csm.AFLATOXINA = 1 Then
                                Dim ml As New dMicotoxinasLeche
                                ml.FICHA = csm.FICHA
                                ml.MUESTRA = csm.MUESTRA
                                ml = ml.buscarxfichaxmuestra
                                If Not ml Is Nothing Then
                                Else
                                    creapreinformecalidad = 0
                                    Exit For
                                End If
                                ml = Nothing
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
                    ElseIf pi.TIPO = 6 Then
                        DataGridViewParaSubir(columna, fila).Value = "Parasitología"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 7 Then
                        DataGridViewParaSubir(columna, fila).Value = "Alimentos"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 10 Then
                        DataGridViewParaSubir(columna, fila).Value = "Calidad"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 11 Then
                        DataGridViewParaSubir(columna, fila).Value = "Ambiental"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 13 Then
                        DataGridViewParaSubir(columna, fila).Value = "Nutrición"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 14 Then
                        DataGridViewParaSubir(columna, fila).Value = "Suelos"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 15 Then
                        DataGridViewParaSubir(columna, fila).Value = "Brucelosis"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 16 Then
                        DataGridViewParaSubir(columna, fila).Value = "Efluentes"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 17 Then
                        DataGridViewParaSubir(columna, fila).Value = "Bact. Tanque"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 18 Then
                        DataGridViewParaSubir(columna, fila).Value = "Bact. clínica aer."
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 19 Then
                        DataGridViewParaSubir(columna, fila).Value = "Foliares"
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 20 Then
                        DataGridViewParaSubir(columna, fila).Value = "Toxicología"
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
                    DataGridViewSubidas(columna, fila).Style.BackColor = Color.SkyBlue
                    columna = columna + 1
                    DataGridViewSubidas(columna, fila).Value = pi.FICHA
                    DataGridViewSubidas(columna, fila).Style.BackColor = Color.SkyBlue
                    columna = columna + 1
                    DataGridViewSubidas(columna, fila).Value = pi.FECHA
                    DataGridViewSubidas(columna, fila).Style.BackColor = Color.SkyBlue
                    columna = columna + 1
                    If pi.TIPO = 1 Then
                        DataGridViewSubidas(columna, fila).Value = "Control"
                        DataGridViewSubidas(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 3 Then
                        DataGridViewSubidas(columna, fila).Value = "Agua"
                        DataGridViewSubidas(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 4 Then
                        DataGridViewSubidas(columna, fila).Value = "ATB"
                        DataGridViewSubidas(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 7 Then
                        DataGridViewSubidas(columna, fila).Value = "Alimentos"
                        DataGridViewSubidas(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 10 Then
                        DataGridViewSubidas(columna, fila).Value = "Calidad"
                        DataGridViewSubidas(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 15 Then
                        DataGridViewSubidas(columna, fila).Value = "Brucelosis"
                        DataGridViewSubidas(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = 0
                        fila = fila + 1
                    ElseIf pi.TIPO = 16 Then
                        DataGridViewSubidas(columna, fila).Value = "Efluentes"
                        DataGridViewSubidas(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridViewSubidas(columna, fila).Value = ""
                        DataGridViewSubidas(columna, fila).Style.BackColor = Color.SkyBlue
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
        Dim El_Ping As Boolean
        Dim eco As New System.Net.NetworkInformation.Ping
        Dim res As System.Net.NetworkInformation.PingReply
        Dim ip As Net.IPAddress
        ip = Net.IPAddress.Parse("192.168.1.50")
        res = eco.Send(ip)
        If res.Status = System.Net.NetworkInformation.IPStatus.Success Then
            El_Ping = (My.Computer.Network.Ping("ibc1123"))
        End If
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
                            Replace(muestra, Chr(34), "")
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
        Dim v As New FormRosaBengalaMarca(Sesion.Usuario)
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
    Private Sub EstadísticasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormEstadisticaCompras(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub RGLAB31ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGLAB31ToolStripMenuItem.Click
        Dim v As New FormRgLab31(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub RGLAB51ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGLAB51ToolStripMenuItem.Click
        Dim v As New FormRgLab51_carga(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub RGLAB51informesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGLAB51informesToolStripMenuItem.Click
        Dim v As New FormRgLab51()
        v.Show()
    End Sub
    Private Sub RGLAB58informesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGLAB58informesToolStripMenuItem.Click
        Dim v As New FormRgLab58()
        v.Show()
    End Sub
    Private Sub RGLAB101cargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGLAB101cargaToolStripMenuItem.Click
        Dim v As New FormRgLab101(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub RGLAB88PlanillaDiariaDeAnálisisCrióscopoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGLAB88PlanillaDiariaDeAnálisisCrióscopoToolStripMenuItem.Click
        Dim v As New FormRgLab88(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub ReproducibilidadPanelDeControlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReproducibilidadPanelDeControlToolStripMenuItem.Click
        Dim v As New FormReproducibilidad(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub RGLAB89ControToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGLAB89ControToolStripMenuItem.Click
        Dim v As New FormRgLab89(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub SolucionesDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolucionesDeTrabajoToolStripMenuItem.Click
        Dim v As New FormSolucionTrabajo(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub buscarinformes()
        Dim _hora As String = ""
        Dim hora As Integer = 0
        Dim minuto As Integer = 0
        _hora = Now.ToString("HH:mm")
        hora = Mid(_hora, 1, 2)
        minuto = Mid(_hora, 4, 2)
        If hora = 8 And minuto < 30 Then
            buscarinformesfq()
        End If
    End Sub
    Private Sub buscarinformesfq()
        Dim pi As New dPreinformes
        Dim fechadesde As Date = Now
        Dim fechahasta As Date = Now
        Dim fechad As String
        Dim fechah As String
        fechad = Format(fechadesde, "yyyy-MM-dd")
        fechah = Format(fechahasta, "yyyy-MM-dd")
        Dim lcontrol As New ArrayList
        Dim lcalidad As New ArrayList
        Dim ficha As Long = 0
        Dim fecha As Date = Now
        Dim tipo As Integer = 0
        Dim resultado As Integer = 0
        Dim coincide As Integer = 0
        Dim observaciones As String = ""
        Dim controlador As Integer = 0
        Dim controlado As Integer = 0
        lcontrol = pi.listarsincontrolclechero(fechad, fechah)
        lcalidad = pi.listarsincontrolcalidad(fechad, fechah)
        '*** CONTROL ***********************************************************************
        If Not lcontrol Is Nothing Then
            If lcontrol.Count > 0 Then
                Dim ci As New dControlInformesFQ
                For Each pi In lcontrol
                    ci.FECHACONTROL = fechad
                    ci.FICHA = pi.FICHA
                    ci.FECHA = fechad
                    ci.TIPO = pi.TIPO
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = 100
                    ci.CONTROLADO = 0
                    ci.guardar()
                Next
            End If
        End If
        '*** CALIDAD ***********************************************************************
        If Not lcalidad Is Nothing Then
            If lcalidad.Count > 0 Then
                Dim ci As New dControlInformesFQ
                For Each pi In lcalidad
                    ci.FECHACONTROL = fechad
                    ci.FICHA = pi.FICHA
                    ci.FECHA = fechad
                    ci.TIPO = pi.TIPO
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = 100
                    ci.CONTROLADO = 0
                    ci.guardar()
                Next
            End If
        End If
    End Sub
    Private Sub buscarinformesmicro()
        Dim pi As New dPreinformes
        Dim fechadesde As Date = Now
        Dim fechahasta As Date = Now
        Dim fechad As String
        Dim fechah As String
        fechad = Format(fechadesde, "yyyy-MM-dd")
        fechah = Format(fechahasta, "yyyy-MM-dd")
        Dim lcalidad As New ArrayList
        Dim lagua As New ArrayList
        Dim lsubproductos As New ArrayList
        Dim ficha As Long = 0
        Dim fecha As Date = Now
        Dim tipo As Integer = 0
        Dim resultado As Integer = 0
        Dim coincide As Integer = 0
        Dim observaciones As String = ""
        Dim controlador As Integer = 0
        Dim controlado As Integer = 0
        lcalidad = pi.listarsincontrolcalidad(fechad, fechah)
        lagua = pi.listarsincontrolagua(fechad, fechah)
        lsubproductos = pi.listarsincontrolsubproductos(fechad, fechah)
        '*** CALIDAD ***********************************************************************
        If Not lcalidad Is Nothing Then
            If lcalidad.Count > 0 Then
                Dim ci As New dControlInformesFQ
                For Each pi In lcalidad
                    ci.FECHACONTROL = fechad
                    ci.FICHA = pi.FICHA
                    ci.FECHA = fechad
                    ci.TIPO = pi.TIPO
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = 100
                    ci.CONTROLADO = 0
                    ci.guardar()
                Next
            End If
        End If
        '*** AGUA ***********************************************************************
        If Not lagua Is Nothing Then
            If lagua.Count > 0 Then
                Dim ci As New dControlInformesMicro
                For Each pi In lagua
                    ci.FECHACONTROL = fechad
                    ci.FICHA = pi.FICHA
                    ci.FECHA = fechad
                    ci.TIPO = pi.TIPO
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = 100
                    ci.CONTROLADO = 0
                    ci.guardar()
                Next
            End If
        End If
        '*** Alimentos ***********************************************************************
        If Not lsubproductos Is Nothing Then
            If lsubproductos.Count > 0 Then
                Dim ci As New dControlInformesMicro
                For Each pi In lsubproductos
                    ci.FECHACONTROL = fechad
                    ci.FICHA = pi.FICHA
                    ci.FECHA = fechad
                    ci.TIPO = pi.TIPO
                    ci.RESULTADO = 0
                    ci.COINCIDE = 0
                    ci.OBSERVACIONES = ""
                    ci.CONTROLADOR = 100
                    ci.CONTROLADO = 0
                    ci.guardar()
                Next
            End If
        End If
    End Sub
    Private Sub ComtrolDeInformesFQToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub BuscarInformesFQMicroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarInformesFQMicroToolStripMenuItem.Click
        buscarinformesfq()
        buscarinformesmicro()
    End Sub
    Private Sub ControlDeInformesMicroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub SolucionesDeTrabajoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolucionesDeTrabajoToolStripMenuItem1.Click
        Dim v As New FormBajaSoluciones(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub SolicitudesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitudesToolStripMenuItem.Click
        Dim v As New FormVerSolicitudes_IT(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub InformesSinVisualizaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformesSinVisualizaciónToolStripMenuItem.Click
        Dim v As New FormSinVisualizacion(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub CMIToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormCMI(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub ComunicacionesTécnicasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComunicacionesTécnicasToolStripMenuItem.Click
        Dim v As New FormComunicacionTecnica(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub enviarcompras()
        Dim c As New dCompras
        Dim lista As New ArrayList
        lista = c.listarsinenviar
        If Not lista Is Nothing Then
            For Each c In lista
                compraid = c.ID
                enviaremailcompras()
            Next
        End If
    End Sub
    Private Sub enviaremailcompras()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim email As String = ""
        Dim destinatario As String = ""
        Dim c As New dCompras
        c.ID = compraid
        c = c.buscar
        If Not c Is Nothing Then
            If c.EMAIL <> "" Then
                email = Trim(c.EMAIL)
            End If
            Dim p As New dProveedores
            p.ID = c.PROVEEDOR
            p = p.buscar
            If Not p Is Nothing Then
                destinatario = p.NOMBRE
            End If
        End If
        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
            _SMTP.Host = "170.249.199.66"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
            _Message.[To].Add(email)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Orden de compra" & " - " & compraid
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            _Message.Body = "Sres. de" & " " & destinatario & ", " & "por medio del presente correo adjuntamos orden de compra. Desde ya gracias. COLAVECO"
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\192.168.1.10\E\NET\COMPRAS\OC\OC_" & compraid & ".xls" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                marcarenvio()
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
                'MessageBox.Show("Falla al enviar el correo!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
            _File = ""
            _Attachment = Nothing
        Else
            MsgBox("No tiene dirección de correo cargada")
        End If
        email = ""
    End Sub
    Private Sub marcarenvio()
        Dim c As New dCompras
        c.ID = compraid
        c.marcarenviado()
    End Sub
    Private Sub cargarpedidosweb()
        Dim pw_com As New dPedidosWeb_com
        Dim fecha As Date = Now
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = pw_com.listar
        If Not lista Is Nothing Then
            For Each pw_com In lista
                Dim pw As New dPedidosWeb
                pw.FECHA = fec
                pw.CODIGO = pw_com.CODIGO
                pw.NOMBRE = pw_com.NOMBRE
                pw.DIRECCION = pw_com.DIRECCION
                pw.AGENCIA = pw_com.AGENCIA
                pw.TELEFONO = pw_com.TELEFONO
                pw.EMAIL = pw_com.EMAIL
                pw.CCONSERVANTE = pw_com.CCONSERVANTE
                pw.SCONSERVANTE = pw_com.SCONSERVANTE
                pw.AGUA = pw_com.AGUA
                pw.SANGRE = pw_com.SANGRE
                pw.OBSERVACIONES = pw_com.OBSERVACIONES
                pw.REALIZADO = 0
                pw.CANCELADO = 0
                pw.guardar()
                pw_com.eliminar()
                pw = Nothing
            Next
        End If
        listarpedidosweb()
    End Sub
    Private Sub listarpedidosweb()
        Dim pw As New dPedidosWeb
        Dim lista As New ArrayList
        lista = pw.listar
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridPedidos.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridPedidos.Rows.Add(lista.Count)
                For Each pw In lista
                    DataGridPedidos(columna, fila).Value = pw.ID
                    columna = columna + 1
                    Dim p As New dCliente
                    p.ID = pw.CODIGO
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridPedidos(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridPedidos(columna, fila).Value = "Cliente no encontrado"
                        columna = 0
                        fila = fila + 1
                    End If
                    p = Nothing
                Next
            End If
        End If
    End Sub
    Private Sub listarpedidospendientes()
        Dim p As New dPedidos
        Dim lista As New ArrayList
        lista = p.listarpendientes
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridViewPP.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridViewPP.Rows.Add(lista.Count)
                For Each p In lista
                    DataGridViewPP(columna, fila).Value = p.ID
                    columna = columna + 1
                    Dim c As New dCliente
                    c.ID = p.IDPRODUCTOR
                    c = c.buscar
                    If Not c Is Nothing Then
                        DataGridViewPP(columna, fila).Value = c.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridViewPP(columna, fila).Value = "Cliente no encontrado"
                        columna = 0
                        fila = fila + 1
                    End If
                    p = Nothing
                Next
            End If
        End If
    End Sub
    Private Sub DataGridPedidos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridPedidos.CellClick
        If DataGridPedidos.Columns(e.ColumnIndex).Name = "Cliente" Then
            Dim row As DataGridViewRow = DataGridPedidos.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim pw As New dPedidosWeb
            id = row.Cells("Id").Value
            pw.ID = id
            pw = pw.buscar
            If Not pw Is Nothing Then
                Dim v As New FormPedidoFrascosWeb(Sesion.Usuario, id)
                v.ShowDialog()
            End If
            listarpedidosweb()
        End If
    End Sub
    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        If nombre_pc = "ROBOT" Or nombre_pc = "IT" Then
            cargarpedidosweb()
            cargarsolicitudesweb()
        End If
    End Sub
    Private Sub EnviarComprasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarComprasToolStripMenuItem.Click
        Dim hoy As Date = Now
        Dim dia As Integer = 0
        dia = hoy.Day
        If dia < 27 Then
            enviarcompras()
        Else
            MsgBox("Por motivos administrativos contables, no se pueden realizar pedidos después del 26 de cada mes.")
        End If
    End Sub
    Private Sub InformesToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformesToolStripMenuItem3.Click
        Dim v As New FormComprasInformes(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub moverarchivossubidos()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim numficha As Long = 0
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\NET\Informes para subir")
        Dim folder As New DirectoryInfo("C:\INFORMES PARA SUBIR")
        Dim _ficheros() As String
        '_ficheros = Directory.GetFiles("\\192.168.1.10\E\NET\Informes para subir")
        _ficheros = Directory.GetFiles("C:\INFORMES PARA SUBIR")
        If Not (_ficheros.Length > 0) Then
        Else
            For Each file As FileInfo In folder.GetFiles("*.*")
                nombrearchivo = file.Name
                extension = Microsoft.VisualBasic.Right(file.Name, 3)
                If extension = "xls" Or extension = "pdf" Or extension = "txt" Or extension = "XLS" Or extension = "PDF" Or extension = "TXT" Then
                    numficha = Mid(file.Name, 1, Len(file.Name) - 4)
                    idficha = numficha
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = numficha
                    sa = sa.buscar
                    If Not sa Is Nothing Then
                        tipoinforme = sa.IDTIPOINFORME
                        If sa.MARCA = 1 Then
                            If extension = "xls" Or extension = "XLS" Then
                                moverexcel()
                            End If
                            If extension = "pdf" Or extension = "PDF" Then
                                moverpdf()
                            End If
                            If extension = "txt" Or extension = "TXT" Then
                                movertxt()
                            End If
                        End If
                    End If
                    sa = Nothing
                End If
            Next
        End If
    End Sub
    Private Sub MoverArchivosSubidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoverArchivosSubidosToolStripMenuItem.Click
        moverarchivossubidos()
    End Sub
    Private Sub CargarPedidosWebToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarPedidosWebToolStripMenuItem.Click
        cargarpedidosweb()
    End Sub
    Private Sub RelaciónTécnicoProductorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelaciónTécnicoProductorToolStripMenuItem.Click
        Dim v As New FormTecnicoProductor(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub MicotoxinasEnLecheToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MicotoxinasEnLecheToolStripMenuItem.Click
        Dim v As New FormMicotoxinasLeche(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub EfluentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormAgua2(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub HistorialPorCajaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistorialPorCajaToolStripMenuItem.Click
        Dim v As New FormHistorialCaja(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub HistorialPorCajaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistorialPorCajaToolStripMenuItem1.Click
        Dim v As New FormHistorialCaja(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub comprobarlicencias()
        Dim l As New dLicencias
        Dim lista As New ArrayList
        lista = l.listarsinaprobar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                MsgBox("Existen licencias sin aprobar!")
            End If
        End If
    End Sub
    Private Sub controles_ibc()
        Dim hoy As Date = Now
        Dim ano As Integer = 0
        Dim mes As Integer = 0
        Dim mes_ As String = ""
        ano = hoy.Year
        mes = hoy.Month
        Dim _mes As New dMeses
        _mes.ID = mes
        _mes = _mes.buscar
        If Not _mes Is Nothing Then
            mes_ = _mes.NOMBRE
        End If
    End Sub
    Private Sub agua(ByVal ano As Integer, ByVal mes As String)
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim ficha As String = ""
        Dim ficha2 As String = ""
        Dim ficha3 As String = "0"
        Dim fecha2 As String = ""
        '**********************************************************************************
        Dim El_Ping As Boolean
        Dim eco As New System.Net.NetworkInformation.Ping
        Dim res As System.Net.NetworkInformation.PingReply
        Dim ip As Net.IPAddress
        ip = Net.IPAddress.Parse("192.168.1.50")
        res = eco.Send(ip)
        If res.Status = System.Net.NetworkInformation.IPStatus.Success Then
            El_Ping = (My.Computer.Network.Ping("ibc1123"))
        End If
        If El_Ping = False Then
        Else
            Dim folder As New DirectoryInfo("\\Ibc1123\Agua\" & ano & "\" & mes)
            For Each file As FileInfo In folder.GetFiles("*.csv")
                nombrearchivo = file.Name
                linea = 1
                extension = Microsoft.VisualBasic.Right(file.Name, 3)
                Dim objReader2 As New StreamReader("\\Ibc1123\Agua\" & ano & "\" & mes & "\" & file.Name)
                Dim sLine As String = ""
                Dim arraytext() As String
                Dim muestra As String = ""
                Dim idibc As Integer = 0
                Dim ibc As Long = 0
                Dim rb As Integer = 0
                If extension = "csv" Or extension = "CSV" Then
                    Do
                        sLine = objReader2.ReadLine()
                        If Not sLine Is Nothing Then
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
                            fecha2 = Format(fechaoriginal, "yyyy-MM-dd")
                        End If
                        linea = linea + 1
                    Loop Until sLine Is Nothing
                    objReader2.Close()
                End If
            Next
        End If
    End Sub
    Private Sub InformeDeCajasSinDevolverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeDeCajasSinDevolverToolStripMenuItem.Click
        Dim v As New FormInformesCajas(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub cargarsolicitudesweb()
        Dim El_Ping As Boolean
        Dim eco As New System.Net.NetworkInformation.Ping
        Dim res As System.Net.NetworkInformation.PingReply
        Dim ip As Net.IPAddress
        ip = Net.IPAddress.Parse("209.62.67.162")
        res = eco.Send(ip)
        If res.Status = System.Net.NetworkInformation.IPStatus.Success Then
            El_Ping = 1
        End If
        If El_Ping = False Then
        Else
            Dim sw As New dSolicitudWeb
            Dim lista As New ArrayList
            lista = sw.listarsincargar
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sw In lista
                        Dim s As New dSolicitudAnalisis
                        s.ID = sw.FICHA
                        s = s.buscar
                        nficha = sw.FICHA
                        If Not s Is Nothing Then
                            nmuestrasweb = s.NMUESTRAS
                            Dim ti As New dTipoInforme
                            ti.ID = s.IDTIPOINFORME
                            ti = ti.buscar
                            If Not ti Is Nothing Then
                                tipoinformeweb = ti.NOMBRE
                            End If
                            Dim si As New dSubInforme
                            si.ID = s.IDSUBINFORME
                            si = si.buscar
                            If Not si Is Nothing Then
                                subtipoinformeweb = si.NOMBRE
                            End If
                            observacionesweb = s.OBSERVACIONES
                            Dim m As New dMuestras
                            m.ID = s.IDMUESTRA
                            m = m.buscar
                            If Not m Is Nothing Then
                                muestraweb = m.NOMBRE
                            End If
                            Dim p As New dCliente
                            p.ID = s.IDPRODUCTOR
                            p = p.buscar
                            If Not p Is Nothing Then
                                nombreproductorweb = p.NOMBRE
                                productorweb_com = p.USUARIO_WEB
                                Dim pw_com As New dProductorWeb_com
                                pw_com.USUARIO = productorweb_com
                                pw_com = pw_com.buscar
                                If Not pw_com Is Nothing Then
                                    idproductorweb_com = pw_com.ID
                                    email = RTrim(pw_com.ENVIAR_EMAIL)
                                    celular = Replace(pw_com.ENVIAR_SMS, " ", "")
                                    InsertarRegistro_com()
                                    sw.marcarcargado()
                                    nficha = 0
                                    email = ""
                                    email2 = ""
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        End If
    End Sub
    Private Sub InsertarRegistro_com()
        Dim tipoinformesw As String
        tipoinformesw = tipoinformeweb
        idficha = nficha
        If tipoinformesw = "Control Lechero" Then 'SI EL TIPO DE INFORME ES DE CONTROL LECHERO
            Dim cw_com As New dControlLecheroWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            cw_com.ID_USUARIO = idproductorweb_com
            cw_com.ABONADO = 0
            cw_com.FECHA_CREADO = fechaemi
            cw_com.FECHA_EMISION = fechaemi
            cw_com.FICHA = idficha
            cw_com.ID_ESTADO = 1
            cw_com.ID_LIBRO = idficha
            If (cw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Calidad de leche" Then 'SI EL TIPO DE INFORME ES DE CALIDAD DE LECHE
            Dim cw_com As New dCalidadWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            cw_com.ID_USUARIO = idproductorweb_com
            cw_com.ABONADO = 0
            cw_com.FECHA_CREADO = fechaemi
            cw_com.FECHA_EMISION = fechaemi
            cw_com.FICHA = idficha
            cw_com.ID_ESTADO = 1
            cw_com.ID_LIBRO = idficha
            If (cw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Agua" Then 'SI EL TIPO DE INFORME ES DE AGUA
            Dim aw_com As New dAguaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Parasitología" Then 'SI EL TIPO DE INFORME ES DE PARASITOLOGÍA
            Dim parw_com As New dParasitologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            parw_com.ID_USUARIO = idproductorweb_com
            parw_com.ABONADO = 0
            parw_com.FECHA_CREADO = fechaemi
            parw_com.FECHA_EMISION = fechaemi
            parw_com.FICHA = idficha
            parw_com.ID_ESTADO = 1
            parw_com.ID_LIBRO = idficha
            If (parw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Alimentos" Then 'SI EL TIPO DE INFORME ES DE ALIMENTOS E INDICADORES
            Dim spw_com As New dSubproductosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            spw_com.ID_USUARIO = idproductorweb_com
            spw_com.ABONADO = 0
            spw_com.FECHA_CREADO = fechaemi
            spw_com.FECHA_EMISION = fechaemi
            spw_com.FICHA = idficha
            spw_com.ID_ESTADO = 1
            spw_com.ID_LIBRO = idficha
            If (spw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Serología" Then 'SI EL TIPO DE INFORME ES DE SEROLOGÍA
            Dim sw_com As New dSerologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            sw_com.ID_USUARIO = idproductorweb_com
            sw_com.ABONADO = 0
            sw_com.FECHA_CREADO = fechaemi
            sw_com.FECHA_EMISION = fechaemi
            sw_com.FICHA = idficha
            sw_com.ID_ESTADO = 1
            sw_com.ID_LIBRO = idficha
            If (sw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Patología - Toxicología" Then 'SI EL TIPO DE INFORME ES DE PATOLOGÍA - TOXICOLOGÍA
            Dim paw_com As New dPatologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            paw_com.ID_USUARIO = idproductorweb_com
            paw_com.ABONADO = 0
            paw_com.FECHA_CREADO = fechaemi
            paw_com.FECHA_EMISION = fechaemi
            paw_com.FICHA = idficha
            paw_com.ID_ESTADO = 1
            paw_com.ID_LIBRO = idficha
            If (paw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Ambiental" Then 'SI EL TIPO DE INFORME ES AMBIENTAL
            Dim aw_com As New dAmbientalWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Lactómetros - Chequeos" Then 'SI EL TIPO DE INFORME ES DE LACTÓMETROS
            Dim lw_com As New dLactometrosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            lw_com.ID_USUARIO = idproductorweb_com
            lw_com.ABONADO = 0
            lw_com.FECHA_CREADO = fechaemi
            lw_com.FECHA_EMISION = fechaemi
            lw_com.FICHA = idficha
            lw_com.ID_ESTADO = 1
            lw_com.ID_LIBRO = idficha
            If (lw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Nutrición" Then 'SI EL TIPO DE INFORME ES DE NUTRICIÓN
            Dim aw_com As New dAgroNutricionWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Otros Servicios" Then 'SI EL TIPO DE INFORME ES DE OTROS SERVICIOS
            Dim osw_com As New dOtrosServiciosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            osw_com.ID_USUARIO = idproductorweb_com
            osw_com.ABONADO = 0
            osw_com.FECHA_CREADO = fechaemi
            osw_com.FECHA_EMISION = fechaemi
            osw_com.FICHA = idficha
            osw_com.ID_ESTADO = 1
            osw_com.ID_LIBRO = idficha
            If (osw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Suelos" Then 'SI EL TIPO DE INFORME ES DE SUELOS
            Dim aw_com As New dAgroSuelosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Brucelosis en leche" Then 'SI EL TIPO DE INFORME ES DE BRUCELOSIS EN LECHE
            Dim bw_com As New dBrucelosisLecheWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            bw_com.ID_USUARIO = idproductorweb_com
            bw_com.ABONADO = 0
            bw_com.FECHA_CREADO = fechaemi
            bw_com.FECHA_EMISION = fechaemi
            bw_com.FICHA = idficha
            bw_com.ID_ESTADO = 1
            bw_com.ID_LIBRO = idficha
            If (bw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinformesw = "Bacteriología y Antibiograma" Then 'SI EL TIPO DE INFORME ES DE BACTERIOLOGIA Y ANTIBIOGRAMA
            Dim aw_com As New dAntibiogramaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        enviomail_sw()
        enviosms_sw()
    End Sub
    Private Sub enviomail_sw()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        '******************************************************************************************************************************************
        Dim ficha As String = nficha
        Dim fecha As Date = DateFecha.Value
        Dim nmuestras As Integer
        nmuestras = nmuestrasweb
        Dim muestra As String = muestraweb
        Dim solicitud As String = ""
        Dim texto As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""
        Dim tipoinforme As String = tipoinformeweb
        Dim subtipoinforme As String = subtipoinformeweb
        Dim observaciones As String = observacionesweb
        Dim titulo As String = ""
        Dim enc_ficha As String = ""
        Dim enc_fecha As String = ""
        Dim enc_cliente As String = ""
        Dim enc_muestras As String = ""
        Dim enc_muestrade As String = ""
        Dim cuerpo_analisis As String = ""
        Dim cuerpo_muestras As String = ""
        Dim pie_observaciones As String = ""
        Dim pie_estadosolicitud As String = "En nuestro sitio web http://www.colaveco.com.uy/gestor, puede ver el estado de su solicitud."
        Dim nombre_productor As String = nombreproductorweb
        Dim sm As New dRelSolicitudMuestras
        Dim spal As New dSolicitudPAL
        Dim csm As New dCalidadSolicitudMuestra
        Dim cs As New dControlSolicitud
        Dim a2 As New dAntibiograma2
        Dim sn As New dSolicitudNutricion
        Dim ss As New dSolicitudSuelos
        Dim bl As New dBrucelosis
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista4 As New ArrayList
        Dim lista5 As New ArrayList
        Dim lista6 As New ArrayList
        Dim lista7 As New ArrayList
        Dim lista10 As New ArrayList
        Dim listabl As New ArrayList
        Dim listanutricion As New ArrayList
        Dim listasuelos As New ArrayList
        lista4 = sm.listarporficha(ficha)
        lista5 = csm.listarporsolicitud3(ficha)
        lista6 = cs.listarporsolicitud(ficha)
        lista7 = a2.listarporsolicitud(ficha)
        lista10 = spal.listarporsolicitud(ficha)
        listanutricion = sn.listarporsolicitud(ficha)
        listasuelos = ss.listarporsolicitud(ficha)
        listabl = sm.listarporficha(ficha)
        ' SI ES ALIMENTOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                    Next
                End If
            End If
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()
            If Not a1 Is Nothing Then
                texto = subtipoinformeweb
                If a1.HET22 = 1 Then
                    texto = texto & " " & " - Heterotróficos 22"
                End If
                If a1.HET35 = 1 Then
                    texto = texto & " " & " - Heterotróficos 35"
                End If
                If a1.HET37 = 1 Then
                    texto = texto & " " & " - Heterotróficos 37"
                End If
                If a1.CLORO = 1 Then
                    texto = texto & " " & " - Cloro"
                End If
                If a1.CONDUCTIVIDAD = 1 Then
                    texto = texto & " " & " - Conductividad"
                End If
                If a1.PH = 1 Then
                    texto = texto & " " & " - pH"
                End If
                If a1.ECOLI = 1 Then
                    texto = texto & " " & " - Ecoli"
                End If
            End If
            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                    Next
                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                    Next
                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next
                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)
            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                    Next
                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)
            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                    Next
                End If
            End If
            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                    Next
                End If
            End If
        End If
        '*** LISTADO DE MUESTRAS *********************************************************************************
        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES CALIDAD ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA
                        If csm.RB = 1 Then
                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then
                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then
                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then
                            cuenta_caseina = cuenta_caseina + 1
                        End If
                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""
            ' SI ES ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES PAL ********************************************************************************
        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            Dim solpal As New dSolicitudPAL
            solpal.FICHA = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                ' x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
            End If
            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************
        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
        End If
        '********************************************************************************************************************
        If tipoinforme = "Nutrición" Or tipoinforme = "Suelos" Then
            If email <> "" Then
                'CONFIGURACIÓN DEL STMP 
                _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
                _SMTP.Host = "170.249.199.66"
                _SMTP.Port = 25
                _SMTP.EnableSsl = False

                ' CONFIGURACION DEL MENSAJE 
                _Message.[To].Add(LTrim(email))
                _Message.[To].Add(LTrim("envios@colaveco.com.uy"))
                'Cuenta de Correo al que se le quiere enviar el e-mail 
                _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
                'Quien lo envía 
                _Message.Subject = "Solicitud de análisis"
                'Sujeto del e-mail 
                _Message.SubjectEncoding = System.Text.Encoding.UTF8
                'Codificacion 
                _Message.Body = "Ha ingresado una solicitud con el número" & " " & ficha & vbCrLf _
                & "Fecha de recepción: " & fecha & "." & vbCrLf _
                & "A nombre de: " & nombre_productor & "." & vbCrLf _
                & "Muestras ingresadas: " & nmuestras & "." & vbCrLf _
                & "Tipo de muestra: " & muestraweb & "." & vbCrLf _
                & "Análisis requerido: " & tipoinforme & "." & vbCrLf _
                & "Subtipo: " & subtipoinforme & "." & vbCrLf _
                & vbCrLf _
                & texto & vbCrLf _
                & vbCrLf _
                & "Observaciones:" & vbCrLf _
                & observaciones & vbCrLf _
                & vbCrLf _
                & "En nuestro sitio web, http://www.colaveco.com.uy/gestor, puede ver el estado de su solicitud." & vbCrLf _
                & "Gracias." & vbCrLf _
                & "COLAVECO"
                'contenido del mail 
                _Message.BodyEncoding = System.Text.Encoding.UTF8 '
                _Message.Priority = System.Net.Mail.MailPriority.Normal
                _Message.IsBodyHtml = False
                ' ADICION DE DATOS ADJUNTOS ‘
                Try
                    _SMTP.Send(_Message)
                Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
                End Try
            End If
            email = ""
            nficha = 0
        Else
            If email <> "" Then
                'CONFIGURACIÓN DEL STMP 
                _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
                _SMTP.Host = "170.249.199.66"
                _SMTP.Port = 25
                _SMTP.EnableSsl = False

                ' CONFIGURACION DEL MENSAJE 
                _Message.[To].Add(LTrim(email))
                _Message.[To].Add(LTrim("envios@colaveco.com.uy"))
                'Cuenta de Correo al que se le quiere enviar el e-mail 
                _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
                'Quien lo envía 
                _Message.Subject = "Solicitud de análisis"
                'Sujeto del e-mail 
                _Message.SubjectEncoding = System.Text.Encoding.UTF8
                'Codificacion 
                _Message.Body = "Ha ingresado una solicitud con el número" & " " & ficha & vbCrLf _
                & "Fecha/Hora de recepción: " & fecha & "." & vbCrLf _
                & "A nombre de: " & nombre_productor & "." & vbCrLf _
                & "Muestras ingresadas: " & nmuestras & "." & vbCrLf _
                & "Tipo de muestra: " & muestraweb & "." & vbCrLf _
                & "Análisis requerido: " & tipoinforme & "." & vbCrLf _
                & "Subtipo: " & subtipoinforme & "." & vbCrLf _
                & vbCrLf _
                & texto & vbCrLf _
                & vbCrLf _
                & "Identificación de las muestras:" & vbCrLf _
                & texto2 & vbCrLf _
                & vbCrLf _
                & "Observaciones:" & vbCrLf _
                & observaciones & vbCrLf _
                & vbCrLf _
                & "En nuestro sitio web, http://www.colaveco.com.uy/gestor, puede ver el estado de su solicitud." & vbCrLf _
                & "Gracias." & vbCrLf & vbCrLf _
                & "COLAVECO" & vbCrLf _
                & "Parque El Retiro - Nueva Helvecia - Tel/Fax: 45545311/45545975/45546838" & vbCrLf _
                & "Email: colaveco@gmail.com - web: http://www.colaveco.com.uy" & vbCrLf & vbCrLf _
                & "-------------------------------------------------------------------------------------" & vbCrLf _
                & "Cuando el cliente solicite suspender el servicio ya presupuestado y en ejecución, o una parte del mismo," & vbCrLf _
                & "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse."
                'contenido del mail 
                _Message.BodyEncoding = System.Text.Encoding.UTF8 '
                _Message.Priority = System.Net.Mail.MailPriority.Normal
                _Message.IsBodyHtml = False
                ' ADICION DE DATOS ADJUNTOS ‘
                Try
                    _SMTP.Send(_Message)
                Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
                End Try
            End If
        End If
    End Sub
    Private Sub enviosms_sw()
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
        Dim posicion As Integer
        Dim posicion1 As Integer
        Dim posicion2 As Integer
        posicion = InStr(celular, ",")
        If posicion > 0 Then
            posicion1 = posicion - 1
            posicion2 = posicion + 1
            cel1 = Mid(celular, 1, posicion1)
            cel2 = Mid(celular, posicion2, largotexto)
            celular1 = cel1
            email = celular1
            num1 = Mid(celular1, 3, 1)
            If num1 = "9" Or num1 = "8" Or num1 = "1" Or num1 = "2" Then
                'ancel es numero  + pin
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
            celular2 = cel2
            email2 = celular2
            num2 = Mid(celular2, 1, 1)
            If num2 = "9" Or num2 = "8" Or num2 = "1" Or num2 = "2" Then
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
            celular2 = celular
            email = celular2
            num1 = Mid(celular2, 1, 1)
            If num1 = "9" Or num1 = "8" Or num1 = "1" Or num1 = "2" Then
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
        Dim p As New dCliente
        Dim ti As New dTipoInforme
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
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
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
            _SMTP.Host = "170.249.199.66"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            _Message.[To].Add(sms)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Su solicitud de análisis Nº " & " " & nficha & " - " & tipo_analisis & " (" & nombre_productor & ")," & "ha ingresado correctamente al sistema. Gracias. COLAVECO"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
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
    Private Sub CargarSolicitudesWebToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarSolicitudesWebToolStripMenuItem.Click
        cargarsolicitudesweb()
    End Sub
    Private Sub CajasToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CajasToolStripMenuItem.Click
        Dim v As New FormCajas(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub chequear_productores()
        Dim pwf As New dProductorWeb_Florida
        Dim lista As New ArrayList
    End Sub
    Private Sub DesmarcarFichaParaVolverAGenerarInformeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesmarcarFichaParaVolverAGenerarInformeToolStripMenuItem.Click
        Dim v As New FormDesmarcarInformes(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub ListadoDeCajasYConservadorasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeCajasYConservadorasToolStripMenuItem.Click
        exportar()
    End Sub
    Private Sub exportar()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(2)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)
        x1hoja.Cells(1, 1).columnwidth = 15
        x1hoja.Cells(1, 2).columnwidth = 15
        x1hoja.Cells(1, 3).columnwidth = 50
        Dim c As New dCajas
        Dim lista As New ArrayList
        lista = c.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                x1hoja.Cells(fila, columna).formula = "LISTADO DE CAJAS"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
                x1hoja.Cells(fila, columna).formula = "Código"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Ubicación"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Cliente"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                fila = fila + 1
                columna = 1
                For Each c In lista
                    x1hoja.Cells(fila, columna).formula = c.CODIGO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    If c.ESTADO = 1 Then
                        x1hoja.Cells(fila, columna).formula = "Laboratorio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    ElseIf c.ESTADO = 2 Then
                        x1hoja.Cells(fila, columna).formula = "Cliente"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        Dim ec As New dEnvioCajas
                        Dim caja As String = c.CODIGO
                        Dim listaenvio As New ArrayList
                        listaenvio = ec.listarultimoenvio(caja)
                        If Not listaenvio Is Nothing Then
                            For Each ec In listaenvio
                                Dim p As New dCliente
                                p.ID = ec.IDPRODUCTOR
                                p = p.buscar
                                If Not p Is Nothing Then
                                    x1hoja.Cells(fila, columna).formula = p.NOMBRE
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    p = Nothing
                                End If
                            Next
                            ec = Nothing
                            listaenvio = Nothing
                        End If
                        columna = 1
                        fila = fila + 1
                    ElseIf c.ESTADO = 3 Then
                        x1hoja.Cells(fila, columna).formula = "Florida"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "Desaparecida"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If
                Next
            End If
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub HistorialDePedidosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistorialDePedidosToolStripMenuItem.Click
        Dim v As New FormBuscarPedidos(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub ControlDeInformesnutriciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub ControlDeInformessuelosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub AutorizacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutorizacionesToolStripMenuItem.Click
        Dim v As New FormAutorizaciones(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub ClientesnoUsarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesnoUsarToolStripMenuItem.Click
        Dim v As New FormClientes(Sesion.Usuario, idprod)
        v.Show()
    End Sub
    Private Sub NuevaSolicitudToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaSolicitudToolStripMenuItem.Click
        Dim v As New FormSolicitud(Sesion.Usuario, 0)
        v.Show()
    End Sub
    Private Sub ListaDePreciosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListaDePreciosToolStripMenuItem.Click
        Dim v As New FormListaDePrecios(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub ControlDeInformesantesDeSubirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeInformesantesDeSubirToolStripMenuItem.Click
        Dim v As New FormControldeInformesPre
        v.Show()
    End Sub
    Private Sub UsuariosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuariosToolStripMenuItem.Click
        Dim v As New FormUsuarios(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub NuevoGestorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoGestorToolStripMenuItem.Click
        Dim v As New FormGestor(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub SaldosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosToolStripMenuItem.Click
        calcularsaldos()
    End Sub
    Private Sub calcularsaldos()
        Dim s As New dSaldos
        s.eliminartodos(Sesion.Usuario)
        Dim m As New dMovCte
        Dim c As New dCliente
        Dim idcliente As Long = 0
        Dim debe As Double = 0
        Dim haber As Double = 0
        Dim saldo As Double = 0
        Dim listaclientes As New ArrayList
        Dim listamovimientos As New ArrayList
        listaclientes = c.listar
        If Not listaclientes Is Nothing Then
            For Each c In listaclientes
                idcliente = c.ID
                listamovimientos = m.saldosxcli(idcliente)
                If Not listamovimientos Is Nothing Then
                    For Each m In listamovimientos
                        If m.MCCCOD = 1 Then
                            debe = debe + m.MCCIMP
                        ElseIf m.MCCCOD = 2 Then
                            haber = haber + m.MCCIMP
                        End If
                    Next
                    saldo = debe - haber
                End If
                s.IDCLIENTE = idcliente
                s.SALDO = saldo
                saldo = 0
                debe = 0
                haber = 0
                s.guardar(Sesion.Usuario)
            Next
        End If
        subirsaldos()
    End Sub
    Private Sub subirsaldos()
        Dim s As New dSaldos
        Dim c As New dCliente
        Dim cw As New dClienteWeb_com
        Dim usuario As String = ""
        Dim saldo As Double = 0
        Dim listasaldos As New ArrayList
        listasaldos = s.listar
        If Not listasaldos Is Nothing Then
            For Each s In listasaldos
                c.ID = s.IDCLIENTE
                c = c.buscar
                If Not c Is Nothing Then
                    usuario = c.USUARIO_WEB
                End If
                saldo = s.SALDO
                cw.USUARIO = usuario
                cw.SALDO_PESOS = saldo
                cw.actualizarsaldo(Sesion.Usuario)
            Next
        End If
    End Sub
    Private Sub PaquetesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaquetesToolStripMenuItem.Click
        Dim v As New FormPaquetes(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub NuevoAnalisisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoAnalisisToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 14
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub
    Private Sub InformesToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformesToolStripMenuItem4.Click
        Dim v As New FormCrearInformes(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub SubirInformeAlGestormanualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubirInformeAlGestormanualToolStripMenuItem.Click
        Dim v As New FormSubirGestor(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub ButtonNuevaSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevaSolicitud.Click
        Dim v As New FormSolicitud(Sesion.Usuario, 0)
        v.Show()
    End Sub
    Private Sub SuelosNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuelosNuevoToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 14
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub
    Private Sub CrearInformesNUEVOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrearInformesNUEVOToolStripMenuItem.Click
        Dim v As New FormCrearInformes(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub EnvíoDeNotificacionesAClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvíoDeNotificacionesAClientesToolStripMenuItem.Click
        Dim v As New FormNotificaciones
        v.Show()
    End Sub
    Private Sub GraficaRCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraficaRCToolStripMenuItem.Click
        Dim v As New FormGraficasRC(0)
        v.Show()
    End Sub
    Private Sub cargarAutorizaciones()
        Dim fecha As Date = Now
        Dim fec As String = Format(fecha, "yyyy-MM-dd")
        Dim fechadesde As Date = Now
        Dim fechahasta As Date = Now
        Dim dia As Integer = Now.DayOfWeek
        If dia = 1 Then
            fechadesde = Now
            fechahasta = Now.AddDays(5)
        ElseIf dia = 2 Then
            fechadesde = Now.AddDays(-1)
            fechahasta = Now.AddDays(4)
        ElseIf dia = 3 Then
            fechadesde = Now.AddDays(-2)
            fechahasta = Now.AddDays(3)
        ElseIf dia = 4 Then
            fechadesde = Now.AddDays(-3)
            fechahasta = Now.AddDays(2)
        ElseIf dia = 5 Then
            fechadesde = Now.AddDays(-4)
            fechahasta = Now.AddDays(1)
        ElseIf dia = 6 Then
            fechadesde = Now.AddDays(-5)
            fechahasta = Now
        ElseIf dia = 7 Then
            fechadesde = Now.AddDays(-6)
            fechahasta = Now.AddDays(-1)
        End If
        Dim fecdesde As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechasta As String = Format(fechahasta, "yyyy-MM-dd")
        DataGridAutorizaciones.Rows.Clear()
        Dim a As New dAutorizaciones
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = a.listarsemana(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridAutorizaciones.Rows.Clear()
                DataGridAutorizaciones.Rows.Add(lista.Count)
                For Each a In lista
                    If a.AUTORIZADA = 0 Then
                        DataGridAutorizaciones(columna, fila).Value = a.ID
                        columna = columna + 1
                        DataGridAutorizaciones(columna, fila).Value = a.FECHAEVENTO
                        DataGridAutorizaciones(columna, fila).Style.BackColor = Color.Yellow
                        DataGridAutorizaciones(columna, fila).Style.ForeColor = Color.Black
                        columna = columna + 1
                        Dim u As New dUsuario
                        u.ID = a.IDUSUARIO
                        u = u.buscar
                        DataGridAutorizaciones(columna, fila).Value = u.NOMBRE
                        DataGridAutorizaciones(columna, fila).Style.BackColor = Color.Yellow
                        DataGridAutorizaciones(columna, fila).Style.ForeColor = Color.Black
                        columna = columna + 1
                        Dim t As New dTipoAutorizacion
                        t.ID = a.TIPO
                        t = t.buscar
                        DataGridAutorizaciones(columna, fila).Value = t.NOMBRE
                        DataGridAutorizaciones(columna, fila).Style.BackColor = Color.Yellow
                        DataGridAutorizaciones(columna, fila).Style.ForeColor = Color.Black
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridAutorizaciones(columna, fila).Value = a.ID
                        columna = columna + 1
                        DataGridAutorizaciones(columna, fila).Value = a.FECHAEVENTO
                        DataGridAutorizaciones(columna, fila).Style.BackColor = Color.Green
                        DataGridAutorizaciones(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        Dim u As New dUsuario
                        u.ID = a.IDUSUARIO
                        u = u.buscar
                        DataGridAutorizaciones(columna, fila).Value = u.NOMBRE
                        DataGridAutorizaciones(columna, fila).Style.BackColor = Color.Green
                        DataGridAutorizaciones(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        Dim t As New dTipoAutorizacion
                        t.ID = a.TIPO
                        t = t.buscar
                        DataGridAutorizaciones(columna, fila).Value = t.NOMBRE
                        DataGridAutorizaciones(columna, fila).Style.BackColor = Color.Green
                        DataGridAutorizaciones(columna, fila).Style.ForeColor = Color.White
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub cargarNotificaciones()
        Dim fecha As Date = Now
        Dim fec As String = Format(fecha, "yyyy-MM-dd")
        Dim fechadesde As Date = Now
        Dim fechahasta As Date = Now
        Dim dia As Integer = Now.DayOfWeek
        If dia = 1 Then
            fechadesde = Now
            fechahasta = Now.AddDays(5)
        ElseIf dia = 2 Then
            fechadesde = Now.AddDays(-1)
            fechahasta = Now.AddDays(4)
        ElseIf dia = 3 Then
            fechadesde = Now.AddDays(-2)
            fechahasta = Now.AddDays(3)
        ElseIf dia = 4 Then
            fechadesde = Now.AddDays(-3)
            fechahasta = Now.AddDays(2)
        ElseIf dia = 5 Then
            fechadesde = Now.AddDays(-4)
            fechahasta = Now.AddDays(1)
        ElseIf dia = 6 Then
            fechadesde = Now.AddDays(-5)
            fechahasta = Now
        ElseIf dia = 7 Then
            fechadesde = Now.AddDays(-6)
            fechahasta = Now.AddDays(-1)
        End If
        Dim fecdesde As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechasta As String = Format(fechahasta, "yyyy-MM-dd")
        DataGridNotificaciones.Rows.Clear()
        Dim n As New dNotificaciones_reloj
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = n.listarsemana(fecdesde, fechasta)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridNotificaciones.Rows.Clear()
                DataGridNotificaciones.Rows.Add(lista.Count)
                For Each n In lista
                    DataGridNotificaciones(columna, fila).Value = n.ID
                    columna = columna + 1
                    DataGridNotificaciones(columna, fila).Value = n.FECHAEVENTO
                    columna = columna + 1
                    Dim u As New dUsuario
                    u.ID = n.IDUSUARIO
                    u = u.buscar
                    DataGridNotificaciones(columna, fila).Value = u.USUARIO
                    columna = columna + 1
                    DataGridNotificaciones(columna, fila).Value = n.DETALLE
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Private Sub NotificacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotificacionesToolStripMenuItem.Click
        Dim v As New FormNotificacionesReloj
        v.Show()
    End Sub
    Private Sub RGLAB102ResumenControlesBentleyDeltaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGLAB102ResumenControlesBentleyDeltaToolStripMenuItem.Click
        Dim v As New FormControlBD2(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub ActivarPedidosAutomáticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivarPedidosAutomáticosToolStripMenuItem.Click
        Dim v As New FormPedidosAutomaticos_it(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub GestorNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GestorNuevoToolStripMenuItem.Click
        Dim v As New FormGestor(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub PaquetesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormPaquetes(Sesion.Usuario)
        v.Show()
    End Sub
    Private Sub CrearTXTDeControlLecheroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrearTXTDeControlLecheroToolStripMenuItem.Click
        creartxt_manual()
    End Sub
    Private Sub creartxt_manual()
        Dim myvalue As Long = 0
        Dim idficha As Long = InputBox("Ingrese el nro de ficha", "Control lechero", myvalue)
        If idficha = 0 Then
            MessageBox.Show("Debe ingresar un nro de ficha válido")
            Return
        End If
        Dim oSW As New StreamWriter("\\ROBOT\INFORMES PARA SUBIR\" & idficha & ".txt")
        Dim c As New dControl
        Dim lista4 As New ArrayList
        lista4 = c.listarporsolicitud(idficha)
        Dim secuencial As Integer = 1
        If Not lista4 Is Nothing Then
            If lista4.Count > 0 Then
                Dim cs As New dControlSolicitud
                cs.FICHA = idficha
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

    Private Sub NutriciónNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NutriciónNuevoToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 13
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub TipoDeAnálisisTercerizadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeAnálisisTercerizadosToolStripMenuItem.Click
        Dim v As New FormAnalisisTercerizadoTipo(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub AlimentosNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlimentosNuevoToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 7
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub PaquetesDeAnálisisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaquetesDeAnálisisToolStripMenuItem.Click
        Dim v As New FormPaquetes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub OtrosLaboratoriosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtrosLaboratoriosToolStripMenuItem.Click
        Dim v As New FormOtrosLaboratorios(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CrearTXTDeCalidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrearTXTDeCalidadToolStripMenuItem.Click
        Dim myvalue As Long = 0
        Dim idficha As Long = InputBox("Ingrese el nro de ficha", "Calidad de leche", myvalue)
        If idficha = 0 Then
            MessageBox.Show("Debe ingresar un nro de ficha válido")
            Return
        End If
        Dim sa As New dSolicitudAnalisis
        sa.ID = idficha
        sa = sa.buscar
        If sa.IDPRODUCTOR = 6299 Or sa.IDPRODUCTOR = 2705 Then
            Dim oSW As New StreamWriter("\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".txt")
            Dim csm As New dCalidadSolicitudMuestra
            Dim lista As New ArrayList
            lista = csm.listarporsolicitud(idficha)
            Dim s As New dSolicitudAnalisis
            s.ID = idficha
            s = s.buscar
            Dim fecha As String = ""
            If Not s Is Nothing Then
                fecha = s.FECHAINGRESO
            End If
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    Dim Linea As String = ""
                    Linea = ""
                    For Each csm In lista
                        Dim c As New dCalidad
                        Dim finmatricula As String = ""
                        Dim matricula As String = ""
                        Dim largocadena As String = ""
                        c.FICHA = idficha
                        c.MUESTRA = Trim(csm.MUESTRA)
                        c = c.buscarxfichaxmuestra
                        If Not c Is Nothing Then
                            largocadena = c.MUESTRA
                            If largocadena.Length > 1 Then
                                finmatricula = Mid(c.MUESTRA, Len(c.MUESTRA) - 1, 2)
                            End If
                        Else
                            largocadena = Trim(csm.MUESTRA)
                            If largocadena.Length > 1 Then
                                finmatricula = Mid(csm.MUESTRA, Len(csm.MUESTRA) - 1, 2)
                            End If
                        End If
                        'If finmatricula = "T1" Or finmatricula = "T2" Or finmatricula = "T3" Or finmatricula = "T4" Or finmatricula = "T5" Or finmatricula = "T6" Or finmatricula = "T7" Or finmatricula = "T8" Or finmatricula = "T9" Or finmatricula = "t1" Or finmatricula = "t2" Or finmatricula = "t3" Or finmatricula = "t4" Or finmatricula = "t5" Or finmatricula = "t6" Or finmatricula = "t7" Or finmatricula = "t8" Or finmatricula = "t9" Then
                        '    matricula = Mid(c.MUESTRA, 1, Len(c.MUESTRA) - 2)
                        'Else
                        '    If Not c Is Nothing Then
                        '        matricula = c.MUESTRA
                        '    Else
                        matricula = csm.MUESTRA
                        'End If
                        'End If
                        If matricula <> "" Then
                            Linea = Linea & matricula & ";"
                        Else
                            Linea = Linea & "-" & ";"
                        End If
                        Dim ibc As New dIbc
                        ibc.FICHA = idficha
                        If Not c Is Nothing Then
                            ibc.MUESTRA = Trim(c.MUESTRA)
                        Else
                            ibc.MUESTRA = Trim(csm.MUESTRA)
                        End If
                        ibc = ibc.buscarxfichaxmuestra
                        If csm.RB = 1 Then
                            If Not ibc Is Nothing Then
                                If ibc.RB <> -1 Then
                                    Linea = Linea & ibc.RB & ";"
                                Else
                                    Linea = Linea & "-" & ";"
                                End If
                            Else
                                Linea = Linea & "-" & ";"
                            End If
                        Else
                            Linea = Linea & "-" & ";"
                        End If
                        ibc = Nothing
                        If csm.RC = 1 Then
                            If Not c Is Nothing Then
                                If c.RC <> -1 Then
                                    Linea = Linea & c.RC & ";"
                                Else
                                    Linea = Linea & "-" & ";"
                                End If
                            Else
                                Linea = Linea & "-" & ";"
                            End If
                        Else
                            Linea = Linea & "-" & ";"
                        End If
                        If csm.COMPOSICION = 1 Then
                            If Not c Is Nothing Then
                                If c.GRASA <> -1 Then
                                    Linea = Linea & c.GRASA & "; " & c.PROTEINA & "; " & c.LACTOSA & "; " & c.ST & "; " & "-0." & c.CRIOSCOPIA
                                Else
                                    Linea = Linea & "-" & ";" & "-" & ";" & "-" & ";" & "-" & ";" & "-"
                                End If
                            Else
                                Linea = Linea & "-" & ";" & "-" & ";" & "-" & ";" & "-" & ";" & "-"
                            End If
                        Else
                            Linea = Linea & "-" & ";" & "-" & ";" & "-" & ";" & "-" & ";" & "-"
                        End If
                        oSW.WriteLine(Linea)
                        Linea = ""
                    Next
                End If
            End If
            oSW.Flush()
            oSW.Close()
            '*************************************************************
            Dim Arch2 As String = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".txt"
            If File.Exists(Arch2) Then
                System.Diagnostics.Process.Start(Arch2)
            End If
            '**************************************************************
            Dim result = MessageBox.Show("Desea enviar un correo electrónico con el archivo txt?", "Atención!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                Exit Sub
            ElseIf result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                If sa.IDPRODUCTOR = 6299 Then
                    enviar_correo_AFB2(idficha)
                ElseIf sa.IDPRODUCTOR = 2705 Then
                    enviar_correo_IS(idficha)
                End If
            End If

        End If
    End Sub

    Private Sub enviar_correo_AFB2(ByVal fi As Long)
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = fi
        email = "jgarello@lasibila.com.ar, pdemaio@lasibila.com.ar, amrodriguez@afb.com.uy, hvilche@afb.com.uy, lab.fisicoquimico@afb.com.uy, mcornejo@afb.com.uy"
        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
            _SMTP.Host = "170.249.199.66"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
            _Message.[To].Add(email)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Colaveco - Calidad de leche - TXT"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "Adjuntamos informe de Calidad de leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\192.168.1.10\E\NET\CALIDAD\" & archivo & ".txt" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("TXT enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Attachment = Nothing
                _File = ""
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
    End Sub
    Private Sub enviar_correo_IS(ByVal fi As Long)
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = fi
        email = "iverocay@hotmail.com"
        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
            _SMTP.Host = "170.249.199.66"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
            _Message.[To].Add(email)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Colaveco - Calidad de leche - TXT"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "Adjuntamos informe de Calidad de leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\192.168.1.10\E\NET\CALIDAD\" & archivo & ".txt" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("TXT enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Attachment = Nothing
                _File = ""
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
    End Sub
    Private Sub AccionesCorrectivasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccionesCorrectivasToolStripMenuItem.Click
        Dim v As New FormAccionCorrectiva(Sesion.Usuario, 0)
        v.Show()
    End Sub

    Private Sub PlanDeAcciónCorrectivaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanDeAcciónCorrectivaToolStripMenuItem.Click
        Dim v As New FormPlanAC(Sesion.Usuario, 0)
        v.Show()
    End Sub

    Private Sub EmbarqueDeCajasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmbarqueDeCajasToolStripMenuItem.Click
        Dim v As New FormEmbarqueCajas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub EmbarqueDeCajasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmbarqueDeCajasToolStripMenuItem1.Click
        Dim v As New FormEmbarqueCajas(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub AmbientalNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmbientalNuevoToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 11
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub ListadoDeFrascosEnviadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeFrascosEnviadosToolStripMenuItem.Click
        Dim v As New FormInformeFrascosEnviados()
        v.Show()
    End Sub

    Private Sub EfluentesnuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EfluentesnuevoToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 16
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub AguaNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AguaNuevoToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 3
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub ParasitologíaNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParasitologíaNuevoToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 6
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub BacteriologíaDeTanqueNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BacteriologíaDeTanqueNuevoToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 17
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub BacteriologíaClínicaAeróbicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BacteriologíaClínicaAeróbicaToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 18
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub DesmarcarFichaParaSubirALaWebToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesmarcarFichaParaSubirALaWebToolStripMenuItem.Click
        Dim myvalue As Long = 0
        Dim idficha As Long = InputBox("Ingrese el nro de ficha", "", myvalue)
        If idficha = 0 Then
            MessageBox.Show("Debe ingresar un nro de ficha válido")
            Return
        End If
        Dim sa As New dSolicitudAnalisis
        sa.ID = idficha
        If sa.desmarcar(Sesion.Usuario) Then
            Dim pi As New dPreinformes
            pi.FICHA = idficha
            pi.PARASUBIR = 1
            pi.SUBIDO = 0
            pi.modificar3()
            MsgBox("Ficha desmarcada!")
        End If
    End Sub

    Private Sub GraficasRCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraficasRCToolStripMenuItem.Click
        Dim v As New FormGraficasRC(0)
        v.Show()
    End Sub

    Private Sub DesmarcarAnálisisParaVolverACargarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesmarcarAnálisisParaVolverACargarToolStripMenuItem.Click
        Dim myvalue As Long = 0
        Dim idficha As Long = InputBox("Ingrese el nro de ficha", "", myvalue)
        If idficha = 0 Then
            MessageBox.Show("Debe ingresar un nro de ficha válido")
            Return
        End If
        Dim na As New dNuevoAnalisis
        na.FICHA = idficha
        If na.desmarcarfinalizado(Sesion.Usuario) Then
            MsgBox("Ficha desmarcada!")
        End If
    End Sub

   
    Private Sub AntibiogramasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AntibiogramasNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ControlDeInformesFQToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeInformesFQToolStripMenuItem.Click
        Dim v As New FormControlInformesFQ(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ControlDeInformesMicroToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeInformesMicroToolStripMenuItem1.Click
        Dim v As New FormControlInformesMicro(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ControlDeInformesNutriciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeInformesNutriciónToolStripMenuItem1.Click
        Dim v As New FormControlInformesNutricion(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ControlDeInformesSuelosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeInformesSuelosToolStripMenuItem1.Click
        Dim v As New FormControlInformesSuelos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub AntibiogramasNuevoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AntibiogramasNuevoToolStripMenuItem1.Click
        Dim tipoanalisis As Integer = 4
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub ConveniosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConveniosToolStripMenuItem.Click
        Dim v As New FormConvenios(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub DataGridPedidos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridPedidos.CellContentClick

    End Sub

    Private Sub DataGridViewPP_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewPP.CellClick
        If DataGridViewPP.Columns(e.ColumnIndex).Name = "NombrePend" Then
            Dim row As DataGridViewRow = DataGridViewPP.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim pp As New dPedidosPendientes
            id = row.Cells("IdPend").Value
            pp.PEDIDO = id
            pp = pp.buscar
            If Not pp Is Nothing Then
                MsgBox("Observaciones: " & pp.OBSERVACIONES)
            End If
        End If
    End Sub

   
    Private Sub DataGridViewPP_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewPP.CellContentClick

    End Sub

    Private Sub PatologíaNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatologíaNuevoToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 9
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub ProlesaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProlesaToolStripMenuItem.Click
        Dim v As New FormProlesa(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub FoliaresNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoliaresNuevoToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 19
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub SerologíaNuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SerologíaNuevoToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 8
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub SolicitudesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitudesToolStripMenuItem1.Click
        Dim v As New FormNoAtendibles(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ControlDeInformesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeInformesToolStripMenuItem1.Click
        Dim v As New FormControlInformesEfluentes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub DataGridViewParaSubir_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewParaSubir.CellClick
        If DataGridViewParaSubir.Columns(e.ColumnIndex).Name = "FichaParaSubir" Then
            Dim id As Long = 0
            Dim row As DataGridViewRow = DataGridViewParaSubir.Rows(e.RowIndex)
            id = row.Cells("FichaParaSubir").Value
            Dim p As New dPreinformes
            If MsgBox("Desea quitar la ficha del listado?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                p.FICHA = id
                p.desmarcarcreadoysubir()
                MsgBox("Listo!")
                cargarfichasparasubir()
            Else
                Exit Sub
            End If
        End If
        If DataGridViewParaSubir.Columns(e.ColumnIndex).Name = "TipoParaSubir" Then
            Dim id As Long = 0
            Dim row As DataGridViewRow = DataGridViewParaSubir.Rows(e.RowIndex)
            id = row.Cells("FichaParaSubir").Value
            Dim p As New dPreinformes
            If MsgBox("Desea quitar la ficha del listado?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                p.FICHA = id
                p.desmarcarcreadoysubir()
                MsgBox("Listo!")
                cargarfichasparasubir()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub DataGridViewParaSubir_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewParaSubir.CellContentClick

    End Sub

    Private Sub CargarEstadísticasDeCalidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarEstadísticasDeCalidadToolStripMenuItem.Click
        Dim v As New FormEstadisticas_Calidad(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ToxicologíaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToxicologíaToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 20
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub ButtonCrearInformes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCrearInformes.Click
        Dim v As New FormCrearInformes(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub OtrosServiciosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtrosServiciosToolStripMenuItem.Click
        Dim tipoanalisis As Integer = 99
        Dim v As New FormNuevoAnalisis(Sesion.Usuario, tipoanalisis)
        v.Show()
    End Sub

    Private Sub ListadoDeFrascosDeAguaSinFacturarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeFrascosDeAguaSinFacturarToolStripMenuItem.Click
        Dim v As New FormFrascosAguaSinFacturar(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub Noticias2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Noticias2ToolStripMenuItem.Click
        Dim v As New FormNoticias2(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub UsuariosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuariosToolStripMenuItem1.Click
        Dim v As New FormUsuarios(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub CapacitaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CapacitaciónToolStripMenuItem.Click

    End Sub

    Private Sub ITToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ITToolStripMenuItem.Click

    End Sub

    Private Sub AnalisisDeClientesPorEmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnalisisDeClientesPorEmpresaToolStripMenuItem.Click
        Dim v As New FormClientesPorEmpresa
        v.Show()
    End Sub

    Private Sub PedidosAutomaticosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosAutomaticosToolStripMenuItem.Click
        Dim v As New FormPedidosAutomaticos(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CrearPreInforme.Click
        Dim v As New FormPreInforme(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub ActualizarGestorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarGestorToolStripMenuItem.Click
        Dim v As New FormActualizarGestor(Sesion.Usuario)
        v.Show()
    End Sub

    Private Sub TimepoDeEnvíoDeInformesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimepoDeEnvíoDeInformesToolStripMenuItem.Click
        Dim v As New FormTiemposEnviosInformes(Sesion.Usuario)
        v.Show()
    End Sub
End Class