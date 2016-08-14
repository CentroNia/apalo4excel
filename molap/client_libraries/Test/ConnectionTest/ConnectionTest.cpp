// ConnectionTest.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "libpalo2.h"


int _tmain(int argc, _TCHAR* argv[])
{
    wchar_t *Server = L"127.0.0.1";
    wchar_t *Port = L"7777";
    wchar_t *User = L"admin";
    wchar_t *Pass = L"admin";

    libpalo_result_struct r;
    libpalo_err err;
    struct conversions convs;
    struct sock_obj so;

    r = libpalo_init_r( &err, &convs );
    if (!r.succeeded)
        return 1;

    r = palo_connect_w_r( &err, &convs, Server, Port, &so );
    if (!r.succeeded)
        {
        libpalo_cleanup_r( &convs );
        return 2;
        }

    r = palo_auth_ssl_w_r( &err, &so, &convs, User, Pass, 0);
    if (!r.succeeded)
        {
        palo_disconnect2( &so, 1 );
        libpalo_cleanup_r( &convs );
        return 3;
        }

	return 0;
}

