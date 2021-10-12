Public Class pUltimoNumero
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dUltimoNumero = CType(o, dUltimoNumero)
        Dim sql As String = "INSERT INTO ultimonumero (fichas, inhibidores, pal, controlaux, leucosis, brucelosis, carpeta_petri, index_petri) VALUES (" & obj.FICHAS & "," & obj.INHIBIDORES & "," & obj.PAL & "," & obj.CONTROLAUX & ", " & obj.LEUCOSIS & ", " & obj.BRUCELOSIS & ", '" & obj.CARPETAPETRI & "', " & obj.INDEXPETRI & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dUltimoNumero = CType(o, dUltimoNumero)
        Dim sql As String = "UPDATE ultimonumero SET fichas=" & obj.FICHAS & ", inhibidores = " & obj.INHIBIDORES & ",pal = " & obj.PAL & ",controlaux = " & obj.CONTROLAUX & ", leucosis= " & obj.LEUCOSIS & ", brucelosis= " & obj.BRUCELOSIS & ", carpeta_petri= '" & obj.CARPETAPETRI & "', index_petri= " & obj.INDEXPETRI & " "

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarcontrol(ByVal o As Object) As Boolean
        Dim obj As dUltimoNumero = CType(o, dUltimoNumero)
        Dim sql As String = "UPDATE ultimonumero SET controlaux = " & obj.CONTROLAUX & " "

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarleucosis(ByVal o As Object) As Boolean
        Dim obj As dUltimoNumero = CType(o, dUltimoNumero)
        Dim sql As String = "UPDATE ultimonumero SET leucosis = " & obj.LEUCOSIS & " "

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarbrucelosis(ByVal o As Object) As Boolean
        Dim obj As dUltimoNumero = CType(o, dUltimoNumero)
        Dim sql As String = "UPDATE ultimonumero SET brucelosis = " & obj.BRUCELOSIS & " "

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarpetri(ByVal o As Object) As Boolean
        Dim obj As dUltimoNumero = CType(o, dUltimoNumero)
        Dim sql As String = "UPDATE ultimonumero SET carpeta_petri = '" & obj.CARPETAPETRI & "', index_petri = " & obj.INDEXPETRI & " "

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function buscar(ByVal o As Object) As dUltimoNumero
        Dim obj As dUltimoNumero = CType(o, dUltimoNumero)
        Dim l As New dUltimoNumero
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT fichas, inhibidores, pal, controlaux, leucosis, brucelosis, carpeta_petri, index_petri FROM ultimonumero ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.FICHAS = CType(unaFila.Item(0), Long)
                l.INHIBIDORES = CType(unaFila.Item(1), Long)
                l.PAL = CType(unaFila.Item(2), Long)
                l.CONTROLAUX = CType(unaFila.Item(3), Long)
                l.LEUCOSIS = CType(unaFila.Item(4), Long)
                l.BRUCELOSIS = CType(unaFila.Item(5), Long)
                l.CARPETAPETRI = CType(unaFila.Item(6), String)
                l.INDEXPETRI = CType(unaFila.Item(7), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT fichas,inhibidores,pal, controlaux, leucosis, brucelosis, carpeta_petri, index_petri FROM ultimonumero"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dUltimoNumero
                    l.FICHAS = CType(unaFila.Item(0), Long)
                    l.INHIBIDORES = CType(unaFila.Item(1), Long)
                    l.PAL = CType(unaFila.Item(2), Long)
                    l.CONTROLAUX = CType(unaFila.Item(3), Long)
                    l.LEUCOSIS = CType(unaFila.Item(4), Long)
                    l.BRUCELOSIS = CType(unaFila.Item(5), Long)
                    l.CARPETAPETRI = CType(unaFila.Item(6), String)
                    l.INDEXPETRI = CType(unaFila.Item(7), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
